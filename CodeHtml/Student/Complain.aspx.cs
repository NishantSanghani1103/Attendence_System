using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.IO;
using System.Data.SqlClient;

namespace CodeHtml.Student
{
    public partial class Complain : System.Web.UI.Page
    {

        SqlConnection con;
        SqlCommand cmd;
        DataSet ds;
        SqlDataAdapter da;

        string fnm = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\.Net\CodeHtml\CodeHtml\App_Data\AttSystem.mdf;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            FillGrid();
        }
        public void GetCon()
        {
            con = new SqlConnection(fnm);
            con.Open();
        }

        public void Clear()
        {
            GetCon();
            txtmsg.Text = "";
            txtsubj.Text = "";
        }

        public DataSet Select(string Name)
        {
            GetCon();
            da = new SqlDataAdapter("select Subject,Message,Reply from Complainmst where Name='"+Name+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select(Session["StudentUsername"].ToString());
            GridView1.DataBind();
        }
        protected void btnreplyy_Click(object sender, EventArgs e)
        {

        }


        protected void btnsend_Click(object sender, EventArgs e)
        {
            GetCon();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            cmd = new SqlCommand("insert into Complainmst (RollNo,Name,StdName,Subject,Message,Reply,EDate)values('" + Session["StudentRollNo"].ToString() + "','" + Session["StudentUsername"].ToString() + "','"+ Session["StudentStd"].ToString()+ "','" + txtsubj.Text + "','" + txtmsg.Text + "','Pending','" + currentDate + "') ", con);
            cmd.ExecuteNonQuery();
            lbl.Text = "complain sent";
            Clear();
            FillGrid();
        }
    }
}