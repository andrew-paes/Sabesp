<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ultimasNoticias.ascx.cs"
	Inherits="controls_noticias_ultimasNoticias" %>
<div class="boxMaisVistosHeader">
	<asp:Literal ID="Literal1" runat="server">Últimas Notícias</asp:Literal></div>
<asp:Repeater ID="rptNoticias" runat="server" OnItemDataBound="rptNoticias_ItemDataBound">
	<HeaderTemplate>
		<ul class="maisVistosList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li id="li" runat="server">
			<asp:HyperLink ID="hlNoticia" NavigateUrl="#" runat="server">
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
