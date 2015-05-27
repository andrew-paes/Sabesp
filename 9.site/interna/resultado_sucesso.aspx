<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="resultado_sucesso.aspx.cs" Inherits="interna_resultado_sucesso" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna sucesso">
            <h2>Fale Conosco</h2>
            <div class="boxSucesso">
                Sua solicitação foi encaminhada à área responsável.
            </div>
            <div class="boxCampo boxFull boxBotoes" style="margin-top:10px;">
			    <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-voltar.gif" runat="server" />
			    <asp:ImageButton ValidationGroup="form" ID="ImageButton1" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-pagina-principal.gif" runat="server" />
		    </div>
        </div>
    </div>
    <div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

