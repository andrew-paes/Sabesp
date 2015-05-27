<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="FaleConoscoOld.aspx.cs" Inherits="fale_Conosco_FaleConoscoOld" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server" Text="Fale Conosco" /></h2>
		<div class="colContent">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<fieldset class="faleConosco">
								<p>
									<asp:Literal ID="Literal2" runat="server" Text="Fale conosco preenchendo o formulário abaixo." /></p>
								<legend>
									<asp:Literal ID="Literal3" runat="server" Text="Formulário de Contato" /></legend>
								<div class="boxFormLine">
									<label>
										<asp:Literal ID="Literal4" runat="server" Text="*Nome" /></label>
									<div class="boxCampo">
										<span>
											<asp:TextBox ID="txtNome" CssClass="text limpaCampo" runat="server" Text="Digite seu nome completo"
												ToolTip="Digite seu nome completo"></asp:TextBox>
										</span>
									</div>
									&nbsp;
									<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
										ErrorMessage="*" Font-Bold="True" InitialValue="Digite seu nome completo" />
								</div>
								<div class="boxFormLine">
									<label>
										<asp:Literal ID="Literal5" runat="server" Text="*E-mail" /></label>
									<div class="boxCampo">
										<span>
											<asp:TextBox ID="txtEmail" CssClass="text limpaCampo" runat="server" Text="exemplo@exemplo.com.br"
												ToolTip="exemplo@exemplo.com.br"></asp:TextBox>
										</span>
									</div>
									&nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server"
										ControlToValidate="txtEmail" ErrorMessage="*" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
									<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
										ErrorMessage="*" Font-Bold="True" InitialValue="exemplo@exemplo.com.br" />
								</div>
								<div class="boxFormLine">
									<label>
										<asp:Literal ID="Literal6" runat="server" Text="Telefone" /></label>
									<div class="boxCampo" style="width: 40px; margin-right: 5px;">
										<span>
											<asp:TextBox ID="txtDDD" CssClass="text limpaCampo" runat="server" Text="DDD" ToolTip="DDD"
												MaxLength="3"></asp:TextBox>
										</span>
									</div>
									<div class="boxCampo" style="width: 75px;">
										<span>
											<asp:TextBox ID="txtNumero" CssClass="text limpaCampo" runat="server" Text="XXXX-XXXX"
												ToolTip="XXXX-XXXX" MaxLength="8"></asp:TextBox>
										</span>
									</div>
								</div>
								<asp:ScriptManager ID="sm" runat="server">
								</asp:ScriptManager>
								<asp:UpdatePanel ID="panelLocalidade" runat="server">
									<ContentTemplate>
										<div class="boxFormLine">
											<label>
												<asp:Literal ID="Literal7" runat="server" Text="*Região" /></label>
											<div class="boxSelect">
												<span>
													<asp:Literal ID="ltrRegiaoSelected" runat="server" />
													<asp:DropDownList ID="ddlRegiao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegiao_SelectedIndexChanged"
														CssClass="select">
													</asp:DropDownList>
												</span>
											</div>
											&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlRegiao"
												ErrorMessage="*" Font-Bold="True" InitialValue="0" />
										</div>
										<asp:Panel ID="panelEstado" runat="server" Visible="false">
											<div class="boxFormLine">
												<label>
													<asp:Literal ID="Literal9" runat="server" Text="*Estado" /></label>
												<div class="boxSelect">
													<span>
														<asp:Literal ID="ltrEstadoSelected" runat="server" />
														<asp:DropDownList ID="ddlEstado" runat="server" CssClass="select" OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged"
															AutoPostBack="true">
														</asp:DropDownList>
													</span>
												</div>
												&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlEstado"
													ErrorMessage="*" Font-Bold="True" InitialValue="0" Style="float: left" />
												<label>
													<asp:Literal ID="Literal11" runat="server" Text="*Cidade" /></label>
												<div class="boxSelect">
													<span>
														<asp:Literal ID="ltrCidadeSelected" runat="server" />
														<asp:DropDownList ID="ddlCidade" runat="server" CssClass="select" AutoPostBack="true"
															OnSelectedIndexChanged="ddlCidade_SelectedIndexChanged">
														</asp:DropDownList>
													</span>
												</div>
												&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlCidade"
													ErrorMessage="*" Font-Bold="True" InitialValue="0" />
											</div>
										</asp:Panel>
									</ContentTemplate>
								</asp:UpdatePanel>
								<div class="boxFormLine">
									<label>
										<asp:Literal ID="Literal13" runat="server" Text="*Assunto" /></label>
									<div class="boxSelect">
										<span>
											<asp:DropDownList ID="ddlAssunto" runat="server" CssClass="select">
											</asp:DropDownList>
										</span>
									</div>
									&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlAssunto"
										ErrorMessage="*" Font-Bold="True" InitialValue="0" />
								</div>
								<div class="boxFormLine">
									<label>
										<asp:Literal ID="Literal15" runat="server" Text="*Mensagem" /></label>
									<div class="boxTextarea">
										<span>
											<asp:TextBox ID="tbMensagem" runat="server" CssClass="textarea limpaCampo" TextMode="MultiLine"
												Text="Digite aqui sua mensagem" ToolTip="Digite aqui sua mensagem" />
										</span>
									</div>
									&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="tbMensagem"
										ErrorMessage="*" Font-Bold="True" InitialValue="Digite aqui sua mensagem" />
								</div>
								<asp:PlaceHolder ID="phMensagemEnviada" runat="server" Visible="false">
									<br />
									<asp:Label ID="lblMensagemEnviada" runat="server" Text="Mensagem enviada com sucesso!" ForeColor="Red" />
									<br />
								</asp:PlaceHolder>
								<div class="boxFormLine">
									<asp:ImageButton ID="btnSend" ImageUrl="~/contents/img/spacer.gif" CssClass="btnEnviar"
										runat="server" OnClick="btnSend_click" />
								</div>
							</fieldset>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:primeiraColunaDinamica runat="server" ID="primeiraColunaDinamica1" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita" runat="server" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
</asp:Content>
<asp:Content ID="cntScripts" ContentPlaceHolderID="scripts" runat="server">
</asp:Content>
