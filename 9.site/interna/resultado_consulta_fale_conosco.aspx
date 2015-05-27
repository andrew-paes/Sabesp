<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="resultado_consulta_fale_conosco.aspx.cs" Inherits="interna_resultado_consulta_fale_conosoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna sucesso">
            <table>
                <colgroup>
                    <col style="width:210px;" />
                    <col style="width:210px;" />
                    <col style="width:210px;" />
                </colgroup>
                <thead>
                    <tr>
                        <th>Nº FC</th>       
                        <th>Assunto</th>   
                        <th>Status</th> 
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td>1601-20</td>
                        <td>Assunto Gláucia</td>
                        <td>Aguardando Análise</td>
                    </tr>
                </tbody>
            </table>
			    
		    <div class="boxCampo boxFull" style="margin-top:10px;">
			    <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-voltar.gif" runat="server" />
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