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
    public partial class Complain : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        DataSet ds;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Label7.Text = Session["DefaultStandered"].ToString();
            GetCon();
            MultiView1.ActiveViewIndex = 0;
            FillGrid();
            lblcomplain.Text = Gv.Rows.Count.ToString();
            Reply();


        }

        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public DataSet Select()
        {
            //da = new SqlDataAdapter("select CID,RollNO,Name,Reply,Subject,Message from Complainmst where StdName='"+Label7.Text+"'", con);
            da = new SqlDataAdapter("SELECT cm.CID, cm.RollNO, cm.Name, cm.Reply, cm.Subject, cm.Message " +
                    "FROM Complainmst cm " +
                    "INNER JOIN StaffMst sm ON cm.StdName = sm.StdName " +
                    "WHERE sm.StdName = '" + Session["DefaultStandered"] + "'", con);

            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            Gv.DataSource = Select();
            Gv.DataBind();
        }

        public DataSet ReplyComplain(int CID)
        {
            GetCon();
            da = new SqlDataAdapter("select Rollno,Name,Subject,Message,Reply from Complainmst where CID='" + CID + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillView()
        {
            GetCon();
            ds = new DataSet();
            ds = ReplyComplain(Convert.ToInt32(ViewState["id"]));


            lblrno.Text = (ds.Tables[0].Rows[0]["Rollno"].ToString());
            lblname.Text = (ds.Tables[0].Rows[0]["Name"].ToString());
            lblsub.Text = (ds.Tables[0].Rows[0]["Subject"].ToString());
            lblcomp.Text = (ds.Tables[0].Rows[0]["Message"].ToString());

        }

        public void Reply()
        {
            GetCon();
            cmd = new SqlCommand("update Complainmst set Reply='" + txtans.Text + "' where CID='" + ViewState["id"] + "'", con);
            cmd.ExecuteNonQuery();

        }
        protected void btnreplyy_Click(object sender, EventArgs e)
        {
            Reply();
        }

        protected void Gv_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "cmd_reply")
            {
                MultiView1.ActiveViewIndex = 1;
                int id = Convert.ToInt32(e.CommandArgument);
                ViewState["id"] = id;
                FillView();
            }
        }
    }
}