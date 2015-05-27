<%@ Control Language="C#" AutoEventWireup="true" CodeFile="maisRecentes.ascx.cs"
	Inherits="controls_bancoAudio_maisRecente" %>
		<div class="content">	
	        <h4 id="h4" style="display:">
	            <asp:HyperLink ID="hlPodcastDestaque" NavigateUrl="#" runat="server"></asp:HyperLink>			
	        </h4>
	        <h5 id="h5" style="display:">
		        <asp:Literal ID="ltrMaisRecentes" runat="server" />
	        </h5>    				
            <asp:Repeater ID="rptPodcasts" runat="server" OnItemDataBound="rptPodcasts_ItemDataBound">
                <HeaderTemplate>
			        <ul id="ul" style="display:">
                </HeaderTemplate>
                <ItemTemplate>            
                    <li id="li" runat="server">
                    <asp:HyperLink ID="hlPodcast" NavigateUrl="#" ToolTip=" " runat="server">                        
				        <strong>
					        <asp:Literal ID="ltrTitulo" runat="server" /><br/>
				        </strong>
				        <asp:Label ID="lblDescricao" runat="server" />

                    </asp:HyperLink>	
                    </li>
                </ItemTemplate>  
                         
                <FooterTemplate>
                    </ul>
                </FooterTemplate>
            </asp:Repeater>									
            <asp:HyperLink ID="hlTodosPodcasts" runat="server" CssClass="lnkFundoGradiente" />                
		</div>