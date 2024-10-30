using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace CodeHtml.Admin
{
    public partial class AddStaff1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        string image;
        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillComb();
        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        public void imageupload()
        {
            GetCon();
            if (FileUpload1.HasFile)
            {
                image = "~/Eximages/" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(image));
            }
        }

        public void FillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select StdName from StdMst", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpstd.Items.Add(ds.Tables[0].Rows[i]["StdName"].ToString());
            }
        }

        public void Clear()
        {
            GetCon();
            txtadd.Text = "";
            txtcity.Text = "";
            txtcpass.Text = "";
            txtemail.Text = "";
            txtmobile.Text = "";
            txtname.Text = "";
            txtpass.Text = "";
            txtpin.Text = "";
            txtqual.Text = "";
            txtuname.Text = "";
            //drpstd.SelectedValue = "";

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            GetCon();
            imageupload();
            if (btnadd.Text == "ADD" && txtpass.Text == txtcpass.Text)
            {
                cmd = new SqlCommand("insert into StaffMst(Name,StdName,Email,Mobile,Image,Qualification,[Add],City,Pincode,Uname,Pass,Gender" + ")" +
                    "values" + "('" + txtname.Text + "','" + drpstd.SelectedValue + "','" + txtemail.Text + "','" + txtmobile.Text + "','" + image + "'," + "" +
                    "'" + txtqual.Text + "','" + txtadd.Text + "','" + txtcity.Text + "','" + txtpin.Text + "','" + txtuname.Text + "'," + "" +
                    "'" + txtpass.Text + "','" + DropDownList1.SelectedValue + "') ", con);
                cmd.ExecuteNonQuery();
                Clear();
                lbl.Text = "Added Successfully...!!";

            }
            else
            {
                lbl.Text = "Enter Valid Password";
            }
        }
    }
}