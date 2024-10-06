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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AccesoConcedidoDatos"] == null || !(bool)Session["AccesoConcedidoDatos"])
            {
                Response.Write("<script>alert('Debe ingresar un código válido o elegir un premio para acceder.');window.location='default.aspx';</script>");
            }
            /*

            AccesoDatos datos = new AccesoDatos();

            datos.setearConsulta("UPDATE Vouchers SET IdCliente = @id, FechaCanje = CURDATE(), IdArticulo =@idArt WHERE id = @idVou;");
            datos.setearParametro("@id@", ); //falta hacer
            datos.setearParametro("@idArt", ); //falta hacer
            datos.setearParametro("@idVou", Session["voucher"]);
            datos.ejecutarAccion();

            */
        }

        protected void btnDatos_Click(object sender, EventArgs e)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            lblErrorDni.Text = string.Empty;
            lblErrorNombre.Text = string.Empty;
            lblErrorApellido.Text = string.Empty;
            lblErrorEmail.Text = string.Empty;
            lblErrorDireccion.Text = string.Empty;
            lblErrorCiudad.Text = string.Empty;
            lblErrorCp.Text = string.Empty;
            lblErrorTerminosCondiciones.Text = string.Empty;

            bool loadError = false;

            if (!validacionTxtBox(txtDNI))
            {
                lblErrorDni.Text = "El campo DNI no puede estar vacio";
                lblErrorDni.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtNombre))
            {
                lblErrorNombre.Text = "El campo Nombre no puede estar vacio";
                lblErrorNombre.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtApellido))
            {
                lblErrorApellido.Text = "El campo Apellido no puede estar vacio";
                lblErrorApellido.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtEmail))
            {
                lblErrorEmail.Text = "El campo Apellido no puede estar vacio";
                lblErrorEmail.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtDireccion))
            {
                lblErrorDireccion.Text = "El campo Direccion no puede estar vacio";
                lblErrorDireccion.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtCiudad))
            {
                lblErrorCiudad.Text = "El campo Ciudad no puede estar vacio";
                lblErrorCiudad.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionTxtBox(txtCp))
            {
                lblErrorCp.Text = "El campo CP no puede estar vacio";
                lblErrorCp.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }
            if (!validacionChechBox(cbxTerminosCondiciones))
            {
                lblErrorTerminosCondiciones.Text = "Por favor acepte los terminos y condiciones";
                lblErrorTerminosCondiciones.ForeColor = System.Drawing.Color.Red;
                loadError = true;
            }

            if (loadError) return;


            try
            {
                Cliente cliente = new Cliente();

                cliente.Documento = txtDNI.Text;
                cliente.Nombre = txtNombre.Text;
                cliente.Apellido = txtApellido.Text;
                cliente.Email = txtEmail.Text;
                cliente.Direccion = txtDireccion.Text;
                cliente.Ciudad = txtCiudad.Text;
                cliente.Cp = int.Parse(txtCp.Text);

                clienteNegocio.agregarCliente(cliente);

                cliente = clienteNegocio.getClienteByDNi(cliente.Documento);

                VoucherNegocio voucherNegocio = new VoucherNegocio();

                int valorPremio = 0;
                if (Session["premio"] != null)
                {
                    valorPremio = Convert.ToInt32(Session["premio"]);
                }
                else
                {
                    Response.Write("<script>alert('Debes elegir un premio para participar');window.location='Premio.aspx';</script>");
                }

                string voucher = "";
                if (Session["voucher"] != null)
                {
                    voucher = Convert.ToString(Session["voucher"]);
                }
                else
                {
                    Response.Write("<script>alert('Debes ingresar un codigo para canjear');window.location='Default.aspx';</script>");
                }

                voucherNegocio.registrarUsoVoucher(cliente.Id, valorPremio,voucher);

                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool validacionTxtBox(TextBox item)
        {
            if (!string.IsNullOrEmpty(item.Text))
            {
                return true;
            }
            return false;
        }

        private bool validacionChechBox(CheckBox item)
        {
            if (item.Checked) { return true; }
            return false;
        }
    }
}