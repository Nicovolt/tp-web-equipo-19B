using Negocio;
using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace tp_web_equipo_19B
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Puedes incluir código adicional en Page_Load si es necesario
        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            lblErrorVoucher.Text = ""; // Limpiar mensajes de error previos
            string codigoVoucher = txtCodigo.Text.Trim();

            try
            {
                if (string.IsNullOrEmpty(codigoVoucher))
                {
                    lblErrorVoucher.Text = "El código está vacío.";
                    lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                VoucherNegocio voucherNegocio = new VoucherNegocio();

                // Intentamos buscar el voucher por su código
                Voucher voucher = voucherNegocio.buscaPorCodigo(codigoVoucher);

                if (voucher == null || string.IsNullOrEmpty(voucher.CodigoVoucher))
                {
                    lblErrorVoucher.Text = "El código ingresado no existe.";
                    lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                else if (voucher.IdCliente != null)
                {
                    lblErrorVoucher.Text = "El código ingresado ya se encuentra asociado a un cliente.";
                    lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                if (voucher.IdCliente == null)
                {
                    Response.Redirect("premio.aspx");
                }

                // Aquí puedes agregar lógica adicional para continuar el flujo si el voucher es válido

            }
            catch (Exception ex)
            {
                // Manejar excepciones generales
                lblErrorVoucher.Text = "Se ha producido un error inesperado. Por favor, inténtelo más tarde.";
                lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                // Puedes registrar el error (ejemplo en un log de errores)
                
            }
        }
    }
}
