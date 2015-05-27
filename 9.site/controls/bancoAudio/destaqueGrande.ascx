<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueGrande.ascx.cs"
    Inherits="controls_bancoAudio_destaqueGrande" %>
    <div class="podCastPlayerPq">
        <asp:Image ID="imgDestaque" AlternateText="" runat="server" ImageUrl="~/contents/img/FAKE_newsDest.jpg" />
    </div>
    <asp:HyperLink ID="hlTitulo" runat="server">
        <strong>
            <asp:Literal ID="ltrTitulo" runat="server" />
        </strong>
        <asp:Label ID="lblChamada" runat="server" />
    </asp:HyperLink>
