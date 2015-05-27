<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="agua_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="Literal1" runat="server">Água</asp:Literal></h2>
		<div class="colContent">
			<sabesp:carroselPaginado runat="server" ID="carroselPaginado" />
			<div class="boxWhite bwTOP">
				<div class="bgrTop">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="header">
									Água no planeta</div>
								<div class="newsContent">
									<p>
										Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
										varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
										imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
										fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
										rutrum.</p>
									<p>
										Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
										eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
										pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi. Lorem ipsum
										dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus a risus. Sed
										quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi condimentum
										nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.
									</p>
									<p>
										Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
										eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
										pretium. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris.
										Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus
										suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi.
										Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus
										a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi
										condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.
									</p>
									<p>
										Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus
										libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida
										id, est. Sed lectus. Praesent elementum hendrerit tortor. Sed semper lorem at felis.
										Vestibulum volutpat, lacus a ultrices sagittis, mi neque euismod dui, eu pulvinar
										nunc sapien ornare nisl. Phasellus pede arcu, dapibus eu, fermentum et, dapibus
										sed, urna.</p>
									<p>
										Morbi interdum mollis sapien. Sed ac risus. Phasellus lacinia, magna a ullamcorper
										laoreet, lectus arcu pulvinar risus, vitae facilisis libero dolor a purus. Sed vel
										lacus. Mauris nibh felis, adipiscing varius, adipiscing in, lacinia vel, tellus.
										Suspendisse ac urna. Etiam pellentesque mauris ut lectus. Nunc tellus ante, mattis
										eget, gravida vitae, ultricies ac, leo. Integer leo pede, ornare a, lacinia eu,
										vulputate vel, nisl.</p>
									<p>
										Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris. Quisque
										eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus suscipit
										pretium. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Nullam ac mauris.
										Quisque eget metus eget tellus ultrices rhoncus. Phasellus id lacus semper lacus
										suscipit pretium. Nulla mollis ligula id tellus. Duis ac libero. Nulla facilisi.
										Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus sodales lacus
										a risus. Sed quis lectus. Morbi condimentum nulla non purus.Sed quis lectus. Morbi
										condimentum nulla non purus. Sed quis lectus. Morbi condimentum nulla non purus.
									</p>
									<p>
										Sed egestas, ante et vulputate volutpat, eros pede semper est, vitae luctus metus
										libero eu augue. Morbi purus libero, faucibus adipiscing, commodo quis, gravida
										id, est. Sed lectus. Praesent elementum hendrerit tortor. Sed semper lorem at felis.
										Vestibulum volutpat, lacus a ultrices sagittis, mi neque</p>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
		<div class="colModules">
			<sabesp:numerosBox ID="numerosBox1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita runat="server" ID="menuDireita" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:boxDirFoto runat="server" ID="boxDirFoto" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" runat="Server">

	<script src="../contents/js/carroselPaginado.js" type="text/javascript"></script>

</asp:Content>
