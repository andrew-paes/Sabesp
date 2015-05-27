<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloTextoBloco.ascx.cs"
	Inherits="CtlTituloTextoBloco" %>
<div class="boxMaisVistosB">
	<div class="boxMaisVistosC">
		<div class="boxMaisVistosHeader">
			<asp:Literal ID="ltrTitulo" runat="server" Text="Últimas" />
		</div>
		<asp:Repeater ID="rptUltimas" runat="server" OnItemDataBound="rptUltimas_ItemDataBound">
			<HeaderTemplate>
				<ul class="maisVistosList">
			</HeaderTemplate>
			<ItemTemplate>
				<li>
					<asp:HyperLink iu="hlDescricao" runat="server">
						<asp:Label ID="lblDescricao" runat="server" /></asp:HyperLink>
				</li>
			</ItemTemplate>
			<FooterTemplate>
				</ul>
			</FooterTemplate>
		</asp:Repeater>
	</div>
</div>
