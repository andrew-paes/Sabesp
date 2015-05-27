<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_etapa2_rgi_endereco_numero.aspx.cs" Inherits="interna_formulario_etapa2_rgi_endereco_numero" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna">
            <h2>FALE CONOSCO</h2>
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <div class="aba">
                        <span>Etapa 1</span> <span class="atv">Etapa 2</span>
                    </div>
                    <div class="clr"><!-- --></div>
                    <div style="font-size:12px; margin-bottom:10px;">R. Costa do Pinheiro</div>
                    <fieldset>
                        <div class="boxCampo">
                            <asp:Label ID="lblNumImovel" AssociatedControlID="NumImovel" runat="server" Text="Número do imóvel"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="NumImovel" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="NumImovel" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o número do imóvel</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="clr"><!-- --></div>					    
					    <div class="boxCampo boxFull">
						    <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-pesquisa.gif" runat="server" />
					    </div>
                    </fieldset>
                    
                    <table>
                        <colgroup>
                            <col style="width:150px;" />
                            <col style="width:270px;" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>Número</th>
                                <th>Complemento</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>00010</td>
                                <td>EXCLUIDO</td>
                            </tr>
                            <tr>
                                <td>00010</td>
                                <td>EXCLUIDO</td>
                            </tr>
                            <tr>
                                <td>00010</td>
                                <td>EXCLUIDO</td>
                            </tr>
                            <tr>
                                <td>00010</td>
                                <td>EXCLUIDO</td>
                            </tr>
                            <tr>
                                <td>00010</td>
                                <td>EXCLUIDO</td>
                            </tr>
                        </tbody>
                    </table>
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

