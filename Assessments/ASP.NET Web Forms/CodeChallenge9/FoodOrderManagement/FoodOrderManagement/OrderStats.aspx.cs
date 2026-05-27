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
    public partial class OrderStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            lblVisitors.Text =
                "Total Visitors : " + Application["TotalVisitors"];

            lblUsers.Text =
                "Current Active Users : " + Application["ActiveUsers"];

            LoadCategoryStats();
        }

        void LoadCategoryStats()
        {
            DataTable dt;

            if (Cache["FoodCategoryStats"] == null)
            {
                string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

                SqlConnection con = new SqlConnection(cs);

                SqlDataAdapter da =
                    new SqlDataAdapter(
                        "select Category, count(*) TotalItems from MenuItems group by Category",
                        con);

                dt = new DataTable();

                da.Fill(dt);

                Cache.Insert("FoodCategoryStats",
                    dt,
                    null,
                    DateTime.Now.AddMinutes(5),
                    System.Web.Caching.Cache.NoSlidingExpiration);
            }
            else
            {
                dt = (DataTable)Cache["FoodCategoryStats"];
            }

            gvStats.DataSource = dt;
            gvStats.DataBind();
        }
    }
}