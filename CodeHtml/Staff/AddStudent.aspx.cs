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
    public partial class AddStudent : System.Web.UI.Page
    {
        SqlDataAdapter da;
        DataSet ds;
        SqlConnection con;
        SqlCommand cmd;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        int rowcount;
        string image;

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public void FillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select DivName from DivMst", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpdiv.Items.Add(ds.Tables[0].Rows[i]["DivName"].ToString());
            }
        }

        public DataSet Select(string username)
        {
            GetCon();
            da = new SqlDataAdapter("SELECT StdName FROM StaffMst WHERE Uname='" + username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillText()
        {
            GetCon();
            if (Session["username"] != null)
            {
                ds = Select(Session["username"].ToString());
                lblstd.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
            }

        }
        public void imageupload()
        {
            GetCon();
            if (FileUpload1.HasFile)
            {
                string relativePath = "~/Staff/StudentImage/" + FileUpload1.FileName;
                string physicalPath = Server.MapPath(relativePath);
                FileUpload1.SaveAs(physicalPath);

                // Now you can use 'relativePath' or 'physicalPath' as needed.
                image = relativePath;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            FillComb();
            FillText();
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }

        protected void btnstuadd_Click(object sender, EventArgs e)
        {
            GetCon();
            imageupload();
            if(txtpass.Text==txtcpass.Text)
            {
                cmd = new SqlCommand("insert into StudentMst(RollNo,Name,StdName,DivName,Email,Mobile,Dob,Image,Address,City,Pincode,Uname,Pass)values('" + txtroll.Text + "','" + txtname.Text + "','" + lblstd.Text + "','" + drpdiv.SelectedValue + "','" + txtemail.Text + "','" + txtmobi.Text + "','" + drpdd.SelectedValue + "-" + drpmm.SelectedValue + "-" + drpyyyy.SelectedValue + "','" + image + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpin.Text + "','" + txtuname.Text + "','" + txtpass.Text + "')", con);
                cmd.ExecuteNonQuery();
                lblmsg.Text = "Student Added SuccessFully...";
            }
            
            else
            {
                lblmsg.Text = "Enter Valid Username Or Password..";
            }
        }
    }
}
