<%@ Control Language="C#" AutoEventWireup="true" CodeFile="galeriaImagens.ascx.cs"
	Inherits="controls_noticias_galeriaImagens" %>
<div class="galeria">
	<asp:Repeater ID="rptImagens" runat="server" OnItemDataBound="rptImagens_ItemDataBound">
		<HeaderTemplate>
			<ul class="fotos">
		</HeaderTemplate>
		<ItemTemplate>
			<li id="liGaleria" runat="server">
				<asp:Image ID="imgGaleria" runat="server" />
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<ul class="numeral" id="ulFooter" runat="server" />
</div>
