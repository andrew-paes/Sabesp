<%@ Control Language="C#" AutoEventWireup="true" CodeFile="infografico.ascx.cs" Inherits="content_module_infografico_infografico" %>
<br />
<strong>Título: </strong>
<br />
<asp:TextBox ID="txtTitulo" runat="server" Width="500px" />&nbsp;
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"/>
<br />
<br />
<strong>Descrição: </strong>
<br />
<ag2:HtmlTextBox ID="txtDescricao" runat="server" />
<br />
<br />
<strong>Imagem: </strong>
<br />
<ag2:SubForm runat="server" ID="sfArquivoImagem" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" ModuloSubForm="arquivo" />
<br />
<br />
<strong>Animação: </strong>
<br />
<ag2:SubForm runat="server" ID="sfArquivoAnimacao" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" ModuloSubForm="arquivo" />
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
