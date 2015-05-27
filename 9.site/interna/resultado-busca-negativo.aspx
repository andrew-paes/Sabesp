<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="resultado-busca-negativo.aspx.cs" Inherits="resultado_busca_negativo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2 class="ttlBusca">
			<asp:Literal ID="ltrResultadoDaBusca" runat="server" Text="Resultado da busca"/></h2>
		<div class="colContent fullWidth busca buscaNegativo">
			<h4 class="txtNotFound">
				<%--<asp:Literal ID="Literal2" runat="server" Text="O termo" />--%>
				<asp:Literal ID="ltrTermoBuscadoNaoEncontrado" runat="server" Text="LOREM IPSUM QUO VADIS" />
				<%--<asp:Literal ID="ltrNaoFoiEncontrado" runat="server" Text="não foi encontrado."/>--%>
			</h4>
			<p>
				<asp:Literal ID="ltrFacaNovaPesquisa" runat="server" Text="Faça uma nova pesquisa ou clique aqui para ir a página inicial." />
			</p>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	</div>
</asp:Content>
