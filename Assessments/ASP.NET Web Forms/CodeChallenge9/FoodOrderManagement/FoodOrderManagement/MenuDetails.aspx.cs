using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FoodOrderManagement
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            int id = Convert.ToInt32(Request.QueryString["MenuId"]);

            string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da =
                new SqlDataAdapter(
                    "select * from MenuItems where MenuId=" + id, con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dvMenu.DataSource = dt;
            dvMenu.DataBind();
        }
    }
}