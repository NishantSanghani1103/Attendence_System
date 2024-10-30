using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CodeHtml
{
    public partial class Feedback : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            GetCon();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cmd = new SqlCommand("insert into FeedBackMst(Email,Mobile,Feedback,EDate)values('"+txtemail.Text+"','"+txtcont.Text+"','"+txtfeed.Text+"','"+currentDate+"')", con);
            cmd.ExecuteNonQuery();
            lbl.Text = "Feedback Sent";
        }
    }
}