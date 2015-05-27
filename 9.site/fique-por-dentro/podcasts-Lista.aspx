<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="podcasts-Lista.aspx.cs" Inherits="podcasts_Lista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Rádio Sabesp</asp:Literal></h2>
		<div class="colContent">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrTopRight">&nbsp;</div>
						<div class="bgrBottomLeft boxNewsDetalhe" style="padding: 0px !important;">
							<asp:ListView ID="lstPodcasts" runat="server" OnItemDataBound="lstPodcasts_ItemDataBound"
								OnPagePropertiesChanging="lstPodcasts_PagePropertiesChanging">
								<LayoutTemplate>
									<ul class="maisVistosList comunicadosList after">
										<asp:PlaceHolder ID="itemPlaceholder" runat="server"></asp:PlaceHolder>
									</ul>
								</LayoutTemplate>
								<ItemTemplate>
									<li><i><asp:Literal ID="ltrPodcastCategoria" runat="server" /></i>
										<asp:HyperLink ID="hlPodcast" runat="server">
											<asp:Label ID="lblData" runat="server" CssClass="data" />&nbsp;<asp:Label ID="lblTitulo"
												runat="server" CssClass="ttl" />
											&nbsp;<asp:Label ID="lblTexto" runat="server" CssClass="txt" />
										</asp:HyperLink>
								</ItemTemplate>
							</asp:ListView>
							<asp:Panel ID="pnlPaginacao" runat="server" CssClass="paginacao after">
								<asp:DataPager ID="DataPager1" runat="server" PagedControlID="lstPodcasts" PageSize="8">
									<Fields>
										<asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btPrev" PreviousPageText=""
											ShowNextPageButton="False" />
										<asp:NumericPagerField ButtonCount="5" CurrentPageLabelCssClass="atv" />
										<asp:NextPreviousPagerField ButtonType="Button" ButtonCssClass="btNext" ShowPreviousPageButton="False" />
									</Fields>
								</asp:DataPager>
							</asp:Panel>
						</div>
					</div>
                   
				</div>
               
			</div>
              <br class="clr" /><br />
		</div>
		<div class="colModules">
			<sabesp:boxZebrado runat="server" ID="boxZebrado" />
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
			<sabesp:podcastMaisVistos runat="server" ID="podcastMaisVistos" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:twitter runat="server" ID="twitter" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
		<sabesp:boxAzulDir runat="server" ID="sabespEnsina" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
