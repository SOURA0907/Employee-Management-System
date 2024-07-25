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
    public partial class WebForm4 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataAdapter da;
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-7O624O7\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
            con.Open();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            s = "Select * from emp where eid=" + TextBox1.Text;
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
                Response.Write("<Sctipt>alert('Record Not Exist')</script>");
            else
            {
                TextBox2.Text = ds.Tables[0].Rows[0][0].ToString();
                TextBox3.Text = ds.Tables[0].Rows[0][1].ToString();
                TextBox4.Text = ds.Tables[0].Rows[0][2].ToString();
                TextBox5.Text = ds.Tables[0].Rows[0][3].ToString();
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            s = "delete from emp where eid=" + TextBox1.Text;
            cmd=new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox1.Focus();
            Response.Write("<script>alert('Employee Deleted Successfully')</script>");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            s = "update emp set ename='" + TextBox3.Text + "', edept='" + TextBox4.Text + "', esal=" + TextBox5.Text + " where eid=" + TextBox1.Text;
            cmd = new SqlCommand(s, con);
            cmd.ExecuteNonQuery();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox1.Focus();
            Response.Write("<script>alert('Employee Record Updated Successfully')</script>");
        }
    }
}