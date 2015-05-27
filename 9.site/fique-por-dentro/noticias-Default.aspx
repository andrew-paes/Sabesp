<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="noticias-Default.aspx.cs" Inherits="noticias_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Notícias</asp:Literal></h2>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:noticiaDestaqueGrande ID="noticiaDestaqueGrande1" runat="server" />
								<div class="newsListContent">
									<sabesp:noticiaDestaqueLista ID="noticiaDestaqueLista1" runat="server" />
									<asp:HyperLink ID="hlTodasNoticias" runat="server" CssClass="lnkFundoGradiente" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<%--coluna direita--%>
			<div class="colContentRight">
				<sabesp:noticiaMaisVistos runat="server" ID="noticiaMaisVistos" />
				<br />
				<div class="boxMaisVistos">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<h3>
								<asp:Literal ID="ltrMaisVistos" runat="server" Text="Veja Também" /></h3>
							<ul class="maisVistosList after">
								<li id="li" runat="server" class="last">
									<asp:HyperLink ID="hlNoticia" NavigateUrl="http://www.sabesp.com.br/CalandraWeb/CalandraRedirect/?temp=0&proj=AgenciaNoticias&pub=T&db=" Target="_blank" runat="server">
										<asp:Label ID="lblChamada" runat="server" Text="No novo site você encontra as notícias mais recentes.
Para acessar o acervo com as mais antigas, clique aqui." />
									</asp:HyperLink></li></ul></div></div></div></div></div><div class="colModules">
		<sabesp:boxZebrado runat="server" ID="boxZebrado" />
		<sabesp:numerosBox ID="numerosBox1" runat="server" />
		<div class="boxMaisVistosB">
			<div class="boxMaisVistosC">
				<sabesp:noticiaUltimasNoticias ID="noticiaUltimasNoticias" runat="server" />
			</div>
		</div>
	</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%> <sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
