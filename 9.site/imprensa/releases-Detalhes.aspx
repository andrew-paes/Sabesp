<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="releases-Detalhes.aspx.cs" Inherits="releases_Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Releases</asp:Literal></h2>
		<div class="colContent">
			<h3 class="sub">
				<asp:Literal ID="ltrTituloRelease" runat="server" /></h3>
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
									<sabesp:releaseGaleriaImagens ID="releaseGaleriaImagens1" runat="server" />
									<div class="newsContent">
										<asp:Literal ID="ltrRelease" runat="server" />
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
		</div>
		<div class="colModules">
			<sabesp:releaseOutrosReleases runat="server" ID="releaseOutrosReleases" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
</asp:Content>
