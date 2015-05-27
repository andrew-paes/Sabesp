<%@ Control Language="C#" AutoEventWireup="true" CodeFile="projetoEspecial.ascx.cs" Inherits="content_module_projetoEspecial_projetoEspecial" %>
<br />
<strong>Titúlo do Projeto: </strong>
<br />
<br />
<asp:TextBox ID="txtTituloProjeto" runat="server" Width="400px" MaxLength="50"  />
<br />
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTituloProjeto"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<strong>Chamada do Projeto: </strong>
<br />
<asp:TextBox ID="txtChamada" TextMode="MultiLine" runat="server"  Height="100px" Width="400px" MaxLength="140"  />
<br />
<br />
<strong>Url: </strong>
<br />
<asp:TextBox ID="txtUrl" runat="server" Width="400px" MaxLength="200"  />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrl"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
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

<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>


