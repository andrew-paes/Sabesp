<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default_teste.aspx.cs" Inherits="interna_Default_teste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				Default Teste
			</h2>
			<div class="colContentLeft">
				<h3 class="boxTitulo">
				</h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxImagem" align="center">
									<img id="ctl00_ContentPlaceHolder1_imgSecao" src="/Sabesp/branches/manut_versao_2.00/site/uploads/secao/150420102323_servi%ef%bf%bdos_canais.jpg"
										style="border-width: 0px;" />
								</div>
								<div id="boxMasterContent" class="boxContent">
									<p>
										Texto ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
										ono ononoo no no no ono non ononono nono nono non onononono nonon on ononon onononoon ono
									</p>
									<p align="justify">
										<span style="font-size: small"><span style="font-family: Tahoma"><a target="_blank"
											href="http://www2.sabesp.com.br/"><u>Link de Teste</u></a></span></span></p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
			</div>
		</div>
	</div>

	<script type="text/javascript">
		var pathURL = '';
		$(document).ready(function() {
			$("div[id$='boxMasterContent']").find("a").click(function() {
				try {
					var tituloLinkContent = $(this).text().trim();
					if (tituloLinkContent != null && tituloLinkContent != '') {
						tituloLinkContent = replaceSpecialChars(tituloLinkContent);
						tituloLinkContent = tituloLinkContent.substr(0, 60);
						//alert(tituloLinkContent); 
						var pageTracker = _gat._getTracker('UA-17790992-1');
						pageTracker._setCustomVar(1, 'LINK', tituloLinkContent, 3);
						pageTracker._setDomainName('none');
						pageTracker._setAllowLinker(true);
						pageTracker._trackPageview('/Default_Teste');
					}
				} catch (err) { }
			});
		});
	</script>

	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
