<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ultimosReleasesHome.ascx.cs"
	Inherits="controls_releases_ultimosReleasesHome" %>
<div class="boxMaisVistosHeader">
	<asp:Literal ID="Literal1" runat="server">Últimos Releases</asp:Literal></div>
<asp:Repeater ID="rptReleases" runat="server" OnItemDataBound="rptReleases_ItemDataBound">
	<HeaderTemplate>
		<ul class="maisVistosList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li id="li" runat="server">
			<asp:HyperLink ID="hlRelease" NavigateUrl="#" runat="server">
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
	</ItemTemplate>
	<FooterTemplate>
		</ul>
		<div class="footerRelese"><!-- --></div>
	</FooterTemplate>
</asp:Repeater>
