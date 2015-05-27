<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="banco-de-audio-Default.aspx.cs" Inherits="banco_de_audio_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTitulo" runat="server" Text="Banco de Áudio" /></h2>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<sabesp:bancoAudioDestaqueGrande ID="bancoAudioDestaqueGrande1" runat="server" />
								</div>
								<div class="newsListContent">
									<sabesp:bancoAudioDestaqueLista ID="bancoAudioDestaqueLista1" runat="server" />
									<asp:HyperLink ID="hlTodosbancoAudio" runat="server" CssClass="lnkFundoGradiente" />
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<%--coluna direita--%>
			<div class="colContentRight">
				<sabesp:bancoAudioMaisVistos runat="server" ID="bancoAudioMaisVistos" />
			</div>
		</div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
