<%@ Control Language="C#" AutoEventWireup="true" CodeFile="atendimentoOnline.ascx.cs"
	Inherits="CtlAtendimentoOnline" %>
<div class="boxDestaques w200">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="contentMaior">
				<h3 class="mt5 mb5">
					Atendimento Online</h3>
				<%--<img src="contents/img/img_atendimentonline.gif" width="166" height="104" class="mb5" />--%>
				<asp:Image CssClass="mb5 mt5 fr" ImageUrl="~/contents/img/img_atendimentonline.gif" ID="Image2"
					Width="166" Height="104" runat="server" Style="cursor: pointer;" 
					onclick="javascript:window.open('https://atendimentoonline.sabesp.com.br/sccusuarioweb/default.aspx','Chat','toolbar=no,status=no,menubar=no,scrollbars=no,resizeable=no,top=0,left=0,width=0,height=0'); return false;" />
			</div>
		</div>
	</div>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMaior borderB">
				Clique para conversar com um de nossos atendentes
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
