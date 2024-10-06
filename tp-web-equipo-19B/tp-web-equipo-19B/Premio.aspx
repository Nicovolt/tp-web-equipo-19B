<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Premio.aspx.cs" Inherits="tp_web_equipo_19B.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .card-img-top {
            width: 100%;
            height: 500px;
            object-fit: contain;
            background-color: #f8f9fa;
        }
        .card {
            height: 100%;
            overflow: hidden;
        }
        .card-body {
            display: flex;
            flex-direction: column;
        }
        .card-text {
            flex-grow: 1;
        }
        .carousel-item {
            text-align: center;
        }
        .carousel-inner {
            height: 500px;
        }
        @media (max-width: 768px) {
            .card-img-top, .carousel-inner {
                height: 300px;
            }
        }
    </style>
    <div class="container">
        <h3>Elegi tu premio</h3>
        <div class="row row-cols-1 row-cols-md-3 g-4">
            <asp:Repeater ID="repProductosSorteo" runat="server">
                <ItemTemplate>
                    <div class="col">
                        <div class="card">
                            <div id='carouselArticulo<%# Eval("Id") %>' class="carousel slide" data-bs-ride="carousel">
                                    <div class="carousel-inner">
                                        <asp:Repeater ID="repImagenes" runat="server" DataSource='<%# Eval("ListaImagenes") %>'>
                                            <ItemTemplate>
                                                <div class='carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>'>
                                                    <img src='<%# Eval("Url") %>' class="d-block w-100 card-img-top" alt="Imagen del artículo">
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </div>
                                    <button class="carousel-control-prev" type="button" data-bs-target='#carouselArticulo<%# Eval("Id") %>' data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Anterior</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target='#carouselArticulo<%# Eval("Id") %>' data-bs-slide="next">
                                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Siguiente</span>
                                    </button>
                                </div>
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Nombre") %></h5>
                                <p class="card-title"><%#Eval("Descripcion") %></p>
                                <asp:Button Text="Quiero este!" runat="server" class="btn btn-primary" ID="btnSeleccionPremio" CommandArgument='<%#Eval("Id") %>' CommandName="PremioId" OnClick="btnSeleccionPremio_Click"/>
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
