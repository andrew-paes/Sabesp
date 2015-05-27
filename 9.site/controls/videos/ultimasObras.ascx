<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ultimasObras.ascx.cs"
	Inherits="controls_videos_ultimasObras" %>
<div class="boxMaisVistosB">
    <div class="boxMaisVistosC">
        <div class="boxMaisVistosHeader"><asp:Literal ID="ltrObras" runat="server">Obras</asp:Literal></div>
			
        <asp:Repeater ID="rptVideos" runat="server" OnItemDataBound="rptVideos_ItemDataBound">
            <HeaderTemplate>
                <ul class="maisVistosList after">
            </HeaderTemplate>
            <ItemTemplate>
                <li id="li" runat="server">
                    <asp:HyperLink ID="hlVideo" NavigateUrl="#" runat="server">
                        <strong><asp:Label runat="server" ID="lblDataHoraPublicacao"/></strong>
                        &nbsp - &nbsp
                        <asp:Label ID="lblChamada" runat="server" />							
                    </asp:HyperLink>
                </li>
            </ItemTemplate>  
                     
            <FooterTemplate>

                </ul>
            </FooterTemplate>
        </asp:Repeater>						

    </div>
</div>
