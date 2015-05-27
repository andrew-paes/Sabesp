<%@ Control Language="C#" AutoEventWireup="true" CodeFile="noticiaTeste.ascx.cs"
    Inherits="content_module_noticiaTeste_noticiaTeste" %>
<br />
<strong>Título: </strong>
<br />
<asp:TextBox ID="txtTitulo" runat="server" Width="400px" />
<br />
<br />
<strong>Conteúdo: </strong>
<br />
<asp:TextBox ID="txtConteudo" runat="server" TextMode="MultiLine" Rows="10" Width="450px" />
<br />
<br />
<ag2:StatusWorkflow ID="StatusWorkflow1" runat="server" ValidationGroup="1" />
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
    <asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
        Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
        CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
