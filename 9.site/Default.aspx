<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Src="controls/siteMap/BreadCrumb.ascx" TagName="BreadCrumb" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	<script type="text/javascript">
		//swfobject.registerObject("flashHome", "9.0.115", "contents/swf/expressInstall.swf");
		//swfobject.registerObject("facaPorAqui", "9.0.115", "contents/swf/expressInstall.swf");
		
	</script>

	<script type="text/javascript" src="<%=ResolveUrl("~/contents/js/tv-sabesp.js") %>"></script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="flashTopoHome">
			<object id="flashHome" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="809"
				height="210">
				<param name="movie" value="contents/swf/default.swf" />
				<param name="wmode" value="transparent" />
				<param name="flashvars" value="xmlURL=contents/swf/xml/banners.xml" />
				<!--[if !IE]>-->
				<object id="flashHomeData" type="application/x-shockwave-flash" data="contents/swf/default.swf"
					width="809" height="210">
					<param name="wmode" value="transparent" />
					<param name="flashvars" value="xmlURL=contents/swf/xml/banners.xml" />
					<div id="contentBannersHome">
					</div>

					<script type="text/javascript">
			            $(document).ready(function(){
			                var banners = new Array();
			                banners[0] = new Array("contents/img/ban-home4.gif", "http://site.sabesp.com.br/site/interna/Default.aspx?secaoId=91");
			                banners[1] = new Array("contents/img/desatqueDebitoAutomatico.jpg", "http://site.sabesp.com.br/site/interna/Default.aspx?secaoId=274");
			                /*banners[0] =  new Array("contents/img/ban-home1.gif", "http://www.ondalimpa.com.br/");
			                banners[1] = new Array("contents/img/ban-home2.gif", "http://vidanova.sabesp.com.br/");
			                banners[2] = new Array("contents/img/ban-home3.gif", "http://www2.sabesp.com.br/projetotiete/");
			                banners[3] = new Array("contents/img/ban-home4.gif", "http://site.sabesp.com.br/site/interna/Default.aspx?secaoId=91");*/
        			        
			                animaBanner(banners, 6000);
			            });
					</script>

				</object>
				<!--<![endif]-->
			</object>
			<!--mg src="contents/img/ban-home1.gif" width="810" height="207" alt="" /-->
		</div>
		<h2>
			<asp:Literal ID="Literal1" runat="server">Faça por aqui</asp:Literal></h2>
		<div class="icoServicosHome">
			<object id="facaPorAqui" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="670"
				height="125">
				<param name="movie" value="contents/swf/facaPorAqui.swf" />
				<param name="wmode" value="transparent" />
				<!--[if !IE]>-->
				<object type="application/x-shockwave-flash" data="contents/swf/facaPorAqui.swf"
					width="670" height="125">
					<param name="wmode" value="transparent" />
					<!--<![endif]-->
					<p>
						FLASH não instalado</p>
					<!--[if !IE]>-->
				</object>
				<!--<![endif]-->
			</object>
		</div>
		<div class="colContent fullWidth rowSolucoesAmbientais">
			<div class="colContentLeft">
				<h3 class="boxTitulo ttlSolucoesAmbientais">
					<asp:Literal ID="ltrTituloSolucoesAmbientais" runat="server" Text="Soluções ambientais" /></h3>
				<sabesp:destaqueProduto ID="destaqueProduto1" runat="server" />
			</div>
			<div class="colContentRight">
				<div class="boxDivider">
					<sabesp:atendimento runat="server" ID="atendimento" />
				</div>
			</div>
		</div>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
                <br /><br /><br /><br />
				<h3 class="boxTitulo ttlNoticias">
					<asp:Literal ID="Literal3" runat="server">Notícias</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:noticiaDestaqueGrande ID="noticiaDestaqueGrande1" runat="server" />
								<div class="newsListContent">
									<sabesp:noticiaDestaqueLista ID="noticiaDestaqueLista1" runat="server" />
									<asp:HyperLink ID="hlTodasNoticias" runat="server" CssClass="lnkFundoGradiente" />
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider">
					<div class="boxMaisVistosB ultimasNoticias">
						<div class="boxMaisVistosC">
							<%--<sabesp:noticiaUltimasNoticias ID="noticiaUltimasNoticias" runat="server" />--%>
							<sabesp:releaseUltimosReleasesHome ID="releaseUltimosReleasesHome" runat="server" />
						</div>
					</div>
				</div>
				<div class="clr">
				</div>
				<%--<h3 class="boxTitulo ttlRadio">
					Rádio Sabesp</h3>
				<div class="boxDivider last" runat="server" visible="true">
					<div class="boxWhite boxPurple" style="width: 400px !important;">
						<div class="bgrTopRight">
							<div class="bgrBottomRight">
								<div class="bgrBottomLeft">
									<div class="content">
										<h5>
											Boletins Diários</h5>
										<ul class="radioList">
											<li><a href="javascript:;"><span>Um guia completo com dicas simples para não faltar
												água na sua casa.</span></a></li>
											<li><a href="javascript:;"><span>Os resultados da campanha de reciclagem no litoral
												norte.</span></a></li>
											<li class="last"><a href="javascript:;"><span>A Sabesp falou com quem foi castigado
												pelas chuvas recentes.</span></a></li>
										</ul>
										<h5>
											Boletim Semanal</h5>
										<ul class="radioList">
											<li class="last"><a href="javascript:;"><span>A Sabesp falou com quem foi castigado
												pelas chuvas recentes.</span></a></li>
										</ul>
										<h5>
											Boletim Quinzenal</h5>
										<ul class="radioList">
											<li><a href="javascript:;"><span>A Sabesp falou com quem foi castigado pelas chuvas
												recentes.</span></a></li>
											<li class="last"><a href="javascript:;"><span>Os resultados da campanha de reciclagem
												no litoral norte.</span></a></li>
										</ul>
										<a href="fique-por-dentro/Podcasts-Lista.aspx?secaoId=65" class="lnkFundoGradiente">
											» Todos os podcasts</a>
									</div>
								</div>
							</div>
						</div>
					</div>
				</div>--%>
				
			</div>
			<div class="colContentRight">
                <br /><br /><br /><br />
				<h3 class="boxTitulo ttlTVSabesp ttlTVSabespHome">
					<asp:Literal ID="Literal5" runat="server">TV Sabesp</asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<sabesp:videoDestaqueGrande ID="videoDestaqueGrande1" runat="server" />
								<div class="newsListContent">
									<sabesp:videoDestaqueLista ID="videoDestaqueLista1" runat="server" />
									<asp:HyperLink ID="hlTodosVideos" runat="server" CssClass="lnkFundoGradiente" />
								</div>
							</div>
						</div>
					</div>
				</div>
				<div class="boxDivider abcMeioAmbiente last" visible="false" runat="server" id="divMeioAmbiente">
					<asp:HyperLink ID="abcMeioAmbiente" NavigateUrl="~/interna/Default.aspx?secaoId=121"
						ToolTip="ABC do Meio Ambiente" runat="server">
						<asp:Image ID="imgAbcMeioAmbiente" AlternateText="ABC do Meio Ambiente" ImageUrl="~/contents/img/img-abc-meioambiente.gif"
							runat="server" />
					</asp:HyperLink>
				</div>
                <br /><br />
                <sabesp:podcastMaisRecentes ID="podcastMaisRecentes" runat="server" />
			</div>
            
		</div>
	</div>
	<div class="colRight">
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
	<sabesp:GoogleAnalytics ID="GoogleAnalytics2" runat="server" />
</asp:Content>
