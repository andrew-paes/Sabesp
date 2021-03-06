﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="boxAbasMunicipio.ascx.cs" Inherits="controls_abas_boxAbasMunicipio" %>
<!-- ABAS -->
<div class="abas">
	<asp:Repeater ID="rptTituloAbas" runat="server" OnItemDataBound="rptTituloAbas_ItemDataBound">
		<HeaderTemplate>
			<ul>
		</HeaderTemplate>
		<ItemTemplate>
			<li id="liTitulo" runat="server" class="fontMaior">
			    <asp:Literal ID="ltrAba" runat="server"/>
			</li>
		</ItemTemplate>
		<FooterTemplate>
			</ul>
		</FooterTemplate>
	</asp:Repeater>
	<asp:Repeater ID="rptAbas" runat="server" OnItemDataBound="rptAbas_ItemDataBound">
		<ItemTemplate>
			<asp:Panel ID="pnlAba" runat="server" CssClass="boxWhite abaContent">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<asp:Panel ID="pnlDivAba" runat="server" CssClass="bgrBottomLeft">
							<asp:Literal ID="ltrTexto" runat="server" />
						</asp:Panel>
					</div>
				</div>
			</asp:Panel>
		</ItemTemplate>
	</asp:Repeater>
	<div class="clr"><!-- --></div>
</div>
<!-- // ABAS -->
