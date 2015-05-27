<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloLinkZebrado.ascx.cs"
	Inherits="CtlTituloLinkZebrado" %>
<div class="boxWhite boxWhitePeq">
	<div class="bgrTopRight">
		<div class="bgrBottomRight">
			<div class="bgrBottomLeft">
				<h3>
					<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h3>
				<asp:Repeater ID="rptBox" runat="server">
					<HeaderTemplate>
						<ul id="tituloLinkZebrado" class="boxWhiteZebrado">
					</HeaderTemplate>
					<ItemTemplate>
						<li>
							<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
						</li>
					</ItemTemplate>
					<AlternatingItemTemplate>
						<li class="alt">
							<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
						</li>
					</AlternatingItemTemplate>
					<FooterTemplate>
						</ul>
					</FooterTemplate>
				</asp:Repeater>
			</div>
		</div>
	</div>
</div>
