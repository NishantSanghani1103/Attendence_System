using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace CodeHtml.Student
{
    public partial class MyAttendence : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
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

        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select EDate,Status,StaffName from Attendancemst where Name='" + Session["StudentName"] + "' AND EDate LIKE '%" + drpmonth.SelectedValue + "%' ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();
            lbl.Text = "Result = " + GridView1.Rows.Count.ToString();
        }
        protected void btnreport_Click(object sender, EventArgs e)
        {

            FillGrid();
        }
    }
}