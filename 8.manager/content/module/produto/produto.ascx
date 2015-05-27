<%@ Control Language="C#" AutoEventWireup="true" CodeFile="produto.ascx.cs" 
Inherits="content_module_produto_produto" %>
<br />
<strong>Tipo de Produto: </strong>
<br />
<asp:DropDownList ID="ddlTipo" CssClass="frmborder" Width="400px" runat="server"/>
&nbsp;
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="ddlTipo"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Titulo Produto: </strong>
<br />
<asp:TextBox ID="txtTituloProduto" runat="server" Width="400px" MaxLength="150"  />
<br />
<br />
<strong>Chamada do Produto: </strong>
<br />
<asp:TextBox ID="txtChamada" runat="server" Width="400px" MaxLength="130"  />
<br />
<br />
<strong>Descrição Produto: </strong>
<br />
<ag2:HtmlTextBox ID="txtDescricao" runat="server" />
<br />
<br />
<strong>Destaque Home: </strong>
<br />
<asp:CheckBox ID="chkDestaque" runat="server" />
<br />
<br />
<strong>Ativo: </strong>
<br />
<asp:CheckBox ID="chkAtivo" runat="server" />
<br />
<br />
<strong>Thumb:</strong>
<br />
<ag2:SubForm runat="server" ID="sfThumb" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" QtdMaxItens="1" ModuloSubForm="arquivo" />
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

