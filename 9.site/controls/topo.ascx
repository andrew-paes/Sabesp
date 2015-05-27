<%@ Control Language="C#" AutoEventWireup="true" CodeFile="topo.ascx.cs" Inherits="controls_topo" %>
<div class="boxTopo">
	<div class="boxConteudoTopo">
		<asp:HyperLink ID="hlHome" runat="server" NavigateUrl="~/Default.aspx" class="lnkLogotipo">
			<strong>Sabesp</strong> <em>
				<asp:Literal ID="Literal1" runat="server">A vida tratada com respeito</asp:Literal></em>
		</asp:HyperLink>
		<div class="boxAuxiliar">
			<ul class="lstFuncionalidades">
				<li class="itmIdioma">
					<asp:LinkButton ID="lnkbtIdioma" runat="server" OnClick="lnkbtIdioma_Click" Visible="false" /></li>
				<li class="itmContraste"><a href="#contraste" id="lnkContraste">Contraste</a></li>
				<li class="itmAumentaFonte"><a href="#aumenta" title="Aumenta fonte" id="lnkAumentaFonte">
					Aumenta fonte</a></li>
				<li class="itmDiminuiFonte"><a href="#diminui" title="Diminui fonte" id="lnkDiminuiFonte">
					Diminui fonte</a></li>
			</ul>
			<ul class="lstBotoes">
				<li class="itmAgenciaVirtual">
					<asp:HyperLink ID="hlAgenciaVirtual" runat="server" Text="Agência Virtual" Target="_blank" /></li>
				<li class="itmFornecedores">
					<asp:HyperLink ID="hlFornecedores" runat="server" Text="Fornecedores" /></li>
				<li class="itmInvestidores">
					<asp:HyperLink ID="hlInvestidores" runat="server" Target="_blank" NavigateUrl="http://www.sabesp.com.br/Calandraweb/CalandraRedirect/?temp=0&proj=investidoresnovo&pub=T&db="
						Text="Investidores" /></li>
				<li class="itmFaleConosco">
					<asp:HyperLink ID="hlFaleConosco" runat="server" Text="Fale Conosco" /></li>
			</ul>
			<sabesp:buscaTopo ID="buscaTopo1" runat="server" />
		</div>
	</div>
	<!-- AVISO -->
	<asp:Panel ID="pnlComunicado" runat="server" CssClass="boxAviso">
		<blockquote>
			<asp:Literal ID="ltrComunicado" runat="server" />
		</blockquote>
		<asp:HyperLink ID="hlSaibaMais" runat="server" />
	</asp:Panel>
	<!-- // AVISO -->
	<asp:Panel ID="pnlMenu" runat="server">
		<!-- MENU -->
		<sabesp:menu ID="menu1" runat="server" />
		<!-- // MENU -->
		<!-- SUBMENU -->
		<sabesp:subMenu ID="subMenu1" runat="server" />
		<!-- // SUBMENU -->
	</asp:Panel>

	<script type="text/javascript">
		$(document).ready(function() {
			$('#hlAgenciaVirtual').click(function() {
				try {
					var pageTracker = _gat._getTracker('UA-17790992-1');
					pageTracker._setDomainName('none');
					pageTracker._setAllowLinker(true);
					pageTracker._trackPageview('/Agencia_Virtual');
				} catch (err) { }
			});

			$('#ctl00_topo_hlFornecedores').click(function() {
				try {
					var pageTracker = _gat._getTracker('UA-17790992-1');
					pageTracker._setDomainName('none');
					pageTracker._setAllowLinker(true);
					pageTracker._trackPageview('/Forncedores');
				} catch (err) { }
			});

			$('#hlInvestidores').click(function() {
				try {
					var pageTracker = _gat._getTracker('UA-17790992-1');
					pageTracker._setDomainName('none');
					pageTracker._setAllowLinker(true);
					pageTracker._trackPageview('/Investidores');
				} catch (err) { }
			});

			$('#hlFaleConosco').click(function() {
				try {
					var pageTracker = _gat._getTracker('UA-17790992-1');
					pageTracker._setDomainName('none');
					pageTracker._setAllowLinker(true);
					pageTracker._trackPageview('/Fale_Conosco');
				} catch (err) { }
			});
		});
	</script>

</div>
