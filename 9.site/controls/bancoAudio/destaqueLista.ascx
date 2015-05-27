<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueLista.ascx.cs"
	Inherits="controls_bancoAudio_destaqueLista" %>
<asp:Repeater ID="rptDestaques" runat="server" 
	onitemdatabound="rptDestaques_ItemDataBound">
	<HeaderTemplate>
		<ul class="newsList after">
	</HeaderTemplate>
	<ItemTemplate>
		<li>
			<div class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" ImageUrl="~/contents/img/FAKE_news.jpg" />
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
			<div class="image">
				<asp:Image ID="imgDestaque" AlternateText="" runat="server" ImageUrl="~/contents/img/FAKE_news.jpg" />
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
