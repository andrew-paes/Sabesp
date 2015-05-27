<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario-resposta-confirmacao.aspx.cs" Inherits="interna_formulario_resposta_confirmacao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>FALE CONOSCO</h2>
			<div class="colContentLeft mb">
				<div class="boxFormularios">
					<div class="alertaConfirmacao">
						Sua solicitação foi encaminhada à área responsável.
					</div>
					<div class="txtCenter" style="margin:20px 0 50px 0;">
						<asp:ImageButton ValidationGroup="form" ID="imgBtnVoltar" 
							CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-voltar.gif" 
							runat="server" OnClientClick="javascript:history.back();return false;" />
						<asp:ImageButton ValidationGroup="form" ID="imgBtnPaginaPrincipal" 
							CssClass="btnSolicitar button" 
							ImageUrl="~/contents/img/btn-pagina-principal.gif" runat="server" 
							onclick="imgBtnPaginaPrincipal_Click" />
					</div>
				</div>

			</div>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

