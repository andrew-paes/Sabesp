<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="formulario_videoteca_2.aspx.cs" Inherits="interna_formulario_videoteca_2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				Videoteca</h2>
			<div class="colContentLeft">
				<div class="boxFormularios">
					<p>
						Para baixar o(s) arquivo(s) disponíveis preencha todos os campos do formulário abaixo:</p>
					<fieldset>
						<legend>Videoteca</legend>
						<asp:Literal ID="ltrMensagem" runat="server" Visible="false"></asp:Literal>
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
						<div class="boxCampo boxRG">
							<asp:Label ID="lblRG" AssociatedControlID="txtRG" runat="server" Text="RG"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="txtRG" CssClass="fldRG" runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtRG" Display="Dynamic"
								CssClass="errorMessage" ID="reqRG" runat="server"><div>Informe o RG</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo boxCPFCNPJ">
							<span>CPF ou CNPJ</span>
							<asp:RadioButtonList RepeatLayout="Flow" ID="rdoPFouPJ" CssClass="lstPFouPJ" runat="server">
								<asp:ListItem Text="Pessoa Física" Value="PF" Selected="True"></asp:ListItem>
								<asp:ListItem Text="Pessoa Jurídica" Value="PJ"></asp:ListItem>
							</asp:RadioButtonList>
						</div>
						<div class="boxCampo boxCPF">
							<asp:Label ID="lblCPF" AssociatedControlID="CPF" runat="server" Text="CPF"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="CPF" CssClass="fldCPF" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="CPF" Display="Dynamic"
								CssClass="errorMessage" ID="reqCPF" runat="server"><div>Informe o CPF</div></asp:RequiredFieldValidator>--%>
							<asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="ValidateCPFouCNPJ"
								runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Informe CPF</div>
							</asp:CustomValidator>
						</div>
						<div class="boxCampo boxCNPJ" style="display: none;">
							<asp:Label ID="lblCNPJ" AssociatedControlID="CNPJ" runat="server" Text="CNPJ"></asp:Label>
							<asp:TextBox ValidationGroup="form" ID="CNPJ" CssClass="fldCNPJ" runat="server"></asp:TextBox>
							<%--<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="CNPJ" Display="Dynamic"
								CssClass="errorMessage" ID="reqCNPJ" runat="server"><div>Informe o CNPJ</div></asp:RequiredFieldValidator>--%>
							<asp:CustomValidator ID="CustomValidator2" ClientValidationFunction="ValidateCPFouCNPJ"
								runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Informe CNPJ</div>
							</asp:CustomValidator>
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
							<asp:HyperLink ID="HyperLink1" NavigateUrl="#" Text="Não sei meu CEP" runat="server"
								Visible="false"></asp:HyperLink>
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
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtTelefone"
								Display="Dynamic" CssClass="errorMessage" ID="reqTelefone" runat="server"><div>Informe o Telefone</div></asp:RequiredFieldValidator>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<p>
							<strong>Selecione o(s) vídeo(s) de seu interesse:</strong></p>
						<div class="boxCampo boxFull">
							<div class="boxVideoList">
								<div class="boxItemList">
									<asp:CheckBox ID="chkGotaBorralheira" CssClass="chk" Text="A Gota Borralheira" runat="server" />
								</div>
								<div class="boxItemList">
									<asp:CheckBox ID="chkAgua4Videos" CssClass="chk" Text="Água 4 Vídeos" runat="server" />
								</div>
								<div class="boxItemList">
									<asp:CheckBox ID="chkSuperH2O" CssClass="chk" Text="Super H2O contra os Poluidores da Água Potável"
										runat="server" />
								</div>
								<div class="clr">
									<!-- -->
								</div>
								<div class="boxItemList">
									<asp:CheckBox ID="chkAguaNaBoca" CssClass="chk" Text="Água na Boca" runat="server" />
								</div>
								<div class="boxItemList">
									<asp:CheckBox ID="chkChuaChuagua" CssClass="chk" Text="Chuá Chuágua" runat="server" />
								</div>
								<div class="boxItemList">
									<asp:CheckBox ID="chlTratamento" CssClass="chk" Text="Tratamento de Água e Esgoto no Estado de São Paulo"
										runat="server" />
								</div>
							</div>
						</div>
						<div class="clr">
							<!-- -->
						</div>
						<div class="boxCampo boxFull boxComprometimento">
							<asp:Label ID="lblUtilizacao" AssociatedControlID="txtUtilizacao" runat="server"
								Text="Informo que utilizarei este material para:"></asp:Label>
							<asp:TextBox ID="txtUtilizacao" TextMode="MultiLine" Columns="109" Rows="5" Text=""
								runat="server"></asp:TextBox>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="txtUtilizacao"
								Display="Dynamic" CssClass="errorMessage" ID="reqUtilizacao" runat="server"><div>Informe como utilizará o material</div></asp:RequiredFieldValidator>
							<br />
							<asp:CheckBox ID="chkComprometimento" ValidationGroup="form" runat="server" CssClass="chk"
								Text="Comprometo-me a não fazer cópias totais ou parciais, nem a edição deste material." />
							<asp:CustomValidator ID="CustomValidator3" ClientValidationFunction="ValidateChecked"
								runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa aceitar os Termos do Regulamento</div>
							</asp:CustomValidator>
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

	<script language="javascript">
		function ValidateChecked(oSrc, args) {
			if (document.getElementById("<%=chkComprometimento.ClientID%>").checked == false) {
				args.IsValid = false;
				//alert('false');
			}
			else {
				args.IsValid = true;
				//alert('true');
			}
		}

		function ValidateCPFouCNPJ(oSrc, args) {
			if (document.getElementById("<%=CPF.ClientID%>").value != "" || (document.getElementById("<%=CNPJ.ClientID%>").value) != "") {
				args.IsValid = true;
			}
			else {
				args.IsValid = false;
			}
		}
	</script>

</asp:Content>
