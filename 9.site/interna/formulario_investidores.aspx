﻿<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="formulario_investidores.aspx.cs" Inherits="interna_formulario_investidores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				Investidores</h2>
			<div class="colContentLeft">
				<div class="boxFormularios">
					<p>
						Preencha o formulário abaixo para receber informações sobre a Sabesp</p>
					<fieldset>
						<legend>Investidores</legend>
						<div class="boxCampo" style="background-color: #FF0000;">
							<asp:Literal ID="ltrMensagem" runat="server" Visible="false"></asp:Literal>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblNome" AssociatedControlID="txtNome" runat="server" Text="Nome"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtNome" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtNome" Display="Dynamic"
								CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o Nome</div></asp:RequiredFieldValidator>
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblEmail" AssociatedControlID="txtEmail" runat="server" Text="E-mail"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtEmail" runat="server"></asp:TextBox>
							<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Deve ser um e-mail válido!"
								ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail"
								Display="Dynamic"></asp:RegularExpressionValidator>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtEmail" Display="Dynamic"
								CssClass="errorMessage" ID="reqEmail" runat="server"><div>Informe o E-mail</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblCompanhia" AssociatedControlID="txtCompanhia" runat="server" Text="Companhia"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtCompanhia" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtCompanhia"
								Display="Dynamic" CssClass="errorMessage" ID="reqCompanhia" runat="server"><div>Informe a Companhia</div></asp:RequiredFieldValidator>
						</div>
						<div class="boxCampo boxQualificacao">
							<asp:Label ID="lblQualificacao" AssociatedControlID="ddlQualificacao" runat="server"
								Text="Qualificação"></asp:Label>
							<asp:DropDownList ValidationGroup="form" ID="ddlQualificacao" runat="server">
							</asp:DropDownList>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="ddlQualificacao"
								Display="Dynamic" CssClass="errorMessage" ID="reqQualificacao" runat="server"><div>Informe a Qualificação</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblCargo" AssociatedControlID="txtCargo" runat="server" Text="Cargo/Posição"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtCargo" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtCargo" Display="Dynamic"
								CssClass="errorMessage" ID="reqCargo" runat="server"><div>Informe o Cargo/Posição</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblProfissao" AssociatedControlID="txtProfissao" runat="server" Text="Profissão"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtProfissao" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtProfissao"
								Display="Dynamic" CssClass="errorMessage" ID="reqProfissao" runat="server"><div>Informe a Profissão</div></asp:RequiredFieldValidator>
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblInstituicao" AssociatedControlID="txtInstituicao" runat="server"
								Text="Instituição/Empresa"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtInstituicao" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtInstituicao"
								Display="Dynamic" CssClass="errorMessage" ID="reqInstituicao" runat="server"><div>Informe a Instituição/Empresa</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo boxCEP">
							<asp:Label ID="lblCEP" AssociatedControlID="txtCep" runat="server" Text="CEP"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtCep" CssClass="fldCEP" runat="server"></asp:TextBox>
							<asp:HyperLink ID="HyperLink1" NavigateUrl="#" Text="Não sei meu CEP" runat="server" Visible="false"></asp:HyperLink>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtCep" Display="Dynamic"
								CssClass="errorMessage" ID="reqCep" runat="server"><div>Informe o CEP</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<div class="boxEstado">
								<asp:Label ID="lblEstado" AssociatedControlID="ddlEstado" runat="server" Text="Estado"></asp:Label>
								<asp:DropDownList ValidationGroup="form" ID="ddlEstado" runat="server">
								</asp:DropDownList>
								<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="ddlEstado"
									Display="Dynamic" CssClass="errorMessage" ID="reqEstado" runat="server"><div>Informe o Estado</div></asp:RequiredFieldValidator>
							</div>
							<div class="boxCidade">
								<asp:Label ID="lblCidade" AssociatedControlID="txtCidade" runat="server" Text="Cidade"></asp:Label>
								<asp:TextBox ValidationGroup="form" ID="txtCidade" runat="server"></asp:TextBox>
								<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtCidade"
									Display="Dynamic" CssClass="errorMessage" ID="reqCidade" runat="server"><div>Informe a Cidade</div></asp:RequiredFieldValidator>
							</div>
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblBairro" AssociatedControlID="txtBairro" runat="server" Text="Bairro"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtBairro" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtBairro"
								Display="Dynamic" CssClass="errorMessage" ID="reqBairro" runat="server"><div>Informe o Bairro</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo">
							<asp:Label ID="lblEndereco" AssociatedControlID="txtEndereco" runat="server" Text="Endereco"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtEndereco" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtEndereco"
								Display="Dynamic" CssClass="errorMessage" ID="reqEndereco" runat="server"><div>Informe o Endereço</div></asp:RequiredFieldValidator>
						</div>
						<div class="boxCampo boxTelefone">
							<asp:Label ID="lblTelefone" AssociatedControlID="txtTelefone" runat="server" Text="Telefone"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtTelefone" CssClass="inpTelefone" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtTelefone" Display="Dynamic"
								CssClass="errorMessage" ID="reqTelefone" runat="server"><div>Informe o Telefone</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo boxFull">
							<p>
								Contato preferencial por:</p>
							<span class="lstChk">
								<asp:CheckBox runat="server" ID="chkContatoEmail" Text="E-mail" />
								<br />
								<asp:CheckBox runat="server" ID="chkContatoTelefone" Text="Telefone" />
							</span>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo boxFull">
							<asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button"
								ImageUrl="~/contents/img/btn-solicitar.png" runat="server" OnClick="btnSolicitar_Click" />
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
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
