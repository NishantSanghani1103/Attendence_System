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
    public partial class Leave : System.Web.UI.Page
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
            da = new SqlDataAdapter("select lm.LID,lm.Rollno,lm.Name,lm.Message,lm.NoDays from LeaveMst lm INNER JOIN StaffMst sm ON lm.StdName=sm.StdName where Reply='Pending' and sm.StdName = '" + Session["DefaultStandered"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();
            lblnew.Text=GridView1.Rows.Count.ToString();
        }
        // For Approve Leave.
        public void ApproveUpdate()
        {
            GetCon();
            cmd = new SqlCommand("update LeaveMst set Reply='Approve' where LID='"+ViewState["id"]+"'", con);
            cmd.ExecuteNonQuery();
        }

        public DataSet ApprovedData()
        {
            GetCon();
            da = new SqlDataAdapter("select lm.LID,lm.Rollno,lm.Name,lm.Message,lm.NoDays,lm.Reply from LeaveMst lm INNER JOIN StaffMst sm ON lm.StdName=sm.StdName where Reply='Approve' and sm.StdName = '" + Session["DefaultStandered"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        
        public void FillApprovedGrid()
        {
            GetCon();
            GridView2.DataSource = ApprovedData();
            GridView2.DataBind();
            lblapp.Text=GridView2.Rows.Count.ToString();
        }

        // For Reject Leave.

        public void RejectUpdate()
        {
            GetCon();
            cmd = new SqlCommand("update LeaveMst set Reply='Reject' where LID='" + ViewState["lid"] + "'", con);
            cmd.ExecuteNonQuery();
        }

        public DataSet RejectData()
        {
            GetCon();
            da = new SqlDataAdapter("select lm.LID,lm.Rollno,lm.Name,lm.Message,lm.NoDays,lm.Reply from LeaveMst lm INNER JOIN StaffMst sm ON lm.StdName=sm.StdName where Reply='Reject' and sm.StdName = '" + Session["DefaultStandered"] + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillRejectGrid()
        {
            GetCon();
            GridView3.DataSource = RejectData();
            GridView3.DataBind();
            lblrej.Text=GridView3.Rows.Count.ToString();
        }
        protected void btnnewleave_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            FillGrid();
        }

        protected void btnapprove_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            FillApprovedGrid();
           
        }

        protected void btnreject_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 2;
            FillRejectGrid();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "cmd_approve")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                ApproveUpdate();
                MultiView1.ActiveViewIndex = -1;
            }
            else if(e.CommandName== "cmd_reject")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["lid"] = id;
                RejectUpdate();

            }
        }

        protected void GridView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}