<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="educacao.aspx.cs" Inherits="social_Ambiental_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2><asp:Literal ID="Literal1" runat="server">Educação</asp:Literal></h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<h3 class="boxTitulo"><asp:Literal ID="Literal2" runat="server">Água</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="Image1" AlternateText="" ImageUrl="~/contents/img/FAKE_newsDest.jpg" runat="server" />
									</div>
									<a href="#">
										<strong>Água e Saúde</strong>
										<span>Nulla dolor urna elementum at iaculis non volutpat molestie magna. Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis. Suspendisse potenti. Curabitur lobortis tincidunt erat feugiat pellentesque. Nunc vehicula; velit ut faucibus scelerisque, dolor nibh cursus eros, pulvinar.</span>
									</a>
								</div>
								<div class="newsListContent">
									<ul class="newsList after">
										<li>
											<div class="image">
												<asp:Image ID="Image2" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
											</div>
											<a href="#">
												<strong>Água no Planeta</strong>
												<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
											</a>
										</li>
										<li>
											<div class="image">
												<asp:Image ID="Image3" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
											</div>
											<a href="#">
												<strong>No fundo da terra</strong>
												<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
											</a>
										</li>
										<li class="quebra"><!-- --></li>
										<li>
											<div class="image">
												<asp:Image ID="Image4" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
											</div>
											<a href="#">
												<strong>Conheça o Ciclo da água</strong>
												<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
											</a>
										</li>
										<li>
											<div class="image">
												<asp:Image ID="Image5" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
											</div>
											<a href="#">
												<strong>Enchentes </strong>
												<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
											</a>
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider">
				    <h3 class="boxTitulo"><asp:Literal ID="Literal3" runat="server">Esgoto</asp:Literal></h3>
					<div class="boxWhite boxBranco">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<div class="imagem">
										<asp:Image ID="Image15" ImageUrl="~/contents/img/FAKE_news.jpg" runat="server" />
									</div>
									<div class="content">
										<ul>
											<li>
												<a href="#" title=" " id="link1">
													<strong>Ciclo do Saneamento</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
											<li>
												<a href="#" title=" " id="link2">
													<strong>Lodos Ativados</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
											<li class="last">
												<a href="#" title=" " id="A1">
													<strong>Voce sabe o que é BDO?</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider last">
                    <h3 class="boxTitulo"><asp:Literal ID="Literal4" runat="server">Saúde</asp:Literal></h3>
					<div class="boxWhite boxBranco">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<div class="content">
										<ul>
											<li>
												<a href="#" title=" " id="A2">
													<strong>Água e saúde</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
											<li class="last">
												<a href="#" title=" " id="A3">
													<strong>Dengue</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<div class="boxDivider">
					<asp:Image ID="Image6" ImageUrl="~/contents/img/img-clubinho-sabesp.gif" runat="server" />
				</div>
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
				</div>
				<div class="clr"><!-- --></div>
				<h3 class="boxTitulo"><asp:Literal ID="Literal5" runat="server">Material Didático</asp:Literal></h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxContent materialDidatico">
									<div class="newsListContent">
										<ul class="newsList after">
											<li>
												<div class="image">
													<asp:Image ID="Image7" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
												</div>
												<a href="#">
													<strong>Videoteca</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
											<li>
												<div class="image">
													<asp:Image ID="Image8" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
												</div>
												<a href="#">
													<strong>Uso Racional da água</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
											<li class="quebra"><!-- --></li>
											<li>
												<a href="#">
													<strong>Glossário</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
											<li>
												<a href="#">
													<strong>Reúso das águas</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
											<li class="quebra"><!-- --></li>
											<li>
												<a href="#">
													<strong>Importância da água</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
											<li>
												<a href="#">
													<strong>Crescimento Urbano</strong>
													<span>Nulla dolor urna em at iaculis non volutpat estie magna.</span>
												</a>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider">
					<h3 class="boxTitulo"><asp:Literal ID="Literal6" runat="server">Meio ambiente</asp:Literal></h3>
					<div class="boxWhite boxBranco">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
							        <div class="content">
										<ul>
											<li>
												<a href="#" title=" " id="A4">
													<strong>Protocolo de Kyoto</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
											<li>
												<a href="#" title=" " id="A5">
													<strong>Ecologia da paisagem</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
											<li class="last">
												<a href="#" title=" " id="A6">
													<strong>Poluição das águas</strong><br>
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider last">
					<h3 class="boxTitulo"><asp:Literal ID="Literal7" runat="server">Visite a Sabesp</asp:Literal></h3>
					<div class="boxWhite boxBranco">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<div class="imagem">
										<asp:Image ID="Image9" AlternateText="" ImageUrl="~/contents/img/FAKE_news.jpg" runat="server" />
									</div>
									<div class="content">
										<ul>
											<li class="last">
												<a href="#" title=" " id="A8">
													Aenean quis quam ut nulla ullamcorper aliquet sit amet eget turpis.
												</a>
											</li>
										</ul>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
