<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tipoProduto.ascx.cs" 
Inherits="content_module_tipoProduto_tipoProduto" %>
<br />
<strong>Titulo do Tipo de Produto: </strong>
<br />
<asp:TextBox ID="txtTipoProduto" runat="server" Width="400px" MaxLength="150"  />
<br />
<br />
<strong>Descrição do Tipo de Produto: </strong>
<br />
<ag2:HtmlTextBox ID="txtDescricao" runat="server" />
<br />
<br />
<strong>Destaque Home: </strong>
<br />
<asp:CheckBox ID="chkDestaque" runat="server" />
<br />
<br />
<strong>Thumb:</strong>
<br />
<ag2:UploadField runat="server" ID="uplField" TargetFolder="produto/" MaxFileLength="50000" />
<br />
<br />
<strong>Imagens do Produto: </strong>
<br />
<ag2:SubForm runat="server" ID="sfArquivo" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" ModuloSubForm="arquivoProduto"
	UrlPagina="edit.aspx?exibiMenu=false" TipoConsistencia="Sincrona" EnableViewState="false"
	OnExcluir="sfArquivo_Excluir" />
<br />

<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>


