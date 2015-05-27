<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Municipio.aspx.cs" Inherits="interna_Municipio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal>
			</h2>
			<div class="colContentLeft suaregiao">
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlTituloMenu" runat="server"></asp:Literal>
				</h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxImagem p10" align="center">
									<asp:Image ID="imgSecao" runat="server" />
								</div>
								<div class="boxContent">
									<asp:Literal ID="ltrContent" runat="server"></asp:Literal>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<sabesp:fiquePorDentro ID="fiquePorDentro1" runat="server" Visible="false" />
			</div>
		</div>
		<div class="suaregiao">
			<sabesp:boxAbasMunicipio ID="boxAbasMunicipio1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<%--<sabesp:atendimento ID="atendimento1" runat="server" />
		<sabesp:redeSociais ID="redeSociais1" runat="server" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		//<![CDATA[
		var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
		document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
		
		$(document).ready(function() {
			//alert($(".boxTitulo").text().trim());

			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/A_Sabesp/Sua_Regiao/Selecionou_Regiao/' + $(".boxTitulo").text().trim());
			} catch (err) { }
		});
		//]]>
	</script>

</asp:Content>
