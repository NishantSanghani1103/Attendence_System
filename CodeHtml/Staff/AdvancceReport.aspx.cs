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
    public partial class AdvancceReport : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
           if(!IsPostBack)
            { 
                FillLabel();
                DivFillComb();
                StudentFillComb();
                Session["StaffStandered"] = lbls.Text;
            }

        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet SelectStd(string Uname)
        {
            GetCon();
            da = new SqlDataAdapter("select StdName from StaffMst where Uname='" + Uname + "' ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillLabel()
        {
            GetCon();
            ds = SelectStd(Session["username"].ToString());

            lbls.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
        }

        // For Division Fill.
        public void DivFillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select DivName from StudentMst", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpdiv.Items.Add(ds.Tables[0].Rows[i]["DivName"].ToString());
            }
        }

        //for Student
        public void StudentFillComb()
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

        public DataSet SelectRecord()
        {
            GetCon();
            da = new SqlDataAdapter("select * from StudentMst where StdName='" + Session["StaffStandered"] + "' and DivName='" + drpdiv.SelectedValue + "' and Name='" + drpstudent.SelectedValue + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillView()
        {
            
            GetCon();
            ds = SelectRecord();
            if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                MultiView1.ActiveViewIndex = 0;
                lblroll.Text = ds.Tables[0].Rows[0]["RollNo"].ToString();
                lblname.Text = (ds.Tables[0].Rows[0][2].ToString());
                lblemail.Text = (ds.Tables[0].Rows[0][5].ToString());
                lblmobile.Text = (ds.Tables[0].Rows[0][6].ToString());
                lbldob.Text = (ds.Tables[0].Rows[0][7].ToString());
                lbladd.Text = (ds.Tables[0].Rows[0][9].ToString());
                lblcity.Text = (ds.Tables[0].Rows[0][10].ToString());
                lblpin.Text = (ds.Tables[0].Rows[0][11].ToString());
                lbluname.Text = (ds.Tables[0].Rows[0][12].ToString());
                lblpass.Text = (ds.Tables[0].Rows[0][13].ToString());
                imgg.ImageUrl = (ds.Tables[0].Rows[0][8].ToString());
            }
            else
            {
                lblcnt.Text = "No Detials Found";
            }
        }
        protected void btnsarch_Click(object sender, EventArgs e)
        {
            
             
            FillView();
            
        }

        protected void drpdiv_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void drpstudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}