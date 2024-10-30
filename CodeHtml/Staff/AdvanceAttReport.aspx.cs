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
    public partial class AdvanceAttReport : System.Web.UI.Page
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
                StdFillComb();
                FillText();
                DivFillComb();
            }
               
            
            
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public void StdFillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select stud.Name from StudentMst stud INNER JOIN StaffMst sm ON stud.StdName=sm.StdName where sm.Stdname='" + Session["DefaultStandered"].ToString() + "'  ", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpstudent.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
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

        public DataSet SelectAtt()
        {
            GetCon();
            da = new SqlDataAdapter("select RollNo,Name,EDate,StaffName,Status from Attendancemst where  Name='"+drpstudent.Text+"' and StaffName='"+ Session["username"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);    
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = SelectAtt();
            GridView1.DataBind();
            lblcnt.Text = "Result= " + GridView1.Rows.Count.ToString();
        }
        protected void btnsarch_Click(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void drpstudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpdiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}