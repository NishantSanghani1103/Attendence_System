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
    public partial class Home_Staff : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                GridFill();
                lblstaff.Text =GvStaff.Rows.Count.ToString();
            }

        }


        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet FillData()
        {
            GetCon();
            da = new SqlDataAdapter("select Sid,Image,Name,Email,Mobile,Qualification,City from StaffMst ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void GridFill()
        {
            GetCon();
            GvStaff.DataSource = FillData();
            GvStaff.DataBind();
        }

        //public void DeleteRecord(int Sid)
        //{
        //    GetCon();
        //    cmd = new SqlCommand("delete from StaffMst where Sid ='" + Sid + "'", con);
        //    cmd.ExecuteNonQuery();

        //}

        //protected void GvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    GetCon();
        //    if (e.CommandName == "cmd_dlt")
        //    {
        //        int id = Convert.ToInt32(e.CommandArgument);
        //        ViewState["id"] = id;
        //        DeleteRecord(id);
        //        GridFill();
        //    }
        //}
    }
}