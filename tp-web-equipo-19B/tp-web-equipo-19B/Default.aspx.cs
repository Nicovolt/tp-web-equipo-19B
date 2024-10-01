using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tp_web_equipo_19B
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            string codigoVoucher = txtCodigo.Text.Trim();

            if (!string.IsNullOrEmpty(codigoVoucher))
            {
                AccesoDatos datos = new AccesoDatos();
                string consulta = "SELECT IdCliente FROM Vouchers WHERE CodigoVoucher = @codigo";
                datos.setearConsulta(consulta);
                datos.setearParametro("@codigo", codigoVoucher);

                try
                {
                    datos.ejecutarLectura();
                    if (datos.Lector.Read())
                    {
                       
                        if (datos.Lector["IdCliente"] != DBNull.Value)
                        {
                       
                            Response.Write("Este voucher ya ha sido utilizado");
                        }
                        else
                        {
                           
                            Session["codigoVoucher"] = codigoVoucher;
                            Response.Redirect("Premio.aspx");
                        }
                    }
                    else
                    {
                     
                        Response.Write("El codigo no es valido, ya esta en uso");
                    }
                }
                catch (Exception ex)
                {
                    
                }
                finally
                {
                    datos.cerrarConexion();
                }
            }
            else
            {
                Response.Write("Por favor, ingrese un codigo");
            }
        }

    }
}