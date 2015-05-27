<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Usuario.ascx.cs" Inherits="content_module_Usuario_Usuario" %>
<div>
    Usuário
    <asp:RequiredFieldValidator ControlToValidate="txtUsuario" ValidationGroup="1" ID="RequiredFieldValidator1"
        runat="server" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtUsuario" CssClass="frmborder" MaxLength="100" runat="server"
        Width="400px"></asp:TextBox>
    <br />
    <br />
    E-mail
    <asp:RequiredFieldValidator ControlToValidate="txtEmail" ValidationGroup="1" ID="RequiredFieldValidator2"
        runat="server" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
    <br />
    <asp:TextBox ID="txtEmail" CssClass="frmborder" MaxLength="150" runat="server" Width="400px"></asp:TextBox>
    <br />
    <br />
    <asp:PlaceHolder ID="phSenha" runat="server">Senha
        <asp:RequiredFieldValidator ControlToValidate="txtSenha" Display="Dynamic" ValidationGroup="1"
            ID="RequiredFieldValidator3" runat="server" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtSenha" ControlToCompare="txtSenhaConfirmacao"
            runat="server" ErrorMessage="Senha não confirmada" Operator="Equal" ValidationGroup="1"></asp:CompareValidator>
        <br />
        <asp:TextBox ID="txtSenha" CssClass="frmborder" TextMode="Password" MaxLength="150"
            runat="server" Width="400px"></asp:TextBox>
        <br />
        <br />
        Confirmação de Senha
        <asp:RequiredFieldValidator ControlToValidate="txtSenhaConfirmacao" ValidationGroup="1"
            ID="RequiredFieldValidator4" runat="server" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
        <br />
        <asp:TextBox ID="txtSenhaConfirmacao" TextMode="Password" CssClass="frmborder" MaxLength="150"
            runat="server" Width="400px"></asp:TextBox>
        <br />
        <br />
    </asp:PlaceHolder>
    Perfil
    <asp:RequiredFieldValidator ControlToValidate="cmbPerfil" ValidationGroup="1" ID="RequiredFieldValidator5"
        runat="server" ErrorMessage="Campo Obrigatório"></asp:RequiredFieldValidator>
    <br />
    <asp:DropDownList ID="cmbPerfil" CssClass="frmborder" runat="server">
    </asp:DropDownList>
    <br />
    <br />
    <asp:CheckBox ID="chkBloqueado" Text="Usuário Bloqueado" runat="server" />
    <br />
    <br />
</div>
<div class="boxesc" style="vertical-align: bottom;">
    <asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
        Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
        CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>



