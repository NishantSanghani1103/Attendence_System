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
    public partial class StaffReport1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridFill();
            }
        }

        public DataSet FillData()
        {
            GetCon();
            da = new SqlDataAdapter("select Sid,Image,Name,Email,Mobile,Qualification,City,Pincode from StaffMst ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void GridFill()
        {
            GetCon();
            GridView1.DataSource = FillData();
            GridView1.DataBind();
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        //Delete POostion

        public void DeleteRecord(int sid)
        {
            GetCon();
            cmd = new SqlCommand("delete from StaffMst where Sid ='" + sid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "cmd_dlt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                DeleteRecord(id);
                GridFill();
            }
        }
    }
}