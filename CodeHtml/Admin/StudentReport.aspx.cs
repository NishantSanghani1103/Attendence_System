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
    public partial class StudentReport1 : System.Web.UI.Page
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
                DivisonFillComb();
                StudentFillComb();
            }
            
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }
        // For Satndered 
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

        //For Division.

        public void DivisonFillComb()
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

        public void StudentFillComb()
        {
            GetCon();
            da = new SqlDataAdapter("select Name from StudentMst", con);
            ds = new DataSet();
            da.Fill(ds);


            rowcount = ds.Tables[0].Rows.Count;

            for (int i = 0; i < rowcount; i++)
            {
                drpstudent.Items.Add(ds.Tables[0].Rows[i]["Name"].ToString());
            }
        }

        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select * from StudentMst where StdName='"+drpstd.SelectedValue+"' and Name='"+drpstudent.SelectedValue+"' and DivName='"+drpdiv.SelectedValue+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillView()
        {
            GetCon();
            ds = Select();

            lblname.Text = (ds.Tables[0].Rows[0][2].ToString());
            lblroll.Text = (ds.Tables[0].Rows[0]["RollNo"].ToString());
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
        protected void btnsarch_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            FillView();
        }
    }
}