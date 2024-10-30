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
    public partial class Home : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
                
        }

        public void getcon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet select(string Uname)
        {
            getcon();
            da = new SqlDataAdapter("select * from StaffMst where Uname='" + Uname + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public DataSet Student(string username)
        {
            getcon();
            da = new SqlDataAdapter("select * from StudentMst where [Uname]='" + username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        protected void btnstafflogin_Click(object sender, EventArgs e)
        {

            if (btnstafflogin.Text == "Login")
            {
                string Uname = txtstaffuname.Text.Trim();
                string Pass = txtstaffpass.Text.Trim();
                DataSet user = select(Uname);

                if (user.Tables[0].Rows.Count > 0)
                {
                    string dbpass = user.Tables[0].Rows[0]["Pass"].ToString();
                    if (Pass == dbpass)
                    {
                        Session["username"] = txtstaffuname.Text;
                        Response.Redirect("Staff/Default.aspx");

                    }
                    else
                    {

                        lblstafferror.Text = "Incorrect password.Please try again.";
                    }
                }
                else
                {

                    lblstafferror.Text = "User with this email does not exist.";
                }
            }
        }

        protected void btnstudenlogin_Click(object sender, EventArgs e)
        {
            getcon();
            if (btnstudenlogin.Text == "Login")
            {

                string studentunm = txtstuuname.Text.Trim();
                string studentpass = txtstupass.Text;

                DataSet Stud = Student(studentunm);

                if (Stud.Tables[0].Rows.Count > 0)
                {
                    string dbpass = Stud.Tables[0].Rows[0][13].ToString();
                    if (studentpass == dbpass)
                    {
                        Session["StudentUsername"] = txtstuuname.Text;
                        Response.Redirect("Student/MyProfile.aspx");
                    }
                    else
                    {
                        lblstuerror.Text = "Incorrect password Please try again.";
                    }
                }
                else
                {
                    lblstuerror.Text = "User with this email does not exist.";
                }
            }
        }
    

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button5_Click(object sender, EventArgs e)
        {

        }
    }
}
