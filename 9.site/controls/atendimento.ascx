<%@ Control Language="C#" AutoEventWireup="true" CodeFile="atendimento.ascx.cs" Inherits="CtlAtendimento" %>
<div class="boxGray">
	<h3><asp:Literal runat="server">Atendimento Sabesp</asp:Literal></h3>
	<div class="bgrBottomRight" style="width:183px !important;">
		<div class="bgrBottomLeft">
			<asp:Image ID="aImage1" AlternateText=" " CssClass="imgAtendimento" runat="server" ImageUrl="~/contents/img/img-atendimento.jpg" />
			<div class="boxBorder">
				<span class="txtChamada"><asp:Literal ID="Literal2" runat="server">Atendimento Online</asp:Literal></span>
				<asp:HyperLink ID="hlAtendimentoOnline" NavigateUrl="#" onclick="javascript:window.open('https://atendimentoonline.sabesp.com.br/sccusuarioweb/default.aspx','Chat','toolbar=no,status=no,menubar=no,scrollbars=no,resizeable=no,top=0,left=0,width=0,height=0'); return false;" CssClass="btnFaleAgora" Width="93" Height="19" ToolTip="Fale agora" runat="server" />
			</div>
			<div class="boxBorderP borderPieFix">
				<div class="boxDestaque">
					<span><asp:Literal ID="Literal3" runat="server">Serviço de emergência</asp:Literal></span>
					<strong><asp:Literal ID="Literal4" runat="server">195</asp:Literal></strong>
				</div>
				<span class="fones borderBottom">
					<span><asp:Literal ID="Literal5" runat="server">São Paulo e Grande S.Paulo</asp:Literal></span>
					<strong><asp:Literal ID="Literal6" runat="server">0800-0119911</asp:Literal></strong>
				</span>
				<span class="fones">
					<span><asp:Literal ID="Literal7" runat="server">Interior e Litoral</asp:Literal></span>
					<strong><asp:Literal ID="Literal8" runat="server">0800-0550195</asp:Literal></strong>
				</span>
			</div>
		</div>
	</div>
</div>
