<%@ Control Language="C#" AutoEventWireup="true" CodeFile="controleSessao.ascx.cs"
    Inherits="content_module_controleSessao_controleSessao" %>
<br />
<strong>Seção: </strong>
<br />
<asp:TextBox ID="txtSecao" runat="server" Width="400px" MaxLength="200" Enabled="false" />
<br />
<br />
<strong>Lista de Controles</strong>
<br />
<asp:Repeater ID="rptControle" runat="server" OnItemDataBound="rptControle_ItemDataBound">
    <ItemTemplate>
        <fieldset style="width: 220px;">
            <legend>
                <asp:Literal ID="ltlControle" runat="server"></asp:Literal></legend>
            <br />
            &nbsp;
            <asp:CheckBox ID="chkControle" runat="server" />
            <asp:DropDownList ID="ddlControle" runat="server">
                <asp:ListItem Text="Coluna..." Value="0" />
                <asp:ListItem Text="Coluna 1" Value="1" />
                <asp:ListItem Text="Coluna 2" Value="2" />
            </asp:DropDownList>
            <asp:DropDownList ID="ddlControlePosicao" runat="server">
                <asp:ListItem Text="Posição..." Value="0" />
                <asp:ListItem Text="Posição 1" Value="1" />
                <asp:ListItem Text="Posição 2" Value="2" />
                <asp:ListItem Text="Posição 3" Value="3" />
                <asp:ListItem Text="Posição 4" Value="4" />
                <asp:ListItem Text="Posição 5" Value="5" />
                <asp:ListItem Text="Posição 6" Value="6" />
                <asp:ListItem Text="Posição 7" Value="7" />
                <asp:ListItem Text="Posição 8" Value="8" />
                <asp:ListItem Text="Posição 9" Value="9" />
            </asp:DropDownList>
            <br />
            &nbsp;
        </fieldset>
        <div style="clear: both">
        </div>
    </ItemTemplate>
</asp:Repeater>
<br />
<div class="boxesc" style="vertical-align: bottom;">
    <asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
        Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
        CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
