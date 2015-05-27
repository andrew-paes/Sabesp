<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloLinkZebrado.ascx.cs"
	Inherits="content_module_tituloLinkZebrado_tituloLinkZebrado" %>
<br />
<strong>Nome Controle: </strong>
<br />
<asp:TextBox ID="txtNomeControle" runat="server" Width="400px" MaxLength="200" Enabled="false" />
<br />
<strong>Titulo: </strong>
<br />
<asp:TextBox ID="txtTitulo" runat="server" Width="400px" MaxLength="200"></asp:TextBox>
&nbsp;
<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo"
	ValidationGroup="1" ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<fieldset style="width: 600px;">
	<legend>Criar Lista</legend>
	<asp:HiddenField ID="hddIdGridView" Value="0" runat="server" />
	<br />
	<strong>Texto Link: </strong>
	<br />
	<asp:TextBox ID="txtTexto" runat="server" Width="595px" MaxLength="200"></asp:TextBox>
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
	<div class="boxesc" style="background-color: #FFFFFF !important; vertical-align: bottom;">
		<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/btn_nova_entrada.gif"
			Width="87" Height="20" BorderWidth="0" AlternateText="Incluir" ImageAlign="AbsMiddle"
			CausesValidation="true" OnClick="btnIncluir_Click" />
		<br />
	</div>
	<strong>Lista: </strong>
	<br />
	<asp:GridView ID="gdvTituloTextoLink" runat="server" AutoGenerateColumns="False"
		DataKeyNames="idGridView,Texto,Link,Janela" BackColor="White" BorderColor="#DEDFDE"
		BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="Sem itens para exibir"
		ForeColor="Black" GridLines="Vertical" OnRowDeleting="gdvTituloTextoLink_RowDeleting"
		OnSelectedIndexChanged="gdvTituloTextoLink_SelectedIndexChanged">
		<RowStyle BackColor="#F7F7DE" />
		<Columns>
			<asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Editar">
				<HeaderStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:CommandField>
			<asp:BoundField HeaderText="Texto" DataField="Texto" ControlStyle-Width="250px">
				<ControlStyle Width="250px"></ControlStyle>
				<HeaderStyle Width="250px" />
			</asp:BoundField>
			<asp:BoundField HeaderText="Link" DataField="Link" ControlStyle-Width="200px">
				<ControlStyle Width="200px"></ControlStyle>
				<HeaderStyle Width="200px" />
			</asp:BoundField>
			<asp:BoundField HeaderText="Janela" DataField="Janela" ControlStyle-Width="50px">
				<ControlStyle Width="50px"></ControlStyle>
				<HeaderStyle Width="50px" />
			</asp:BoundField>
			<asp:CommandField ShowDeleteButton="True" ButtonType="Button" DeleteText="Excluir">
				<HeaderStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:CommandField>
		</Columns>
		<FooterStyle BackColor="#CCCC99" />
		<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
		<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
		<HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
		<AlternatingRowStyle BackColor="White" />
	</asp:GridView>
	<br />
</fieldset>
<br />
<ag2:StatusWorkflow ID="StatusWorkflow1" runat="server" ValidationGroup="1" />
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
