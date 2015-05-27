<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="templates.aspx.cs" Inherits="templates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="colLeft">
	<h2>Notícias da SABESP no seu celular</h2>
	<div class="colContent">

		<div style="padding:10px 0; margin:20px 0; border:1px red solid; border-left:0; border-right:0;">
			User Id: <asp:Label ID="lblUser" runat="server" />
			<br />
			Texto Multi-idioma: <asp:Label ID="lblTextoMultiIdioma" runat="server" />
		</div>

		<%--EXPANSIVEL--%>
		<br /><br />
		<dl class="expansivel">
		    <dt>
		        <span>Link do menu</span>
		    </dt>		    
		    <dd>
		        <div class="bgBottom">
		            <div class="ddC">
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		            </div>
		        </div>
		    </dd>    
		</dl>
		<br /><br />
		<dl class="expansivel">
		    <dt>
		        <span>Link do menu</span>
		    </dt>		    
		    <dd>
		        <div class="bgBottom">
		            <div class="ddC">
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		                <p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
		            </div>
		        </div>
		    </dd>    
		</dl>

		<!-- ABAS -->
		<div class="abas">
			<ul>
				<li><a href="#aba1"><span>Índices de atendimento</span></a></li>
				<li class="on"><a href="#aba2"><span>Interior e litoral</span></a></li>
				<li><a href="#aba3"><span>Região metropolitana</span></a></li>
			</ul>
			<div id="aba1" class="boxWhite abaContent">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<p>ABA UUUMMM - Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.</p>
							<p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam.</p>
							<p>Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
						</div>
					</div>
				</div>
			</div>
			<div id="aba2" class="boxWhite abaContent on">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<p>ABA DOOOIISSSSSS - Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.</p>
							<p>Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
						</div>
					</div>
				</div>
			</div>
			<div id="aba3" class="boxWhite abaContent">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<p>ABA TREEEESSSS - Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis rutrum.</p>
							<p>Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.</p>
						</div>
					</div>
				</div>
			</div>
			<div class="clr"><!-- --></div>
		</div>
		<!-- // ABAS -->

    <br /><br />
    
    <div class="boxWhite bwHeaderBottom">
		    <div class="bgrTop">
		        <div class="bgrBottom">
		            <div class="bgrTopRight">
		                <div class="bgrBottomRight">
		                    <div class="bgrBottomLeft">
		                        <br /><br /><br /><br /><br /><br />
		                        asdasdasdasdasd
		                        <br /><br /><br /><br /><br /><br />
		                    </div>
		                </div>
		            </div>
		        </div>
		    </div>
		</div>

	</div>

	<div class="colModules">
		<sabesp:boxAzulEsq runat="server" id="boxAzulEsq" />
		<sabesp:numerosBox ID="numerosBox1" runat="server" />
		<sabesp:boxZebrado runat="server" ID="boxZebrado" />
		<sabesp:eventos runat="server" ID="eventos" />
		<sabesp:ultimas runat="server" ID="ultimas" />
	</div>

</div>

<div class="colRight">
	<sabesp:menuDireita ID="menuDireita" runat="server" />
	<sabesp:twitter ID="twitter1" runat="server" />
	<sabesp:redeSociais runat="server" ID="redeSociais" />
	<sabesp:boxAzulDir runat="server" id="boxAzulDir" />
	<sabesp:atendimento runat="server" ID="atendimento" />
    <sabesp:solucoesAmbientais runat="server" ID="solucoesAmbientais" />    
    <%--<sabesp:solucoesAmbientaisLink runat="server" ID="solucoesAmbientaisLink" />    --%>
    <sabesp:suaRegiao runat="server" ID="suaRegiao" />
    <sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
</div>

</asp:Content>
