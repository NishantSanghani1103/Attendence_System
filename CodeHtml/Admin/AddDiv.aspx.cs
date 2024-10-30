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
    public partial class AddDiv1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        string fn = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        int rowcount;
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
            if (!IsPostBack)
            {
                
                FillComb();
            }
          
            
        }


        // for AutoFill DropDownList
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
        public void GetCon()
        {
            con = new SqlConnection(fn);
            con.Open();
        }
        public DataSet FillData()
        {
            GetCon();
            da = new SqlDataAdapter("select * from DivMst", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = FillData();
            GridView1.DataBind();

        }


        // Upadte Postion
        public DataSet Update(int id)
        {
            GetCon();
            da = new SqlDataAdapter("select * from DivMst where Did='"+id+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillUpdate()
        {
            GetCon();
            ds = new DataSet();
            ds = Update(Convert.ToInt32(ViewState["id"]));

            txtdname.Text = (ds.Tables[0].Rows[0]["DivName"].ToString());
            txtseat.Text = (ds.Tables[0].Rows[0]["Seat"].ToString());
            drpstd.SelectedValue = (ds.Tables[0].Rows[0]["StdName"].ToString());
        }

        public void Clear()
        {
            GetCon();
            txtdname.Text = "";
            txtseat.Text = "";
            //drpstd.SelectedValue = "";
        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            GetCon();
            if(btnadd.Text=="ADD")
            {
                cmd = new SqlCommand("insert into DivMst(DivName,StdName,Seat)values('"+txtdname.Text+"','"+drpstd.SelectedValue+"','"+txtseat.Text+"') ",con);
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear();
                lbl.Text = "Added Successfully..!!";
                
            }
            else if(btnadd.Text=="UPDATE")
            {
                cmd = new SqlCommand("update DivMst set DivName='"+txtdname.Text+"',StdName='"+drpstd.SelectedValue+"', Seat='"+txtseat.Text+"' where Did='"+ViewState["id"]+"'", con);
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear();
                lbl.Text = "Upadeted Successfully..!!";
            }
            else
            {
                cmd = new SqlCommand("delete  from DivMst where Did='"+ViewState["id"]+"'", con);
                cmd.ExecuteNonQuery();
                FillGrid();
                Clear();
                lbl.Text = "Delete Successfully..!!";
            }    
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GetCon();
            if(e.CommandName=="cmd_edt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                btnadd.Text="UPDATE";
                FillUpdate();
            }
            else if(e.CommandName== "emd_dlt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                btnadd.Text = "DELETE";
                FillUpdate();
            }
        }
    }
}