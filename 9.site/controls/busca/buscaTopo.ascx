<%@ Control Language="C#" AutoEventWireup="true" CodeFile="buscaTopo.ascx.cs" Inherits="controls_busca_buscaTopo" %>
<asp:Panel ID="pnlBusca" DefaultButton="btnBusca" runat="server">
<fieldset id="fsBusca">
	<legend><asp:Literal ID="ltrBusca" runat="server" /></legend>
	<asp:TextBox ID="txtBusca" CssClass="text limpaCampo" runat="server" />
	<asp:ImageButton ID="btnBusca" CssClass="button" ImageUrl="~/contents/img/btn-buscar.gif"
		runat="server" onclick="btnBusca_Click" />
</fieldset>
</asp:Panel>
