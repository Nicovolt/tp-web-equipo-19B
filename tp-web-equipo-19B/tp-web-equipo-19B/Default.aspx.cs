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
            string codigoVoucher = txtCodigo.Text.Trim();

            if (string.IsNullOrEmpty(codigoVoucher))
            {
                throw new Exception("El codigo esta vacio");
            }

            VoucherNegocio voucherNegocio = new VoucherNegocio();

            Voucher voucher = voucherNegocio.buscaPorCodigo(codigoVoucher);

            if (voucher == null || voucher.CodigoVoucher.Equals(""))
            {
                throw new Exception("El codigo ingresado no existe");
            }

            if (voucher.IdCliente != null)
            {
                throw new Exception("El codigo ingresado ya se encuentra asociado a un cliente");
            }

            /* TODO: actualizacion de la pagina a los productos */
        }

    }
}