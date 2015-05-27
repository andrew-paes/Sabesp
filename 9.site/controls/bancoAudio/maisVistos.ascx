<%@ Control Language="C#" AutoEventWireup="true" CodeFile="maisVistos.ascx.cs" Inherits="controls_bancoAudio_maisVistos" %>
<div class="boxMaisVistos">
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<h3><asp:Literal ID="ltrMaisVistos" runat="server" /></h3>
           <asp:Repeater ID="rptMaisVistos" runat="server" OnItemDataBound="rptMaisVistos_ItemDataBound">
                <HeaderTemplate>
                    <ul class="maisVistosList after">
                </HeaderTemplate>
                <ItemTemplate>
                    <li id="li" runat="server">
                        <!--<asp:Image ID="mImage1" AlternateText=" " runat="server" ImageUrl="~/contents/img/FAKE_news.jpg" />-->                
	                    <asp:HyperLink ID="hlPodcast" NavigateUrl="#" runat="server">
	                        <asp:Label ID="lblChamada" runat="server" />							
	                    </asp:HyperLink>
	                    <asp:Label ID="lblQtdVisualizacoes" runat="server" /> 
                    </li>
                </ItemTemplate>  
                         
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>				
		</div>
	</div>
</div>
