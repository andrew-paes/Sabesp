<%@ Control Language="C#" AutoEventWireup="true" CodeFile="noticia.ascx.cs" Inherits="content_module_noticia_noticia" %>

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
<asp:TextBox ID="txtTitulo" MaxLength="100" runat="server" Width="400px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Resumo: </strong>
<br />
<ag2:HtmlTextBox ID="txtChamadaNoticia" runat="server" />
<br />
<br />
<strong>Conteúdo: </strong>
<br />
<ag2:HtmlTextBox ID="txtConteudo" runat="server" />
<br />
<br />
<strong>Fonte: </strong>
<br />
<asp:TextBox ID="txtFonte" MaxLength="200" runat="server" Width="450px" />
<br />
<br />
<strong>Fonte URL: </strong>
<br />
<asp:TextBox ID="txtFonteURL" MaxLength="500" runat="server" Width="450px" />
<br />
<br />
<strong>Autor: </strong>
<br />
<asp:TextBox ID="txtAutor" MaxLength="100" runat="server" Width="450px" />
<br />
<br />
<strong>Data Publicação: </strong>
<br />
<ag2:DateField runat="server" ID="txtdtPublicacao" CssClass="frmborder" ValidationGroup="1" />
&nbsp;
<asp:CustomValidator ID="CustomValidator2" ControlToValidate="txtdtPublicacao" Display="Static"
	ErrorMessage="Data inválida!" ForeColor="Red" OnServerValidate="ServerValidationDateTime"
	runat="server" ValidationGroup="1" ValidateEmptyText="true" />
<br />
<br />
<strong>Data inicio da exibição: </strong>
<br />
<ag2:DateField runat="server" ID="txtdtInicio" CssClass="frmborder" ValidationGroup="1" />
&nbsp;
<asp:TextBox ID="txtHoraInicio" runat="server" Width="50px" class="isTime" />
&nbsp;
<asp:CustomValidator ID="CustomValidator1" ControlToValidate="txtdtInicio" Display="Static"
	ErrorMessage="Data inválida!" ForeColor="Red" OnServerValidate="ServerValidationDateTime"
	runat="server" ValidationGroup="1" ValidateEmptyText="true" />
<br />
<br />
<strong>Data fim exibição: </strong>
<br />
<ag2:DateField runat="server" ID="txtdtFim" CssClass="frmborder" ValidationGroup="1" />
&nbsp;
<asp:TextBox ID="txtHoraFim" runat="server" Width="50px" class="isTime" />
&nbsp;
<asp:CustomValidator ID="CustomValidator3" ControlToValidate="txtdtFim" Display="Static"
	ErrorMessage="Data inválida!" ForeColor="Red" OnServerValidate="ServerValidationDateTime"
	runat="server" ValidationGroup="1" ValidateEmptyText="true" />
<br />
<br />
<strong>Arquivos thumb Médio: </strong>
<br />
<ag2:SubForm runat="server" ID="sfMedio" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" QtdMaxItens="1" ModuloSubForm="arquivo" />
<br />
<br />
<strong>Arquivos thumb Grande: </strong>
<br />
<ag2:SubForm runat="server" ID="sfGrande" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" QtdMaxItens="1" ModuloSubForm="arquivo" />
<br />
<br />
<strong>Arquivos: </strong>
<br />
<ag2:SubForm runat="server" ID="sfArquivo" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" ModuloSubForm="arquivonoticia"
	UrlPagina="edit.aspx?exibiMenu=false" TipoConsistencia="Sincrona" EnableViewState="false"
	OnExcluir="sfArquivo_Excluir" />
<br />
<br />
<strong>Destaque: </strong>
<br />
<asp:CheckBox ID="chbDestaque" runat="server" />
<br />
<br />
<strong>Destaque home: </strong>
<br />
<asp:CheckBox ID="chbDestaqueHome" runat="server" />
<br />
<br />
<strong>Destaque fique por dentro: </strong>
<br />
<asp:CheckBox ID="chbDestaqueFique" runat="server" />
<br />
<br />
<strong>Destaque últimas notícias: </strong>
<br />
<asp:CheckBox ID="chbDestaqueUltimasNoticias" runat="server" />
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
