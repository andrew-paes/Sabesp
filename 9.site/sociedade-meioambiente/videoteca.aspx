<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="videoteca.aspx.cs" Inherits="sociedade_meioambiente_videoteca" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Videoteca</asp:Literal></h2>
		<div class="colContent imprensa">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="newsListContent">
								<ul class="newsList after">
									<li class="variacao variacaoVideoteca">
										<div class="image">
											<asp:Image ID="Image1" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<div class="conteudo after">
											<p>
												Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
												varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
												imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
												fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
												rutrum.</p>
											<a href="#">Veja na TV sabesp</a> <a href="#" class="btDownload">Baixe o Arquivo</a>
										</div>
									</li>
									<li class="variacao variacaoVideoteca">
										<div class="image">
											<asp:Image ID="Image2" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<div class="conteudo after">
											<p>
												Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
												varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
												imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
												fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
												rutrum.</p>
											<a href="#">Veja na TV sabesp</a> <a href="#" class="btDownload">Baixe o Arquivo</a>
										</div>
									</li>
									<li class="variacao variacaoVideoteca">
										<div class="image">
											<asp:Image ID="Image3" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<div class="conteudo after">
											<p>
												Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
												varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
												imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
												fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
												rutrum.</p>
											<a href="#">Veja na TV sabesp</a> <a href="#" class="btDownload">Baixe o Arquivo</a>
										</div>
									</li>
									<li class="variacao variacaoVideoteca">
										<div class="image">
											<asp:Image ID="Image4" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<div class="conteudo after">
											<p>
												Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
												varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
												imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
												fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
												rutrum.</p>
											<a href="#">Veja na TV sabesp</a> <a href="#" class="btDownload">Baixe o Arquivo</a>
										</div>
									</li>
									<li class="variacao variacaoVideoteca">
										<div class="image">
											<asp:Image ID="Image5" AlternateText="" ImageUrl="~/contents/img/FAKE_mananciais.jpg" runat="server" />
										</div>
										<div class="conteudo after">
											<p>
												Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
												varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
												imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
												fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
												rutrum.</p>
											<a href="#">Veja na TV sabesp</a> <a href="#" class="btDownload">Baixe o Arquivo</a>
										</div>
									</li>
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
