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
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con;
        SqlDataAdapter da;
        string s;
        protected void Page_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=DESKTOP-7O624O7\SQLEXPRESS;Initial Catalog=employee;Integrated Security=True");
            con.Open();
            s = "select * from emp";
            DataSet ds = new DataSet();
            da = new SqlDataAdapter(s, con);
            da.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}