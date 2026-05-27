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
    public partial class MenuList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadMenu();
            }
        }

        void LoadMenu()
        {
            string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlDataAdapter da =
                new SqlDataAdapter("select * from MenuItems", con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            gvMenu.DataSource = dt;
            gvMenu.DataBind();
        }

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            string id =
                ((System.Web.UI.WebControls.LinkButton)sender)
                .CommandArgument;

            string cs = ConfigurationManager.ConnectionStrings["FoodDBCS"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);

            SqlCommand cmd =
                new SqlCommand("delete from MenuItems where MenuId=@id", con);

            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            LoadMenu();
        }
    }
}