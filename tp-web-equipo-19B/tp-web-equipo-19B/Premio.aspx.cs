using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19B
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            ListaArticulos = articuloNegocio.listar();


            if (Session["AccesoConcedido"] == null || !(bool)Session["AccesoConcedido"])
            {
                Response.Write("<script>alert('Debe ingresar un código válido para ver los premios.');window.location='default.aspx';</script>");
            }

            if (!IsPostBack)
            {
                repProductosSorteo.DataSource = ListaArticulos;
                repProductosSorteo.DataBind();
            }
        }

        protected void btnSeleccionPremio_Click(object sender, EventArgs e)
        {
            string valor = ((Button)sender).CommandArgument;
            Session["AccesoConcedidoDatos"] = true;
            Response.Redirect("Datos.aspx");

        }
    }
}