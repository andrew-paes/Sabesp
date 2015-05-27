<%@ Control Language="C#" AutoEventWireup="true" CodeFile="listaProdutosSubHome.ascx.cs"
	Inherits="controls_produtos_listaProdutosSubHome" %>
<asp:Repeater ID="rptContent" runat="server" OnItemDataBound="rptContent_ItemDataBound">
	<ItemTemplate>
		<div class="boxWhite bwHeader">
			<div class="bgrBottom">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft bgNone">
							<div class="header after">
								<asp:Label ID="lblTitulo" runat="server"></asp:Label>
							</div>
							<asp:Image ID="imgEmpresa" ImageUrl="~/contents/img/FAKE_transparencia.jpg" Width="190"
								Height="130" runat="server" CssClass="fl" />
							<div class="blocoTexto fl">
								<asp:Literal ID="ltlTexto" runat="server"/>
								<br />
								<br />
								<asp:HyperLink ID="hypTexto" runat="server" class="btn-conheca" />
							</div>
							<br class="clr" />
						</div>
					</div>
				</div>
			</div>
		</div>
	</ItemTemplate>
</asp:Repeater>
