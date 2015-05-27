<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listaProdutos.ascx.cs"
	Inherits="controls_produtos_listaProdutos" %>
<div class="content">
	<asp:Repeater ID="rptDestaques" runat="server" OnItemDataBound="rptDestaques_ItemDataBound">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<asp:HyperLink ID="hlTitulo" runat="server">
					<strong>
						<asp:Literal ID="ltrTitulo" runat="server" />
					</strong>
				</asp:HyperLink>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>
