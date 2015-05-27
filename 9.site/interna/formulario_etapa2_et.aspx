<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_etapa2_et.aspx.cs" Inherits="interna_formulario_etapa2_et" Title="Untitled Page" %>

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
                        <fieldset>
                            <div class="boxCampo">
                                <asp:Label ID="lblCep" AssociatedControlID="Cep" runat="server" Text="CEP"></asp:Label>
						        <asp:TextBox ValidationGroup="form" ID="Cep" runat="server"></asp:TextBox>
						        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Cep" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o CEP</div></asp:RequiredFieldValidator>
                                <a href="javascript:;">Encontre o seu CEP</a>
                            </div>
                            <div class="boxCampo">
                                <asp:Label ID="lblEndereco" AssociatedControlID="Endereco" runat="server" Text="Endereço"></asp:Label>
						        <asp:TextBox ValidationGroup="form" ID="Endereco" runat="server"></asp:TextBox>
						        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Cep" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator1" runat="server"><div>Informe o Endereço</div></asp:RequiredFieldValidator>
                            </div>
                            <div class="clr"><!-- --></div>
                            <div class="boxCampo">
                                <asp:Label ID="lblNumero" AssociatedControlID="Numero" runat="server" Text="Número"></asp:Label>
						        <asp:TextBox ValidationGroup="form" ID="Numero" runat="server"></asp:TextBox>
						        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Numero" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator2" runat="server"><div>Informe o Número</div></asp:RequiredFieldValidator>
                            </div>
                            <div class="boxCampo">
                                <asp:Label ID="lblComplemento" AssociatedControlID="Complemento" runat="server" Text="Complemento"></asp:Label>
						        <asp:TextBox ValidationGroup="form" ID="Complemento" runat="server"></asp:TextBox>
						        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Numero" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator3" runat="server"><div>Informe o Complemento</div></asp:RequiredFieldValidator>
                            </div>
                            <div class="boxCampo">
                                <asp:Label ID="lblBairro" AssociatedControlID="Bairro" runat="server" Text="Bairro"></asp:Label>
						        <asp:TextBox ValidationGroup="form" ID="Bairro" runat="server"></asp:TextBox>
						        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Bairro" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator4" runat="server"><div>Informe o Bairro</div></asp:RequiredFieldValidator>
                            </div>
                            <div class="clr"><!-- --></div>
                            <div class="boxCampo">
							    <asp:Label ID="lblEstado" AssociatedControlID="Estado" runat="server" Text="Estado"></asp:Label>
							    <asp:DropDownList ValidationGroup="form" ID="Estado" runat="server">
								    <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
								    <asp:ListItem Text="SP" Value="sp"></asp:ListItem>
							    </asp:DropDownList>
							    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Estado" Display="Dynamic" CssClass="errorMessage" ID="reqEstado" runat="server"><div>Informe o Estado</div></asp:RequiredFieldValidator>
						    </div>
						    <div class="boxCampo">
							    <asp:Label ID="lblCidade" AssociatedControlID="Cidade" runat="server" Text="Cidade"></asp:Label>
							    <asp:DropDownList ValidationGroup="form" ID="Cidade" runat="server">
								    <asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
								    <asp:ListItem Text="São Paulo" Value="sp"></asp:ListItem>
							    </asp:DropDownList>
							    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Cidade" Display="Dynamic" CssClass="errorMessage" ID="reqCidade" runat="server"><div>Informe o Cidade</div></asp:RequiredFieldValidator>
						    </div>
						    <div class="clr"><!-- --></div>					    
					        <div class="boxCampo boxFull">
						        <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-continuar.gif" runat="server" />
					            <asp:ImageButton ValidationGroup="form" ID="ImageButton1" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-cancelar.gif" runat="server" />
					        </div>
                        </fieldset>
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

