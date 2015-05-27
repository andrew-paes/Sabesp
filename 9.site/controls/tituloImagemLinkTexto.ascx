<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloImagemLinkTexto.ascx.cs"
	Inherits="CtlTituloImagemLinkTexto" %>

<script type="text/javascript">
	$(document).ready(function() {
		$("#tituloImagemLinkTexto li:last").addClass("last");
	});
</script>

<div class="boxMaisVistos">
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<h3>
				<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h3>
			<asp:Repeater ID="rptBox" runat="server">
				<HeaderTemplate>
					<ul id="tituloImagemLinkTexto" class="maisVistosList after">
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<asp:Image ID="imgRptBox" AlternateText=" " runat="server" ImageUrl="" />
						<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
						<%--<a href="#"><span>Nulla dolor urna elementum at iaculis non volutpat molestie</span></a>--%>
					</li>
				</ItemTemplate>
				<FooterTemplate>
					</ul>
				</FooterTemplate>
			</asp:Repeater>
		</div>
	</div>
</div>
