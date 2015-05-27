<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="agua.aspx.cs" Inherits="saneamento_agua" %>

<%@ Register Src="../controls/flash/numerosBox.ascx" TagName="numerosBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
				<%--############
				First
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxFirst" runat="server">Teste</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<%--<img src="../contents/img/FAKE_newsDest.jpg" alt="" />--%>
										<asp:Image ID="imgFirstItem" AlternateText="" runat="server" Width="384px" />
									</div>
									<%--<a href="#"><strong>Sabesp e Fapesp juntas para pesquisas</strong> <span>Instituições
										têm até o dia 31 de março para inscrever projetos com resultados inovadores. Fique
										de olho.</span> </a>--%>
									<asp:HyperLink ID="hplFirstItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<%--<ul class="newsList after">
										<li class="titleList">Distribuição de Água </li>
										<li>
											<div class="image">
												<img src="../contents/img/FAKE_news.jpg" alt="" />
											</div>
											<a href="#"><strong>Sabesp e Fapesp juntas para pesquisas</strong> <span>Instituições
												têm até o dia 31 de março para inscrever projetos com resultados inovadores. Fique
												de olho.</span> </a></li>
										<li>
											<div class="image">
												<img src="../contents/img/FAKE_news.jpg" alt="" />
											</div>
											<a href="#"><strong>Sabesp e Fapesp juntas para pesquisas</strong> <span>Instituições
												têm até o dia 31 de março para inscrever projetos com resultados inovadores. Fique
												de olho.</span> </a></li>
										<li class="quebra">
											<!-- -->
										</li>
									</ul>
									<a href="#" class="lnkFundoGradiente">> Todas as notícias</a>--%>
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
			</div>
			<%--coluna direita--%>
			<div class="colContentRight">
				<%--############
				Second
				############--%>
				<div class="boxMaisVistos">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<h3>
								<asp:Literal ID="ltlBoxSecond" runat="server"></asp:Literal></h3>
							<%--<ul class="maisVistosList after">
								<li class="last">
									<asp:Image ID="mImage3" AlternateText=" " runat="server" ImageUrl="../contents/img/mais-vistos-img.jpg" />
									<a href="#">
										<span>
										<b>Monitoramento de Mananciais</b>
										</span>
									</a>
									<span>
									Nulla dolor urna
									elementum at iaculis non volutpat molestiedolor urna elementum at iaculis non volutpat
									molestie
									</span>
								</li>
							</ul>--%>
							<asp:Repeater ID="rptSecond" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
								<HeaderTemplate>
									<ul id="boxSecond" class="maisVistosList after">
								</HeaderTemplate>
								<ItemTemplate>
									<li>
										<asp:Image ID="imgRptItensSecond" runat="server" Width="172px" />
										<asp:HyperLink ID="hplRptItensSecond" runat="server"></asp:HyperLink>
										<span>
											<asp:Literal ID="ltlRptItensSecond" runat="server"></asp:Literal>
										</span></li>
								</ItemTemplate>
								<FooterTemplate>
									</ul>
								</FooterTemplate>
							</asp:Repeater>
						</div>
					</div>
				</div>
				<div class="clr">
					<!-- -->
				</div>
				<%--############
				Third
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxThird" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgThirdItem" AlternateText="" runat="server" Width="384px" />
									</div>
									<asp:HyperLink ID="hplThirdItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptThird" runat="server" OnItemDataBound="rptThird_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxThird" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensThird" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensThird" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensThird" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensThird" runat="server"></asp:HyperLink>
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
			</div>
		</div>
		<div class="colModules">
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		$(document).ready(function() {
			if ($("#boxFirst li:last").attr("class") == "quebra") {
				$("#boxFirst li:last").css("display", "none");
			}

			if ($("#boxThird li:last").attr("class") == "quebra") {
				$("#boxThird li:last").css("display", "none");
			}

			$("#boxSecond li:last").addClass("last");
		});
	</script>

</asp:Content>
