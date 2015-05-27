<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="resultado_consulta_finalizado.aspx.cs" Inherits="interna_resultado_consulta_finalizado" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna">
            <h2>Consultar Fale Conosco</h2>
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <fieldset>
					    <div class="boxCampo boxTextarea">
					        <asp:Label ID="lblCliente" AssociatedControlID="Cliente" runat="server" Text="Manifestação do Cliente"></asp:Label>
						    <asp:TextBox ValidationGroup="form" TextMode="MultiLine" Text="Texto" ID="Cliente" runat="server"></asp:TextBox>
					    </div>
					    <div class="boxCampo boxTextarea">
					        <asp:Label ID="lblResposta" AssociatedControlID="Resposta" runat="server" Text="Resposta"></asp:Label>
						    <asp:TextBox ValidationGroup="form" TextMode="MultiLine" Text="Texto" ID="Resposta" runat="server"></asp:TextBox>
					    </div>
                    </fieldset>
                    <div class="boxCampo boxFull" style="margin-top:10px;">
			            <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-voltar.gif" runat="server" />
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

