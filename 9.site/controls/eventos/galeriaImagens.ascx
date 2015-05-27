<%@ Control Language="C#" AutoEventWireup="true" CodeFile="galeriaImagens.ascx.cs"
    Inherits="controls_eventos_galeriaImagens" %>
<div class="galeriaModal">
    <div class="galeriaModalCrop">
        <span class="titleBox"><asp:Literal ID="Literal1" runat="server">Fotos do Evento</asp:Literal></span>
        <asp:Repeater ID="rptImagens" runat="server" OnItemDataBound="rptImagens_ItemDataBound">
            <HeaderTemplate>
                <ul class="galeriaList after">
            </HeaderTemplate>
            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="hlGaleria" runat="server" rel="galeria">
                        <span>
                            <asp:Image ID="imgDestaque" Height="65" width="98" AlternateText="" runat="server" />                            
                        </span>
                        <asp:Literal ID="ltrDescricao" runat="server" />
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
           
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
