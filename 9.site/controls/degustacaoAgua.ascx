<%@ Control Language="C#" AutoEventWireup="true" CodeFile="degustacaoAgua.ascx.cs"
	Inherits="CtlDegustacaoAgua" %>
<div class="boxDestaques w200">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="contentMaior">
				<h3 class="mt5 mb5">
					Degustação da Água</h3>
				<%--<img src="contents/img/img_degustacao.gif" width="166" height="91" class="mb5" />--%>
				<asp:ImageButton CssClass="mb5" ID="ImageButton1" ImageUrl="~/contents/img/img_degustacao.gif"
					Width="166" Height="91" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=41" />
			</div>
		</div>
	</div>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMaior borderB">
				Profissionais treinados para garantir a qualidade da água.
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
