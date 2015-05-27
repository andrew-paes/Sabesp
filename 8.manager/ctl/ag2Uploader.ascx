<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ag2Uploader.ascx.cs" ClassName="ag2Upload" Inherits="ctl_ag2Uploader" %>
<table>
    <tr>
        <td>
            <asp:Image ID="imgImagem" runat="server" Visible="false" Width="100px" />
        </td>
        <td valign="bottom">
            <asp:Label ID="lblArquivo" runat="server" Text="" /><br />
            <asp:FileUpload ID="uplFile" runat="server" Width="270"/>
        </td>
    </tr>
</table>
