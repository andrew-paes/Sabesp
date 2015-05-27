<%@ Control Language="C#" AutoEventWireup="true" CodeFile="imagensSabesp.ascx.cs"
	Inherits="controls_imprensa_imagensSabesp" %>
<div class="boxWhite">
	<div class="bgrTopRight">
		<div class="bgrBottomRight">
			<div class="bgrBottomLeft">
				<h3>
					<asp:Literal ID="ltrimagensSabesp" runat="server">Imagens da Sabesp</asp:Literal></h3>
				<div class="content">
					<p>
					</p>
					<a id="hrefFlickRImagemSabesp" href="http://www.flickr.com/photos/sabesp" class="lnkFundoGradiente">
						&raquo; Entre no Flickr</a>
				</div>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
	$(document).ready(function() {
		$('#hrefFlickRImagemSabesp').click(function() {
			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/Imprensa/Explicando_a_Sabesp/Flickr');
			} catch (err) { }
		});
	});
</script>

