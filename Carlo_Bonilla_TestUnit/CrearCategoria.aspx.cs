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
    public partial class CrearCategoria : System.Web.UI.Page
    {
        readonly SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        public static string id = "-1";
        public static string sOpc = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            //Obtener id
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    id = Request.QueryString["id"].ToString();
                    CargarDatos();
                }

                if (Request.QueryString["op"] != null)
                {
                    sOpc = Request.QueryString["op"].ToString();
                    switch (sOpc)
                    {
                        case "C":
                            lblTitulo.Text = "Ingresar una Nueva Categoría";
                            BtnCreate.Visible = true;
                            break;
                        case "R":
                            lblTitulo.Text = "Consulta de Usuario";
                            break;
                        case "U":
                            lblTitulo.Text = "Modificar Categoría";
                            BtnUpdate.Visible = true;
                            break;
                        case "D":
                            lblTitulo.Text = "Eliminar Categoría";
                            BtnDelete.Visible = true;
                            break;
                    }
                }
            }
        }

        void CargarDatos()
        {
            con.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Usp_Read", con);
            sqlDataAdapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlDataAdapter.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            DataSet ds = new DataSet();
            ds.Clear();
            sqlDataAdapter.Fill(ds);
            DataTable dt = ds.Tables[0];
            DataRow dr = dt.Rows[0];
            txtIdCategoria.Text = dr[0].ToString();
            txtNombre.Text = dr[1].ToString();
            txtEstado.Text = dr[2].ToString();
            con.Close();

        }


        protected void BtnCreate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Ins_Co_Categoria", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = txtIdCategoria.Text;
            cmd.Parameters.Add("@cNombCateg", SqlDbType.NVarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@cEsActiva", SqlDbType.NVarChar).Value = txtEstado.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Categoria.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Update", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@cNombCateg", SqlDbType.NVarChar).Value = txtNombre.Text;
            cmd.Parameters.Add("@cEsActiva", SqlDbType.NVarChar).Value = txtEstado.Text;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Categoria.aspx");
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("Usp_Delete", con);
            con.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.Add("@nIdCategori", SqlDbType.Int).Value = id;
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect("Categoria.aspx");
        }

        protected void BtnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Categoria.aspx");
        }
    }
}