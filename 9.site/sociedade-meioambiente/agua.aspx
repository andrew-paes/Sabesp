<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="agua.aspx.cs" Inherits="sociedade_meioambiente_agua" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Água</asp:Literal></h2>
		<div class="colContent imprensa">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="newsListContent">
								<ul class="newsList after">
									<li>
										<div class="image">
											<asp:Image ID="Image2" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Sobre a marca</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio.
											Quisque volutpat mattis eros. Nullam malesuada erat ut turpis.</span> <em>Conheça nosso
												Flickr &raquo;</em> </a></li>
									<li>
										<div class="image">
											<asp:Image ID="Image3" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Explicações Sabesp</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a></li>
									<li class="variacao">
										<div class="image">
											<asp:Image ID="Image1" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Explicações Sabesp</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a></li>
									<li class="variacao">
										<div class="image">
											<asp:Image ID="Image4" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Explicações Sabesp</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a></li>
									<li class="variacao">
										<div class="image">
											<asp:Image ID="Image5" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Explicações Sabesp</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a></li>
									<li class="variacao last">
										<div class="image">
											<asp:Image ID="Image6" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<a href="#"><strong>Explicações Sabesp</strong> <span>Lorem ipsum dolor sit amet, consectetuer
											adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat
											ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede.</span>
										</a></li>
								</ul>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
			<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
