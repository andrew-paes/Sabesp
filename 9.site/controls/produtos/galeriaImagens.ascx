<%@ Control Language="C#" AutoEventWireup="true" CodeFile="galeriaImagens.ascx.cs"
    Inherits="controls_produtos_galeriaImagens" %>
<div class="galeriaModal">
    <div class="galeriaModalCrop">
        <asp:Label ID="lblTitulo" runat="server" CssClass="titleBox" Text="Fotos do Produto"/>
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
                    </asp:HyperLink>
                </li>
            </ItemTemplate>
           
            <FooterTemplate>
                </ul>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</div>
