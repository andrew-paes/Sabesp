<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="produto.aspx.cs" Inherits="produtos_e_servicos_produto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTituloSecao" runat="server" Text="Água de reúso" /></h2>
		<div class="colContent">
			<div class="boxWhite bwHeader">
				<div class="bgrBottom">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft bgNone">
								<div class="header after">
									<asp:Literal ID="ltrTituloProduto" runat="server" />
								</div>
								<asp:Image ID="imgProduto" ImageUrl="~/contents/img/FAKE_transparencia.jpg" Width="340"
									Height="180" runat="server" CssClass="fl" />
								<div class="blocoTextoMed fl">
									<asp:Literal ID="ltrTextoProduto" runat="server" />
									<br />
									<br />
									<asp:HyperLink ID="hlConheca" runat="server" class="btn-contrate" Text="Conheça"
										NavigateUrl="~/fale-conosco/Default.aspx?secaoId=71" />
								</div>
								<br class="clr" />
								<sabesp:galeriaProduto ID="galeriaProduto1" runat="server" />
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq" />
			<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq1" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:twitter ID="twitter1" runat="server" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
