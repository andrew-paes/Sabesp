<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloImagemTextoLink.ascx.cs"
	Inherits="CtlTituloImagemTextoLink" %>
<div class="boxGray">
	<h3>
		<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h3>
	<div class="boxGrayC">
		<asp:Repeater ID="rptBox" runat="server">
			<HeaderTemplate>
				<ul id="tituloImagemTextoLink" class="listBoxGray">
			</HeaderTemplate>
			<ItemTemplate>
				<li>
					<asp:Image ID="imgRptBox" AlternateText="" runat="server" ImageUrl="" />
					<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
				</li>
			</ItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</div>
</div>
