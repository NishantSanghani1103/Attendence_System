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
    public partial class feedback : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;
        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Grid.DataBind();
                lbl.Text = "Total: " + Grid.Rows.Count.ToString();
            }


        }
       public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet FillData()
        {
            GetCon();
            da = new SqlDataAdapter("select * from FeedBackMst", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            Grid.DataSource = FillData();
            


        }
        protected void GvFeed_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Grid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GetCon();
            if (e.CommandName == "cmd_dlt")
            {
                int id = Convert.ToInt32(e.CommandArgument);

                DeleteRecord(id);
                FillGrid();


            }


        }
        public void DeleteRecord(int sid)
        {
            GetCon();
            cmd = new SqlCommand("delete from FeedBackMst where FId ='" + sid + "'", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}