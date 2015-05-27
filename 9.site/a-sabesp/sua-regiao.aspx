<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="sua-regiao.aspx.cs" Inherits="interna_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>
			<div class="colContentLeft">
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlTituloMenu" runat="server"></asp:Literal></h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxImagem" align="center">
									<asp:Image ID="imgSecao" runat="server" />
								</div>
								<div class="boxContent">
									<asp:Literal ID="ltrContent" runat="server"></asp:Literal>

									<script type="text/javascript">
										swfobject.registerObject("flashMapa", "9.0.115", "contents/swf/expressInstall.swf");
									</script>

									<script type="text/javascript">
										function showMap(area) {
											//alert(area);
											tb_show(area.toUpperCase(), '../contents/img/mapas/' + area + '.jpg', null);
										}

										function showRegion(area) {

											$.ajax({
												type: "POST",
												url: "sua-regiao.aspx/BindMunicipios",
												data: "{ 'siglaRegiao': '" + area + "'}",
												contentType: "application/json; charset=utf-8",
												dataType: "json",
												success: function(j) {
													//alert(j.d[0].MunicipioId);
													//alert(j.d.length);
													var options = '';
													$("#h2Titulo").html('');
													$("#h2Titulo").hide();

													for (var i = 0; i < j.d.length; i++) {
														if (i == 0) {
															$("#h2Titulo").html(j.d[i].Nome);
															$("#h2Titulo").show();

															try {
																var pageTracker = _gat._getTracker('UA-17790992-1');
																pageTracker._setDomainName('none');
																pageTracker._setAllowLinker(true);
																pageTracker._trackPageview('/A_Sabesp/Sua_Regiao/Selecionou_Regiao/' + j.d[i].Nome);
															} catch (err) { }
														}
														else {
															options += '<li><a href="../interna/Municipio.aspx?secaoId=18&id=' + j.d[i].MunicipioId + '">' + j.d[i].Nome + '</a></li>';
														}
													}

													if (j.d.length == 1) {
														$(".spanMsgVazia").show();
													}
													else {
														$(".spanMsgVazia").hide();
													}
													$("#ulZebrada").html(options);
													$("#ulZebrada li:odd").addClass("alt");
												},
												error: function(j) {
													$("#h2Titulo").hide();
													$(".spanMsgVazia").show();
													$("#ulZebrada").html('')
												}
											})
										}
									</script>

									<object id="flashMapa" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="560"
										height="400" style="visibility: visible;">
										<param name="movie" value="../contents/swf/mapa.swf" />
										<param name="wmode" value="transparent" />
										<!--[if !IE]>-->
										<object type="application/x-shockwave-flash" data="../contents/swf/mapa.swf" width="560"
											height="400">
											<param name="wmode" value="opaque" />
											<!--<![endif]-->
											<p>
												FLASH não instalado</p>
											<!--[if !IE]>-->
										</object>
										<!--<![endif]-->
									</object>
									<!-- LISTA CIDADES(?) DA REGIAO CLICADA NO MAPA EM FLASH -->
									<asp:Panel ID="pnlMunicipios" runat="server" CssClass="boxListagemArea">
										<h2 id="h2Titulo" style="display: none">
										</h2>
										<span class="spanMsgVazia" style="display: none">Não foi encontrado nenhum município
											associado a esta região.</span>
										<ul class="zebrada lstCidades" id="ulZebrada">
										</ul>
									</asp:Panel>
									<!-- LISTA CIDADES(?) DA REGIAO CLICADA NO MAPA EM FLASH -->
									<!--<a href="../contents/img/Mapa RB.jpg" class="thickbox">VER MAPA</a>-->
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
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
