<%@ Control Language="C#" AutoEventWireup="true" CodeFile="solucaoAmbiental.ascx.cs" Inherits="content_module_solucaoAmbiental_solucaoAmbiental" %>
<br />
<strong>Título Principal: </strong>
<br />
<asp:TextBox ID="txtTituloPrincipal" runat="server" Width="500px" />&nbsp;
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTituloPrincipal"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"/>
<br />
<br />
<strong>Imagem: </strong>
<br />
<asp:CustomValidator runat="server" ID="cvValidarArquivo" OnServerValidate="cvValidarArquivo_ServerValidate" ValidationGroup="1"></asp:CustomValidator>
<ag2:SubForm runat="server" ID="sfArquivoImagem" SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
	DataValueField="arquivoId" DataTextField="nomeArquivo" ModuloSubForm="arquivo" />
<br />
<strong>Link Imagem: </strong>
<br />
<asp:TextBox ID="txtLinkImagem" runat="server" Width="500px" />
<br />
<br />
<asp:CustomValidator runat="server" ID="cvValidarChamada1" OnServerValidate="cvValidarChamada1_ServerValidate" ValidationGroup="1"></asp:CustomValidator><br />
<strong>Título Chamada 1: </strong>
<br />
<asp:TextBox ID="txtTituloChamada1" runat="server" Width="500px" />
<br />
<strong>Texto Chamada 1: </strong>
<br />
<ag2:HtmlTextBox ID="txtTextoChamada1" runat="server" />
<br />
<strong>Link Chamada 1: </strong>
<br />
<asp:TextBox ID="txtLink1" runat="server" Width="500px" />
<br />
<br />
<asp:CustomValidator runat="server" ID="cvValidarChamada2" OnServerValidate="cvValidarChamada2_ServerValidate" ValidationGroup="1"></asp:CustomValidator><br />
<strong>Título Chamada 2: </strong>
<br />
<asp:TextBox ID="txtTituloChamada2" runat="server" Width="500px" />
<br />
<strong>Chamada 2: </strong>
<br />
<ag2:HtmlTextBox ID="txtTextoChamada2" runat="server" />
<br />
<strong>Link Chamada 2: </strong>
<br />
<asp:TextBox ID="txtLink2" runat="server" Width="500px" />
<br />
<br />
<asp:CustomValidator runat="server" ID="cvValidarChamada3" OnServerValidate="cvValidarChamada3_ServerValidate" ValidationGroup="1"></asp:CustomValidator><br />
<strong>Título Chamada 3: </strong>
<br />
<asp:TextBox ID="txtTituloChamada3" runat="server" Width="500px" />
<br />
<strong>Chamada 3: </strong>
<br />
<ag2:HtmlTextBox ID="txtTextoChamada3" runat="server" />
<br />
<strong>Link Chamada 3: </strong>
<br />
<asp:TextBox ID="txtLink3" runat="server" Width="500px" />
<br />
<br />
<strong>Idioma: </strong>
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="cmbIdioma"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"/>
<br />
<asp:DropDownList id="cmbIdioma" runat="server" CssClass = "frmborder">
</asp:DropDownList>
<br />
<br />

<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
