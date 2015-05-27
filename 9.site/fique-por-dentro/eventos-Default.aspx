<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="eventos-Default.aspx.cs" Inherits="eventos_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<div class="colLeft">
	<h2><asp:Literal ID="Literal1" runat="server">Eventos</asp:Literal></h2>
	<div class="colContent">
		<%--coluna da esquerda--%>
		<div class="colContentLeft">
		    <div class="boxWhite boxWhiteMed">
		        <div class="bgrTopRight">
		            <div class="bgrBottomRight">		            
		                <div class="bgrBottomLeft boxWhiteMedP">
							<sabesp:eventoDestaqueGrande ID="eventoDestaqueGrande1" runat="server" />
							<div class="newsListContent">
								<sabesp:eventoDestaqueLista ID="eventoDestaqueLista1" runat="server" />
								<asp:HyperLink ID="hlTodosEventos" runat="server" CssClass="lnkFundoGradiente" />
							</div>		                   		                   		                
		                </div>
		            </div>
		        </div>
		    </div>
		</div>
		
		<%--coluna direita--%>
		<div class="colContentRight">
		    <sabesp:eventoMaisVistos runat="server" ID="eventoMaisVistos" />		    
		</div>
		
	</div>
	<div class="colModules">		
		<sabesp:boxZebrado runat="server" ID="boxZebrado" />		
        <sabesp:numerosBox ID="numerosBox1" runat="server" />
		<sabesp:eventoProximos runat="server" ID="eventoProximos" />		
	</div>
</div>

<div class="colRight">	
	<%--<sabesp:menuDireita runat="server" id="menuDireita" />		
	<sabesp:atendimento runat="server" ID="atendimento" />	
	<sabesp:redeSociais runat="server" ID="redeSociais" />	--%>
	<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
</div>

</asp:Content>
