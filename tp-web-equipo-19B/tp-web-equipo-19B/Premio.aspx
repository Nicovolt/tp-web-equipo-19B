<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premio.aspx.cs" Inherits="tp_web_equipo_19B.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container text-center">
        <h3>Elegi tu premio</h3>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repProductosSorteo" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <img src="<%#Eval("ImagenUrl")%>" alt="..." class="card-img-top rounded" />
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-text"><%#Eval("Descripcion") %></p>
                                <asp:Button Text="Quiero este!" runat="server" class="btn btn-primary" ID="btnSeleccionPremio" CommandArgument='<%#Eval("Id") %>' CommandName="PremioId" OnClick="btnSeleccionPremio_Click"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
