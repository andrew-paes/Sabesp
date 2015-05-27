<%@ Control Language="C#" AutoEventWireup="true" CodeFile="numerosBar.ascx.cs" Inherits="CtlNumerosBar" %>

<script type="text/javascript">
	swfobject.registerObject("numerosBar", "9.0.115", "contents/swf/expressInstall.swf");
</script>

<div class="boxFlash">
	<%--<asp:Image ID="Image1" ImageUrl="~/contents/img/widget-maracana-lotado.jpg" AlternateText="Imagem de marcação para widget em FLASH: Maracanã lotado"
		runat="server" />--%>
	<object id="flashHome" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="466"
		height="71" style="visibility: visible;">
		<param name="movie" value="<%=urlFlash %>" />
		<param name="wmode" value="transparent" />
		<!--[if !IE]>-->
		<object type="application/x-shockwave-flash" data="<%=urlFlash %>"
			width="466" height="71">
			<param name="wmode" value="transparent" />
			<!--<![endif]-->
			<p>
				FLASH não instalado</p>
			<!--[if !IE]>-->
		</object>
		<!--<![endif]-->
	</object>
</div>
