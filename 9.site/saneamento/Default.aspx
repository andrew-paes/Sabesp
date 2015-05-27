<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true"
	CodeFile="Default.aspx.cs" Inherits="saneamento_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

	<script type="text/javascript">
		swfobject.registerObject("flashCicloAgua", "9.0.115", "../contents/swf/expressInstall.swf");
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft">
		<h2>
			<asp:Literal ID="ltlTitulo" runat="server"></asp:Literal></h2>
		<div class="colContent fullWidth">
			<div class="colContentLeft">
				<%--############
				First
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxFirst" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgFirstItem" AlternateText="" runat="server" Width="393px" />
									</div>
									<asp:HyperLink ID="hplFirstItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptFirst" runat="server" OnItemDataBound="rptFirst_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxFirst" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFirst" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFirst" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensFirst" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensFirst" runat="server"></asp:HyperLink>
											</li>
											<li class="quebra">
												<!-- -->
											</li>
										</AlternatingItemTemplate>
										<FooterTemplate>
											</ul>
										</FooterTemplate>
									</asp:Repeater>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
			<div class="colContentRight">
				<div class="boxDivider">
					<asp:Image ID="Image6" ImageUrl="~/contents/img/Sabesp_Ciclo_Agua.png" runat="server"
						Style="cursor: pointer;" onclick="javascript:window.open('../contents/swf/ciclo_agua.swf','Flash','toolbar=no,status=no,menubar=no,scrollbars=no,resizeable=no,top=100,left=100,width=700,height=425'); return false;" />
					<%--<object id="flashCicloAgua" classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000"
						width="196" height="197">
						<param name="movie" value="../contents/swf/ciclo_agua.swf" />
						<param name="wmode" value="transparent" />
						<!--[if !IE]>-->
						<object id="flashHomeData" type="application/x-shockwave-flash" data="../contents/swf/ciclo_agua.swf"
							width="196" height="197">
							<param name="wmode" value="transparent" />
							<!--<![endif]-->
							<p>
								FLASH não instalado</p>
							<!--[if !IE]>-->
						</object>
						<!--<![endif]-->
					</object>--%>
				</div>
				<div class="boxDivider last">
					<sabesp:numerosBox ID="numerosBox1" runat="server" />
				</div>
				<div class="clr">
					<!-- -->
				</div>
				<%--############
				Third
				############--%>
				<h3 class="boxTitulo">
					<asp:Literal ID="ltlBoxThird" runat="server"></asp:Literal></h3>
				<div class="boxWhite boxWhiteMed tvSabesp">
					<div class="bgrTopRight">
						<div class="bgrBottomRight">
							<div class="bgrBottomLeft boxWhiteMedP">
								<div class="newsDestaque">
									<div class="image after">
										<asp:Image ID="imgThirdItem" AlternateText="" runat="server" Width="384px" />
									</div>
									<asp:HyperLink ID="hplThirdItem" runat="server"></asp:HyperLink>
								</div>
								<div class="newsListContent">
									<asp:Repeater ID="rptThird" runat="server" OnItemDataBound="rptThird_ItemDataBound">
										<HeaderTemplate>
											<ul id="boxThird" class="newsList after">
										</HeaderTemplate>
										<ItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensThird" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensThird" runat="server"></asp:HyperLink>
											</li>
										</ItemTemplate>
										<AlternatingItemTemplate>
											<li>
												<div class="image">
													<asp:Image ID="imgRptItensThird" AlternateText="" runat="server" Width="184px" />
												</div>
												<asp:HyperLink ID="hplRptItensThird" runat="server"></asp:HyperLink>
											</li>
											<li class="quebra">
												<!-- -->
											</li>
										</AlternatingItemTemplate>
										<FooterTemplate>
											</ul>
										</FooterTemplate>
									</asp:Repeater>
								</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="colRight">
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>

	<script type="text/javascript">
		$(document).ready(function() {
			if ($("#boxFirst li:last").attr("class") == "quebra") {
				$("#boxFirst li:last").css("display", "none");
			}
		});
	</script>

</asp:Content>
