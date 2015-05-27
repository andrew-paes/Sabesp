<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tv-sabesp-YouTube.aspx.cs"
	Inherits="tv_Sabesp_YouTube" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
	<div style="margin: 10px;">
		<div style="float: left; width: 350px; height: 500px; overflow: scroll;">
			<asp:Repeater ID="repVideoList" runat="server" OnItemDataBound="repVideoList_ItemDataBound"
				OnItemCommand="repVideoList_ItemCommand">
				<HeaderTemplate>
					<table>
				</HeaderTemplate>
				<ItemTemplate>
					<tr>
						<td>
							<asp:LinkButton ID="btnShowVideo" runat="server">Show Video</asp:LinkButton>
							<br />
							<asp:Image ID="imgThumb" runat="server" />
							<br>
							<strong>
								<asp:Literal ID="Title" runat="server"></asp:Literal></strong>
							<br />
							<asp:Literal ID="Description" runat="server"></asp:Literal>
							<br />
							Rating:
							<asp:Literal ID="Ratings" runat="server"></asp:Literal>
							<br />
							Comments:
							<asp:Literal ID="NoOfComments" runat="server"></asp:Literal>
							<br />
							Duration:
							<asp:Literal ID="Duration" runat="server"></asp:Literal>
							<br />
							Keywords:
							<asp:Literal ID="Keywords" runat="server"></asp:Literal>
							<br />
							<br />
						</td>
					</tr>
				</ItemTemplate>
				<FooterTemplate>
					</table>
				</FooterTemplate>
			</asp:Repeater>
		</div>
		<div style="float: left; margin-left: 15px; width: 600px;">
			<object width="480" height="385" style="float: left; clear: both; margin-bottom: 10px;">
				<param name="movie" value="http://www.youtube.com/v/<%=YouTubeMovieID %>&hl=en&fs=1&rel=0">
				</param>
				<param name="allowFullScreen" value="true"></param>
				<param name="allowscriptaccess" value="always"></param>
				<embed src="http://www.youtube.com/v/<%=YouTubeMovieID %>&hl=en&fs=1&rel=0" type="application/x-shockwave-flash"
					allowscriptaccess="always" allowfullscreen="true" width="480" height="385"></embed>
			</object>
			<div style="float: left;">
				<asp:Label ID="lblDescription" runat="server"></asp:Label>
			</div>
		</div>
		<div style="float: left; margin-left: 20px">
			<br />
			<br />
			Busca:
			<asp:TextBox ID="txtBusca" runat="server" />
			<asp:Button ID="btnBusca" runat="server" Text="Buscar" OnClick="btnBusca_Click" />
			- Resultados:
			<asp:Literal ID="ltrResultados" runat="server" />
		</div>
	</div>
	</form>
</body>
</html>
