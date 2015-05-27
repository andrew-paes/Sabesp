<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="formulario_inscricao.aspx.cs" Inherits="interna_formulario_inscricao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				Inscrição Curso de Pesquisa de Vazamentos</h2>
			<div class="colContentLeft">
				<div class="boxFormularios">
					<p>
						Para se inscrever no Curso de Pesquisa de Vazamentos, preencha todos os campos do
						formulário abaixo e clique em <strong>Solicitar</strong>.</p>
					<fieldset>
						<legend>Inscrição Curso de Pesquisa de Vazamentos</legend>
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
						<div class="boxCampo boxFull">
							<div class="boxItemList">
								<h4>
									Escolaridade</h4>
								<asp:RadioButtonList RepeatLayout="Flow" ID="rdoEscolaridade" CssClass="chk" runat="server">
									<%--<asp:ListItem Text="1º Grau" Value=""></asp:ListItem>
									<asp:ListItem Text="2º Grau" Value=""></asp:ListItem>
									<asp:ListItem Text="Técnico" Value=""></asp:ListItem>
									<asp:ListItem Text="Superior" Value=""></asp:ListItem>
									<asp:ListItem Text="Outros" Value=""></asp:ListItem>--%>
								</asp:RadioButtonList>
								<asp:TextBox ValidationGroup="form" ID="txtEscolaridadeOutros" CssClass="outros"
									runat="server"></asp:TextBox>
								<asp:CustomValidator ID="CustomValidator1" ClientValidationFunction="ValidateSelectedEscolaridade"
									runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa informar a escolaridade!</div>
								</asp:CustomValidator>
							</div>
							<div class="boxItemList">
								<h4>
									Tipo de Imóvel</h4>
								<asp:RadioButtonList RepeatLayout="Flow" ID="rdoImovel" CssClass="chk" runat="server">
									<%--<asp:ListItem Text="Casa" Value=""></asp:ListItem>
									<asp:ListItem Text="Prédio" Value=""></asp:ListItem>
									<asp:ListItem Text="Comercial" Value=""></asp:ListItem>
									<asp:ListItem Text="Industrial" Value=""></asp:ListItem>
									<asp:ListItem Text="Outros" Value=""></asp:ListItem>--%>
								</asp:RadioButtonList>
								<asp:TextBox ValidationGroup="form" ID="txtImovelOutros" CssClass="outros" runat="server"></asp:TextBox>
								<asp:CustomValidator ID="CustomValidator2" ClientValidationFunction="ValidateSelectedImovel"
									runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa informar o tipo de imóvel!</div>
								</asp:CustomValidator>
							</div>
							<div class="boxItemList">
								<h4>
									Veículo</h4>
								<asp:RadioButtonList RepeatLayout="Flow" ID="rdoVeiculo" CssClass="chk" runat="server">
									<%--<asp:ListItem Text="Jornal, revista ou TV" Value=""></asp:ListItem>
									<asp:ListItem Text="Indicações" Value=""></asp:ListItem>
									<asp:ListItem Text="Site Sabesp" Value=""></asp:ListItem>
									<asp:ListItem Text="Outros" Value=""></asp:ListItem>--%>
								</asp:RadioButtonList>
								<asp:TextBox ValidationGroup="form" ID="txtVeiculoOutros" CssClass="outros" runat="server"></asp:TextBox>
								<asp:CustomValidator ID="CustomValidator3" ClientValidationFunction="ValidateSelectedVeiculo"
									runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa informar o veículo!</div>
								</asp:CustomValidator>
							</div>
							<div class="clr">
								<!-- -->
							</div>
							<div class="boxItemList">
								<h4>
									Indique o local de sua preferência para realizar o curso</h4>
								<asp:RadioButtonList RepeatLayout="Flow" ID="rdoLocal" CssClass="chk" runat="server">
									<%--<asp:ListItem Text="Ipiranga" Value=""></asp:ListItem>
									<asp:ListItem Text="Itaquera" Value=""></asp:ListItem>
									<asp:ListItem Text="Santo Amaro" Value=""></asp:ListItem>
									<asp:ListItem Text="Santana" Value=""></asp:ListItem>
									<asp:ListItem Text="São Bernardo do Campo" Value=""></asp:ListItem>
									<asp:ListItem Text="Santo Antonio da Patrulha" Value=""></asp:ListItem>--%>
								</asp:RadioButtonList>
								<asp:CustomValidator ID="CustomValidator4" ClientValidationFunction="ValidateSelectedLocal"
									runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa informar o local!</div>
								</asp:CustomValidator>
							</div>
							<div class="boxItemList">
								<h4>
									Indique o horário de sua preferência</h4>
								<asp:RadioButtonList RepeatLayout="Flow" ID="rdoHorario" CssClass="chk" runat="server">
									<%--<asp:ListItem Text="8 às 12 horas" Value=""></asp:ListItem>
									<asp:ListItem Text="13 às 17 horas" Value=""></asp:ListItem>--%>
								</asp:RadioButtonList>
								<asp:CustomValidator ID="CustomValidator5" ClientValidationFunction="ValidateSelectedHorario"
									runat="server" ValidationGroup="form" Display="Dynamic"><br /><div>
									Você precisa informar o horário!</div>
								</asp:CustomValidator>
							</div>
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
		function ValidateSelectedEscolaridade(oSrc, args) {
			// se foi selcionado algum radio
			if ($("input[name$='rdoEscolaridade']:checked").val() != undefined && $("input[name$='rdoEscolaridade']:checked").val() != '') {
				// se o radio selecionado eh o ultimo
				if ($("input[name$='rdoEscolaridade']:last").val() == $("input[name$='rdoEscolaridade']:checked").val()) {
					// se o o 'outros' estah preenchido
					if (document.getElementById("<%=txtEscolaridadeOutros.ClientID%>").value != '') {
						args.IsValid = true;
					}
					else {
						args.IsValid = false;
					}
				}
				else {
					args.IsValid = true;
				}
			}
			else {
				args.IsValid = false;
			}
		}

		function ValidateSelectedImovel(oSrc, args) {
			// se foi selcionado algum radio
			if ($("input[name$='rdoImovel']:checked").val() != undefined && $("input[name$='rdoImovel']:checked").val() != '') {
				// se o radio selecionado eh o ultimo
				if ($("input[name$='rdoImovel']:last").val() == $("input[name$='rdoImovel']:checked").val()) {
					// se o o 'outros' estah preenchido
					if (document.getElementById("<%=txtImovelOutros.ClientID%>").value != '') {
						args.IsValid = true;
					}
					else {
						args.IsValid = false;
					}
				}
				else {
					args.IsValid = true;
				}
			}
			else {
				args.IsValid = false;
			}
		}

		function ValidateSelectedVeiculo(oSrc, args) {
			// se foi selcionado algum radio
			if ($("input[name$='rdoVeiculo']:checked").val() != undefined && $("input[name$='rdoVeiculo']:checked").val() != '') {
				// se o radio selecionado eh o ultimo
				if ($("input[name$='rdoVeiculo']:last").val() == $("input[name$='rdoVeiculo']:checked").val()) {
					// se o o 'outros' estah preenchido
					if (document.getElementById("<%=txtVeiculoOutros.ClientID%>").value != '') {
						args.IsValid = true;
					}
					else {
						args.IsValid = false;
					}
				}
				else {
					args.IsValid = true;
				}
			}
			else {
				args.IsValid = false;
			}
		}

		function ValidateSelectedLocal(oSrc, args) {
			// se foi selcionado algum radio
			if ($("input[name$='rdoLocal']:checked").val() != undefined && $("input[name$='rdoLocal']:checked").val() != '') {
				args.IsValid = true;
			}
			else {
				args.IsValid = false;
			}
		}

		function ValidateSelectedHorario(oSrc, args) {
			// se foi selcionado algum radio
			if ($("input[name$='rdoHorario']:checked").val() != undefined && $("input[name$='rdoHorario']:checked").val() != '') {
				args.IsValid = true;
			}
			else {
				args.IsValid = false;
			}
		}
	</script>

</asp:Content>
