<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="social_Ambiental_Default" Debug="true" %>

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
				<%--############
				Second
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxSecond" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgSecondItem" AlternateText="" runat="server" Width="393px" />
									</div>
									<asp:HyperLink ID="hplSecondItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptSecond" runat="server" OnItemDataBound="rptSecond_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxSecond" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensSecond" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensSecond" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensSecond" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensSecond" runat="server"></asp:HyperLink>
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
			<div class="colContentRight">
				<div class="boxDivider">
					<asp:HyperLink ID="clubinhoSabesp" Target="_blank" NavigateUrl="http://www.clubinhosabesp.com.br/"
						ToolTip="Clubinho Sabesp" runat="server">
						<asp:Image ID="Image6" ImageUrl="~/contents/img/img-clubinho-sabesp.gif" runat="server" />
					</asp:HyperLink>
				</div>
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
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
				<%--<h3 class="boxTitulo">
					<asp:Literal ID="Literal4" runat="server">Transparência</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="Image12" AlternateText="" ImageUrl="~/contents/img/FAKE_transparencia.jpg" runat="server" />
									</div>
									<a href="#"><strong>Conferência de gestão ambiental</strong> <span>Nulla dolor urna
										elementum at iaculis non volutpat molestie magna. Aenean quis quam ut nulla ullamcorper
										aliquet sit amet eget turpis. Suspendisse potenti. Curabitur lobortis tincidunt
										erat feugiat pellentesque.</span> </a>
								</div>
							</div>
						</div>
					</div>
				</div>--%>
				<%--############
				Fourth
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxFourth" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgFourthItem" AlternateText="" runat="server" Width="384px" />
									</div>
									<asp:HyperLink ID="hplFourthItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptFourth" runat="server" OnItemDataBound="rptFourth_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxFourth" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFourth" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFourth" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFourth" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFourth" runat="server"></asp:HyperLink>
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
	</div>
	<%--
	<div class="colRight">
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
	--%>
	<div class="colRight">
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		$(document).ready(function() {
			if ($("#boxThird li:last").attr("class") == "quebra") {
				$("#boxThird li:last").css("display", "none");
			}

			if ($("#boxFourth li:last").attr("class") == "quebra") {
				$("#boxFourth li:last").css("display", "none");
			}
		});
	</script>

</asp:Content>
