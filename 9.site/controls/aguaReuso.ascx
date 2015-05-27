<%@ Control Language="C#" AutoEventWireup="true" CodeFile="aguaReuso.ascx.cs"
	Inherits="CtlAguaReuso" %>
<div class="boxDestaquesBgr w192">
	<h3 class="mt5 mb5">
		Água de Reúso</h3>
	<%--<img src="contents/img/img_resultadoanalise.gif" width="192" height="82" class="mbm2" />--%>
	<asp:Image CssClass="mbm2" ImageUrl="~/contents/img/img_aguareuso.gif" ID="Image2"
		Width="192" Height="82" runat="server" />
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMedio borderB">
				Conheça o tratamento que permite o reaproveitamento da água.
				<%--<img src="contents/img/btn_saibamais.gif" width="75" height="19" class="mb5 mt5 fr" />--%>
				<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_saibamais.gif"
					Width="75" Height="19" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=42" />
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
