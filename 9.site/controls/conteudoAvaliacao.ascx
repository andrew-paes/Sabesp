<%@ Control Language="C#" AutoEventWireup="true" CodeFile="conteudoAvaliacao.ascx.cs" Inherits="controls_conteudoAvaliacao" %>
<script type="text/javascript" >
    function voteBad()
    {
	    jQuery.ajax({
		    type: "POST",
		    url: "../PostPage.aspx/voteBad",		    		    
		    data: "{'conteudoId':'" + $("input[id$='hdnConteudoId']").val() + "'}",
		    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    success: function(msg) {		        
		        $("a[id$='hlVoteBad']").html(msg.d);
		        $("a[id$='hlVoteBad']").removeAttr('href');		        
		        $("a[id$='hlVoteGood']").removeAttr('href');		        
			    //
		    }
	    });
    }
    function voteGood()
    {
	    jQuery.ajax({
		    type: "POST",
		    url: "../PostPage.aspx/voteGood",		    		    
		    data: "{'conteudoId':'" + $("input[id$='hdnConteudoId']").val() + "'}",
		    contentType: "application/json; charset=utf-8",
		    dataType: "json",
		    success: function(msg) {		        
		        $("a[id$='hlVoteGood']").html(msg.d);
		        $("a[id$='hlVoteBad']").removeAttr('href');		        
		        $("a[id$='hlVoteGood']").removeAttr('href');		        
			    //
		    }
	    });
    }    
</script>
<div class="avalieContent after">
	<div class="voteContent">
		<asp:Label ID="lblConteudo" runat="server" />
		<div class="vote">
		    <asp:HyperLink NavigateUrl="javascript:voteGood();" ID="hlVoteGood" class="voteGood" runat="server"></asp:HyperLink>			
		    <asp:HyperLink NavigateUrl="javascript:voteBad();" ID="hlVoteBad" class="voteBad" runat="server"></asp:HyperLink>
		</div>
	</div>
	 <asp:HyperLink class="compartilhe" ID="hlCompartilhe" runat="server">
	    <asp:Literal ID="ltrComportilhe" runat="server" />
	 </asp:HyperLink>
	 <asp:HyperLink NavigateUrl="javascript:print();" class="print" ID="hlImprima" runat="server">
	    <asp:Literal ID="ltrImprima" runat="server" />
	 </asp:HyperLink>
	 <input type="hidden" runat="server" id="hdnConteudoId"></input>
	 <div class="boxSocialMedia">
	 	<a href="#" class="lnkClose" title="Fechar">X</a>
	 	<ul>
			<li id="liTwitter" runat="server"><asp:HyperLink ID="lnkTwitter" Target="_blank" ToolTip="Twitter" CssClass="lnkTwitter" NavigateUrl="#" runat="server">Twitter</asp:HyperLink></li>
			<li id="liFacebook" runat="server"><asp:HyperLink ID="lnkFacebook" Target="_blank" ToolTip="Facebook" CssClass="lnkFacebook" NavigateUrl="#" runat="server">Facebook</asp:HyperLink></li>
			<li id="liYoutube" runat="server" visible="false"><asp:HyperLink ID="lnkYoutube" Target="_blank" ToolTip="Youtube" CssClass="lnkYoutube" NavigateUrl="#" runat="server">Youtube</asp:HyperLink></li>
			<li id="liRSS" runat="server"><asp:HyperLink ID="lnkRSS" Target="_blank" ToolTip="RSS" CssClass="lnkRSS" NavigateUrl="#" runat="server">RSS</asp:HyperLink></li>
			<li id="liDelicious" runat="server" class="last"><asp:HyperLink ID="lnkDelicious" Target="_blank" ToolTip="Delicious" CssClass="lnkDelicious" NavigateUrl="#" runat="server">Delicious</asp:HyperLink></li>
		</ul>
	 </div>
</div>		
