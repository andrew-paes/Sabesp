<%@ Control Language="C#" AutoEventWireup="true" CodeFile="menu-direita.ascx.cs"
    Inherits="controls_menu_direita" %>
<asp:Repeater ID="rptMenuLateral" runat="server" OnItemDataBound="rptMenuLateral_ItemDataBound">
    <HeaderTemplate>
        <ul class="menuDireita">
    </HeaderTemplate>
    <ItemTemplate>
        <li id="liMenuLateral" runat="server">
            <asp:Label ID="lblItemMenu" runat="server">
                <asp:HyperLink ID="hlItemMenu" runat="server" />
            </asp:Label>
            <asp:Repeater ID="rptItemSubMenu" runat="server" OnItemDataBound="rptItemSubMenu_ItemDataBound">
                <HeaderTemplate>
                    <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li id="liSubMenuLateral" runat="server">
                        <asp:HyperLink ID="hlItemSubMenu" runat="server" />
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>
        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
    </FooterTemplate>
</asp:Repeater>
<%--<ul class="menuDireita">
    <li class="on"><span><a href="#">Água</a></span>
        <ul>
            <li><a href="#">Água no planeta</a></li>
            <li><a href="#">No fundo da terra</a></li>
            <li><a href="#">Dessalinização</a></li>
            <li><a href="#" class="on">Elementos químicos</a></li>
            <li><a href="#">Enchentes</a></li>
            <li><a href="#">Mananciais</a></li>
            <li><a href="#">Poços artesianos</a></li>
            <li><a href="#">Água virtual</a></li>
            <li class="last"><a href="#">Reúso planejado</a></li>
        </ul>
    </li>
    <li><span><a href="#">Esgoto</a></span>
        <ul>
            <li><a href="#">Água no planeta</a></li>
            <li><a href="#">No fundo da terra</a></li>
            <li><a href="#">Dessalinização</a></li>
            <li><a href="#">Elementos químicos</a></li>
            <li><a href="#">Enchentes</a></li>
            <li><a href="#">Mananciais</a></li>
            <li><a href="#">Poços artesianos</a></li>
            <li><a href="#">Água virtual</a></li>
            <li class="last"><a href="#">Reúso planejado</a></li>
        </ul>
    </li>
</ul>--%>
