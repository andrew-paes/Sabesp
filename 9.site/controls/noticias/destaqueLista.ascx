<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueLista.ascx.cs"
	Inherits="controls_noticias_destaqueLista" %>
<asp:Repeater ID="rptDestaques" runat="server" OnItemDataBound="rptDestaques_ItemDataBound">
	<HeaderTemplate>
		<ul class="newsList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li>
			<div id="divImg" runat="server" class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
			</div>
			<asp:HyperLink ID="hlTitulo" runat="server">
				<strong>
					<asp:Literal ID="ltrTitulo" runat="server" /></strong><br />
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
	</ItemTemplate>
	<AlternatingItemTemplate>
		<li>
			<div id="divImg" runat="server" class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
			</div>
			<asp:HyperLink ID="hlTitulo" runat="server">
				<strong>
					<asp:Literal ID="ltrTitulo" runat="server" /></strong><br />
				<asp:Label ID="lblChamada" runat="server" />
			</asp:HyperLink>
		</li>
		<li id="li" runat="server" class="quebra">
			<!-- -->
		</li>
	</AlternatingItemTemplate>
	<FooterTemplate>
		</ul>
	</FooterTemplate>
</asp:Repeater>
