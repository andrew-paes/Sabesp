<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ultimosReleases.ascx.cs"
	Inherits="controls_releases_ultimosReleases" %>
<asp:Repeater ID="rptReleases" runat="server" OnItemDataBound="rptReleases_ItemDataBound">
	<HeaderTemplate>
		<ul class="maisVistosList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li id="li" runat="server">
			<asp:HyperLink ID="hlRelease" runat="server">
				<%--<asp:Literal ID="ltlData" runat="server"></asp:Literal>--%>
				<strong><asp:Literal ID="ltrTitulo" runat="server" /></strong>
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
			<em>
				<sabesp:tags ID="tags1" runat="server" />
			</em></li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
