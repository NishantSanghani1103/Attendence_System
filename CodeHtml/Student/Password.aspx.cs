using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace CodeHtml.Student
{
    public partial class Password : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet select()
        {
            GetCon();
            da = new SqlDataAdapter("select pass from StudentMst where Name='" + Session["StudentName"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        protected void btnchangepass_Click(object sender, EventArgs e)
        {
            GetCon();
            string CurrentPass = txtcurrent.Text;
            string NewPass = txtnewpass.Text;
            string ConPass = txtconfpass.Text;
            DataSet user = select();
            if (user.Tables[0].Rows.Count > 0)
            {
                string dbpass = user.Tables[0].Rows[0]["Pass"].ToString();
                if (CurrentPass == dbpass)
                {
                    if (NewPass == ConPass)
                    {
                        cmd = new SqlCommand("update StudentMst set Pass='" + txtconfpass.Text + "' where Name='" + Session["StudentName"] + "'", con);
                        cmd.ExecuteNonQuery();
                        lbl.Text = "Password Changed Successfully.";
                    }
                    else
                    {
                        lbl.Text = "Enter Correct New Password";
                    }
                }
                else
                {
                    lbl.Text = "Enter Valid Password";
                }
            }
            else
            {
                lbl.Text = "";
            }
        }
    }
}