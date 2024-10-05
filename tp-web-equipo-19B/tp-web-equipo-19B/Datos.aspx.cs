using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19B
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccesoConcedidoDatos"] == null || !(bool)Session["AccesoConcedidoDatos"])
            {
                Response.Write("<script>alert('Debe ingresar un código válido o elegir un premio para acceder.');window.location='default.aspx';</script>");
            }

        }
    }
}