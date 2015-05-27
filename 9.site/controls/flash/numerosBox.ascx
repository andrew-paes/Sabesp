<%@ Control Language="C#" AutoEventWireup="true" CodeFile="numerosBox.ascx.cs" Inherits="CtlNumerosBox" %>

<script type="text/javascript">
	swfobject.registerObject("numerosBox", "9.0.115", "contents/swf/expressInstall.swf");
</script>

<div class="boxFlash">
	<%--<asp:Image ID="Image1" ImageUrl="~/contents/img/widget-maracana-lotado.jpg" AlternateText="Imagem de marcação para widget em FLASH: Maracanã lotado"
		runat="server" />--%>
	<object id="numerosBox" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" width="184"
		height="210">
		<param name="movie" value="<%=urlFlash %>" />
		<param name="wmode" value="transparent" />
		<!--[if !IE]>-->
		<object type="application/x-shockwave-flash" data="<%=urlFlash %>"
			width="184" height="195">
			<param name="wmode" value="transparent" />
			<!--<![endif]-->
			<p>
				FLASH não instalado</p>
			<!--[if !IE]>-->
		</object>
		<!--<![endif]-->
	</object>
</div>
