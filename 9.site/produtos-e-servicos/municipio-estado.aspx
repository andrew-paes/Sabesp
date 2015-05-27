<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="municipio-estado.aspx.cs" Inherits="produtos_e_servicos_municipio_estado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrTitulo" runat="server" Text="Municípios e Estados" /></h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<sabesp:listaProdutosSubHome runat="server" ID="listaProdutos" />
			</div>
			<div class="colContentRight">
				<div class="boxDivider">
					<!-- -->
					<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
					<sabesp:boxDirFoto runat="server" ID="boxDirFoto1" />
					<!-- -->
				</div>
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
				</div>
				<div class="clr">
					<!-- -->
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:boxDirFoto runat="server" ID="boxDirFoto2" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
