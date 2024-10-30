using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace CodeHtml.Staff
{
    public partial class StudentReport : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                StanderedFillComb();
                DivFillComb();
            }
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public void StanderedFillComb()
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
        public void DivFillComb()
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

        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select Image,RollNo,Name,Mobile,Email,DOB from StudentMst where StdName='" + drpstd.SelectedValue + "' and DivName='" + drpdiv.SelectedValue + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();
            lbl.Text = "Result= " + GridView1.Rows.Count.ToString();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void drpstd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpdiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}