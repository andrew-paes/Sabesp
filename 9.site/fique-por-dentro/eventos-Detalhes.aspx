<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="eventos-Detalhes.aspx.cs" Inherits="eventos_Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
	<link rel="stylesheet" href="../contents/css/fancybox/jquery.fancybox-1.3.1.css"
		type="text/css" media="screen">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">EVENTOS</asp:Literal></h2>
		<div class="colContent">
			<h3 class="sub">
				<asp:Literal ID="ltrTituloEvento" runat="server" /></h3>
			<div class="boxWhite bwHeaderBottom">
				<div class="bgrTop">
					<div class="bgrBottom">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft boxNewsDetalhe">
									<div class="header after">
										<asp:Label ID="lblLocal" runat="server" CssClass="autor" />&nbsp;<asp:Label ID="lblData"
											runat="server" CssClass="data" />
									</div>
									<div class="newsContent">
										<asp:Literal ID="ltrEvento" runat="server" />
									</div>
									<sabesp:eventoGaleriaImagens ID="eventoGaleriaImagens1" runat="server" />
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
			<sabesp:eventoMaisVistos runat="server" ID="eventoMaisVistos" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:twitter runat="server" ID="twitter" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
		<sabesp:boxAzulDir runat="server" ID="sabespEnsina" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">

	<script src="../contents/css/fancybox/jquery.fancybox-1.3.1.js" type="text/javascript"></script>

	<script type="text/javascript">
    $(".galeriaList li a").fancybox({
        margin:0,
        padding:10,
        overlayOpacity:0.8,
        overlayColor:'#000',
        titlePosition:'inside'

    });
	</script>

</asp:Content>