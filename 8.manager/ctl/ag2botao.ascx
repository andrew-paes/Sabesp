<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ag2Botao.ascx.cs" Inherits="ctl_ag2Botao" %>
<asp:LinkButton ID="lnkBotao" runat="server" OnClick="lnkBotao_Click"></asp:LinkButton>

<table id="tbTabela" runat="server" border="0" cellpadding="0" cellspacing="0" onclick="" class="tdBotaoTabela">
    <tr>
        <td height="22" class="tdBotaoFundo1">
            &nbsp;
        </td>
        <td class="tdBotaoFundo2" nowrap height="22">
            <asp:Label ID="txtTexto" runat="server" Text=""></asp:Label>
        </td>
    </tr>
</table>
