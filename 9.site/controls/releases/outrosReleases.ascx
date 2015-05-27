<%@ Control Language="C#" AutoEventWireup="true" CodeFile="outrosReleases.ascx.cs"
	Inherits="controls_releases_outrosReleases" %>
<div class="boxMaisVistos">
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<h3>
				<asp:Literal ID="ltrOutrosReleases" runat="server" /></h3>
			<asp:Repeater ID="rptOutrosReleases" runat="server" OnItemDataBound="rptOutrosReleases_ItemDataBound">
				<HeaderTemplate>
					<ul class="maisVistosList after">
				</HeaderTemplate>
				<ItemTemplate>
					<li id="li" runat="server">
						<asp:Label ID="lblDataPublicacao" runat="server" />
						<br/>
						<span class="bold">
							<asp:Literal ID="ltrTitulo" runat="server" />
						</span>
						<br/>
						<asp:HyperLink ID="hlRelease" NavigateUrl="#" runat="server">	                        
						</asp:HyperLink>
					</li>
				</ItemTemplate>
				<FooterTemplate>
					</ul>
				</FooterTemplate>
			</asp:Repeater>
		</div>
	</div>
</div>
