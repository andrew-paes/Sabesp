<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
    CodeFile="explicacoes-sabesp.aspx.cs" Inherits="explicacoes_sabesp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

<div class="colLeft">
	<h2><asp:Literal ID="ltrTitulo" runat="server">Explicando a Sabesp</asp:Literal></h2>
	<div class="colContent fullWidth imprensa">
		<div class="colContentLeft">
			<div class="boxWhite">
				<div class="bgrTopRight">
					<div class="bgrBottomRight">
						<div class="bgrBottomLeft">
							<div class="newsContent">
							    <asp:Literal runat="server" ID="ltrDescricao">
							        Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede. Donec nec justo eget felis facilisis fermentum. Aliquam porttitor mauris sit amet orci. Aenean dignissim pellentesque felis.<br><br>Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida id, est. Sed lectus. Praesent elementum hendrerit tortor. Sed semper lorem at felis. Vestibulum volutpat, lacus a ultrices sagittis, mi neque euismod dui, eu pulvinar nunc sapien ornare nisl. Phasellus pede arcu, dapibus eu, fermentum et, dapibus sed, urna.<br><br>Morbi interdum mollis sapien. Sed ac risus. Phasellus lacinia, magna a ullamcorper laoreet, lectus arcu pulvinar risus, vitae facilisis libero dolor a purus. Sed vel lacus. Mauris nibh felis, adipiscing varius, adipiscing in, lacinia vel, tellus. Suspendisse ac urna. Etiam pellentesque mauris ut lectus. Nunc tellus ante, mattis eget, gravida vitae, ultricies ac, leo. Integer leo pede, ornare a, lacinia eu, vulputate vel, nisl.<br><br>Suspendisse mauris. Fusce accumsan mollis eros. Pellentesque a diam sit amet mi ullamcorper vehicula. Integer adipiscing risus a sem. Nullam quis massa sit amet nibh viverra malesuada. Nunc sem lacus, accumsan quis, faucibus non, congue vel, arcu. Ut scelerisque hendrerit tellus. Integer sagittis. Vivamus a mauris eget arcu gravida tristique. Nunc iaculis mi in ante. Vivamus imperdiet nibh feugiat est.<br><br>Ut convallis, sem sit amet interdum consectetuer, odio augue aliquam leo, nec dapibus tortor nibh sed augue. Integer eu magna sit amet metus fermentum posuere. Morbi sit amet nulla sed dolor elementum imperdiet. Quisque fermentum. Cum sociis natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Pellentesque adipiscing eros ut libero. Ut condimentum mi vel tellus. Suspendisse laoreet. Fusce ut est sed dolor gravida convallis. Morbi vitae ante. Vivamus ultrices luctus nunc. Suspendisse et dolor. Etiam dignissim. Proin malesuada adipiscing lacus. Donec metus. Curabitur gravida.
							    </asp:Literal>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colContentRight">
            <sabesp:imprensaImagensSabesp runat="server" id="imprensaImagensSabesp" />
				<%-- <div class="boxFlash">
				<asp:HyperLink ID="HyperLink1" runat="server"><asp:Image ID="Image5" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo da Água" runat="server" /></asp:HyperLink>
			</div>

			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink2" runat="server"><asp:Image ID="Image6" ImageUrl="~/contents/img/FAKE_ciclo_agua.jpg" ToolTip="Ciclo do Saneamento" runat="server" /></asp:HyperLink>
			</div> --%>
			<!--div class="boxFlash">
                <asp:HyperLink ID="HyperLink1" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/ciclo_agua.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image1" ImageUrl="~/contents/img/ciclo_agua.jpg" ToolTip="Ciclo de Agua" runat="server" /></asp:HyperLink>
			</div-->
			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink4" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_agua.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image3" ImageUrl="~/contents/img/tratamento_agua.jpg" ToolTip="Tratamento Água" runat="server" /></asp:HyperLink>
			</div>
			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink2" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_esgoto_solido.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image6" ImageUrl="~/contents/img/tratamento_esgoto_solido.jpg" ToolTip="Tratamento Esgoto Sólido" runat="server" /></asp:HyperLink>
			</div>
			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink5" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/tratamento_esgoto_liquido.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image4" ImageUrl="~/contents/img/tratamento_esgoto_liquido.jpg" ToolTip="Tratamento Esgoto Liquído" runat="server" /></asp:HyperLink>
			</div>		
			<div class="boxFlash">
				<asp:HyperLink ID="HyperLink3" rel="prettyPhoto[flash]" NavigateUrl="~/contents/swf/simulador.swf?width=1200&amp;height=1000" runat="server"><asp:Image ID="Image2" ImageUrl="~/contents/img/simulador.jpg" ToolTip="Simulador Consumo" runat="server" /></asp:HyperLink>
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
