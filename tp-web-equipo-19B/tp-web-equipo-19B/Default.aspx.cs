using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        protected void btnCodigo_Click(object sender, EventArgs e)
        {
            lblErrorVoucher.Text = "";
            string codigoVoucher = txtCodigo.Text.Trim();


            if (string.IsNullOrEmpty(codigoVoucher))
            {
                lblErrorVoucher.Text = "El codigo esta vacio";
                lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                return;
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            Voucher voucher = voucherNegocio.buscaPorCodigo(codigoVoucher);

            if (voucher == null || voucher.CodigoVoucher.Equals(""))
            {
                lblErrorVoucher.Text = "El codigo ingresado no existe";
                lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (voucher.IdCliente != null)
            {
                lblErrorVoucher.Text = "El código ingresado ya se encuentra asociado a un cliente";
                lblErrorVoucher.ForeColor = System.Drawing.Color.Red;
                return;
            }

            /* TODO: actualizacion de la pagina a los productos */
        }

    }
}