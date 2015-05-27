<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_etapa2_rgi_endereco.aspx.cs" Inherits="interna_formulario_etapa2_rgi_endereco" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna">
            <h2>Abertura - Etapa 2</h2>
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <div class="aba">
                        <span>Etapa 1</span> <span class="atv">Etapa 2</span>
                    </div>
                    <div class="clr"><!-- --></div>
                    <fieldset>
                        <div class="boxCampo">
                            <asp:Label ID="lblLogradoura" AssociatedControlID="Logradoura" runat="server" Text="Digite o Logradoura"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Logradoura" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Logradoura" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o Logradoura </div></asp:RequiredFieldValidator>
						    (Ex.: para Av. Paulista, digitar apenas Paulista e para Av. Barão de Mauá, digitar apenas Maua)
                        </div>
                        <div class="clr"><!-- --></div>					    
					    <div class="boxCampo boxFull" style="margin-top:0;">
						    <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn_nova_pesquisa.gif" runat="server" />
					    </div>
                    </fieldset>
                    
                    <table>
                        <colgroup>
                            <col style="width:105px;" />
                            <col style="width:270px;" />
                            <col style="width:220px;" />
                        </colgroup>
                        <thead>
                            <tr>
                                <th>Código</th>
                                <th>Endereço</th>
                                <th>Bairro</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
                            </tr>
                            <tr>
                                <td>0000005428</td>
                                <td>R. Costa Carvalho</td>
                                <td>Pinheiros</td>
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

