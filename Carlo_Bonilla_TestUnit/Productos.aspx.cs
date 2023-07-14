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
    public partial class Productos : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int categoryId = 0; // Asigna el ID de la categoría deseada

                CargarTable(categoryId);
            }
        }

        void CargarTable(int categoryId)
        {
            SqlCommand cmd = new SqlCommand("Usp_Sel_Co_Productos", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // Agregar el parámetro @CategoryId al comando
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);

            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            con.Close();

            // Verifica el estado de la categoría y muestra los productos solo si está activa
            if (EsCategoriaActiva(categoryId))
            {
                gvProductos.DataSource = dataTable;
                gvProductos.DataBind();
            }
            else
            {
                // Limpia el GridView si la categoría está inactiva
                gvProductos.DataSource = null;
                gvProductos.DataBind();
            }


        }

        bool EsCategoriaActiva(int categoryId)
        {
            SqlCommand cmd = new SqlCommand("SELECT cEsActiva FROM coCategoria WHERE nIdCategori = @CategoryId", con);
            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
            con.Open();
            string estado = (string)cmd.ExecuteScalar();
            con.Close();

            return (estado == "Activa");
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtIdCategoria.Text, out int categoryId))
            {
                CargarTable(categoryId);
            }
        }
    }
}