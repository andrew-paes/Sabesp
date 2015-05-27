<%@ Control Language="C#" AutoEventWireup="true" CodeFile="resultadoAnalise.ascx.cs"
	Inherits="CtlResultadoAnalise" %>
<div class="boxDestaquesBgr w192">
	<h3 class="mt5 mb5">
		Resultado de Análise</h3>
	<%--<img src="contents/img/img_resultadoanalise.gif" width="192" height="82" class="mbm2" />--%>
	<asp:Image CssClass="mbm2" ImageUrl="~/contents/img/img_resultadoanalise.gif" ID="Image2"
		Width="192" Height="82" runat="server" />
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMedio borderB">
				Relatórios mensais sobre a qualidade da água de cada município.
				<%--<img src="contents/img/btn_saibamais.gif" width="75" height="19" class="mb5 mt5 fr" />--%>
				<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_confira.gif"
					Width="49" Height="19" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=42" />
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
