using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CodeHtml.Student
{
    public partial class Student : System.Web.UI.MasterPage
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            FillText();
            //Label1.Text = "Welcome: " + Session["StudentUsername"].ToString();
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet Select(string username)
        {
            GetCon();
            da = new SqlDataAdapter("select Name,Image from StudentMst where Uname='" + username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillText()
        {
            GetCon();
            ds = Select(Session["StudentUsername"].ToString());

            //parsing
            Label1.Text = "Welcome:  " + (ds.Tables[0].Rows[0]["Name"].ToString());
            Image4.ImageUrl = (ds.Tables[0].Rows[0]["Image"].ToString());
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}