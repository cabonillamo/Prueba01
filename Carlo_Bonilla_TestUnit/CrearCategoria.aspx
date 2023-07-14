<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearCategoria.aspx.cs" Inherits="Carlo_Bonilla_TestUnit.CrearCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <br />
    <div class="mx-auto" style="width: 250px">
        <asp:Label runat="server" CssClass="h2" ID="lblTitulo"></asp:Label>
    </div>
        <!--Este div es para el espacio donde se digitá el ID de la Categoría -->
        <div class="mb-3">
            <label class="form-label">ID Categoría</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtIdCategoria"></asp:TextBox>
        </div>
         <!--Este div es para el espacio donde se digitá el Nombre de dicha categoría -->
        <div class="mb-3">
            <label class="form-label">Nombre</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtNombre"></asp:TextBox>
        </div>
         <!--Este div es para el espacio donde se digitá el estado de la categoría -->
        <div class="mb-3">
            <label class="form-label">Estado</label>
            <asp:TextBox runat="server" CssClass="form-control" ID="txtEstado" PlaceHolder="Activa/Inactiva"></asp:TextBox>
        </div>
         <!--Este es el botón para guardar la categoria-->
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnCreate" Text="Crear" Visible="false" OnClick="BtnCreate_Click"/>
         <!--Este es el botón para editar la categoria-->
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnUpdate" Text="Editar" Visible="false" OnClick="BtnUpdate_Click" />
         <!--Este es el botón para eliminar la categoria-->
        <asp:Button runat="server" CssClass="btn btn-primary" ID="BtnDelete" Text="Eliminar" Visible="false" OnClick="BtnDelete_Click"/>
         <!--Este es el botón para volver la categoria-->
        <asp:Button runat="server" CssClass="btn btn-primary btn-dark" ID="BtnVolver" Text="Volver" Visible="true" OnClick="BtnVolver_Click" />

</asp:Content>
