using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Carlo_Bonilla_TestUnit
{
    public partial class Categoria : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string id = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarTabla();
        }

        void CargarTabla()
        {
            SqlCommand cmd = new SqlCommand("Usp_load", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            gvProductos.DataSource = dataTable;
            gvProductos.DataBind();
            con.Close();
        }


        protected void BtnCreate_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/CrearCategoria.aspx?op=C");
        }

        protected void BtnRead_Click(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow gridViewRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = gridViewRow.Cells[1].Text;
            Response.Redirect("~/CrearCategoria.aspx?id=" + id + "&op=R");
        }

        protected void BtnUpdate_Click1(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow gridViewRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = gridViewRow.Cells[1].Text;
            Response.Redirect("~/CrearCategoria.aspx?id=" + id + "&op=U");
        }

        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            string id;
            Button BtnConsultar = (Button)sender;
            GridViewRow gridViewRow = (GridViewRow)BtnConsultar.NamingContainer;
            id = gridViewRow.Cells[1].Text;
            Response.Redirect("~/CrearCategoria.aspx?id=" + id + "&op=D");
        }
    }
}