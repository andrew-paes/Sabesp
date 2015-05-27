<%@ Control Language="C#" AutoEventWireup="true" CodeFile="regiao.ascx.cs" Inherits="content_module_regiao_regiao" %>
<br />
<strong>Região: </strong>
<br />
<asp:TextBox ID="txtTitulo" MaxLength="50" runat="server" Width="400px" />&nbsp;<asp:RequiredFieldValidator
	ID="rfvTitulo" runat="server" ControlToValidate="txtTitulo" ValidationGroup="1"
	ErrorMessage="Campo obrigatório" ForeColor="Red"></asp:RequiredFieldValidator>
<br />
<br />
<asp:Panel ID="pnlMunicipioRelacionado" runat="server">
	<asp:DropDownList ID="ddlPesquisaMunicipio" Width="400px" OnSelectedIndexChanged="ddlPesquisaMunicipio_SelectedIndexChanged"
		AutoPostBack="true" runat="server">
		<asp:ListItem Text=":: Filtro ::" Value=""></asp:ListItem>
		<asp:ListItem Text="A - Municipios que começam com 'A'" Value="A"></asp:ListItem>
		<asp:ListItem Text="B - Municipios que começam com 'B'" Value="B"></asp:ListItem>
		<asp:ListItem Text="C - Municipios que começam com 'C'" Value="C"></asp:ListItem>
		<asp:ListItem Text="D - Municipios que começam com 'D'" Value="D"></asp:ListItem>
		<asp:ListItem Text="E - Municipios que começam com 'E'" Value="E"></asp:ListItem>
		<asp:ListItem Text="F - Municipios que começam com 'F'" Value="F"></asp:ListItem>
		<asp:ListItem Text="G - Municipios que começam com 'G'" Value="G"></asp:ListItem>
		<asp:ListItem Text="H - Municipios que começam com 'H'" Value="H"></asp:ListItem>
		<asp:ListItem Text="I - Municipios que começam com 'I'" Value="I"></asp:ListItem>
		<asp:ListItem Text="J - Municipios que começam com 'J'" Value="J"></asp:ListItem>
		<asp:ListItem Text="K - Municipios que começam com 'K'" Value="K"></asp:ListItem>
		<asp:ListItem Text="L - Municipios que começam com 'L'" Value="L"></asp:ListItem>
		<asp:ListItem Text="M - Municipios que começam com 'M'" Value="M"></asp:ListItem>
		<asp:ListItem Text="N - Municipios que começam com 'N'" Value="N"></asp:ListItem>
		<asp:ListItem Text="O - Municipios que começam com 'O'" Value="O"></asp:ListItem>
		<asp:ListItem Text="P - Municipios que começam com 'P'" Value="P"></asp:ListItem>
		<asp:ListItem Text="Q - Municipios que começam com 'Q'" Value="Q"></asp:ListItem>
		<asp:ListItem Text="R - Municipios que começam com 'R'" Value="R"></asp:ListItem>
		<asp:ListItem Text="S - Municipios que começam com 'S'" Value="S"></asp:ListItem>
		<asp:ListItem Text="T - Municipios que começam com 'T'" Value="T"></asp:ListItem>
		<asp:ListItem Text="U - Municipios que começam com 'U'" Value="U"></asp:ListItem>
		<asp:ListItem Text="V - Municipios que começam com 'V'" Value="V"></asp:ListItem>
		<asp:ListItem Text="W - Municipios que começam com 'W'" Value="W"></asp:ListItem>
		<asp:ListItem Text="X - Municipios que começam com 'X'" Value="X"></asp:ListItem>
		<asp:ListItem Text="Y - Municipios que começam com 'Y'" Value="Y"></asp:ListItem>
		<asp:ListItem Text="Z - Municipios que começam com 'Z'" Value="Z"></asp:ListItem>
	</asp:DropDownList>
	<br />
	<br />
	<table>
		<tr>
			<td>
				<asp:Label ID="lblSelecione" runat="server" Font-Bold="true" Text="Selecione"></asp:Label>
			</td>
			<td>
			</td>
			<td>
				<asp:Label ID="lblSelecionadas" runat="server" Font-Bold="true" Text="Selecionados"></asp:Label>
			</td>
		</tr>
		<tr>
			<td>
				<asp:ListBox SelectionMode="Multiple" CssClass="frmborder" runat="server" Width="400px"
					Height="300px" ID="lstOrigem"></asp:ListBox>
			</td>
			<td>
				<div style="vertical-align: top;">
					<center>
						<asp:Button runat="server" ID="btnAdicionar" Text=">" OnClick="btnAdicionar_Click"
							Width="80px" />
						<br />
						<br />
						<asp:Button runat="server" ID="btnAdicionarT" Text=">>" OnClick="btnAdicionarT_Click"
							Width="80px" />
						<br />
						<br />
						<asp:Button runat="server" ID="btnRemover" Text="<" OnClick="btnRemover_Click" Width="80px" />
						<br />
						<br />
						<asp:Button runat="server" ID="btnRemoverT" Text="<<" Width="80px" OnClick="btnRemoverT_Click" />
						<br />
						<br />
					</center>
				</div>
			</td>
			<td>
				<asp:ListBox SelectionMode="Multiple" CssClass="frmborder" runat="server" Width="400px"
					Height="300px" ID="lstDestino"></asp:ListBox>
			</td>
		</tr>
	</table>
	<br />
	<br />
	<%--
	<asp:CheckBoxList ID="chbMunicipio" runat="server" RepeatDirection="Horizontal" RepeatColumns="4">
	</asp:CheckBoxList>
	--%>
</asp:Panel>
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
