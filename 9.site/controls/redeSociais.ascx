<%@ Control Language="C#" AutoEventWireup="true" CodeFile="redeSociais.ascx.cs" Inherits="CtlRedeSociais" %>
<div class="boxBlue">
	<div class="bgrTopRight">
		<div class="bgrBottomRight">
			<div class="bgrTopLeft">
				<div class="bgrBottomLeft">
					<div class="boxContent">
						<h3>
							<asp:Literal ID="Literal1" runat="server">Nas redes sociais</asp:Literal></h3>
						<ul>
							<li><a id="hrefRedeYoutube" href="http://www.youtube.com/user/SaneamentoSabesp" class="youtube"
								target="_blank"><span>Youtube</span></a></li>
							<li><a id="hrefRedeFlickr" href="http://www.flickr.com/photos/sabesp" class="flickr"
								target="_blank"><span>Flickr</span></a></li>
							<%--<li><a href="#" class="orkut" target="_blank"><span>Orkut</span></a></li>--%>
							<li><a id="hrefRedeTwitter" href="http://twitter.com/CiaSabesp" class="twitter" target="_blank">
								<span>Twitter</span></a></li>
							<li><a id="hrefRedeFaceBook" href="http://www.facebook.com/profile.php?id=100000098004882&ref=search&sid=530504857.318958971..1"
								class="facebook" target="_blank"><span>Facebook</span></a></li>
							<%--<li><a href="#" class="delicious" target="_blank"><span>Del.icio.us</span></a></li>--%>
						</ul>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript">
	$(document).ready(function() {
		$('#hrefRedeYoutube').click(function() {
			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/Redes_Sociais/Youtube');
			} catch (err) { }
		});

		$('#hrefRedeFlickr').click(function() {
			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/Redes_Sociais/Flickr');
			} catch (err) { }
		});

		$('#hrefRedeTwitter').click(function() {
			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/Redes_Sociais/Twitter');
			} catch (err) { }
		});

		$('#hrefRedeFaceBook').click(function() {
			try {
				var pageTracker = _gat._getTracker('UA-17790992-1');
				pageTracker._setDomainName('none');
				pageTracker._setAllowLinker(true);
				pageTracker._trackPageview('/Redes_Sociais/Facebook');
			} catch (err) { }
		});
	});
</script>

