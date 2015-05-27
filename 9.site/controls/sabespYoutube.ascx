<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sabespYoutube.ascx.cs"
	Inherits="CtlSabespYoutube" %>
<div class="boxDestaques">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="content">
				<%--<img src="contents/img/ttl_sabespYoutube.gif" width="149" height="25" class="mt5 mb5" />--%>
				<%--<img src="contents/img/img_sabespYoutube.gif" width="149" height="68" class="mb5" />--%>
				<asp:Image CssClass="mt5 mb5" ImageUrl="~/contents/img/ttl_sabespYoutube.gif" ID="Image1"
					Width="149" Height="25" runat="server" />
				<asp:Image CssClass="mb5" ImageUrl="~/contents/img/img_sabespYoutube.gif" ID="Image2"
					Width="149" Height="68" runat="server" />
			</div>
		</div>
	</div>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="content borderB">
				O canal de vídeos da Sabesp na Internet.
				<%--<img src="contents/img/btn_assista.gif" width="49" height="19" class="mb5 mt5 fr" />--%>
				<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_assista.gif"
					Width="49" Height="19" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=68" />
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
