<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloTextoCaixaDireita.ascx.cs"
	Inherits="content_module_tituloTextoCaixaDireita_tituloTextoCaixaDireita" %>
<br />
<strong>Nome Controle: </strong>
<br />
<asp:TextBox ID="txtNomeControle" runat="server" Width="400px" MaxLength="200" Enabled="false" />
<br />
<strong>Titulo: </strong>
<br />
<asp:TextBox ID="txtTitulo" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
<br />
<strong>Link: </strong>
<br />
<asp:TextBox ID="txtLink" runat="server" Width="595px" MaxLength="200"></asp:TextBox>
<br />
<strong>Target: </strong>
<br />
<asp:DropDownList ID="ddlTarget" runat="server">
	<asp:ListItem Text="Selecione..." Value="_blank" />
	<asp:ListItem Text="Mesma Janela" Value="_parent" />
	<asp:ListItem Text="Nova Janela" Value="_blank" />
</asp:DropDownList>
<br />
<strong>Texto: </strong>
<br />
<ag2:HtmlTextBox ID="htmConteudo" runat="server" />
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