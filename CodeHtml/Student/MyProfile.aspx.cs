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
    public partial class MyProfile : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string image;
        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {

                FillText();
                //lblname.Text = Session["StudentUsername"].ToString();
                Session["StudentRollNo"] = lblroll.Text;
                Session["StudentName"] = lblname.Text;
                Session["StudentStd"] = Label3.Text;
                imageupload();
            }
           
        }

        public  void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet Select(string username)
        {
            GetCon();
            da = new SqlDataAdapter("select Name,StdName,Email,Address,City,Pincode,RollNo,Mobile,Image from StudentMst where Uname='"+username+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillText()
        {
            GetCon();
            ds = Select(Session["StudentUsername"].ToString());

            //parsing
            Label3.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
            lblname.Text = (ds.Tables[0].Rows[0]["Name"].ToString());
            txtemail.Text = (ds.Tables[0].Rows[0]["Email"].ToString());
            txtmobile.Text = (ds.Tables[0].Rows[0]["Mobile"].ToString());
            txtadd.Text = (ds.Tables[0].Rows[0]["Address"].ToString());
            txtcity.Text = (ds.Tables[0].Rows[0]["City"].ToString());
            txtpin.Text = (ds.Tables[0].Rows[0]["Pincode"].ToString());
            lblroll.Text = (ds.Tables[0].Rows[0]["RollNo"].ToString());
            //Imgprofile.ImageUrl = (ds.Tables[0].Rows[0]["Image"].ToString());
            img.ImageUrl = (ds.Tables[0].Rows[0]["Image"].ToString());
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

        public void ImageUpdate()
        {
            GetCon();
            cmd = new SqlCommand("update StudentMst set Image='"+image+"' where Uname='"+ Session["StudentUsername"] + "'",con);
            cmd.ExecuteNonQuery();
        }
        protected void btnchange_Click(object sender, EventArgs e)
        {
            imageupload();
            ImageUpdate();

        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            GetCon();
            cmd = new SqlCommand("update StudentMst set Email='" + txtemail.Text + "',Mobile='" + txtmobile.Text + "',Address='" + txtadd.Text + "',City='" + txtcity.Text + "',Pincode='" + txtpin.Text + "' where Name='" + Session["StudentName"] + "'", con);
            cmd.ExecuteNonQuery();
            Label2.Text = "Update Successfully.";
        }
    }
}