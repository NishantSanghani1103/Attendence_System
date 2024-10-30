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
    public partial class Complain1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select Rollno,Name,Subject,Message,Reply from Complainmst ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();
            lblcomplain.Text = GridView1.Rows.Count.ToString();
        }
    }
}