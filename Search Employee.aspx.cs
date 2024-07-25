using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace Employee_management_system
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter da;
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-7O624O7\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            s = "select * from emp where eid=" + textBox1.Text;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                Response.Write("<script>alert('Record Not Found')</script>");
                textBox1.Text = "";
                textBox1.Focus();
            }
            else
            {
                Label1.Text = ds.Tables[0].Rows[0][0].ToString();
                Label2.Text = ds.Tables[0].Rows[0][1].ToString();
                Label3.Text = ds.Tables[0].Rows[0][2].ToString();
                Label4.Text = ds.Tables[0].Rows[0][3].ToString();
                textBox1.Text = "";
                textBox1.Focus();
            }
        }
    }
}