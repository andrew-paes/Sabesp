<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="fique_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js"></script>

	<script type="text/javascript" src="<%=ResolveUrl("~/contents/js/tv-sabesp.js") %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Fique por dentro</asp:Literal></h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<h3 class="boxTitulo ttlNoticias">
					<asp:Literal ID="Literal2" runat="server">Notícias</asp:Literal></h3>
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
				<div class="boxDivider">
					<div class="boxMaisVistosB ultimasNoticias">
						<div class="boxMaisVistosC">
							<sabesp:noticiaUltimasNoticias ID="noticiaUltimasNoticias" runat="server" />
							<div class="footer">
								<!-- -->
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<sabesp:comunicados ID="Comunicados" runat="server" />
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
				</div>
				<div class="clr">
					<!-- -->
				</div>
				<h3 class="boxTitulo ttlTVSabesp">
					<asp:Literal ID="Literal4" runat="server">TV Sabesp</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:videoDestaqueGrande ID="videoDestaqueGrande1" runat="server" />
								<div class="newsListContent">
									<sabesp:videoDestaqueLista ID="videoDestaqueLista1" runat="server" />
									<asp:HyperLink ID="hlTodosVideos" runat="server" CssClass="lnkFundoGradiente" />
								</div>
							</div>
						</div>
					</div>
                   
				</div>
                <sabesp:podcastMaisRecentes ID="podcastMaisRecentes" runat="server" />
			</div>
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:twitter runat="server" ID="twitter" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
