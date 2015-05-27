<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="resultado-busca.aspx.cs" Inherits="resultado_busca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2 class="ttlBusca">
			<asp:Literal ID="ltrResultadoDaBusca" runat="server" Text="Resultado da busca" /></h2>
		<asp:Panel ID="pnlBusca" runat="server" CssClass="colContent fullWidth busca">
			<h4>
				<asp:Literal ID="ltrResultadosEncontrados" runat="server" Text="Foram encontrados {0} resultados para o termo:" />
				<%--<asp:Literal ID="Literal3" runat="server">resultados para o termo:</asp:Literal>--%>
				<asp:Literal ID="ltrTermoBuscado" runat="server" />
			</h4>
			<div class="colContentLeft">
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<%--<ul class="maisVistosList after">
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong> <span>
										Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices
										lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
									<li class="last"><strong><a href="#">Lorem ipsum dolor sit amet, consectetuer</a></strong>
										<span>Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt
											ultrices lacus. Aliquam vehicula adipiscing leoMorbi.</span> </li>
								</ul>--%>
								<asp:ListView ID="lstConteudos" runat="server" OnItemDataBound="lstConteudos_ItemDataBound"
									OnPagePropertiesChanging="lstConteudos_PagePropertiesChanging">
									<LayoutTemplate>
										<ul class="maisVistosList after">
											<asp:PlaceHolder ID="itemPlaceholder" runat="server" />
										</ul>
									</LayoutTemplate>
									<ItemTemplate>
										<li><strong>
											<asp:HyperLink ID="hlConteudo" runat="server" />
										</strong>
											<asp:Label ID="lblDescricao" runat="server" />
										</li>
									</ItemTemplate>
								</asp:ListView>
								<asp:Panel ID="pnlPaginacao" runat="server" CssClass="paginacao after">
									<asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstConteudos" PageSize="8">
										<Fields>
											<asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btPrev" PreviousPageText=""
												ShowNextPageButton="False" />
											<asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="atv" />
											<asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btNext" ShowPreviousPageButton="False" />
										</Fields>
									</asp:DataPager>
								</asp:Panel>
							</div>
						</div>
					</div>
				</div>
			</div>
		</asp:Panel>
		<asp:Panel ID="pnlBuscaNaoEncontrada" runat="server" CssClass="colContent fullWidth busca buscaNegativo"
			Visible="false">
			<h4 class="txtNotFound">
				<%--<asp:Literal ID="Literal2" runat="server" Text="O termo" />--%>
				<asp:Literal ID="ltrTermoBuscadoNaoEncontrado" runat="server" Text="LOREM IPSUM QUO VADIS" />
				<%--<asp:Literal ID="ltrNaoFoiEncontrado" runat="server" Text="não foi encontrado."/>--%>
			</h4>
			<p>
				<asp:HyperLink ID="hlFacaNovaPesquisa" runat="server" NavigateUrl="~/Default.aspx" />
			</p>
		</asp:Panel>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	</div>

	<script type="text/javascript">
		var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
		document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));

		try {
			var pageTracker = _gat._getTracker('UA-17790992-1');
			pageTracker._setDomainName('none');
			pageTracker._setAllowLinker(true);
			pageTracker._trackPageview('/Realizou_Busca');
		} catch (err) { }
	</script>

</asp:Content>
