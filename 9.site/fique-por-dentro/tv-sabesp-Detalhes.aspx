<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="tv-sabesp-Detalhes.aspx.cs" Inherits="fique_por_dentro_tv_sabesp_Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/swfobject/2.2/swfobject.js"></script>

	<script type="text/javascript" src="<%=ResolveUrl("~/contents/js/tv-sabesp.js") %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">TV SABESP</asp:Literal></h2>
		<div class="colContent">
			<h3 class="sub">
				<asp:Literal ID="ltrTitulo" runat="server" />
			</h3>
			<div class="boxWhite bwHeaderBottom">
				<div class="bgrTop">
					<div class="bgrBottom">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft boxNewsDetalhe">
									<div class="header after">
										<asp:Label ID="lblAutor" runat="server" CssClass="autor" />&nbsp;<asp:Label ID="lblData"
											runat="server" CssClass="data" />
									</div>
									<div class="galeria">
										<asp:Literal ID="ltrVideo" runat="server" />
									</div>
									<div class="newsContent">
										<asp:Literal ID="ltrDescricao" runat="server" />
									</div>
									<div class="tagsContent">
										<sabesp:tags ID="tags1" runat="server" />
									</div>
									<sabesp:conteudoAvaliacao ID="conteudoAvaliacao" runat="server" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<br />
			<br />
			<sabesp:conteudoRelacionado runat="server" ID="conteudoRelacionado1" />
		</div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
			<sabesp:videoMaisVistos runat="server" ID="videoMaisVistos" />
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
