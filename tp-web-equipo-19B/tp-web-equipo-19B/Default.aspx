<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tp_web_equipo_19B._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>

        <h1>Ganaste</h1>

        <asp:Label ID="Label1" runat="server" Text="Ingrese el codigo de su voucher "></asp:Label>
        <asp:TextBox ID="txtCodigo" runat="server"></asp:TextBox>
        <asp:Button ID="btnCodigo" runat="server" Text="Siguiente" />
    
    
    </main>

</asp:Content>
