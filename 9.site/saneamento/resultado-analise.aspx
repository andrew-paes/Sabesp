<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="resultado-analise.aspx.cs" Inherits="saneamento_resultado_analise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Resultado de Análises</asp:Literal></h2>
		<div class="colContent">
			<div class="boxWhite ">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft boxNewsDetalhe">
							<div class="image">
								<img src="../contents/img/FAKE_newsG.jpg" alt="" />
							</div>
							<div class="newsContent">
								<p>
									Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
									varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
									imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
									fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
									rutrum.</p>
								<p>
									Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
									eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
									pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum
									dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed
									quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum
									nulla non purus. Sed quis lectus. Morbi condimentum nulla non.</p>
								<p>
									Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
									eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
									pretium. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris.
									Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus
									suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi.
									Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus
									a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi
									condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla.</p>
								<p>
									Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
									eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
									pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum
									dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed
									quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum
									nulla non purus. Sed quis lectus. Morbi condimentum nulla non.</p>
								<p>
									Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
									varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
									imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
									fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
									rutrum. Duis ac libero. Nulla facilisi. Lorem ipsum dolor sit amet, consectetuer
									adipiscing elit. Vivamus sodales lacus a risus. Sed quis lectus. Morbi condimentum
									nulla non purus.Sed quis lectus. Morbi condimentum nulla non purus. Sed quis lectus.
									Morbi condimentum nulla non.</p>
								<ul class="listPDF">
									<li><a href="#">Relatório de qualidade de agua <em>0.00 MB</em> </a></li>
									<li><a href="#">Relatório de qualidade de agua <em>0.00 MB</em> </a></li>
								</ul>
							</div>
							<%--<sabesp:paginacao runat="server" ID="paginacao" />--%>
						</div>
					</div>
				</div>
			</div>
			<br />
			<h3 class="sub">
				<asp:Literal ID="Literal2" runat="server">ANOS ANTERIORES - Relatório de Qualidade da Água</asp:Literal></h3>
			<div class="boxFiltro">
				<div class="boxFiltroleft">
					<div class="boxFiltroRight">
						<div class="boxFormLine">
							<div class="boxSelect" style="width: 215px;">
								<span>
									<select name="regiao" id="regiao" class="select">
										<option value="">Informações Complementares</option>
										<option value="">01</option>
										<option value="">02</option>
										<option value="">03</option>
										<option value="">04</option>
										<option value="">05</option>
										<option value="">06</option>
										<option value="">07</option>
										<option value="">08</option>
										<option value="">09</option>
										<option value="">10</option>
										<option value="">11</option>
										<option value="">12</option>
										<option value="">13</option>
										<option value="">14</option>
										<option value="">15</option>
										<option value="">16</option>
										<option value="">17</option>
										<option value="">18</option>
										<option value="">19</option>
										<option value="">20</option>
										<option value="">21</option>
										<option value="">22</option>
										<option value="">23</option>
										<option value="">24</option>
										<option value="">25</option>
										<option value="">26</option>
										<option value="">27</option>
										<option value="">28</option>
										<option value="">29</option>
										<option value="">30</option>
										<option value="">31</option>
									</select>
								</span>
							</div>
						</div>
						<div class="boxFormLine">
							<label>
								<asp:Literal ID="Literal3" runat="server">Mês</asp:Literal></label>
							<div class="boxSelect" style="width: 50px;">
								<span>
									<select name="regiao" id="Select1" class="select">
										<option value="">&nbsp;</option>
										<option value="">01</option>
										<option value="">02</option>
										<option value="">03</option>
										<option value="">04</option>
										<option value="">05</option>
										<option value="">06</option>
										<option value="">07</option>
										<option value="">08</option>
										<option value="">09</option>
										<option value="">10</option>
										<option value="">11</option>
										<option value="">12</option>
									</select>
								</span>
							</div>
						</div>
						<div class="boxFormLine">
							<label>
								<asp:Literal ID="Literal4" runat="server">Ano</asp:Literal></label>
							<div class="boxSelect" style="width: 80px;">
								<span>
									<select name="regiao" id="Select2" class="select">
										<option value="">&nbsp;</option>
										<option value="">2010</option>
										<option value="">2009</option>
										<option value="">2008</option>
									</select>
								</span>
							</div>
						</div>
						<input type="image" src="../contents/img/bt-buscar.gif" class="btoBuscar" />
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
			<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq" />
			<sabesp:boxAzulEsq runat="server" ID="boxAzulEsq1" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="sabespEnsina" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
