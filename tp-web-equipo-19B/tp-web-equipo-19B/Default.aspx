<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web_equipo_19B._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="d-flex align-items-center justify-content-center min-vh-100" style="margin-top: -200px;">
        <div class="card p-4 custom-card" style="max-width: 400px; width: 100%;">
            <h1 class="text-center mb-4 gradient-text">CANJEA TU CÓDIGO</h1>

            <!-- Label del código de voucher con estilo degradado -->
            <div class="text-center mb-2">
                <asp:Label ID="lblVoucher" runat="server" Text="Ingrese el código de su voucher" CssClass="form-label gradient-label"></asp:Label>
            </div>

            <!-- Contenedor flexible para alinear el TextBox y el Botón -->
            <div class="d-flex flex-column align-items-stretch">
                <!-- TextBox para ingresar el código con margen -->
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control mb-3 ms-4" placeholder="Código aquí"></asp:TextBox>

                <!-- Botón siguiente con estilo degradado -->
                <asp:Button ID="btnCodigo" runat="server" Text="Siguiente" CssClass="btn btn-primary w-100 gradient-button ms-4" OnClick="btnCodigo_Click" />
            </div>

            <!-- Label para mostrar errores -->
            <asp:Label ID="lblErrorVoucher" runat="server" Text="" CssClass="text-danger" style="margin-top: 10px;"></asp:Label>
        </div>
    </main>

    <style>
        .custom-card {
            box-shadow: 0 4px 20px rgba(128, 0, 128, 0.2), 0 0 25px rgba(138, 43, 226, 0.3);
        }

        .gradient-text {
            font-weight: bold;
            font-size: 2.5rem; /* Ajusta el tamaño de la fuente como desees */
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            -webkit-background-clip: text; 
            -webkit-text-fill-color: transparent;
            margin: 0; /* Eliminar márgenes adicionales */
        }

        .gradient-label {
            font-weight: bold;
            font-size: 1.2rem; /* Ajusta el tamaño de la fuente del label */
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            -webkit-background-clip: text; 
            -webkit-text-fill-color: transparent;
        }

        .gradient-button {
            background: linear-gradient(90deg, rgba(138, 43, 226, 1), rgba(255, 105, 180, 1)); /* Degradado de violeta a rosa */
            color: white; /* Cambiar el color del texto del botón a blanco */
            border: none; /* Sin borde */
            transition: background 0.3s; /* Transición para el efecto hover */
        }

        .gradient-button:hover {
            background: linear-gradient(90deg, rgba(255, 105, 180, 1), rgba(138, 43, 226, 1)); /* Degradado revertido en hover */
        }

    </style>

</asp:Content>
