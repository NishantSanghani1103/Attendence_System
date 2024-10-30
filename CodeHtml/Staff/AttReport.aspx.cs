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
    public partial class AttReport : System.Web.UI.Page
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
                FillText();
                FillComb();
                Session["AttReportStd"] = lblstd.Text;
            }
            
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
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
            ds = Select(Session["username"].ToString());

            lblstd.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
        }

        //For Fill DropDownList.
        public void FillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select stud.Name from StudentMst stud INNER JOIN StaffMst sm ON stud.StdName=sm.StdName where sm.Stdname='" + Session["DefaultStandered"].ToString() + "'  ", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpname.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
            }
        }

        public DataSet SelectAttendence()
        {
            GetCon();
            string selectedDate = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            da = new SqlDataAdapter("SELECT Rollno, Name, Status, StaffName, DAY(Date) AS DayOfMonth, MONTH(Date) AS MonthOfYear FROM Attendancemst WHERE CONVERT(date, Date) = '" + selectedDate+"' and Name='"+drpname.Text+ "' and StaffName='" + Session["username"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = SelectAttendence();
            GridView1.DataBind();
            lblcnt.Text = "Result = " + GridView1.Rows.Count.ToString();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            FillGrid();
        }
    }
}