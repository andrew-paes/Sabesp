<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="produtos_Servicos_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTituloProdutosServicos" runat="server" Text="Produtos e serviços" />
		</h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<h3 class="boxTitulo">
					<asp:Literal ID="ltrTituloGrandesEmpresas" runat="server" Text="Para grandes empresas" />
				</h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:produtoDestaqueGrande ID="produtoDestaqueGrande1" runat="server" />
								<div class="newsListContent produtosServicos">
									<sabesp:produtoDestaqueLista ID="produtoDestaqueLista1" runat="server" />
									<asp:HyperLink CssClass="lnkFundoGradiente" ID="hlTodosProdutos1" NavigateUrl="#"
										runat="server" />
								</div>
							</div>
						</div>
					</div>
				</div>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltrTituloCondominios" runat="server" Text="Para condomínios residenciais e comerciais" /></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsListContent produtosServicos" style="padding-top: 0">
									<sabesp:produtoDestaqueLista ID="produtoDestaqueLista2" runat="server" />
									<asp:HyperLink CssClass="lnkFundoGradiente" ID="hlTodosProdutos2" NavigateUrl="#"
										runat="server" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<div class="boxDivider">
					<div class="boxWhite boxConsultoria">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<h3>
										<asp:Literal ID="ltrTituloConsultorias" runat="server" Text="Consultorias" />
									</h3>
									<%--<asp:Image ID="Image4" ImageUrl="~/contents/img/FAKE_coleta.jpg" runat="server" />--%>
									<sabesp:produtoLista ID="produtoLista1" runat="server" />
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
				</div>
				<div class="clr">
					<!-- -->
				</div>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltrSolucoesMunicipios" runat="server" Text="Soluções para municípios e estados" />
				</h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:produtoDestaqueGrande ID="produtoDestaqueGrande2" runat="server" ImageWidth="384"
									ImageHeight="257" />
								<div class="newsListContent produtosServicos">
									<sabesp:produtoDestaqueLista ID="produtoDestaqueLista3" runat="server" />
								</div>
								<asp:HyperLink CssClass="lnkFundoGradiente" ID="hlTodosProdutos3" NavigateUrl="#"
									runat="server" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
