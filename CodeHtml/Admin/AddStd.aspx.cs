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
    public partial class AddStd1 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                FillGrid();
              

            }
        }

        public DataSet Select()
        {
            GetCon();
            da = new SqlDataAdapter("select SID,StdName from [StdMst]", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select();
            GridView1.DataBind();

        }

        //Update Postion

        public DataSet UpdateDelete(int SID)
        {
            GetCon();
            da = new SqlDataAdapter("select StdName from StdMst where SID='"+SID+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void FillText()
        {
            GetCon();
            ds = new DataSet();
            ds = UpdateDelete(Convert.ToInt32(ViewState["id"]));

            //Parsing

            txtstdname.Text = (ds.Tables[0].Rows[0]["StdName"].ToString());
        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        protected void btnaddstd_Click(object sender, EventArgs e)
        {
            GetCon();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (btnaddstd.Text == "ADD")
            {
                
                cmd = new SqlCommand("insert into StdMst(StdName,EDate)values('" + txtstdname.Text + "','"+currentDate+"')", con);
                cmd.ExecuteNonQuery();
                lbl.Text = "Added Seccessfully..!!";
               
            }
            else if(btnaddstd.Text=="Delete")
            {
                cmd = new SqlCommand("delete  from StdMst where SID='"+ViewState["id"]+"'", con);
                cmd.ExecuteNonQuery();
                lbl.Text = "Deleted Successfully..!!";
                FillGrid();
            }
            else
            {
                cmd = new SqlCommand("update StdMst set StdName='"+txtstdname.Text+"' where SID='"+ViewState["id"]+"'", con);
                cmd.ExecuteNonQuery();
                lbl.Text = "Updated Successfully..!!";
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName== "cmd_dlt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                btnaddstd.Text = "Delete";
                FillText();
            }
            else if(e.CommandName== "cmd_edt")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                btnaddstd.Text = "EDIT";
                FillText();
            }    
        }
    }
}