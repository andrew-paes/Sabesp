<%@ Control Language="C#" AutoEventWireup="true" CodeFile="guiaEducacao.ascx.cs"
	Inherits="CtlguiaEducacao" %>
<div class="boxDestaques w200">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="contentMaior">
				<h3 class="mt5 mb5">
					Guia de Educação</h3>
				<%--<img src="contents/img/img_sabespYoutube.gif" width="149" height="68" class="mb5" />--%>
				<asp:Image CssClass="mb5" ImageUrl="~/contents/img/img_sabespYoutube.gif" ID="Image1"
					Width="149" Height="68" runat="server" />
			</div>
		</div>
	</div>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMaior borderB">
				Ações e projetos de Educação Ambiental e Educação Sanitária.
				<%--<img src="contents/img/btn_saibamais.gif" width="75" height="19" class="mb5 mt5 fr" />--%>
				<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_saibamais.gif"
					Width="75" Height="19" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=176" />
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
