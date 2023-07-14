<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Carlo_Bonilla_TestUnit.Productos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

        <br />
        <div class="mx-auto" style="width: 300px">
            <h2>Listado de Productos</h2>
        </div>
        <br />
      <div class="container">
            <div class="row">
                <div class="col align-self-end">
                     <label class="form-label">Id Categoría</label>
                     <asp:TextBox runat="server" CssClass="form-control" ID="txtIdCategoria"></asp:TextBox>
                     <asp:Button runat="server" ID="BtnBuscar" CssClass="btn btn-success form-control-sm" Text="Buscar" OnClick="BtnBuscar_Click" />
                </div>
            </div>
        </div>
     <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvProductos" class="table table-borderless table-hover">
              </asp:GridView>
            </div>

        </div>
</asp:Content>
