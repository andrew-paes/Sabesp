<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
    CodeFile="infograficos-Lista.aspx.cs" Inherits="infograficos_Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="colLeft">
	<h2><asp:Literal ID="Literal1" runat="server">Infográficos</asp:Literal></h2>
	<div class="colContent fullWidth imprensa">
		<div class="colContentLeft">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="newsListContent">							
                               <asp:Repeater ID="rptInfograficos" runat="server" OnItemDataBound="rptInfograficos_ItemDataBound">
                                    <HeaderTemplate>
                                        <ul class="newsList after">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <li id="li" runat="server">
                                            <div class="image">
                                                <asp:Image ID="imgDestaque" AlternateText="" runat="server" />                
                                            </div>    
	                                        <asp:HyperLink ID="hlInfografico" NavigateUrl="#" rel="prettyPhoto[flash]" runat="server">
	                                            <strong><asp:Literal ID="ltrTitulo" runat="server" /></strong>
	                                            <asp:Label ID="lblDescricao" runat="server" />	
	                                            <em><asp:Literal ID="ltrAnimacao" runat="server" /></em>						
	                                        </asp:HyperLink>
	                                        
                                        </li>
                                    </ItemTemplate>  
                                             
                                    <FooterTemplate>
                                        </ul>
                                    </FooterTemplate>
                                </asp:Repeater>																						
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colContentRight">
            <sabesp:imprensaImagensSabesp runat="server" id="imprensaImagensSabesp" />
		</div>
	</div>
</div>

<div class="colRight">
	<sabesp:menuDireita runat="server" id="menuDireita" />
	<sabesp:atendimento runat="server" ID="atendimento" />
	<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	<sabesp:redeSociais runat="server" id="redeSociais" />
</div>

</asp:Content>
