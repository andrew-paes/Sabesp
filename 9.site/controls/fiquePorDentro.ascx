<%@ Control Language="C#" AutoEventWireup="true" CodeFile="fiquePorDentro.ascx.cs"
	Inherits="fiquePorDentro" %>
<div class="boxMaisVistosB">
	<div class="boxMaisVistosC">
		<div class="boxMaisVistosHeader">
			<asp:Literal ID="ltrTitulo" runat="server" Text="Fique Por Dentro" />
		</div>
		<ul class="maisVistosListZebrado">
			<li id="liNoticias" runat="server">
				<asp:Label ID="lblNoticias" runat="server" Text="Notícias" />
				<asp:Repeater id="rptNoticias" runat="server" OnItemDataBound="rptNoticias_ItemDataBound">
					<ItemTemplate>
						<strong><asp:Literal ID="ltrData" runat="server" /></strong>&nbsp;-&nbsp;<asp:HyperLink ID="hlConteudo" runat="server" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
			<li id="liComunicados" runat="server">
				<asp:Label ID="lblComunicados" runat="server" Text="Comunicados" />
				<asp:Repeater id="rptComunicados" runat="server" OnItemDataBound="rptComunicados_ItemDataBound">
					<ItemTemplate>
						<strong><asp:Literal ID="ltrData" runat="server" /></strong>&nbsp;-&nbsp;<asp:HyperLink ID="hlConteudo" runat="server" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
			<li id="liPodcasts" runat="server">
				<asp:Label ID="lblPodcast" runat="server" Text="Podcasts" />
				<asp:Repeater id="rptPodcast" runat="server" OnItemDataBound="rptPodcast_ItemDataBound">
					<ItemTemplate>
						<strong><asp:Literal ID="ltrData" runat="server" /></strong>&nbsp;-&nbsp;<asp:HyperLink ID="hlConteudo" runat="server" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
			<li id="liTvSabesp" runat="server">
				<asp:Label ID="lblTvSabesp" runat="server" Text="TV Sabesp" />
				<asp:Repeater id="rptTvSabesp" runat="server" OnItemDataBound="rptTvSabesp_ItemDataBound">
					<ItemTemplate>
						<strong><asp:Literal ID="ltrData" runat="server" /></strong>&nbsp;-&nbsp;<asp:HyperLink ID="hlConteudo" runat="server" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
			<li id="liEventos" runat="server">
				<asp:Label ID="lblEvento" runat="server" Text="Eventos" />
				<asp:Repeater id="rptEventos" runat="server" OnItemDataBound="rptEventos_ItemDataBound">
					<ItemTemplate>
						<strong><asp:Literal ID="ltrData" runat="server" /></strong>&nbsp;-&nbsp;<asp:HyperLink ID="hlConteudo" runat="server" />
					</ItemTemplate>
				</asp:Repeater>
			</li>
		</ul>
	</div>
</div>
