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
    public partial class Default : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string image;
        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            
                GetCon();
                //lblname.Text = Session["username"].ToString();

                FillText();
                Session["DefaultStandered"] = lblstd.Text;
            
           
                

        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet Select(string username)
        {
            GetCon();
            da = new SqlDataAdapter("SELECT Name,Email,Mobile,StdName,[Add],City,PinCode,Image FROM StaffMst WHERE Uname='" + username + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillText()
        {
            GetCon();
            ds = Select(Session["username"].ToString());


            // Parsing
            lblname.Text = (ds.Tables[0].Rows[0]["Name"].ToString());
            txtemail.Text = (ds.Tables[0].Rows[0]["Email"].ToString());
            txtmobile.Text = (ds.Tables[0].Rows[0]["Mobile"].ToString());
            txtadd.Text = (ds.Tables[0].Rows[0]["Add"].ToString());
            txtcity.Text = (ds.Tables[0].Rows[0]["City"].ToString());
            txtpin.Text = (ds.Tables[0].Rows[0]["Pincode"].ToString());
            lblstd.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
            Imgprofile.ImageUrl = (ds.Tables[0].Rows[0]["image"].ToString());
        }
        public void Clear()
        {
            txtemail.Text = "";
        }

        public void Update()
        {

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
        protected void btnupdate_Click(object sender, EventArgs e)
        {
            GetCon();
            cmd = new SqlCommand("update StaffMst set Email='" + txtemail.Text + "',Mobile='" + txtmobile.Text + "',[Add]='" + txtadd.Text + "',City='" + txtcity.Text + "',Pincode='" + txtpin.Text + "' where Uname='" + Session["username"] + "'", con);
            cmd.ExecuteNonQuery();
            Label2.Text = "Update Successfully.";
        }

        public void ImageUpdate()
        {
            GetCon();
            imageupload();
            cmd = new SqlCommand("update StaffMst set Image='" + image + "' where Uname='" + Session["username"] + "'", con);
            cmd.ExecuteNonQuery();
        }
        protected void btnchange_Click(object sender, EventArgs e)
        {
            ImageUpdate();
        }
    }
}
