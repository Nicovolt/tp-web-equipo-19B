<%@ Page Title="Formulario de Datos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario_web1.aspx.cs" Inherits="tp_web_equipo_19B.Formulario_web11" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="d-flex align-items-center justify-content-center min-vh-100" style="margin-top: -100px;">
        <div class="card p-4 custom-card" style="max-width: 400px; width: 100%;">
            <h1 class="text-center mb-4 gradient-text">INGRESA TUS DATOS</h1>

            <!-- DNI -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblDNI" runat="server" Text="DNI" CssClass="form-label gradient-label ms-10"></asp:Label>
                <asp:TextBox ID="txtDNI" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorDni" runat="server" />
            </div>

            <!-- Nombre -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorNombre" runat="server" />
            </div>

            <!-- Apellido -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblApellido" runat="server" Text="Apellido" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtApellido" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorApellido" runat="server" />
            </div>

            <!-- Email -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblEmail" runat="server" Text="Email" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtEmail" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorEmail" runat="server" />
            </div>

            <!-- Dirección -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblDireccion" runat="server" Text="Dirección" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtDireccion" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorDireccion" runat="server" />
            </div>

            <!-- Ciudad -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblCiudad" runat="server" Text="Ciudad" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtCiudad" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorCiudad" runat="server" />
            </div>

            <!-- CP -->
            <div class="mb-3 text-center">
                <asp:Label ID="lblCp" runat="server" Text="CP" CssClass="form-label gradient-label"></asp:Label>
                <asp:TextBox ID="txtCp" CssClass="form-control custom-input" runat="server" />
                <asp:Label Text="" ID="lblErrorCp" runat="server" />
            </div>

            <!-- Terminos y Condiciones -->
            <div class="mb-3 text-center">
                <asp:CheckBox ID="cbxTerminosCondiciones" runat="server" />
                <asp:Label ID="lblTerminosCondiciones" runat="server" Text="Acepta terminos y condiciones" CssClass="form-label gradient-label"></asp:Label>
                <br>
                <asp:Label Text="" ID="lblErrorTerminosCondiciones" runat="server" />
            </div>

            <!-- Botón de Envío -->
            <asp:Button ID="btnDatos" runat="server"  Text="Enviar" CssClass="btn btn-primary w-100 gradient-button custom-button" OnClick="btnDatos_Click"/>
        </div>
    </main>

    <style>
        .custom-card {
            box-shadow: 0 4px 20px rgba(128, 0, 128, 0.2), 0 0 25px rgba(138, 43, 226, 0.3);
            border-radius: 15px;
            background-color: white;
        }

        .gradient-text {
            font-weight: bold;
            font-size: 2rem;
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
            margin: 0;
        }

        .gradient-label {
            font-weight: bold;
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            -webkit-background-clip: text;
            -webkit-text-fill-color: transparent;
        }

        .gradient-button {
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            color: white; /* Texto en blanco */
            border: none;
            transition: background 0.3s;
        }

        .gradient-button:hover {
            background: linear-gradient(90deg, rgba(255, 105, 180, 1), rgba(138, 43, 226, 1)); /* Degradado invertido en hover */
        }

        main {
            margin-top: -200px;
        }

        .custom-input {
            width: 80%; 
            margin: 0 auto; 
        }
        .custom-button {
            width: 80%; 
            margin: 0 auto; 
            margin-top: 5%
}
    </style>

</asp:Content>
