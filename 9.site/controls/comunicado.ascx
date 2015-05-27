<%@ Control Language="C#" AutoEventWireup="true" CodeFile="comunicado.ascx.cs"
	Inherits="controls_comunicado" %>	
<div class="boxDivider">
	<h3 class="boxTitulo ttlComunicado"><asp:Literal ID="Literal1" runat="server">Comunicado</asp:Literal></h3>
	<div class="boxWhite boxYellow">
		<div class="bgrTopRight">
			<div class="bgrBottomRight">
				<div class="bgrBottomLeft">
					<div class="content">									
				        <asp:Repeater ID="rptComunicados" runat="server" OnItemDataBound="rptComunicados_ItemDataBound">
                            <HeaderTemplate>
                                <ul >
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li id="li" runat="server">
                                    <asp:HyperLink ID="hlComunicado" NavigateUrl="#" runat="server">                        
                                        <strong>
	                                        <asp:Literal ID="ltrTitulo" runat="server" /><br/>
                                        </strong>
                                        <asp:Literal ID="ltrDescricao" runat="server" />

                                    </asp:HyperLink>	
                                </li>
                            </ItemTemplate>  
                            <AlternatingItemTemplate>
                                <li id="li" runat="server">
                                    <asp:HyperLink ID="hlComunicado" NavigateUrl="#" runat="server">                        
                                        <asp:Literal ID="ltrTitulo" Visible=false runat="server" /><br/>
                                        <asp:Literal ID="ltrDescricao" runat="server" />
                                    </asp:HyperLink>	                                                
                                </li>    
                            </AlternatingItemTemplate>         
                            <FooterTemplate>

                                </ul>
                            </FooterTemplate>
                        </asp:Repeater>																		
						<asp:HyperLink ID="hlTodosComunicados" runat="server" CssClass="lnkFundoGradiente" />                										
					</div>
				</div>
			</div>
		</div>
	</div>
</div>