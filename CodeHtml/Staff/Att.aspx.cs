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
    public partial class Att : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCon();
                FillText();
                FillComb();
                Session["AttStandered"] = lblstd.Text;
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

        // Auto Fill DropDownList Fill From StdMst Table
        public void FillComb()
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
        public void FillText()
        {
            GetCon();
            ds = Select(Session["username"].ToString());


            // Parsing

            lblstd.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());

        }

        public DataSet SelectGrid()
        {
            GetCon();
            da = new SqlDataAdapter("select RollNo,Name from StudentMst where DivName='" + drpdiv.SelectedValue + "'and StdName='" + Session["AttStandered"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = SelectGrid();
            GridView1.DataBind();
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            FillGrid();
        }


        public string RollNo(GridViewRow row)
        {


            Label lblRollNo = row.FindControl("Label2") as Label;
            if (lblRollNo != null)
            {
                return lblRollNo.Text;
            }
            else
            {
                return "";
            }
        }


        public string GetName(GridViewRow row)
        {

            // For example:
            Label lblName = row.FindControl("Label3") as Label;
            if (lblName != null)
            {
                return lblName.Text; // Return Name in the format '"Name"'
            }
            else
            {
                return ""; // Return empty string if Name is not found
            }
        }

        protected void btnaddatt_Click(object sender, EventArgs e)
        {
            GetCon();

            string currentDate = Calendar1.SelectedDate.Date.ToString("yyyy-MM-dd");

            // Loop through each row in the GridView using Rows.Count
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];

                string name = GetName(row);

                // Check attendance for the selected date
                cmd = new SqlCommand("SELECT COUNT(*) FROM Attendancemst WHERE Date = '" + Calendar1.SelectedDate.Date.GetDateTimeFormats()[8].ToString() + "' and Name='" + name + "'", con);

                int attendanceCount = (int)cmd.ExecuteScalar();

                if (attendanceCount > 0)
                {
                    MultiView1.ActiveViewIndex = -1;
                    lblatt.Text = "Attendance For Selected Date And Student Already Filled.";
                    return;
                }

                DropDownList drpatt = row.FindControl("drpatt") as DropDownList;

                if (drpatt != null && !string.IsNullOrEmpty(drpatt.SelectedValue))
                {
                    string rollNo = RollNo(row);
                    string currentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    cmd = new SqlCommand("INSERT INTO Attendancemst ([Rollno], Name, Status, Date, StaffName, EDate) " +
                                                          "SELECT '" + rollNo + "', '" + name + "', '" + drpatt.SelectedValue + "', '" + Calendar1.SelectedDate.Date.GetDateTimeFormats()[8].ToString() + "', '" + Session["username"].ToString() + "', '" + currentDate + "' " +
                                                          "WHERE NOT EXISTS (SELECT 1 FROM Attendancemst WHERE Date = '" + Calendar1.SelectedDate.Date.GetDateTimeFormats()[8].ToString() + "' and Name='" + name + "')", con);

                    cmd.ExecuteNonQuery();
                }
            }

            MultiView1.ActiveViewIndex = -1;
            drpdiv.SelectedIndex = 0;
            lblatt.Text = "Attendance Saved.";
        }


        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}