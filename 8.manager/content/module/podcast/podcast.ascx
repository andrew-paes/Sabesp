﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="podcast.ascx.cs" Inherits="content_module_podcast_podcast" %>

<script type="text/javascript">
	$(document).ready(function() {
		$('input[id$="txtdtPublicacao"]').setMask('99/99/9999');
		$('input[id$="txtdtInicio"]').setMask('99/99/9999');
		$('input[id$="txtdtFim"]').setMask('99/99/9999');
	});
</script>

<br />
<strong>Categoria: </strong>
<br />
<asp:DropDownList ID="ddlCategoria" runat="server">
</asp:DropDownList>&nbsp;
<asp:RequiredFieldValidator
	ID="rfvCategoria" runat="server" ControlToValidate="ddlCategoria" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Título: </strong>
<br />
<asp:TextBox ID="txtTitulo" runat="server" MaxLength="200" Width="450px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Descrição: </strong>
<br />
<ag2:HtmlTextBox ID="txtDescricao" runat="server" />
<br />
<br />
<strong>Autor: </strong>
<br />
<asp:TextBox ID="txtAutor" runat="server" MaxLength="100" Width="450px" />
<br />
<br />
<strong>Arquivo: </strong>
<br />
<ag2:SubForm runat="server" ID="sfArquivo" SqlStringCommand="SELECT * FROM arquivo WHERE arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" QtdMaxItens="1" ModuloSubForm="arquivo" />
<br />
<br />
<strong>Data Publicação: </strong>
<br />
<ag2:DateField runat="server" ID="txtdtPublicacao" CssClass="frmborder" />
&nbsp;<asp:RequiredFieldValidator ID="rfvPub" runat="server" ControlToValidate="txtdtPublicacao"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
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
<strong>Ativo: </strong>
<br />
<asp:CheckBox ID="chbAtivo" runat="server" />
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
