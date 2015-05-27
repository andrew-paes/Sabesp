<%@ Control Language="C#" AutoEventWireup="true" CodeFile="faq.ascx.cs" Inherits="content_module_faq_faq" %>
<br />
<strong>Pergunta: </strong>
<br />
<asp:TextBox ID="txtPergunta" runat="server" Width="500px" />
<br />
<br />
<strong>Resposta: </strong>
<br />
<ag2:HtmlTextBox ID="txtResposta" runat="server" />
<br />
<br />
<strong>Ordem: </strong>
<br />
<asp:TextBox ID="txtOrdem" runat="server" Width="40px" />
&nbsp;
<asp:RequiredFieldValidator ID="rfvOrdem" runat="server" ControlToValidate="txtOrdem"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<asp:RegularExpressionValidator ID="revOrdem" runat="server" ErrorMessage="Insira um número."
	ControlToValidate="txtOrdem" ValidationGroup="1" ValidationExpression="^([0-9]*)$"></asp:RegularExpressionValidator>
<br />
<br />
<strong>Categoria: </strong>
<br />
<asp:DropDownList ID="ddlcategoria" runat="server">
</asp:DropDownList>
&nbsp;
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="ddlcategoria"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Destaque: </strong>
<br />
<asp:CheckBox ID="chkDestaque" runat="server" />
<br />
<br />
<strong>Ativo: </strong>
<br />
<asp:CheckBox ID="chbAtivo" runat="server" />
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
