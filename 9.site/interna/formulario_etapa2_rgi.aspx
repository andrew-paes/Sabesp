<%@ Page Language="C#" MasterPageFile="~/masterpages/MasterPage.master" AutoEventWireup="true" CodeFile="formulario_etapa2_rgi.aspx.cs" Inherits="interna_formulario_etapa_rgi" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="colLeft">
        <div class="colContent fullWidth interna">
            <h2>FALE CONOSCO</h2>
            <div class="colContentLeft">
                <div class="boxFormularios">
                    <div class="aba">
                        <span>Etapa 1</span> <span class="atv">Etapa 2</span>
                    </div>
                    <div class="clr"><!-- --></div>
                    <fieldset>
                        <div class="boxCampo">
                            <asp:Label ID="lblRgi" AssociatedControlID="Rgi" runat="server" Text="Digite o RGI do seu imóvel"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Rgi" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Rgi" Display="Dynamic" CssClass="errorMessage" ID="reqNome" runat="server"><div>Informe o RGI</div></asp:RequiredFieldValidator>
                            <br />Obs: O RGI poderá ser encontrado no canto superior da conta da água.<br />
                            <a href="javascript:;">Clique aqui para saber a localização</a>
                        </div>
                        
                        <div class="boxCampo">
                            <asp:Label ID="lblLogradouro" AssociatedControlID="Logradouro" runat="server" Text="Digite o Logradouro"></asp:Label>
						    <asp:TextBox ValidationGroup="form" ID="Logradouro" runat="server"></asp:TextBox>
						    <asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Logradouro" Display="Dynamic" CssClass="errorMessage" ID="RequiredFieldValidator1" runat="server"><div>Informe o Logradouro</div></asp:RequiredFieldValidator>
                            <br />Ex.: Para Av. Paulista, digitar apenas Paulista e para Av. Barão de Mauá, digitar apenas Maua<br />
                        </div>
                        <div class="clr"><!-- --></div>	
                        <div class="boxCampo">
							<asp:Label ID="lblMunicipio" AssociatedControlID="Municipio" runat="server" Text="Município"></asp:Label>
							<asp:DropDownList ValidationGroup="form" ID="Municipio" runat="server">
								<asp:ListItem Selected="True" Text="" Value=""></asp:ListItem>
								<asp:ListItem Text="São Paulo" Value="sp"></asp:ListItem>
							</asp:DropDownList>
							<asp:RequiredFieldValidator ValidationGroup="form" ControlToValidate="Municipio" Display="Dynamic" CssClass="errorMessage" ID="reqMunicipio" runat="server"><div>Informe o Município</div></asp:RequiredFieldValidator>
						</div>
                        <div class="clr"><!-- --></div>					    
					    <div class="boxCampo boxFull">
						    <asp:ImageButton ValidationGroup="form" ID="btnSolicitar" CssClass="btnSolicitar button" ImageUrl="~/contents/img/btn_nova_pesquisa.gif" runat="server" />
					    </div>
                    </fieldset>
                </div>
            </div>
        </div>
    </div>
    
    <div class="colRight">
		<sabesp:menuDireita ID="menuDireita1" runat="server" />
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="scripts" Runat="Server">
</asp:Content>

