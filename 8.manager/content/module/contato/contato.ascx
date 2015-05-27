<%@ Control Language="C#" AutoEventWireup="true" CodeFile="contato.ascx.cs" Inherits="content_module_controleSessao_controleSessao" %>
<br />
<strong>Nome: </strong>
<br />
<asp:TextBox ID="txtNome" MaxLength="50" runat="server" Width="400px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvNome" runat="server" ControlToValidate="txtNome" ValidationGroup="1" ErrorMessage="Campo obrigatório"
	ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>E-mail: </strong>
<br />
<asp:TextBox ID="txtEmail" MaxLength="50" runat="server" Width="400px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvEmail" runat="server" ControlToValidate="txtEmail" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Panel ID="pnlFormulario" runat="server">
	<asp:CheckBoxList ID="chbFormulario" runat="server" RepeatDirection="Horizontal"
		RepeatColumns="1">
	</asp:CheckBoxList>
</asp:Panel>
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
