<%@ Control Language="C#" AutoEventWireup="true" CodeFile="maisRecentes.ascx.cs"
	Inherits="controls_podcasts_maisRecente" %>
<%--<div class="content">
	<h4 id="h4">
		<asp:HyperLink ID="hlPodcastDestaque" NavigateUrl="#" runat="server"></asp:HyperLink>
	</h4>
	<h5 id="h5">
		<asp:Literal ID="ltrMaisRecentes" runat="server" />
	</h5>
	<asp:Repeater ID="rptPodcasts" runat="server" OnItemDataBound="rptPodcasts_ItemDataBound">
		<HeaderTemplate>
			<ul id="ul">
		</HeaderTemplate>
		<ItemTemplate>
			<li id="li" runat="server">
				<asp:HyperLink ID="hlPodcast" NavigateUrl="#" ToolTip=" " runat="server">
					<strong>
						<asp:Literal ID="ltrTitulo" runat="server" /><br />
					</strong>
					<asp:Label ID="lblDescricao" runat="server" />
				</asp:HyperLink>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<asp:HyperLink ID="hlTodosPodcasts" runat="server" CssClass="lnkFundoGradiente" />
</div>--%>
<h3 class="boxTitulo ttlRadio">
	Rádio Sabesp</h3>
<div id="Div1" class="boxDivider last" runat="server" visible="true">
	<div class="boxWhite boxPurple" style="width: 400px !important;">
		<div class="bgrTopRight">
			<div class="bgrBottomRight">
				<div class="bgrBottomLeft">
					<div class="content">
						<div id="divDiario" runat="server">
							<h5>
								<asp:Literal ID="ltrDiario" runat="server" /></h5>
							<asp:Repeater ID="rptDiario" runat="server" OnItemDataBound="rptDiario_ItemDataBound">
								<HeaderTemplate>
									<ul class="radioList">
								</HeaderTemplate>
								<ItemTemplate>
									<li id="li" runat="server">
										<asp:HyperLink ID="hlPodcast" NavigateUrl="#" ToolTip=" " runat="server">
											<span>
												<asp:Literal ID="ltrTitulo" runat="server" /><br />
											</span>
										</asp:HyperLink>
									</li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div id="divSemanal" runat="server">
							<h5>
								<asp:Literal ID="ltrSemanal" runat="server" /></h5>
							<asp:Repeater ID="rptSemanal" runat="server" OnItemDataBound="rptSemanal_ItemDataBound">
								<HeaderTemplate>
									<ul class="radioList">
								</HeaderTemplate>
								<ItemTemplate>
									<li id="li" runat="server">
										<asp:HyperLink ID="hlPodcast" NavigateUrl="#" ToolTip=" " runat="server">
											<span>
												<asp:Literal ID="ltrTitulo" runat="server" /><br />
											</span>
										</asp:HyperLink>
									</li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<div id="divQuinzenal" runat="server">
							<h5>
								<asp:Literal ID="ltrQuinzenal" runat="server" /></h5>
							<asp:Repeater ID="rptQuinzenal" runat="server" OnItemDataBound="rptQuinzenal_ItemDataBound">
								<HeaderTemplate>
									<ul class="radioList">
								</HeaderTemplate>
								<ItemTemplate>
									<li id="li" runat="server">
										<asp:HyperLink ID="hlPodcast" NavigateUrl="#" ToolTip=" " runat="server">
											<span>
												<asp:Literal ID="ltrTitulo" runat="server" /><br />
											</span>
										</asp:HyperLink>
									</li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
						<asp:HyperLink ID="hlTodosPodcasts" runat="server" CssClass="lnkFundoGradiente" />
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
