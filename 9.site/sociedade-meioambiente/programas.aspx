<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="programas.aspx.cs" Inherits="social_Ambiental_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<%--############
				First
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxFirst" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgFirstItem" AlternateText="" runat="server" Width="393px" />
									</div>
									<asp:HyperLink ID="hplFirstItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptFirst" runat="server" OnItemDataBound="rptFirst_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxFirst" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFirst" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFirst" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFirst" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFirst" runat="server"></asp:HyperLink>
											</li>
											<li class="quebra">
												<!-- -->
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
				</div>
			    <div class="boxFlash fl mr10">
				    <asp:HyperLink ID="HyperLink4" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_agua.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image3" ImageUrl="~/contents/img/tratamento_agua.jpg" ToolTip="Tratamento Água" runat="server" /></asp:HyperLink>
			    </div>
			    <div class="boxFlash fl">
				    <asp:HyperLink ID="HyperLink2" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_esgoto_solido.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image6" ImageUrl="~/contents/img/tratamento_esgoto_solido.jpg" ToolTip="Tratamento Esgoto Sólido" runat="server" /></asp:HyperLink>
			    </div>
			    <div class="boxFlash fl mr10">
				    <asp:HyperLink ID="HyperLink5" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_esgoto_liquido.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image4" ImageUrl="~/contents/img/tratamento_esgoto_liquido.jpg" ToolTip="Tratamento Esgoto Liquído" runat="server" /></asp:HyperLink>
			    </div>		
			    <div class="boxFlash fl">
				    <asp:HyperLink ID="HyperLink3" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/simulador.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image2" ImageUrl="~/contents/img/simulador.jpg" ToolTip="Simulador Consumo" runat="server" /></asp:HyperLink>
			    </div>					
			</div>
			<div class="colContentRight">
				<%--############
				Second
				############--%>
				<div class="boxDivider">
					<div class="boxWhite boxGreen">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<h3>
										<asp:Literal ID="ltlBoxSecond" runat="server"></asp:Literal>
									</h3>
									<div class="imagem">
										<asp:Image ID="imgSecondItem" ImageUrl="~/contents/img/FAKE_news.jpg" runat="server"
											Width="184" />
									</div>
									<div class="p10">
										<span>
											<%--<asp:Literal ID="ltrTexto" runat="server" /></span>--%>
											<asp:HyperLink ID="hplSecondItem" runat="server"></asp:HyperLink>
									</div>
									<div class="content">
										<asp:Repeater ID="rptSecond" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
											<HeaderTemplate>
												<ul id="boxSecond">
											</HeaderTemplate>
											<ItemTemplate>
												<li>
													<asp:HyperLink ID="hplRptItensSecond" runat="server"></asp:HyperLink>
												</li>
											</ItemTemplate>
											<FooterTemplate>
												</ul>
											</FooterTemplate>
										</asp:Repeater>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider last">
					<sabesp:numerosbox id="numerosBox1" runat="server" />
				</div>
				<div class="clr">
					<!-- -->
				</div>
				<%--############
				Third
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxThird" runat="server"></asp:Literal></h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxContent social">
									<div class="newsDestaque after">
										<div class="image after">
											<asp:Image ID="imgThirdItem" AlternateText="" ImageUrl="~/contents/img/FAKE_educacao.jpg"
												runat="server" />
										</div>
										<%--<a href="#"><strong>Agente da Gente</strong> <span>Nulla dolor urna elementum at iaculis
											non volutpat molestie magna. Aenean quis quam ut nulla ullamcorper aliquet sit amet
											eget turpis. Suspendisse potenti.</span> <em>Conheça o projeto &raquo;</em>
										</a>--%>
										<asp:HyperLink ID="hplThirdItem" runat="server"></asp:HyperLink>
									</div>
									<div class="newsListContent">
										<%--<ul class="newsList after">
											<li><a href="#"><strong>Abraço Verde</strong> <span>Nulla dolor urna em at iaculis non
												volutpat estie magna volutpat estie magna.</span> </a></li>
											<li><a href="#"><strong>1 Milhão de Árvores</strong> <span>Nulla dolor urna em at iaculis
												non volutpat estie magna volutpat estie magna.</span> </a></li>
											<li><a href="#"><strong>1 Milhão de Árvores</strong> <span>Nulla dolor urna em at iaculis
												non volutpat estie magna volutpat estie magna.</span> </a></li>
										</ul>--%>
										<asp:Repeater ID="rptThird" runat="server" OnItemDataBound="rptThird_ItemDataBound">
											<HeaderTemplate>
												<ul class="newsList after">
											</HeaderTemplate>
											<ItemTemplate>
												<li>
													<asp:HyperLink ID="hplRptItensThird" runat="server"></asp:HyperLink>
												</li>
											</ItemTemplate>
											<FooterTemplate>
												</ul>
											</FooterTemplate>
										</asp:Repeater>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				


			</div>				
				<%--############
				Fourth
				############--%>
				<%--<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxFourth" runat="server"></asp:Literal></h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxContent cultural">
									<div class="newsListContent">
										<ul class="newsList after">
											<li>
												<a href="#">
													<strong>Abraço Verde</strong> <span>Nulla dolor urna em at iaculis non
												volutpat estie magna volutpat estie magna. Nulla dolor urna em at iaculis non volutpat
												estie magna volutpat estie magna. Nulla dolor urna em at iaculis non volutpat estie
												magna volutpat estie magna.</span> </a></li>
										</ul>
										<asp:Repeater ID="rptFourth" runat="server" OnItemDataBound="rptFourth_ItemDataBound">
											<HeaderTemplate>
												<ul id="boxFourth" class="newsList after">
											</HeaderTemplate>
											<ItemTemplate>
												<li>
													<asp:HyperLink ID="hplRptItensFourth" runat="server"></asp:HyperLink>
												</li>
											</ItemTemplate>
											<FooterTemplate>
												</ul>
											</FooterTemplate>
										</asp:Repeater>
									</div>
								</div>
							</div>
						</div>
					</div>--%>

		</div>
	</div>
	</div>
	<%--<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>--%>
	<div class="colRight">
		<sabesp:menudireita runat="server" id="menuDireita" />
		<sabesp:segundacolunadinamica id="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		$(document).ready(function() {
			$("#boxSecond li:last").addClass("last");
			$("#boxFourth li:last").addClass("last");
		});
	</script>

</asp:Content>
