<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_consulta_fale_conosco.aspx.cs" Inherits="interna_formulario_consulta_fale_conosoc" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna sucesso">
            <h2>Fale Conosco</h2>
            
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <div class="aba">
                        <span>Etapa 1</span> <span class="atv">Etapa 2</span>
                    </div>
                    <div class="clr"><!-- --></div>
                    <fieldset>
                        <div class="boxCampo">
                            <asp:Label ID="lblNumero" AssociatedControlID="Numero" runat="server" Text="N° Fale Conosco"></asp:Label>
					        <asp:TextBox ValidationGroup="form" ID="Numero" runat="server"></asp:TextBox>
					        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Numero" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o N° Fale Conosco</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="boxCampo" style="postion:relative; z-index:1;">
                            <asp:Label ID="lblCpf" AssociatedControlID="Cpf" runat="server" Text="CPF / RG / RNE / CNPJ"></asp:Label>
					        <asp:TextBox ValidationGroup="form" ID="Cpf" runat="server"></asp:TextBox>
                            <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" style="width:auto !important; position:absolute;" ImageUrl="~/contents/img/btn-pesquisa.gif" runat="server" />
					        <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Cpf" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator1" runat="server"><div>Informe o CPF / RG / RNE / CNPJ</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="clr"><!-- --></div>					    
				        <div class="boxCampo boxFull">
				            <asp:ImageButton ValidationGroup="form" ID="ImageButton1" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn-cancelar.gif" runat="server" />
				        </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

