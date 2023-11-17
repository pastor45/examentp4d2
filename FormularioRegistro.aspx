<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="FormularioRegistro.aspx.cs" Inherits="exaamentp42.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">

body {
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f4;
}

nav {
    background-color: #333;
    padding: 10px;
}

nav ul {
    list-style-type: none;
    margin: 0;
    padding: 0;
}

nav ul li {
    display: inline;
    margin-right: 20px;
}

nav a {
    text-decoration: none;
    color: #fff;
    font-weight: bold;
    font-size: 16px;
}

nav a:hover {
    color: #ffcc00;
}

footer {
    padding-top: 20;
    background-color: #333;
    color: #fff;
    padding: 10px;
    text-align: center;
    bottom: 0;
    width: 100%;
}

form {
    max-width: 400px;
    margin: 20px auto;
    background-color: #fff;
    padding: 20px;
    border-radius: 5px;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
}

h2 {
    color: #333;
    text-align: center;
}

label {
    display: block;
    margin-bottom: 8px;
    color: #333;
}

input[type="text"],
input[type="number"],
input[type="password"] {
    width: 100%;
    padding: 8px;
    margin-bottom: 15px;
    box-sizing: border-box;
}

button {
    background-color: #333;
    color: #fff;
    padding: 10px 15px;
    border: none;
    border-radius: 3px;
    cursor: pointer;
}

button:hover {
    background-color: #ffcc00;
}
</style>
    <h2>Registración</h2>
    <asp:TextBox ID="txtEmail" runat="server" placeholder="Correo electrónico" required></asp:TextBox>
    <asp:TextBox ID="txtUsername" runat="server" placeholder="Nombre de usuario" required></asp:TextBox>
    <asp:TextBox ID="txtEdad" runat="server" type="number" placeholder="Edad" required></asp:TextBox>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Contraseña" required></asp:TextBox>
    <asp:TextBox ID="txtRepeatPassword" runat="server" TextMode="Password" placeholder="Repetir Contraseña" required></asp:TextBox>
    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
    <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
</asp:Content>