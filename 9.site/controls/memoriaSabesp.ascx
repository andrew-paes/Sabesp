<%@ Control Language="C#" AutoEventWireup="true" CodeFile="memoriaSabesp.ascx.cs"
	Inherits="CtlMemoriaSabesp" %>
<div class="boxDestaquesBgr w192">
	<h3 class="mt5 mb5">
		Memória Sabesp</h3>
	<%--<img src="contents/img/img_memoriasabesp.gif" width="182" height="82" class="mbm2" />--%>
	<asp:ImageButton CssClass="mbm2" ID="ImageButton1" ImageUrl="~/contents/img/img_memoriasabesp.gif"
					Width="182" Height="82" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=28" />
	<div class="bgrBottomRight w182">
		<div class="bgrBottomLeft">
			<div class="contentMedio borderB w131">
				Conheça toda a trajetória da Sabesp até hoje.
				<br class="clr" />
			</div>
		</div>
	</div>
</div>
