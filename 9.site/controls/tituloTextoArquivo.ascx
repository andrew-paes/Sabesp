<%@ Control Language="C#" AutoEventWireup="true" CodeFile="tituloTextoArquivo.ascx.cs" Inherits="CtlTituloTextoArquivo" %>
<script type="text/javascript">
	$(document).ready(function() {
	$("#tituloTextoArquivo li:last").addClass("last");
	});
</script>

<div class="boxMaisVistos">
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<h3>
				<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h3>
			<asp:Repeater ID="rptBox" runat="server">
				<HeaderTemplate>
					<ul id="tituloTextoArquivo" class="maisVistosList after">
				</HeaderTemplate>
				<ItemTemplate>
					<li>
						<asp:Literal ID="ltlTexto" runat="server"></asp:Literal>
						<br />
						<br />
						<span><asp:LinkButton ID="lnkArquivo" Text="Download"
                            runat="server"></asp:LinkButton></span>
					</li>
				</ItemTemplate>
				<FooterTemplate>
					</ul>
				</FooterTemplate>
			</asp:Repeater>
		</div>
	</div>
</div>
