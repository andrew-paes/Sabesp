<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="mananciais.aspx.cs" Inherits="saneamento_mananciais" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Mananciais</asp:Literal></h2>
		<div class="colContent">
			<p class="txtContent">
				<asp:Literal ID="Literal2" runat="server">Veja o índice de armazenamento e pluviometria das represas que abastecem a Região Metropolitana de São Paulo.</asp:Literal></p>
			<div class="boxFiltro">
				<div class="boxFiltroleft">
					<div class="boxFiltroRight">
						<div class="boxFormLine">
							<label>
								Dia</label>
							<div class="boxSelect" style="width: 50px;">
								<span>
									<select name="regiao" id="regiao" class="select">
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
						<asp:LinkButton ID="LinkButton1" runat="server" CssClass="btoBuscar">
							<asp:Literal ID="Literal5" runat="server">Buscar</asp:Literal></asp:LinkButton>
					</div>
				</div>
			</div>
			<div class="boxWhite bwHeaderBottom">
				<div class="bgrBottom">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<table class="tbMananciais" cellpadding="0" cellspacing="0">
									<colgroup>
										<col width="80%" />
										<col width="20%" />
									</colgroup>
									<thead>
										<tr>
											<td>
												Nome
											</td>
											<td class="corner">
												&nbsp;
											</td>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
										<tr class="alt">
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
										<tr>
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
									</tbody>
								</table>
								<table class="tbMananciais" cellpadding="0" cellspacing="0">
									<colgroup>
										<col width="80%" />
										<col width="20%" />
									</colgroup>
									<thead>
										<tr>
											<td colspan="2">
												Nome
											</td>
										</tr>
									</thead>
									<tbody>
										<tr>
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
										<tr class="alt">
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
										<tr>
											<td>
												Volume armazenado
											</td>
											<td class="right">
												98,99%
											</td>
										</tr>
									</tbody>
								</table>
								<span class="bottomContent">* total acumulado até o mês de referência</span>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:suaRegiao runat="server" ID="suaRegiao" />
		<sabesp:boxAzulDir runat="server" ID="boxAzulDir" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
