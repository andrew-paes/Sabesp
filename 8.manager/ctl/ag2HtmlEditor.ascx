<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ag2HtmlEditor.ascx.cs" Inherits="ctl_ag2HtmlEditor"  %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
<script type="text/javascript">
    function validaFck()
    {
        alert('<%=FCKeditor1.ClientID %>');
        var fckBody= FCKeditorAPI.GetInstance('<%=FCKeditor1.ClientID %>');
        alert(fckBody);
    }
</script>
<FCKeditorV2:FCKeditor id="FCKeditor1" BasePath="~/FCKeditor/" runat="server"  Height="500" Width="600" />


