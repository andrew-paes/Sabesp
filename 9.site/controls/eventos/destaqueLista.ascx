<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueLista.ascx.cs"
	Inherits="controls_eventos_destaqueLista" %>
<asp:Repeater ID="rptDestaques" runat="server" 
	onitemdatabound="rptDestaques_ItemDataBound">
	<HeaderTemplate>
		<ul class="newsList after">
		<li class="titleList"><asp:Literal ID="Literal1" runat="server">Últimos Eventos</asp:Literal></li>
	</HeaderTemplate>
	<ItemTemplate>
		<li>		    
			<div id="divImg" runat="server" class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
			</div>
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
			<div id="divImg" runat="server" class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
			</div>
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
