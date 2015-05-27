<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="interna-tema.aspx.cs" Inherits="fale_conosco_interna_tema" %>

<%@ Register Src="~/controls/siteMap/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Vazamentos</asp:Literal></h2>
		<div class="colContent">
			<%--EXPANSIVEL--%>
			<h3 class="sub">
				<asp:Literal ID="Literal2" runat="server">Etiam mollis commodo tellus. Nullam ultricies dui eu diam praesent.</asp:Literal></h3>
			<dl class="expansivel">
				<dt><span>Link do menu</span> </dt>
				<dd>
					<div class="bgBottom">
						<div class="ddC">
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
						</div>
					</div>
				</dd>
			</dl>
			<dl class="expansivel">
				<dt><span>Link do menu</span> </dt>
				<dd>
					<div class="bgBottom">
						<div class="ddC">
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
							<p>
								Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
								varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
								imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
								fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
								rutrum.</p>
						</div>
					</div>
				</dd>
			</dl>
		</div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<%--<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq" />
			<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq1" />--%>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita" runat="server" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
</asp:Content>
