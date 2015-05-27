<%@ Control Language="C#" AutoEventWireup="true" CodeFile="rodape.ascx.cs" Inherits="controls_rodape" %>
<div class="boxRodape">
	<div class="topRow">
	    <div class="boxDivider" style="width: 192px; float: left; margin-left:120px; margin-top:-50px;">
			<asp:HyperLink ID="clubinhoSabesp" Target="_blank" NavigateUrl="http://www.clubinhosabesp.com.br/"
				ToolTip="Clubinho Sabesp" runat="server">
				<asp:Image ID="imgClubinhoSabesp" AlternateText="Clubinho Sabesp" ImageUrl="~/contents/img/img-clubinho-sabesp.gif"
					runat="server" />
			</asp:HyperLink>
		</div>
		<div class="boxProjetos">
			<h2>
				<asp:Literal ID="ltrPessoasTrabalhando" runat="server" Text="Pessoas Trabalhando" /></h2>
			<asp:Label ID="lblConhecaProjetos" runat="server" Text="Conheça os projetos que a Sabesp está fazendo agora" />
			<div class="boxCarrossel" id="boxCarrossel">
				<ul>
					<li>
						<asp:HyperLink ID="hypOndaLimpa" NavigateUrl="http://www.ondalimpa.com.br/" Target="_blank"
							runat="server" CssClass="onda-limpa" ToolTip="Programa Onda Limpa">Programa Onda Limpa</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="hypCorregoLimpo" NavigateUrl="http://www.corregolimpo.com.br/"
							Target="_blank" runat="server" CssClass="corrego-limpo" ToolTip="Córrego Limpo">Córrego Limpo</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="hypParqueVarzeas" NavigateUrl="http://www.parquevarzeasdotiete.com.br/"
							Target="_blank" runat="server" CssClass="parque-varzeas-tiete" ToolTip="Parque Várzeas do Tietê">Parque Várzeas do Tietê</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="hypVidaNova" NavigateUrl="http://vidanova.sabesp.com.br/" Target="_blank"
							runat="server" CssClass="programa-vida-nova" ToolTip="Programa Vida Nova">Programa Vida Nova</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="hypProjetoTiete" NavigateUrl="http://www2.sabesp.com.br/projetotiete/"
							Target="_blank" runat="server" CssClass="projeto-tiete" ToolTip="Projeto Tietê"
							Text="Projeto Tietê">Projeto Tietê</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink1" NavigateUrl="http://www.ondalimpa.com.br/" Target="_blank"
							runat="server" CssClass="onda-limpa" ToolTip="Programa Onda Limpa">Programa Onda Limpa</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink2" NavigateUrl="http://www.corregolimpo.com.br/" Target="_blank"
							runat="server" CssClass="corrego-limpo" ToolTip="Córrego Limpo">Córrego Limpo</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink3" NavigateUrl="http://www.parquevarzeasdotiete.com.br/"
							Target="_blank" runat="server" CssClass="parque-varzeas-tiete" ToolTip="Parque Várzeas do Tietê">Parque Várzeas do Tietê</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink4" NavigateUrl="http://www.sabesp.com.br/vidanova" Target="_blank"
							runat="server" CssClass="programa-vida-nova" ToolTip="Programa Vida Nova">Programa Vida Nova</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink5" NavigateUrl="http://www2.sabesp.com.br/projetotiete/"
							Target="_blank" runat="server" CssClass="projeto-tiete" ToolTip="Projeto Tietê"
							Text="Projeto Tietê">Projeto Tietê</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink6" NavigateUrl="http://www.ondalimpa.com.br/" Target="_blank"
							runat="server" CssClass="onda-limpa" ToolTip="Programa Onda Limpa">Programa Onda Limpa</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink7" NavigateUrl="http://www.corregolimpo.com.br/" Target="_blank"
							runat="server" CssClass="corrego-limpo" ToolTip="Córrego Limpo">Córrego Limpo</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink8" NavigateUrl="http://www.parquevarzeasdotiete.com.br/"
							Target="_blank" runat="server" CssClass="parque-varzeas-tiete" ToolTip="Parque Várzeas do Tietê">Parque Várzeas do Tietê</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink9" NavigateUrl="http://www.sabesp.com.br/vidanova" Target="_blank"
							runat="server" CssClass="programa-vida-nova" ToolTip="Programa Vida Nova">Programa Vida Nova</asp:HyperLink>
					</li>
					<li>
						<asp:HyperLink ID="HyperLink10" NavigateUrl="http://www2.sabesp.com.br/projetotiete/"
							Target="_blank" runat="server" CssClass="projeto-tiete" ToolTip="Projeto Tietê"
							Text="Projeto Tietê">Projeto Tietê</asp:HyperLink>
					</li>
				</ul>
			</div>
		</div>
		<div class="boxTempoNavegacao">
			<sabesp:numerosBar ID="numerosBar1" runat="server" />
		</div>
	</div>
	<div class="boxExploreSite">
		<h3>
			<asp:Literal ID="ltrExploreSiteSabesp" runat="server" Text="Explore o site da Sabesp" /></h3>
		<div class="boxItens">
			<sabesp:menuRodape ID="menuRodape4" runat="server" CssClass="boxFiquePorDentro" TipoMenuPrincipal="FiquePorDentro" />
			<sabesp:menuRodape ID="menuRodape3" runat="server" CssClass="boxProdutosServicos"
				TipoMenuPrincipal="ProdutosEServicos" />
			<sabesp:menuRodape ID="menuRodape2" runat="server" CssClass="boxSaneamentoBasico"
				TipoMenuPrincipal="Saneamento" />
			<div class="clr">
				<!-- -->
			</div>
			<sabesp:menuRodape ID="menuRodape5" runat="server" CssClass="boxAgenciaVirtual" TipoMenuPrincipal="AgenciaVirtual" />
			<sabesp:menuRodape ID="menuRodape6" runat="server" CssClass="boxSustentabilidade"
				TipoMenuPrincipal="SociedadeEMeioAmbiente" />
			<sabesp:menuRodape ID="menuRodape1" runat="server" CssClass="boxASabesp" TipoMenuPrincipal="ASabesp" />
		</div>
		<div class="boxLinksDireita">
			<h4 class="rss">
				<asp:HyperLink ID="hlRSS" runat="server" NavigateUrl="~/rss/Default.aspx" Text="RSS" /></h4>
			<h4>
				<asp:Literal ID="ltrSobreSabesp" runat="server" Text="Sobre a Sabesp" /></h4>
			<ul>
				<li class="last">
					<asp:HyperLink ID="hlFaleComPresidente" runat="server" Target="_blank" NavigateUrl="http://www2.sabesp.com.br/agvirtual2/asp/ouvidoria.asp"
						Text="Ouvidoria" /></li>
				<%--<li>
							<asp:HyperLink ID="hlTermosUso" runat="server" NavigateUrl="#" Text="Termos de Uso" /></li>
				<li class="last">
					<asp:HyperLink ID="hlPoliticaPrivacidade" runat="server" NavigateUrl="#" Text="Política de Privacidade" /></li>
					--%>
			</ul>
			<h4 style="padding-top:5px;">
				<asp:Literal ID="ltrAjuda"  runat="server" Text="Ajuda?" /></h4>
			<ul>
				<li>
					<asp:HyperLink ID="hlFAQ" runat="server" Text="Perguntas Frequentes" /></li>
				<li class="last">
					<asp:HyperLink ID="lnkContraste" runat="server" NavigateUrl="#contraste" Text="Contraste" /></li>
				<%--<li><a href="~/rss/" runat="server" class="btnRss">RSS</a></li>
								<li>
					<asp:HyperLink ID="hlLibras" runat="server" NavigateUrl="#" Text="Libras" /></li>
				<li>
					<asp:HyperLink ID="hlBraile" runat="server" NavigateUrl="#" Text="Braile" /></li>--%>
			</ul>
			<div>
				<asp:HyperLink ID="hlSabesp" runat="server" CssClass="lnkSabesp" NavigateUrl="http://www.sabesp.com.br"
					title="Sabesp" Text="Sabesp" />
				<asp:HyperLink ID="hlGoverno" runat="server" CssClass="lnkGovernoSP" NavigateUrl="http://www.saopaulo.sp.gov.br"
					Target="_blank" Text="Governo do Estado de São Paulo" />
			</div>
		</div>
		<div class="clr">
			<!-- -->
		</div>
	</div>
</div>

<script type="text/javascript">
	$(document).ready(function() {
		$('#ctl00_rodape_hypOndaLimpa').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Onda_Limpa");
		});

		$('#ctl00_rodape_hypCorregoLimpo').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Corrego_Limpo");
		});

		$('#ctl00_rodape_hypParqueVarzeas').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Parque_das_Varzeas");
		});

		$('#ctl00_rodape_hypVidaNova').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Vida_Nova");
		});

		$('#ctl00_rodape_hypProjetoTiete').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Projeto_Tiete");
		});

		$('#ctl00_rodape_HyperLink1').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Onda_Limpa");
		});

		$('#ctl00_rodape_HyperLink2').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Corrego_Limpo");
		});

		$('#ctl00_rodape_HyperLink3').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Parque_das_Varzeas");
		});

		$('#ctl00_rodape_HyperLink4').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Vida_Nova");
		});

		$('#ctl00_rodape_HyperLink5').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Projeto_Tiete");
		});

		$('#ctl00_rodape_HyperLink6').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Onda_Limpa");
		});

		$('#ctl00_rodape_HyperLink7').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Corrego_Limpo");
		});

		$('#ctl00_rodape_HyperLink8').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Parque_das_Varzeas");
		});

		$('#ctl00_rodape_HyperLink9').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Vida_Nova");
		});

		$('#ctl00_rodape_HyperLink10').click(function() {
			CadastraGA("/Projetos/Clicou_em_Projetos/Projeto_Tiete");
		});
	});

	function CadastraGA(pathGA) {
		try {
			var pageTracker = _gat._getTracker('UA-17790992-1');
			pageTracker._setDomainName('none');
			pageTracker._setAllowLinker(true);
			pageTracker._trackPageview(pathGA);
		} catch (err) { }
	}
</script>

