<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="rss" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>Listas RSS</h2>
			<div class="colContentLeft">
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxContent">
									<ul class="lstRSS">
										<li>
											<strong><asp:HyperLink ID="hlEvento" runat="server" Target="_blank" Text="Evento"/></strong>
										</li>
										<li>
											<strong><asp:HyperLink ID="hlNoticia" runat="server" Target="_blank" Text="Notícias" /></strong>
										</li>
										<li>
											<strong><asp:HyperLink ID="hlImprensa" runat="server" Target="_blank" Text="Press Release" /></strong>
										</li>
										<li>
											<strong><asp:HyperLink ID="hlPodcast" runat="server" Target="_blank" Text="Podcasts" /></strong>
										</li>
										<li>
											<strong><asp:HyperLink ID="hlBancoAudio" runat="server" Target="_blank" Text="Banco de Áudio" /></strong>
										</li>
									</ul>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<sabesp:primeiraColunaDinamica ID="primeiraColunaDinamica1" runat="server" />
			</div>
		</div>
		<sabesp:boxAbas ID="boxAbas1" runat="server" />
	</div>
	<div class="colRight">
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>
