<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueLista.ascx.cs"
	Inherits="controls_podcasts_destaqueLista" %>
<asp:Repeater ID="rptDestaques" runat="server" 
	onitemdatabound="rptDestaques_ItemDataBound">
	<HeaderTemplate>
		<ul class="newsList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li>
			<asp:HyperLink ID="hlTitulo" runat="server">
				<strong>
					<asp:Literal ID="ltrTitulo" runat="server" />
				</strong>
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
	</ItemTemplate>
	<AlternatingItemTemplate>
		<li>
			<asp:HyperLink ID="hlTitulo" runat="server">
				<strong>
					<asp:Literal ID="ltrTitulo" runat="server" />
				</strong>
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
		<li id="li" runat="server" class="quebra"><!-- --></li>
	</AlternatingItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
