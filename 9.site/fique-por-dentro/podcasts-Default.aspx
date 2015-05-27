<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="podcasts-Default.aspx.cs" Inherits="podcasts_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Rádio Sabesp</asp:Literal></h2>
		<div class="colContent">
			<%--coluna da esquerda--%>
			<div class="colContentLeft">
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div id="divDiario" runat="server">
									<h5>
										<asp:Literal ID="ltrDiario" runat="server" /></h5>
									<div class="newsDestaque">
										<asp:HyperLink ID="hlTituloDiario" runat="server">
											<strong>
												<asp:Literal ID="ltrTituloDiario" runat="server" />
											</strong>
											<asp:Label ID="lblChamadaDiario" runat="server" />
										</asp:HyperLink>
									</div>
									<div class="newsListContent">
										<asp:Repeater ID="rptDiario" runat="server" OnItemDataBound="rptDiario_ItemDataBound">
											<HeaderTemplate>
												<ul class="newsList after">
											</HeaderTemplate>
											<ItemTemplate>
												<li>
													<asp:HyperLink ID="hlTitulo" runat="server">
														<strong>
															<asp:Literal ID="ltrTitulo" runat="server" />
														</strong>
														<asp:Label ID="lblChamada" runat="server" />
													</asp:HyperLink>
												</li>
											</ItemTemplate>
											<AlternatingItemTemplate>
												<li>
													<asp:HyperLink ID="hlTitulo" runat="server">
														<strong>
															<asp:Literal ID="ltrTitulo" runat="server" />
														</strong>
														<asp:Label ID="lblChamada" runat="server" />
													</asp:HyperLink>
												</li>
												<li id="li" runat="server" class="quebra">
													<!-- -->
												</li>
											</AlternatingItemTemplate>
											<FooterTemplate>
												</ul>
											</FooterTemplate>
										</asp:Repeater>
									</div>
								</div>
								<div id="divSemanal" runat="server">
									<h5>
										<asp:Literal ID="ltrSemanal" runat="server" /></h5>
									<div class="newsDestaque">
										<%--<a href="javascript:;"><strong>Cine Sabesp sedia Festival de Cinema Universitário</strong><span><p>
											Cine Sabesp sedia Festival de Cinema Universitário Podcast Teste</p>
										</span></a>--%>
										<asp:HyperLink ID="hlTituloSemanal" runat="server">
											<strong>
												<asp:Literal ID="ltrTituloSemanal" runat="server" />
											</strong>
											<asp:Label ID="lblChamadaSemanal" runat="server" />
										</asp:HyperLink>
									</div>
								</div>
								<div id="divQuinzenal" runat="server">
									<h5>
										<asp:Literal ID="ltrQuinzenal" runat="server" /></h5>
									<div class="newsDestaque">
										<%--<a href="javascript:;"><strong>Cine Sabesp sedia Festival de Cinema Universitário</strong><span><p>
											Cine Sabesp sedia Festival de Cinema Universitário Podcast Teste</p>
										</span></a>--%>
										<asp:HyperLink ID="hlTituloQuinzenal1" runat="server">
											<strong>
												<asp:Literal ID="ltrTituloQuinzenal1" runat="server" />
											</strong>
											<asp:Label ID="lblChamadaQuinzenal1" runat="server" />
										</asp:HyperLink>
									</div>
									<div id="divQuinzenal2" runat="server">
										<div class="newsListContent">
											<ul class="newsList2">
												<li>
													<%--<a href="javascript:;"><strong>testes</strong><span>testestestes</span></a>--%>
													<asp:HyperLink ID="hlTituloQuinzenal2" runat="server">
														<strong>
															<asp:Literal ID="ltrTituloQuinzenal2" runat="server" />
														</strong>
														<asp:Label ID="lblChamadaQuinzenal2" runat="server" />
													</asp:HyperLink>
												</li>
											</ul>
										</div>
									</div>
								</div>
								<asp:HyperLink ID="hlTodosPodcasts" runat="server" CssClass="lnkFundoGradiente" />
							</div>
						</div>
					</div>
				</div>
			</div>
            <%--coluna direita--%>
			<div class="colContentRight">
				<sabesp:podcastMaisVistos runat="server" ID="podcastMaisVistos" />
			</div>
        </div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
		</div>
    </div>
		<div class="colRight">
			<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
			<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
		</div>
</asp:Content>
