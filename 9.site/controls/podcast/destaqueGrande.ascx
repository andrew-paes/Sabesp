<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueGrande.ascx.cs"
    Inherits="controls_podcasts_destaqueGrande" %>

    <asp:HyperLink ID="hlTitulo" runat="server">
        <strong>
            <asp:Literal ID="ltrTitulo" runat="server" />
        </strong>
        <asp:Label ID="lblChamada" runat="server" />
    </asp:HyperLink>
