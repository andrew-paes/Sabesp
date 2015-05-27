<%@ Control Language="C#" AutoEventWireup="true" CodeFile="twitter.ascx.cs" Inherits="CtlTwitter" %>
<script language="javascript" type="text/javascript">
      var path = <% =("'" + ResolveClientUrl("~/controls/TwitterPost.aspx") + "'")%> ;
      
      $(document).ready(function() {
	    jQuery.ajax({
		    type: "POST",
		    url: path,		    		    		    
		    success: function(msg) {
		        $("ul[id$='ulRepeater']").html(msg);
		    }		    
	    });	  
      });


</script>
<div class="boxTwitter">
	<div class="bgrTopLeft">
		<div class="bgrTopRight">
			<div class="bgrBottomLeft">
				<div class="bgrBottomRight">
					<div class="boxContent">
						<h4><asp:Literal ID="ttlTwitter" runat="server" /></h4>
						<asp:Label ID="lblErro" runat="server"></asp:Label>
						<ul id="ulRepeater" >

						</ul>
					</div>
					<asp:HyperLink ID="lnkMore" CssClass="lnkMore" runat="server"></asp:HyperLink>
				</div>
			</div>
		</div>
	</div>
</div>
