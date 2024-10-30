using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;
using System.Data;

namespace CodeHtml.Admin
{
    public partial class Home : System.Web.UI.Page
    {

        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        public DataSet select(string Username)
        {
            GetCon();
            da = new SqlDataAdapter("select * from AdminMst where Username='" + Username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            GetCon();
            if (btnlogin.Text == "Login")
            {
                string Uname = txtuname.Text.Trim();
                string Pass = txtupass.Text.Trim();
                DataSet user = select(Uname);

                if (user.Tables[0].Rows.Count > 0)
                {
                    string dbpass = user.Tables[0].Rows[0]["Pass"].ToString();
                    if (Pass == dbpass)
                    {
                        Session["adminusername"] = txtuname.Text;
                        Response.Redirect("AddStd.aspx");
                    }
                    else
                    {

                        lbl.Text = "Incorrect password.Please try again.";
                    }
                }
                else
                {

                    lbl.Text = "User with this email does not exist.";
                }
            }
        }
    }
}