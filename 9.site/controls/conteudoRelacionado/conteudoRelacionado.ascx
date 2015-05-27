<%@ Control Language="C#" AutoEventWireup="true" CodeFile="conteudoRelacionado.ascx.cs"
    Inherits="controls_conteudoRelacionado_conteudoRelacionado" %>
<asp:Panel ID="pnlContent" runat="server">
    <h3 class="sub"><asp:Literal ID="ltrConteudosRelacionados" runat="server" /></h3>
    <div class="boxWhite">
        <div class="bgrTopRight">
            <div class="bgrBottomRight">
                <div class="bgrBottomLeft">
                    <ul class="listNewsRel">
                        <asp:Repeater ID="rptContent" runat="server" OnItemDataBound="rptContent_ItemDataBound">
                            <ItemTemplate>
                                <li><asp:Label ID="lblDate" runat="server" /> - <asp:HyperLink ID="hlContent" runat="server" /></li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </div>
        </div>
</asp:Panel>
