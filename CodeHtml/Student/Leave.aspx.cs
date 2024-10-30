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

        public void Clear()
        {
            txtmsg.Text = "";
            //DropDownList1.SelectedValue = "";
        }
        protected void Button7_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
            
            

        }

        protected void Button8_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 1;
            FillGrid();
        }

        public DataSet Select(string Name)
        {
            GetCon();
            da = new SqlDataAdapter("select Message,NoDays,Reply from LeaveMst where Name='"+Name+"'", con);
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void FillGrid()
        {
            GetCon();
            GridView1.DataSource = Select(Session["StudentName"].ToString());
            GridView1.DataBind();
        }

       
        public string GetstdName(string Name)
        {
            GetCon();
            da = new SqlDataAdapter("select StdName from StudentMst where Name='" + Name + "'", con);
            ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return ds.Tables[0].Rows[0]["StdName"].ToString();
            }
            return "";
        }

        protected void btnappluleave_Click(object sender, EventArgs e)
        {
            GetCon();
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string stdName = GetstdName(Session["StudentName"].ToString());
          
                cmd = new SqlCommand("insert into LeaveMst(Rollno,Name,StdName,Message,NoDays,Reply,EDate)values" +
                    "('" + Session["StudentRollNo"] + "','" + Session["StudentName"] + "','" + stdName + "','" + txtmsg.Text + "','" + DropDownList1.SelectedValue + "','Pending','" + currentDate + "')", con);
                cmd.ExecuteNonQuery();
                Clear();
                lbl.Text = "Apply for leave successfully";
           
        }
    }
}