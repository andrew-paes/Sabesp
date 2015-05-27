<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TwitterPost.aspx.cs" Inherits="TwitterPost" %>
							<asp:Repeater ID="rptTwitter" runat="server">
								<ItemTemplate>
									<li><asp:Literal ID="litTextoDt" runat="server"></asp:Literal></li>
								</ItemTemplate>
								<AlternatingItemTemplate>
									<li class="bg"><asp:Literal ID="litTextoDt" runat="server"></asp:Literal></li>
								</AlternatingItemTemplate>
							</asp:Repeater>
