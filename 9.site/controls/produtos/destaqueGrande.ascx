<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueGrande.ascx.cs"
    Inherits="controls_produtos_destaqueGrande" %>
<asp:Panel ID="pnlDestaque" runat="server">
    <div id="divImgDestaque" runat="server" class="image after">
        <asp:Image ID="imgDestaque" AlternateText="" runat="server" />
    </div>
    <asp:HyperLink ID="hlTitulo" runat="server">
        <strong>
            <asp:Literal ID="ltrTitulo" runat="server" />
        </strong>
        <asp:Label ID="lblChamada" runat="server" />
    </asp:HyperLink>
</asp:Panel>
