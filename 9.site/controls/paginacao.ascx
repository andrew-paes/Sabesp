<%@ Control Language="C#" AutoEventWireup="true" CodeFile="paginacao.ascx.cs" Inherits="controls_paginacao" %>
<div class="paginacao after">
	<asp:HyperLink ID="btnVoltarPaginacao" CssClass="btPrev" ToolTip="Voltar" NavigateUrl="#" runat="server">Voltar</asp:HyperLink>
	<asp:HyperLink ID="btnAvancarPaginacao" CssClass="btNext" ToolTip="Avançar" NavigateUrl="#" runat="server">Avançar</asp:HyperLink>
	<div class="paginas after">
		<a href="#"><span>1</span></a>
		<a class="atv" href="#"><span>2</span></a>
		<a href="#"><span>3</span></a>
		<a href="#"><span>4</span></a>
		<a href="#"><span>5</span></a>
		<span>&nbsp;...&nbsp;</span>
		<a href="#"><span>10</span></a>
	</div>
</div>