using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CodeHtml.Staff
{
    public partial class Staff : System.Web.UI.MasterPage
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;


        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            FillText();
        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        public DataSet Select(string username)
        {
            GetCon();
            da = new SqlDataAdapter("SELECT Name,Image FROM StaffMst WHERE Uname='" + username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void FillText()
        {
            GetCon();
            ds = Select(Session["username"].ToString());
            Label1.Text = "Welcome: "+(ds.Tables[0].Rows[0]["Name"].ToString());
            string imagePath = (ds.Tables[0].Rows[0]["Image"].ToString());
            Image4.ImageUrl = ResolveUrl(imagePath);
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            GetCon();
            Session.Abandon();
        }
    }
}