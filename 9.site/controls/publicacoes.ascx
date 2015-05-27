<%@ Control Language="C#" AutoEventWireup="true" CodeFile="publicacoes.ascx.cs" Inherits="CtlMaisVistos" %>
<div class="boxMaisVistos">
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<h3><asp:Literal ID="Literal1" runat="server">Mais Vistos</asp:Literal></h3>
			<ul class="maisVistosList after">
				<li>
					<asp:Image ID="mImage1" AlternateText=" " runat="server" ImageUrl="../contents/img/mais-vistos-img.jpg" />
					<a href="#"><span>Nulla dolor urna elementum at iaculis non volutpat molestie</span></a>
					<span>1.410 visualizações</span>
				</li>
				<li>
					<asp:Image ID="mImage2" AlternateText=" " runat="server" ImageUrl="../contents/img/mais-vistos-img.jpg" />
					<a href="#"><span>Nulla dolor urna elementum at iaculis non volutpat molestie</span></a>
					<span>1.410 visualizações</span>
				</li>
				<li class="last">
					<asp:Image ID="mImage3" AlternateText=" " runat="server" ImageUrl="../contents/img/mais-vistos-img.jpg" />
					<a href="#"><span>Nulla dolor urna elementum at iaculis non volutpat molestie</span></a>
					<span>1.410 visualizações</span>
				</li>
			</ul>
		</div>
	</div>
</div>
