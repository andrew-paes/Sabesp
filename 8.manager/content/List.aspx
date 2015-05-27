<%@ Page Language="C#" MasterPageFile="~/content/MasterPage.master" AutoEventWireup="true"
	CodeFile="List.aspx.cs" Inherits="content_List" EnableEventValidation="false"
	EnableViewState="true" Theme="Default" EnableSessionState="True" %>

<%@ Register TagName="Paging" TagPrefix="ag2" Src="~/ctl/ag2paging.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="holderPrincipal" runat="Server">

	<script type="text/javascript" language="javascript">

		function listAction() {
			var cmbAction = document.getElementById("ctl00_holderPrincipal_cmbAction");
			return (cmbAction.selectedIndex > 0);
		}

		function filterBox(id) {
			document.getElementById(id).value = "S";
		}

	</script>

	<table border="0" cellpadding="0" cellspacing="0" summary="" class="mb10">
		<tr>
			<td width="100%" style="height: 39px">
				<h1>
					<asp:Label runat="server" ID="lblModuleTitle" /></h1>
			</td>
			<td>
				<ag2:BarraIdiomas ID="barraIdioma" runat="server" />
			</td>
			<td width="99" style="height: 39px">
				<asp:HyperLink runat="server" ID="lnkNewRegister" SkinID="lnkNewRegister" NavigateUrl="edit.aspx" />
			</td>
			<td width="87" style="height: 39px">
				<asp:ImageButton runat="server" ImageUrl="~/img/btn_aplicar_filtro.gif" Width="87"
					Height="20" BorderWidth="0" AlternateText="Exibir Filtro" ID="showFilter" />
			</td>
		</tr>
	</table>
	<div id="statusMessage" class="ManagerMessage">
		[texto]</div>
	<br />
	<asp:HiddenField runat="server" ID="IsFilterData" />
	<asp:HiddenField runat="server" ID="IsShwoFilterBox" />
	<asp:Panel ID="pnlFiltro" DefaultButton="btnFilter" runat="server">
		<div class="filtro" id="tableFilter" runat="server">
			<div class="barra">
				<div class="filtrofont">
					Aplicar Filtro
				</div>
				<div class="filtro2">
					<img src="../img/btn_close.jpg" id="closeFilter" alt="" border="0" />
				</div>
			</div>
			<div class="contentFilter">
				<div>
					<div runat="server" id="boxFilter">
					</div>
				</div>
				<div class="divBtnFilter">
					<br />
					<asp:ImageButton runat="server" ID="btnFilter" ImageUrl="~/img/btn_filtrar.gif" OnClick="btnFilter_Click" />
				</div>
			</div>
		</div>
	</asp:Panel>
	<table id="tblCombo" runat="server" border="0" cellpadding="0" cellspacing="0" width="100%"
		summary="" class="mb3">
		<tr>
			<td height="55" valign="top">
				<div class="imgSetaSelecionaCima">
					<!-- //-->
				</div>
			</td>
			<td width="100%" valign="top">
				<table border="0" cellpadding="0" cellspacing="0" width="100%" summary="" class="contpag">
					<tr>
						<td height="41">
							<table border="0" cellpadding="0" cellspacing="0" width="100%">
								<tr>
									<td>
										<asp:PlaceHolder ID="phAction" Visible="false" runat="server">
											<asp:ListBox runat="server" ID="cmbAction" Rows="1" CssClass="formselect">
												<asp:ListItem Selected="True" Text="Selecione" Value="0" />
												<asp:ListItem Text="Excluir" Value="delete" />
											</asp:ListBox>
											<asp:ImageButton runat="server" ID="btnAction" ImageUrl="~/img/btn_seta_fundo_cinza_claro.gif"
												BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle" CssClass="imgselecione"
												OnClientClick="return listAction()" OnClick="btnAction_Click" />
										</asp:PlaceHolder>
										<ag2:Button ID="btnExcluir" Text="Excluir Registros Selecionados" runat="server" />
										<ag2:Button ID="btnRetornarSelecionados" runat="server" OnClick="btnRetornarSelecionados_Click"
											Text="Retornar Seleção" />
									</td>
									<td style="text-align: right;">
										<asp:PlaceHolder ID="phOptions" Visible="false" runat="server">
											<asp:DropDownList ID="cmbOptions" CssClass="formselect" runat="server">
											</asp:DropDownList>
											<asp:ImageButton runat="server" ID="btnExecOptions" ImageUrl="~/img/btn_seta_fundo_cinza_claro.gif"
												BorderWidth="0" AlternateText="Executar" OnClick="btnExecOptions_Click" ImageAlign="AbsMiddle"
												CssClass="imgselecione" />
										</asp:PlaceHolder>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<!-- LISTA DE CONTEUDO -->
			<ag2:GridViewEditable ID="managerContent" runat="server" AutoGenerateColumns="False"
				Width="100%" BorderStyle="None" BorderWidth="0px" OnRowDataBound="managerContent_RowDataBound">
				<AlternatingRowStyle CssClass="cinza" />
				<HeaderStyle CssClass="cabecalho" />
				<Columns>
					<asp:TemplateField>
						<ItemTemplate>
							<asp:CheckBox runat="server" ID="chkSelect" />
						</ItemTemplate>
						<HeaderTemplate>
							<input id="chkAll" onclick="javascript:SelectAllCheckboxes(this);" runat="server"
								type="checkbox" value="" />
						</HeaderTemplate>
						<HeaderStyle CssClass="cabecalhoprimeiro" Width="36px" />
					</asp:TemplateField>
				</Columns>
			</ag2:GridViewEditable>
			<!-- // LISTA DE CONTEUDO -->
			<table border="0" cellpadding="0" cellspacing="0" width="100%" summary="">
				<tr>
					<td width="100%" valign="bottom">
						<table border="0" cellpadding="0" cellspacing="0" width="100%" summary="" class="contpag">
							<tr>
								<td height="41" width="100%" class="contpag2">
									<!-- paginacao -->
									<ag2:Paging runat="server" ID="pagingBottom" PagingGridId="managerContent" />
									<!-- //paginacao -->
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>
