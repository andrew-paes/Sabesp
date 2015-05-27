<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destSolucoesAmbientais.ascx.cs"
	Inherits="CtlDestSolucoesAmbientais" %>
<div class="boxDestaquesBgr w192">
    <h3 class="mt5 mb5">Soluções Ambientais</h3>	
	<img src="contents/img/img_solucoesambientais.gif" width="182" height="83" class="mbm2" />
	<div class="bgrBottomRight w182">
		<div class="bgrBottomLeft">
			<div class="contentMedio borderB w131">
				Programas desenvolvidos pela Sabesp para preservar a natureza.				<%--<img src="contents/img/btn_saibamais.gif" width="75" height="19" class="mb5 mt5 fr" />--%>
				<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_conheca.gif"
					Width="65" Height="19" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=176" />
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
