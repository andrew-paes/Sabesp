<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="tv-sabesp-Default.aspx.cs" Inherits="tv_sabesp_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">  
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js" ></script>
    <script type="text/javascript" src="<%=ResolveUrl("~/contents/js/tv-sabesp.js") %>" ></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h3 class="boxTitulo ttlTVSabesp"><asp:Literal ID="Literal1" runat="server">TV Sabesp</asp:Literal></h3>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
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
			</div>
			<%--coluna direita--%>
			<div class="colContentRight">
			    <sabesp:videoMaisVistos runat="server" ID="videoMaisVistos" />				
			</div>
		</div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
			<sabesp:videoUltimasObras runat="server" ID="videoUltimasObras" />
		</div>
	</div>
	<div class="colRight">
	    <%--<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:twitter runat="server" ID="twitter" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
