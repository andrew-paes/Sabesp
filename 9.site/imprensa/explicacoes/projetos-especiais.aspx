<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="projetos-especiais.aspx.cs" Inherits="projetos_especiais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Projetos especiais</asp:Literal></h2>
		<div class="colContent fullWidth imprensa">
			<div class="colContentLeft">
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="newsListContent">
									<asp:Repeater ID="rptProjetosEspeciais" runat="server" OnItemDataBound="rptProjetosEspeciais_ItemDataBound">
										<HeaderTemplate>
											<ul class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li id="li" runat="server">
												<div class="image">
													<asp:Image ID="imgDestaque" AlternateText="" runat="server" />
												</div>
												<asp:HyperLink ID="hlProjetosEspeciais" NavigateUrl="#" runat="server">
													<strong>
														<asp:Literal ID="ltrTitulo" runat="server" /></strong>
													<asp:Label ID="lblDescricao" runat="server" />
													<br />
													<em>
														<asp:Literal ID="ltrVejaMaisSobreProjeto" runat="server" /></em>
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
				<sabesp:primeiraColunaDinamica runat="server" ID="primeiraColunaDinamica1" />
				<div class="boxFlash">
					<asp:HyperLink ID="HyperLink1" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/ciclo_agua.swf?width=1200&amp;height=1000"
						runat="server">
						<asp:Image ID="Image1" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo da Agua"
							runat="server" /></asp:HyperLink>
				</div>
				<div class="boxFlash">
					<asp:HyperLink ID="HyperLink2" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/ciclo_saneamento.swf?width=1200&amp;height=1000"
						runat="server">
						<asp:Image ID="Image6" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo do Saneamento"
							runat="server" /></asp:HyperLink>
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />
	</div>
</asp:Content>
