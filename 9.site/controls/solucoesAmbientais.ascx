<%@ Control Language="C#" AutoEventWireup="true" CodeFile="solucoesAmbientais.ascx.cs"
	Inherits="CtlSolucoesAmbientais" %>
<div class="boxGray">
	<h3><asp:Literal ID="Literal1" runat="server">Soluções Ambientais</asp:Literal></h3>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft">
			<asp:Image ID="Image1" AlternateText=" " CssClass="imgAtendimento" runat="server" ImageUrl="~/contents/img/img-atendimento.jpg" />
			<div class="boxBorder" style="#padding-bottom:10px;">
                <div class="boxSolucoesAmbientais">
					Atendimento <br />0800-7712482<br /><br /><a href="mailto:solucoesambientais@sabesp.com.br">E-mail</a>
				</div>
			</div>
		</div>
	</div>
</div>