<%@ Control Language="C#" AutoEventWireup="true" CodeFile="sabespEnsina.ascx.cs"
	Inherits="CtlSabespEnsina" %>
<div class="boxDestaques w200">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="contentMaior">
				<h3 class="mt5 mb5">
					Sabesp Ensina</h3>
				<%--<img src="contents/img/img_sabespYoutube.gif" width="149" height="68" class="mb5" />--%>
				<asp:Image CssClass="mb5" ImageUrl="~/contents/img/img_sabespensina.gif" ID="Image1"
					Width="166" Height="91" runat="server" />
			</div>
		</div>
	</div>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<div class="contentMaior borderB">
				Material didático gratuito sobre o ciclo da água e do esgoto para professores, alunos
				e interessados.
				<asp:Image CssClass="mb5 mt5 fr" ImageUrl="~/contents/img/btn_saibamais.gif" ID="Image2"
					Width="75" Height="19" runat="server" Style="cursor: pointer;" 
					onclick="javascript:window.open('http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=4&proj=sabesp&pub=T&db=&docid=D57CA0A5E2BDCCAC832570830057CBC4','Chat','toolbar=no,status=no,menubar=no,scrollbars=no,resizeable=no,top=0,left=0,width=0,height=0'); return false;" />
				<%--<asp:ImageButton CssClass="mb5 mt5 fr" ID="ImageButton1" ImageUrl="~/contents/img/btn_saibamais.gif"
					Width="75" Height="19" runat="server" />--%>
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
