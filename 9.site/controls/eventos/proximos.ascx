<%@ Control Language="C#" AutoEventWireup="true" CodeFile="proximos.ascx.cs"
	Inherits="controls_eventos_proximos" %>
<div class="boxMaisVistosB">
    <div class="boxMaisVistosC">	
		<div class="boxMaisVistosHeader"><asp:Literal ID="Literal1" runat="server">Proximos Eventos</asp:Literal></div>
			
        <asp:Repeater ID="rptEventos" runat="server" OnItemDataBound="rptEventos_ItemDataBound">
            <HeaderTemplate>
                <ul class="maisVistosList after">
            </HeaderTemplate>
            <ItemTemplate>
                <li id="li" runat="server">
	                <asp:HyperLink ID="hlEvento" NavigateUrl="#" runat="server">	                    
	                <strong><asp:Label ID="lblTitulo" runat="server" /></strong>
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
