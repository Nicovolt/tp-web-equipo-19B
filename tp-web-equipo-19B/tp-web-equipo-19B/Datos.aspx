<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Datos.aspx.cs" Inherits="tp_web_equipo_19B.Datos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
  
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
        }

        form {
            background-color: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
            max-width: 500px;
            width: 100%;
        }

        h1 {
            text-align: center;
            color: #333;
        }

        h2 {
            font-size: 16px;
            color: #666;
        }

        div {
            margin-bottom: 15px;
        }

        input[type="text"] {
            width: 100%;
            padding: 8px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        

        button:hover {
            background-color: #218838;
        }
    </style>
</head>
<body>
    <h1>Ingresa tus datos</h1>
    <form id="contact" runat="server">
        <div id="dni"> 
            <h2>DNI</h2> 
            <asp:TextBox ID="txtDNI" runat="server"></asp:TextBox>
        </div>

        <div id="nombre">
            <h2>Nombre</h2>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            
            <h2>Apellido</h2>
            <asp:TextBox ID="txtApellido" runat="server"></asp:TextBox>
            
            <h2>Email</h2>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </div>

        <div id="direccion">   
            <h2>Direccion</h2>
            <asp:TextBox ID="txtDireccion" runat="server"></asp:TextBox>
            
            <h2>Ciudad</h2>
            <asp:TextBox ID="txtCiudad" runat="server"></asp:TextBox>
            
            <h2>CP</h2>
            <asp:TextBox ID="txtCp" runat="server"></asp:TextBox>
        </div>

        <asp:Button ID="Button1" runat="server" Text="Enviar" CssClass="btn btn-primary" />
    </form>
</body>
</html>
