<%@ Control Language="C#" AutoEventWireup="true" CodeFile="destaqueGrande.ascx.cs"
	Inherits="controls_videos_destaqueGrande" %>	
<asp:Panel ID="pnlDestaque" runat="server">
	<div class="image after">
		<asp:Literal ID="ltrVideo" runat="server" />
	</div>
	<asp:HyperLink ID="hlTitulo" runat="server">
		<strong>
			<asp:Literal ID="ltrTitulo" runat="server" />
		</strong>
		<asp:Label ID="lblChamada" runat="server" />
	</asp:HyperLink>	
</asp:Panel>
