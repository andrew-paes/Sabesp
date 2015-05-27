﻿<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
    CodeFile="noticias-Lista.aspx.cs" Inherits="noticias_Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="colLeft">
        <h2><asp:Literal ID="Literal1" runat="server">NOTÍCIAS</asp:Literal></h2>
        <div class="colContent">
            <div class="boxWhite">
                <div class="bgrTopRight">
                    <div class="bgrBottomRight">
                        <div class="bgrBottomLeft boxNewsDetalhe">
                            <asp:ListView ID="lstNoticias" runat="server" OnItemDataBound="lstNoticias_ItemDataBound"
                                OnPagePropertiesChanging="lstNoticias_PagePropertiesChanging">
                                <LayoutTemplate>
                                    <ul class="maisVistosList comunicadosList after">
                                        <asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
                                    </ul>
                                </LayoutTemplate>
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink ID="hlNoticia" runat="server">
                                            <asp:Label ID="lblData" runat="server" CssClass="data" />&nbsp;<asp:Label ID="lblTitulo"
                                                runat="server" CssClass="ttl" />
                                            &nbsp;<asp:Label ID="lblTexto" runat="server" CssClass="txt" />
                                        </asp:HyperLink>
                                </ItemTemplate>
                            </asp:ListView>
                            <asp:Panel ID="pnlPaginacao" runat="server" CssClass="paginacao after">
                                <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstNoticias" PageSize="8">
                                    <Fields>
                                        <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btPrev" PreviousPageText=""
                                            ShowNextPageButton="False" />
                                        <asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="atv" />
                                        <asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btNext" ShowPreviousPageButton="False" />
                                    </Fields>
                                </asp:DataPager>
                            </asp:Panel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="colModules">
            <sabesp:boxZebrado runat="server" ID="boxZebrado" />
            <sabesp:numerosBox ID="numerosBox1" runat="server" />
            <sabesp:noticiaMaisVistos runat="server" ID="noticiaMaisVistos" />
        </div>
    </div>
    <div class="colRight">
        <%--<sabesp:suaRegiao runat="server" ID="suaRegiao" />
        <sabesp:twitter runat="server" ID="twitter" />
        <sabesp:redeSociais runat="server" ID="redeSociais" />
        <sabesp:boxAzulDir runat="server" ID="sabespEnsina" />--%>
        <sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
    </div>
</asp:Content>
