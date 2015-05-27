<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="glossario.aspx.cs" Inherits="social_e_ambiental_glossario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltrGlossario" runat="server" /></h2>
		<div class="colSingle">
			<p class="txtContent">
				<asp:Literal ID="ltrDescrGlossario" runat="server" /></p>
			<br />
			<br />
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="glosarioContent">
								<ul class="listLetra">
									<li>
										<asp:LinkButton ID="A" runat="server" OnClick="ChangeLetter">A</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="B" runat="server" OnClick="ChangeLetter">B</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="C" runat="server" OnClick="ChangeLetter">C</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="D" runat="server" OnClick="ChangeLetter">D</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="E" runat="server" OnClick="ChangeLetter">E</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="F" runat="server" OnClick="ChangeLetter">F</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="G" runat="server" OnClick="ChangeLetter">G</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="H" runat="server" OnClick="ChangeLetter">H</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="I" runat="server" OnClick="ChangeLetter">I</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="J" runat="server" OnClick="ChangeLetter">J</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="K" runat="server" OnClick="ChangeLetter">K</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="L" runat="server" OnClick="ChangeLetter">L</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="M" runat="server" OnClick="ChangeLetter">M</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="N" runat="server" OnClick="ChangeLetter">N</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="O" runat="server" OnClick="ChangeLetter">O</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="P" runat="server" OnClick="ChangeLetter">P</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="Q" runat="server" OnClick="ChangeLetter">Q</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="R" runat="server" OnClick="ChangeLetter">R</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="S" runat="server" OnClick="ChangeLetter">S</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="T" runat="server" OnClick="ChangeLetter">T</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="U" runat="server" OnClick="ChangeLetter">U</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="V" runat="server" OnClick="ChangeLetter">V</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="W" runat="server" OnClick="ChangeLetter">W</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="X" runat="server" OnClick="ChangeLetter">X</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="Y" runat="server" OnClick="ChangeLetter">Y</asp:LinkButton></li>
									<li>
										<asp:LinkButton ID="Z" runat="server" OnClick="ChangeLetter">Z</asp:LinkButton></li>
									<input type="hidden" runat="server" id="hdnLetterAtu"></input>
								</ul>
								<div class="conteudoGlosario">
									<asp:Repeater ID="rptGlossario" runat="server" OnItemDataBound="rptGlossario_ItemDataBound">
										<HeaderTemplate>
											<ul class="listGlosario">
										</HeaderTemplate>
										<ItemTemplate>
											<li><strong>
												<asp:Literal ID="ltrPalavra" runat="server" /></strong><br />
												<asp:Literal ID="ltrDescricao" runat="server" />
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
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita" runat="server" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
