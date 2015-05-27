<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="imprensa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrImprensa" runat="server" /></h2>
		<div class="colContent fullWidth imprensa">
			<div class="colContentLeft">
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="newsDestaque">
									<asp:Label ID="lblDescrImprensa" runat="server" />
								</div>
								<%--							<div class="newsListContent">
								<ul class="newsList after">
									<li>
										<div class="image">
											<asp:Image ID="Image2" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#">
											<strong>Sobre a marca</strong>
											<span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis.</span>
											<em>Conheça nosso Flickr &raquo;</em>
										</a>
									</li>
									<li class="last">
										<div class="image">
											<asp:Image ID="Image3" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#">
											<strong>Explicações Sabesp</strong>
											<span>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a>
									</li>
								</ul>
							</div>--%>
								<sabesp:imprensaDestaqueLista runat="server" ID="imprensaDestaqueLista" />
							</div>
						</div>
					</div>
				</div>
				<div class="boxMaisVistosB ultimosReleases">
					<div class="boxMaisVistosC">
						<div class="boxMaisVistosHeader">
							<asp:Literal ID="Literal2" runat="server">Últimos releases</asp:Literal></div>
						<sabesp:releaseUltimosReleases runat="server" ID="releaseUltimosReleases" />
					</div>
				</div>
				<%--			<div class="boxMaisVistosB ultimosReleases">
				<div class="boxMaisVistosC">
					<div class="boxMaisVistosHeader"><asp:Literal ID="Literal2" runat="server">Últimos releases</asp:Literal></div>				        
					<ul class="maisVistosList after">
						<li>
							<strong><a href="#">22/02 - Lorem ipsum dolor sit amet, consectetuer</a></strong>
							<span>Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi.</span>
							<em>Tags: <a href="#">Lorem</a>, <a href="#">Lorem</a>, <a href="#">Lorem</a></em>
						</li>
						<li>
							<strong><a href="#">22/02 - Lorem ipsum dolor sit amet, consectetuer</a></strong>
							<span>Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi.</span>
							<em>Tags: <a href="#">Lorem</a>, <a href="#">Lorem</a>, <a href="#">Lorem</a></em>
						</li>
						<li>
							<strong><a href="#">22/02 - Lorem ipsum dolor sit amet, consectetuer</a></strong>
							<span>Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi.</span>
							<em>Tags: <a href="#">Lorem</a>, <a href="#">Lorem</a>, <a href="#">Lorem</a></em>
						</li>
						<li class="last">
							<strong><a href="#">22/02 - Lorem ipsum dolor sit amet, consectetuer</a></strong>
							<span>Morbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi tincidunt ultrices lacus. Aliquam vehicula adipiscing leoMorbi.</span>
							<em>Tags: <a href="#">Lorem</a>, <a href="#">Lorem</a>, <a href="#">Lorem</a></em>
						</li>
					</ul>
				</div>
			</div>--%>
			</div>
			<%--	<div class="colContentRight">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<h3><asp:Literal ID="Literal3" runat="server">Cadastro de jornalista</asp:Literal></h3>
							<div class="content">
								<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna nibh.</p>
								<a href="#" class="lnkFundoGradiente">&raquo; Cadastre-se e receba novidades</a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>--%>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
</asp:Content>
