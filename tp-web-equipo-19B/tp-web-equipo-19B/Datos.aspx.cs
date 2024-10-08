﻿using Dominio;
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
            if (!IsPostBack)
            {
                // Si el DNI ya fue ingresado, busca al cliente y carga los datos.
                string dni = txtDNI.Text.Trim();
                if (!string.IsNullOrEmpty(dni))
                {
                    CargarDatosCliente(dni);
                }
            }


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
                Response.Write("<script>alert('ya esta participando, sera devuelto al inicio');window.location='default.aspx';</script>");

                confirmacion();
                

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

        private void CargarDatosCliente(string dni)
        {
            ClienteNegocio clienteNegocio = new ClienteNegocio();
            Cliente cliente = clienteNegocio.getClienteByDNi(dni); 

            if (cliente != null)
            {
              
                txtNombre.Text = cliente.Nombre;
                txtApellido.Text = cliente.Apellido;
                txtEmail.Text = cliente.Email;
                txtDireccion.Text = cliente.Direccion;
                txtCiudad.Text = cliente.Ciudad;
                txtCp.Text = cliente.Cp.ToString();
            }
            else
            {
                
                lblErrorDni.Text = "No se ha encontrado un cliente con este DNI.";
                lblErrorDni.ForeColor = System.Drawing.Color.Red;
                LimpiarCampos(); 
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtCp.Text = string.Empty;
        }
        protected void txtDNI_TextChanged(object sender, EventArgs e)
        {
            string dni = txtDNI.Text.Trim();
            if (!string.IsNullOrEmpty(dni))
            {
                CargarDatosCliente(dni); 
            }
        }

        private void confirmacion()
        {
            Negocio.ServicioEmail servicioEmail = new Negocio.ServicioEmail();

            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string documento = txtDNI.Text;
            string mailUsuario = txtEmail.Text;

            servicioEmail.ConfirmarParticipacion(mailUsuario, nombre, apellido, documento);
        }
    }
}