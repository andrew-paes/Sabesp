<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_abertura_etapa1.aspx.cs" Inherits="interna_formulario_abertura_etapa1" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna">
            <h2>FALE CONOSCO</h2>
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <div class="aba">
                        <span class="atv">Etapa 1</span> <span>Etapa 2</span>
                    </div>
                    <div class="clr"><!-- --></div>
                    <fieldset>
                        <div class="boxCampo">
							<asp:Label ID="lblAssunto" AssociatedControlID="Assunto" runat="server" Text="Assunto"></asp:Label>
							<asp:DropDownList ValidationGroup="form" ID="Assunto" runat="server">
								<asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
								<asp:ListItem Text="a" Value="a"></asp:ListItem>
								<asp:ListItem Text="b" Value="b"></asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Assunto" Display="Dynamic" CssClass="errorMessage" ID="reqEstado" runat="server"><div>Informe o Assunto</div></asp:RequiredFieldValidator>
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblComentarios" AssociatedControlID="Comentarios" runat="server" Text="Comentários"></asp:Label>
							<asp:DropDownList ValidationGroup="form" ID="Comentarios" runat="server">
								<asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
								<asp:ListItem Text="a" Value="a"></asp:ListItem>
								<asp:ListItem Text="b" Value="b"></asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Comentarios" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator1" runat="server"><div>Informe o Comentários</div></asp:RequiredFieldValidator>
						</div>
                        <div class="boxCampo">
                            <asp:Label ID="lblNome" AssociatedControlID="Nome" runat="server" Text="Nome"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Nome" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Nome" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o Nome</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblRgRne" AssociatedControlID="RgRne" runat="server" Text="RG/RNE"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="RgRne" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="RgRne" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator2" runat="server"><div>Informe o RG/RNE</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblCpf" AssociatedControlID="Cpf" runat="server" Text="CPF"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Cpf" runat="server"></asp:TextBox>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblCnpj" AssociatedControlID="Cnpj" runat="server" Text="CNPJ"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Cnpj" runat="server"></asp:TextBox>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblEmpresa" AssociatedControlID="Empresa" runat="server" Text="Empresa"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Empresa" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Empresa" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator3" runat="server"><div>Informe o Empresa</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblEmail" AssociatedControlID="Email" runat="server" Text="E-mail"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Email" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Email" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator4" runat="server"><div>Informe o E-mail</div></asp:RequiredFieldValidator>
                        </div>
                        <div class="boxCampo">
                            <asp:Label ID="lblTelefone" AssociatedControlID="Telefone" runat="server" Text="Telefone"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Telefone" CssClass="inpTelefone" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Telefone" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator6" runat="server"><div>Informe o Telefone</div></asp:RequiredFieldValidator>
                        </div>
                        
                        <div class="clr"><!-- --></div>
					    <div class="boxCampo boxTextarea">
					        <asp:Label ID="lblTexto" AssociatedControlID="Texto" runat="server" Text="Texto"></asp:Label>
						    <asp:TextBox ValidationGroup="form" TextMode="MultiLine" ID="Texto" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Telefone" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator5" runat="server"><div>Informe o Texto</div></asp:RequiredFieldValidator>
					    </div>
					    
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

