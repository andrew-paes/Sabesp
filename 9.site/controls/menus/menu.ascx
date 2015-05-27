<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu.ascx.cs" Inherits="controls_menus_menu" %>
<ul class="lstMenu" id="lstMenu">
	<li class="itmSabesp">
		<asp:HyperLink runat="server" ID="hlMenuSabesp" NavigateUrl="#" rel="l0" Text="A Sabesp" />
	</li>
	<li class="itmSaneamento">
		<asp:HyperLink runat="server" ID="hlMenuSaneamento" NavigateUrl="#" rel="l-102px"
			Text="Saneamento" />
	</li>
	<li class="itmSociedade">
		<asp:HyperLink runat="server" ID="hlMenuSociedade" NavigateUrl="#" rel="l-263px"
			Text="Sociedade e meio ambiente" />
	</li>
	<li class="itmProdutos">
		<asp:HyperLink runat="server" ID="hlMenuProdutos" NavigateUrl="#" rel="l-414px" Text="Produtos e serviços" />
	</li>
	<li class="itmFiquePorDentro">
		<asp:HyperLink runat="server" ID="hlMenuFiquePorDentro" NavigateUrl="../../fique-por-dentro/Default.aspx"
			rel="l-573px" Text="Fique por dentro" />
	</li>
	<li class="itmAtendimento">
		<asp:HyperLink runat="server" ID="hlMenuAtendimento" NavigateUrl="../../fale-conosco/Default.aspx"
			rel="l-724px" Text="Central de atendimento" />
	</li>
	<li class="itmAgenciaVirtual">
		<asp:HyperLink runat="server" ID="hlMenuAgenciaVirtual" rel="l-875px" Text="Clientes e Serviços" />
	</li>
</ul>
