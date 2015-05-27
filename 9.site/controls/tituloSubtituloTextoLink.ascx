<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloSubtituloTextoLink.ascx.cs" Inherits="CtlTituloSubtituloTextoLink" %>
<div class="boxMaisVistosD">
	<div class="boxMaisVistosC">
		<div class="boxMaisVistosHeader"><asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></div>
		<asp:Repeater ID="rptBox" runat="server">
			<HeaderTemplate>
				<ul id="tituloSubtituloTextoLink" class="maisVistosListZebrado">
			</HeaderTemplate>
			<ItemTemplate>
				<li>
					<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
				</li>
			</ItemTemplate>
			<AlternatingItemTemplate>
				<li class="alt">
					<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
				</li>
			</AlternatingItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</div>
</div>
