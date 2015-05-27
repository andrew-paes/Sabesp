<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="banco-de-audio-Detalhes.aspx.cs" Inherits="banco_de_audio_Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTitulo" runat="server" Text="Banco de Áudio" /></h2>
		<div class="colContent">
			<h3 class="sub">
				<asp:Literal ID="ltrTituloPodcast" runat="server" />
			</h3>
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
										<asp:Literal ID="ltrPodcast" runat="server" />
									</div>
									<div class="podCastPlayer">
										<object id="podCastPlayer" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="445"
											height="55">
											<param name="movie" value="<%=urlFlash %>" />
											<param name="wmode" value="transparent" />
											<!--[if !IE]>-->
											<object type="application/x-shockwave-flash" data="<%=urlFlash %>"
												width="445" height="55">
												<param name="wmode" value="transparent" />
												<!--<![endif]-->
												<p>
													FLASH não instalado</p>
												<!--[if !IE]>-->
											</object>
											<!--<![endif]-->
										</object>
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
			<sabesp:bancoAudioMaisVistos runat="server" ID="bancoAudioMaisVistos" />
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
