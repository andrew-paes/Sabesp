<%@ Control Language="C#" AutoEventWireup="true" CodeFile="categoriaFaq.ascx.cs"
    Inherits="categoriaFaq" %>
<div class="boxWhite boxWhitePeq">
    <div class="bgrTopRight">
        <div class="bgrBottomRight">
            <div class="bgrBottomLeft">
                <h3>
                    <asp:Literal ID="ltrAssuntos" text="Assuntos" runat="server"/></h3>
                <ul class="boxWhiteZebrado">
                    <asp:Repeater ID="rptCategoria" runat="server" OnItemDataBound="rptCategoria_ItemDataBound">
                        <ItemTemplate>
                            <li>
                                <asp:HyperLink ID="hlComunicado" NavigateUrl="#" runat="server" />
                            </li>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <li class="alt">
                                <asp:HyperLink ID="hlComunicado" NavigateUrl="#" runat="server" />
                            </li>
                        </AlternatingItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</div>
