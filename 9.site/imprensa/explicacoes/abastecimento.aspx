<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
    CodeFile="abastecimento.aspx.cs" Inherits="abastecimento" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="colLeft">
	<h2><asp:Literal ID="ltrTitulo" runat="server"/></h2>
	<div class="colContent fullWidth imprensa">
		<div class="colContentLeft">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="newsContent">
							    <asp:Literal runat="server" ID="ltrDescricao"/>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colContentRight">
            <sabesp:imprensaImagensSabesp runat="server" id="imprensaImagensSabesp" />
			<div class="boxFlash">
                <asp:HyperLink ID="HyperLink1" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/ciclo_agua.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image1" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo da Agua" runat="server" /></asp:HyperLink>
			</div>

			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink2" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/ciclo_saneamento.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image6" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo do Saneamento" runat="server" /></asp:HyperLink>
			</div>

		</div>
	</div>
</div>

<div class="colRight">
	<sabesp:menuDireita runat="server" id="menuDireita" />
	<sabesp:atendimento runat="server" ID="atendimento" />
	<sabesp:suaRegiao runat="server" ID="suaRegiao" />
	<sabesp:redeSociais runat="server" id="redeSociais" />
</div>

</asp:Content>
