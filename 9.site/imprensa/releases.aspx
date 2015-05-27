<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
    CodeFile="releases.aspx.cs" Inherits="imprensa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="colLeft">
	<h2><asp:Literal ID="Literal1" runat="server">Releases</asp:Literal></h2>
	<div class="colContent fullWidth imprensa">
		<div class="colContentLeft">
			<div class="boxMaisVistosB ultimosReleases">
				<div class="boxMaisVistosC">
					<div class="boxMaisVistosHeader"><asp:Literal ID="Literal2" runat="server">Todos os releases</asp:Literal></div>				        					
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
			</div>
			<sabesp:paginacao runat="server" id="paginacao" />
		</div>
		<div class="colContentRight">

			<%--<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<h3><asp:Literal ID="Literal3" runat="server">Cadastro de jornalista</asp:Literal></h3>
							<div class="content">
								<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna nibh.</p>
								<a href="#" class="lnkFundoGradiente">&raquo; <asp:Literal ID="Literal4" runat="server">Cadastre-se e receba novidades</asp:Literal></a>
							</div>
						</div>
					</div>
				</div>
			</div>--%>

		</div>
	</div>
</div>

<div class="colRight">
	<sabesp:atendimento runat="server" ID="atendimento" />
	<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	<sabesp:redeSociais runat="server" id="redeSociais" />
</div>

</asp:Content>
