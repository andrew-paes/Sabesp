<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="esgoto.aspx.cs" Inherits="saneamento_esgoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Esgoto</asp:Literal></h2>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
				<%--############
				First
				############--%>
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
										<li class="titleList">Estações de tratamento de Esgoto </li>
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
										<li>
											<div class="image">
												<img src="../contents/img/FAKE_news.jpg" alt="" />
											</div>
											<a href="#"><strong>Sabesp e Fapesp juntas para pesquisas</strong> <span>Instituições
												têm até o dia 31 de março para inscrever projetos com resultados inovadores. Fique
												de olho.</span> </a></li>
									</ul>
									<a href="#" class="lnkFundoGradiente">> Todos os eventos</a>--%>
									<asp:Repeater ID="rptFirst" runat="server" OnItemDataBound="rptFirst_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxFirst" class="newsList after">
												<li class="titleList">Estações de tratamento de Esgoto </li>
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
				<sabesp:numerosBox ID="numerosBox1" runat="server" />
				<%--############
				Second
				############--%>
				<%--<div class="boxGray">
					<h3>
						<asp:Literal ID="Literal2" runat="server">Guia de Educação</asp:Literal></h3>
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<asp:Image ID="Image1" AlternateText=" " runat="server" ImageUrl="~/contents/img/img-atendimento.jpg" />
							<a href="#" class="lkBoxGray">Nulla dolor urna elementum at iaculis non volutp molesti.</a>
						</div>
					</div>
				</div>--%>
				<asp:Repeater ID="rptSecond" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
					<HeaderTemplate>
					</HeaderTemplate>
					<ItemTemplate>
						<div class="boxGray">
							<h3>
								<asp:Literal ID="ltlRptItensSecond" runat="server"></asp:Literal></h3>
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<asp:Image ID="imgRptItensSecond" AlternateText=" " runat="server" Width="191px" />
									<asp:HyperLink ID="hplRptItensSecond" runat="server"></asp:HyperLink>
								</div>
							</div>
						</div>
					</ItemTemplate>
					<FooterTemplate>
					</FooterTemplate>
				</asp:Repeater>
			</div>
		</div>
		<div class="colModules">
			<sabesp:widgetFlash runat="server" ID="widgetFlash1" Visible="false" />
			<sabesp:widgetFlash runat="server" ID="widgetFlash2" Visible="false" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		$(document).ready(function() {
			if ($("#boxFirst li:last").attr("class") == "quebra") {
				$("#boxFirst li:last").css("display", "none");
			}
		});
	</script>

</asp:Content>
