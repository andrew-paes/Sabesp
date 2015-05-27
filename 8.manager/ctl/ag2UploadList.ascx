<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ag2UploadList.ascx.cs"
	Inherits="ctl_ag2UploadList" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
		<asp:CustomValidator ID="cvArquivo" runat="server" ErrorMessage="Campo Obrigatorio"
			Display="Dynamic" ControlToValidate="uplField" OnServerValidate="cvArquivo_ServerValidate"
			ValidationGroup="uploadList"></asp:CustomValidator>
		<ag2:UploadField runat="server" ID="uplField" TargetFolder="~/uploads/" />
		<br />
		<strong>
			<label for="txtTitulo">
				Titulo do Arquivo:
			</label>
		</strong>
		<asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ErrorMessage="Campo Obrigatório"
			Display="Dynamic" ControlToValidate="txtTitulo" ValidationGroup="uploadList"></asp:RequiredFieldValidator>
		<br />
		<asp:TextBox ID="txtTitulo" runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:LinkButton
			ID="btnAdiciona" runat="server" OnClick="btnAdiciona_Click" CssClass="frmborder"
			ValidationGroup="uploadList">Adicionar arquivo</asp:LinkButton>
		<br />
		<br />
		<asp:GridView ID="grdLista" runat="server" AutoGenerateColumns="False" BackColor="White"
			BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" CellSpacing="2"
			ForeColor="Black" GridLines="Vertical" DataKeyNames="arquivo" OnRowDeleting="grdLista_RowDeleting">
			<RowStyle BackColor="#F7F7DE" HorizontalAlign="Center" />
			<FooterStyle BackColor="#CCCC99" />
			<PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
			<SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
			<HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:BoundField DataField="titulo" HeaderText="Titulo">
					<ItemStyle Width="125px" />
				</asp:BoundField>
				<asp:BoundField DataField="arquivo" HeaderText="Arquivos">
					<ItemStyle Width="235px" />
				</asp:BoundField>
				<asp:TemplateField>
					<ItemTemplate>
						<asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Remover"
							OnClientClick="javascript : return confirm('Deseja remover este item?');">
						</asp:LinkButton>
					</ItemTemplate>
					<ItemStyle Width="60px" />
				</asp:TemplateField>
			</Columns>
		</asp:GridView>
		<br />
	</ContentTemplate>
</asp:UpdatePanel>
