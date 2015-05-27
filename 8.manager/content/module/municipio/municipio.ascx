<%@ Control Language="C#" AutoEventWireup="true" CodeFile="municipio.ascx.cs" Inherits="content_module_municipio_municipio" %>
<br />
<strong>Município: </strong>
<br />
<asp:TextBox ID="txtMunicipio" runat="server" Width="400px" MaxLength="200" />
<br />
<strong>Imagem:</strong>
<br />
<ag2:UploadField runat="server" ID="uplField" TargetFolder="municipio/" MaxFileLength="50000" />
<br />
<strong>Texto: </strong>
<br />
<ag2:HtmlTextBox ID="htmMunicipio" runat="server" />
<br />
<fieldset style="width: 600px;">
	<legend>Criar Abas</legend>
	<asp:HiddenField ID="hddIdGridView" Value="0" runat="server" />
	<br />
	<strong>Título: </strong>
	<br />
	<asp:TextBox ID="txtTituloAba" runat="server" Width="595px" MaxLength="200"></asp:TextBox>
	<br />
	<strong>Texto: </strong>
	<br />
	<ag2:HtmlTextBox ID="htmTextoAba" runat="server" />
	<br />
	<div class="boxesc" style="background-color: #FFFFFF !important; vertical-align: bottom;">
		<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/img/btn_nova_entrada.gif"
			Width="87" Height="20" BorderWidth="0" AlternateText="Incluir" ImageAlign="AbsMiddle"
			CausesValidation="true" OnClick="btnIncluir_Click" />
		<br />
	</div>
    <strong>Ativo: </strong>
    <br />
    <asp:CheckBox ID="chbAtivo" runat="server" />
    <br />
	
	<strong>Lista: </strong>
	<br />
	<asp:GridView ID="gdvTituloTextoLink" runat="server" AutoGenerateColumns="False"
		DataKeyNames="idGridView,idAbaDB,Titulo,Texto, Ativo" BackColor="White" BorderColor="#DEDFDE"
		BorderStyle="None" BorderWidth="1px" CellPadding="4" EmptyDataText="Sem itens para exibir"
		ForeColor="Black" GridLines="Vertical" OnRowDeleting="gdvTituloTextoLink_RowDeleting"
		OnSelectedIndexChanged="gdvTituloTextoLink_SelectedIndexChanged">
		<RowStyle BackColor="#F7F7DE" />
		<Columns>
			<asp:CommandField ShowSelectButton="True" ButtonType="Button" SelectText="Editar">
				<HeaderStyle Width="50px" HorizontalAlign="Center" VerticalAlign="Middle" />
				<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
			</asp:CommandField>
			<asp:BoundField HeaderText="Titulo" DataField="Titulo" ControlStyle-Width="450px">
				<ControlStyle Width="450px"></ControlStyle>
				<HeaderStyle Width="450px" />
			</asp:BoundField>
			<asp:BoundField HeaderText="Texto" DataField="Texto" ControlStyle-Width="0px" 
				Visible="False">
				<ControlStyle Width="0px"></ControlStyle>
				<HeaderStyle Width="0px" />
			</asp:BoundField>
			<asp:BoundField HeaderText="Ativo" DataField="Ativo" ControlStyle-Width="50px" >
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
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
