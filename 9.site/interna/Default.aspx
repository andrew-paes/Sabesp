<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="interna_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<div class="colContent fullWidth interna">
			<h2>
				<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal>
			</h2>
			<div class="colContentLeft">
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlTituloMenu" runat="server"></asp:Literal>
				</h3>
				<div class="boxWhite">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft">
								<div class="boxImagem" align="center">
									<asp:Image ID="imgSecao" runat="server" />
								</div>
								<div id="boxMasterContent" class="boxContent">
									<asp:Literal ID="ltrContent" runat="server"></asp:Literal>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<sabesp:primeiraColunaDinamica ID="primeiraColunaDinamica1" runat="server" />
			</div>
		</div>
		<sabesp:boxAbas ID="boxAbas1" runat="server" />
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">
</asp:Content>
