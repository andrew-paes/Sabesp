<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="formulario-resposta-erro.aspx.cs" Inherits="interna_resposta_formulario_erro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				FALE CONOSCO</h2>
			<div class="colContentLeft mb">
				<div class="boxFormularios">
					<div class="alertaErro">
						Ocorreu um erro no envio do seu formulário. Por favor verificar.
					</div>
					<div class="txtCenter" style="margin: 20px 0 50px 0;">
						<asp:ImageButton ValidationGroup="form" ID="imgBtnVoltar" CssClass="btnSolicitar button"
							ImageUrl="~/contents/img/btn-voltar.gif" runat="server" OnClientClick="javascript:history.back();return false;" />
						<asp:ImageButton ValidationGroup="form" ID="imgBtnPaginaPrincipal" CssClass="btnSolicitar button"
							ImageUrl="~/contents/img/btn-pagina-principal.gif" runat="server" OnClick="imgBtnPaginaPrincipal_Click" />
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
	<asp:HiddenField ID="hdnExceptionForm" runat="server" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
