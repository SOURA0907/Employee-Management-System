using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Employee_management_system
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con= new SqlConnection(@"Data Source=DESKTOP-7O624O7\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
        SqlCommand cmd;
        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "insert into emp values(" + TextBox1.Text + ",'" + TextBox2.Text + "','" + TextBox3.Text + "'," + TextBox4.Text + ")";
            cmd = new SqlCommand(s,con);
            cmd.ExecuteNonQuery();
            Response.Write("<Script>alert('Employee Registered Successfully')</script>");
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox1.Focus();

            
        }
    }
}