using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace CodeHtml.Admin
{
    public partial class Message1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillComb();
        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        // For Auto Fill DropDwonList.
        public void FillComb()
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

        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select RollNo,Name,Message,NoDays,Reply from LeaveMst where StdName='"+drpstd.SelectedValue+"' ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FIllGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();
            lblnew.Text=GridView1.Rows.Count.ToString();
        }


        // Approve Leave
        public DataSet ApproveData()
        {
            GetCon();
            da = new SqlDataAdapter("select RollNo,Name,Message,NoDays,Reply from LeaveMst where StdName='" + drpstd.SelectedValue + "' and Reply='Approve' ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillApproveGrid()
        {
            GetCon();
            GridView2.DataSource = ApproveData();
            GridView2.DataBind();
            lblapp.Text = GridView2.Rows.Count.ToString();
        }

        // Reject Leave

        public DataSet RejectData()
        {
            GetCon();
            da = new SqlDataAdapter("select RollNo,Name,Message,NoDays,Reply from LeaveMst where StdName='" + drpstd.SelectedValue + "' and Reply='Reject' ", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillRejectGrid()
        {
            GetCon();
            GridView3.DataSource = RejectData();
            GridView3.DataBind();
            lblrej.Text = GridView3.Rows.Count.ToString();
        }
        protected void btnnewleave_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex =0;
            FIllGrid();
        }

        protected void btnnewleave_Click1(object sender, EventArgs e)
        {
            
        }

        protected void drpstd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            FillApproveGrid();
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            FillRejectGrid();
        }
    }
}