<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
    AutoEventWireup="true" CodeFile="comunicados-Detalhes.aspx.cs" Inherits="fique_por_dentro_comunicados_Detalhes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="colLeft">
        <h2><asp:Literal ID="Literal1" runat="server">COMUNICADOS</asp:Literal></h2>
        <div class="colContent">
            <h3 class="sub">
                <asp:Literal ID="ltrTituloComunicado" runat="server" />
            </h3>
            <div class="boxWhite bwHeaderBottom">
                <div class="bgrTop">
                    <div class="bgrBottom">
                        <div class="bgrTopRight">
                            <div class="bgrBottomRight">
                                <div class="bgrBottomLeft boxNewsDetalhe">
                                    <div class="header after">
                                        <asp:Label ID="lblAutor" runat="server" CssClass="autor" />&nbsp;<asp:Label ID="lblData"
                                            runat="server" CssClass="data" />
                                        <%--<span class="autor">Lorem Ipsum</span> <span class="data">09/10/2009 às 17:02</span>--%>
                                    </div>
                                    <div class="newsContent">
                                        <p><asp:Literal ID="ltrComunicado" runat="server" /></p>
                                    </div>
                                    <div class="tagsContent">
                                        <sabesp:tags ID="tags1" runat="server" />
                                    </div>
                                    <sabesp:conteudoAvaliacao ID="conteudoAvaliacao" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <br />
            <br />
			
			<sabesp:conteudoRelacionado runat="server" ID="conteudoRelacionado1" />

        </div>
        <div class="colModules">
            <sabesp:boxZebrado runat="server" ID="boxZebrado" />
            <sabesp:numerosBox ID="numerosBox1" runat="server" />
            <%//<sabesp:maisVistos runat="server" ID="maisVistos" />%>
        </div>
    </div>
    <div class="colRight">
        <%--<sabesp:suaRegiao runat="server" ID="suaRegiao" />
        <sabesp:twitter runat="server" ID="twitter" />
        <sabesp:boxAzulDir runat="server" ID="sabespEnsina" />
        <sabesp:redeSociais runat="server" ID="redeSociais" />--%>
        <sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
    </div>
</asp:Content>
