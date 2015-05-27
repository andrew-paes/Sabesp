<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="fale_Conosco_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTitulo" runat="server" Text="Fale Conosco" /></h2>
		<div class="colContent">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="boxContent">
								<asp:Literal ID="ltrDescricao" runat="server" />
								<br />
								<p>
									<asp:Literal ID="Literal7" runat="server" Text="Selecione uma região sobre o qual gostaria de saber e/ou falar:" />
								</p>
								<fieldset class="faleConosco">
									<legend>
										<asp:Literal ID="Literal3" runat="server" Text="Formulário de Contato" /></legend>
									<asp:ScriptManager ID="scrmngr1" runat="server" />
									<asp:UpdatePanel ID="updPnl1" runat="server" UpdateMode="Conditional">
										<ContentTemplate>
											<div class="boxFormLine">
												<br />
												<div class="boxSelect w320">
													<span>
														<asp:Literal ID="ltrRegiaoSelected" runat="server" />
														<asp:DropDownList ID="ddlRegiao" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlRegiao_SelectedIndexChanged"
															CssClass="select w310">
															<asp:ListItem Text="Selecione uma região" Value="" />
															<asp:ListItem Text="Atendimento Interior e Litoral" Value="28" />
															<asp:ListItem Text="Atendimento Região Metropolitana - Centro" Value="27" />
															<asp:ListItem Text="Atendimento Região Metropolitana - Zona Leste" Value="25" />
															<asp:ListItem Text="Atendimento Região Metropolitana - Zona Norte" Value="23" />
															<asp:ListItem Text="Atendimento Região Metropolitana - Zona Oeste" Value="24" />
															<asp:ListItem Text="Atendimento Região Metropolitana - Zona Sul" Value="26" />
														</asp:DropDownList>
													</span>
												</div>
											</div>
											<p>
												<asp:Literal ID="lblDescricaoRegiao" runat="server" />
											</p>
											<input type="hidden" id="cbogrupo" name="cbogrupo" value="<%=OptionSelectedId %>" />
										</ContentTemplate>
									</asp:UpdatePanel>
									<div class="boxFormLine">
										<asp:ImageButton ID="btnSend" runat="server" ImageUrl="~/contents/img/spacer.gif"
											CssClass="btnEnviar" PostBackUrl="http://www2.sabesp.com.br/fale%20conosco/fale_conosco_envio.asp" />
									</div>
								</fieldset>
								<p>
									Clique
									<asp:HyperLink ID="hlConsultar" runat="server" Text="aqui" NavigateUrl="http://www2.sabesp.com.br/fale%20conosco/fale_conosco_posicao.asp" />
									para consultar um Fale Conosco aberto anteriormente.
								</p>
							</div>
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
