<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueHome.ascx.cs"
	Inherits="controls_produtos_destaqueHome" %>
<div class="boxWhite">
	<div class="bgrTopRight">
		<div class="bgrBottomRight">
			<div class="bgrTopLeft">
				<div class="bgrBottomLeft after">
					<div class="newsDestaque">
					    <asp:HyperLink ID="hlLinkImagem" NavigateUrl="#" runat="server">
						    <asp:Image ID="ImageMain" ImageUrl="~/contents/img/produtos_home.jpg" AlternateText=" " runat="server" />
                        </asp:HyperLink>						    
						<asp:HyperLink ID="hlProdutoMain" NavigateUrl="#" runat="server">
							<strong style="padding-bottom:0;">
								<asp:Literal ID="ltlTituloFirst" runat="server" Text="Conheça nossos produtos" />
							</strong>
							<asp:Label ID="lblDescricaoFirst" runat="server" Visible="false" />
						</asp:HyperLink>
					</div>
					<asp:Panel ID="pnlDestaque1" runat="server" CssClass="boxWhite boxGrayCutLeft">
						<div class="bgrTopRight">
							<div class="bgrBottomRight after">
								<asp:HyperLink ID="hlProdutoSecond" runat="server">
									<strong>
										<asp:Literal ID="ltlTituloSecond" runat="server" />
									</strong>
									<br />
									<asp:Label ID="lblDescricaoSecond" runat="server" />
								</asp:HyperLink>
							</div>
						</div>
					</asp:Panel>
					<asp:Panel ID="pnlDestaque2" runat="server" CssClass="boxWhite boxGrayCutLeft">
						<div class="bgrTopRight">
							<div class="bgrBottomRight after">
								<asp:HyperLink ID="hlProdutoThird" runat="server">
									<strong>
										<asp:Literal ID="ltlTituloThird" runat="server" />
									</strong>
									<br />
									<asp:Label ID="lblDescricaoThird" runat="server" />
								</asp:HyperLink>
							</div>
						</div>
					</asp:Panel>
					<asp:Panel ID="pnlDestaque3" runat="server" CssClass="boxWhite boxGrayCutLeft">
						<div class="bgrTopRight">
							<div class="bgrBottomRight after">
								<asp:HyperLink ID="hlProdutoFourth" runat="server">
									<strong>
										<asp:Literal ID="ltlTituloFourth" runat="server" />
									</strong>
									<br />
									<asp:Label ID="lblDescricaoFourth" runat="server" />
								</asp:HyperLink>
							</div>
						</div>						
					</asp:Panel>
				</div>
			</div>
		</div>
	</div>
</div>
