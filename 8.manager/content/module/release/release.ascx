<%@ Control Language="C#" AutoEventWireup="true" CodeFile="release.ascx.cs" Inherits="content_module_release_release" %>

<script type="text/javascript">
	$(document).ready(function() {
		$('input[id$="txtdtPublicacao"]').setMask('99/99/9999');
		$('input[id$="txtdtInicio"]').setMask('99/99/9999');
		$('input[id$="txtdtFim"]').setMask('99/99/9999');
	});
</script>

<br />
<strong>Título: </strong>
<br />
<asp:TextBox ID="txtTitulo" MaxLength="200" runat="server" Width="400px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Resumo: </strong>
<br />
<ag2:HtmlTextBox ID="txtChamadaRelease" runat="server" />
<br />
<br />
<strong>Conteúdo: </strong>
<br />
<ag2:HtmlTextBox ID="txtConteudo" runat="server" />
<br />
<br />
<strong>Autor: </strong>
<br />
<asp:TextBox ID="txtAutor" MaxLength="200" runat="server" Width="450px" />
<br />
<br />
<strong>Data Publicação: </strong>
<br />
<ag2:DateField runat="server" ID="txtdtPublicacao" CssClass="frmborder" ValidationGroup="1" />
&nbsp;
<asp:TextBox ID="txtHoraPublicacao" MaxLength="5" runat="server" Width="50px" />
&nbsp;
<asp:CustomValidator ID="CustomValidator2" ControlToValidate="txtdtPublicacao" Display="Static"
	ErrorMessage="Data inválida!" ForeColor="Red" OnServerValidate="ServerValidationDateTime"
	runat="server" ValidationGroup="1" ValidateEmptyText="true" />
<br />
<br />
<strong>Arquivos: </strong>
<br />
<%--<ag2:SubForm runat="server" ID="sfArquivo" DataValueField="arquivoId" DataTextField="nomeArquivo"
	ModuloSubForm="arquivo" SqlStringCommand="SELECT * FROM arquivo WHERE arquivoId = @arquivoId"
	UrlPagina="edit.aspx?exibiMenu=false" />--%>
<ag2:SubForm runat="server" ID="sfArquivo" DataValueField="arquivoId" DataTextField="nomeArquivo"
	ModuloSubForm="arquivo" SqlStringCommand="SELECT * FROM arquivo WHERE arquivoId = @arquivoId" />
<br />
<br />
<strong>Ativo: </strong>
<br />
<asp:CheckBox ID="chbAtivo" runat="server" />
<br />
<br />
<strong>Destaque home: </strong>
<br />
<asp:CheckBox ID="chbDestaqueHome" runat="server" />
<br />
<br />
<asp:Panel ID="pnlRegiaoRelacionado" runat="server">
	<strong>Regiões: </strong>
	<br />
	<asp:CheckBoxList ID="chbRegiao" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
	</asp:CheckBoxList>
</asp:Panel>
<br />
<br />
<strong>Tags: </strong>
<br />
<asp:TextBox ID="txtTags" runat="server" Width="450px" />
<br />
<br />
<asp:Panel ID="pnlRelacionado" runat="server">
	<br />
	<div class="boxesc" style="vertical-align: bottom; text-align: left; padding-left: 10px;
		margin-bottom: 25;">
		<h1>
			CONTEÚDO RELACIONADO</h1>
	</div>
	<div style="background: #F0F0F0; padding: 10px;">
		<ag2:ag2Relacionar ID="ctrConteudoRelacionado" runat="server" />
	</div>
	<br />
</asp:Panel>
<br />
<br />
<ag2:StatusWorkflow ID="StatusWorkflow1" runat="server" ValidationGroup="1" />
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
