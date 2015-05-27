<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueLista.ascx.cs"
	Inherits="controls_imprensa_destaqueLista" %>
<div class="newsListContent">
	<asp:Repeater ID="rptDestaques" runat="server" OnItemDataBound="rptDestaques_ItemDataBound">
		<HeaderTemplate>
			<ul class="newsList after">
				<li>
					<div id="divImage" runat="server" class="image">
						
					</div>
					<asp:HyperLink ID="hlCadastrese" runat="server" NavigateUrl="~/interna/formulario_imprensa.aspx">
						<strong>
							<asp:Literal ID="ltrCadastreSe" runat="server" Text="Cadastre-se" />
						</strong>
						<br />
						<asp:Label ID="lblTextoCadastreSe" runat="server" Text="Para receber notícias da Sabesp preencha o formulário." /><br />
					</asp:HyperLink>
				</li>
		</HeaderTemplate>
		<ItemTemplate>
			<li>
				<div id="divImage" runat="server" class="image">
					<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
				</div>
				<asp:HyperLink ID="hlTitulo" runat="server">
					<strong>
						<asp:Literal ID="ltrTitulo" runat="server" />
					</strong>
					<br />
					<asp:Label ID="lblTexto" runat="server" /><br />
					<em>
						<asp:Literal ID="ltrConheca" runat="server" /></em>
				</asp:HyperLink>
			</li>
		</ItemTemplate>
		<AlternatingItemTemplate>
			<li class="last">
				<div id="divImage" runat="server" class="image">
					<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
				</div>
				<asp:HyperLink ID="hlTitulo" runat="server">
					<strong>
						<asp:Literal ID="ltrTitulo" runat="server" />
					</strong>
					<br />
					<asp:Label ID="lblTexto" runat="server" /><br />
					<em>
						<asp:Literal ID="ltrConheca" runat="server" /></em>
				</asp:HyperLink>
		</AlternatingItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
</div>
