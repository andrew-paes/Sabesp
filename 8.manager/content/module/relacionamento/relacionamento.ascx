<%@ Control Language="C#" AutoEventWireup="true" CodeFile="relacionamento.ascx.cs"
    Inherits="content_module_relacionamento_relacionamento" %>
<br />
<asp:Label ID="lblTipoConteudo" runat="server" Font-Bold="true" Text="Tipo de Conteúdo:"></asp:Label>&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlTipoConteudo" CssClass="frmborder" AutoPostBack="true" runat="server"
    OnSelectedIndexChanged="ddlTipoConteudo_SelectedIndexChanged">
</asp:DropDownList>
<br />
<asp:Panel ID="pnVideo" runat="server" Visible="false" Width="100%">
    <fieldset id="fsVideo">
        <legend>Video </legend>&nbsp;&nbsp;
        <asp:TextBox CssClass="frmborder fl" ID="txtSearchVideo" runat="server"></asp:TextBox>
        <asp:ImageButton ImageUrl="~/img/btn_buscar.gif" ID="btnBuscaVideo"  
            ValidationGroup="0" runat="server" Text="Buscar" 
            OnClick="btnBuscaVideo_Click" /><br />
        <br />
        <!-- LISTA DE VIDEOS -->
        <asp:GridView ID="grdVideo" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="autorId" BackColor="White" BorderColor="#DEDFDE"
            CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowDataBound="grdGeral_RowDataBound"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllVideo" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="videoId" />
                <asp:BoundField DataField="tituloVideo" HeaderText="Título" />
                <asp:BoundField DataField="dataHoraPublicacao" HeaderText="Data Publicação" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE VIDEOS -->
        <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravarVideo" 
            ValidationGroup="0" runat="server" Text="Gravar" 
            OnClick="btnGravarVideo_Click" />
        <br />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnPodcast" runat="server" Visible="false" Width="100%">
    <fieldset id="fsPodcast">
        <legend>Podcast </legend>&nbsp;&nbsp;<asp:TextBox CssClass="frmborder" ID="txtSearchPodcast"
            runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:ImageButton 
            ImageUrl="~/img/btn_buscar.gif" ID="btnBuscaPodcast" runat="server"
                Text="Buscar" OnClick="btnBuscaPodcast_Click" ValidationGroup="0" /><br />
        <br />
        <!-- LISTA DE PODCASTS -->
        <asp:GridView ID="grdPodcast" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="podcastId" OnRowDataBound="grdGeral_RowDataBound"
            BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllPodcast" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="podcastiId" />
                <asp:BoundField DataField="tituloPodcast" HeaderText="Título" />
                <asp:BoundField DataField="dataHoraPublicacao" HeaderText="Data Publicação" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE PODCASTS -->
       <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravarPodcast" 
            ValidationGroup="0" runat="server" Text="Gravar" 
            OnClick="btnGravarPodcast_Click" />
        <br />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnComunicado" runat="server" Visible="false" Width="100%">
    <fieldset id="fsComunicado">
        <legend>Comunicado </legend>&nbsp;&nbsp;<asp:TextBox CssClass="frmborder" ID="txtSearchComunicado"
            runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:ImageButton 
            ImageUrl="~/img/btn_buscar.gif" ID="btnBuscaComunicado" runat="server"
                Text="Buscar" OnClick="btnBuscaComunicado_Click" ValidationGroup="0" /><br />
        <br />
        <!-- LISTA DE COMUNICADO -->
        <asp:GridView ID="grdComunicado" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="comunicadoId" OnRowDataBound="grdGeral_RowDataBound"
            BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllComunicado" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="comunicadoId" />
                <asp:BoundField DataField="tituloComunicado" HeaderText="Título" />
                <asp:BoundField DataField="dataExibicaoInicio" HeaderText="Data Inicio" />
                <asp:BoundField DataField="dataExibicaoFim" HeaderText="Data Fim" />               
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE COMUNICADO -->
        <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravarComunicado" 
            ValidationGroup="0" runat="server" Text="Gravar" 
            OnClick="btnGravarComunicado_Click" />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnEvento" runat="server" Visible="false" Width="100%">
    <fieldset id="fsEvento">
        <legend>Evento </legend>&nbsp;&nbsp;<asp:TextBox CssClass="frmborder" ID="txtSearchEvento"
            runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:ImageButton 
            ImageUrl="~/img/btn_buscar.gif" ID="btnBuscaEvento" runat="server"
                Text="Buscar" OnClick="btnBuscaEvento_Click" ValidationGroup="0" /><br />
        <br />
        <!-- LISTA DE EVENTO -->
        <asp:GridView ID="grdEvento" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="eventoId" OnRowDataBound="grdGeral_RowDataBound"
            BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllEvento" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="eventoId" />
                <asp:BoundField DataField="nomeEvento" HeaderText="Nomeghgfhgf" />
                <asp:BoundField DataField="dataHoraEventoInicio" HeaderText="Data Inicio" />
                <asp:BoundField DataField="dataHoraEventoFim" HeaderText="Data Fim" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE EVENTO -->
        <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravarEvento" ValidationGroup="1" runat="server" Text="Gravar" OnClick="btnGravarEvento_Click" />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnNoticia" runat="server" Visible="false" Width="100%">
    <fieldset id="fsNoticia">
        <legend>Notícia </legend>&nbsp;&nbsp;<asp:TextBox CssClass="frmborder" ID="txtsearchNoticia"
            runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:ImageButton 
            ImageUrl="~/img/btn_buscar.gif" ID="btnBuscaNoticia" runat="server"
                Text="Buscar" OnClick="btnBuscaNoticia_Click" ValidationGroup="0" /><br />
        <br />
        <!-- LISTA DE NOTÍCIA -->
        <asp:GridView ID="grdNoticia" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="noticiaId" OnRowDataBound="grdGeral_RowDataBound"
            BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllNoticia" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="noticiaId" />
                <asp:BoundField DataField="tituloNoticia" HeaderText="Titulo" />
                <asp:BoundField DataField="dataExibicaoInicio" HeaderText="Data Inicio" />
                <asp:BoundField DataField="dataExibicaoFim" HeaderText="Data Fim" />
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE NOTÍCIA -->
        <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravarNoticia" 
            ValidationGroup="0" runat="server" Text="Gravar" 
            OnClick="btnGravarNoticia_Click" />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnRelease" runat="server" Visible="false" Width="100%">
    <fieldset id="fsRelease">
        <legend>Release </legend>&nbsp;&nbsp;<asp:TextBox CssClass="frmborder" ID="txtsearchRelease"
            runat="server"></asp:TextBox>&nbsp;&nbsp;<asp:ImageButton 
            ImageUrl="~/img/btn_buscar.gif" ID="btnBuscarRelease" runat="server"
                Text="Buscar" OnClick="btnBuscaRelease_Click" ValidationGroup="0" /><br />
        <br />
        <!-- LISTA DE NOTÍCIA -->
        <asp:GridView ID="grdRelease" runat="server" AutoGenerateColumns="False" BorderStyle="None"
            BorderWidth="1px" DataKeyNames="releaseId" OnRowDataBound="grdGeral_RowDataBound"
            BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
            Width="100%">
            <HeaderStyle CssClass="cabecalho" Height="30px" />
            <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox runat="server" ID="chkSelect" />
                    </ItemTemplate>
                    <HeaderTemplate>
                        <asp:CheckBox ID="chkAllRelease" runat="server" />
                    </HeaderTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="releaseId" />
                <asp:BoundField DataField="tituloRelease" HeaderText="Titulo" />
                <asp:BoundField DataField="dataHoraPublicacao" HeaderText="Data" />                
            </Columns>
            <FooterStyle BackColor="#CCCC99" />
            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <!-- // LISTA DE NOTÍCIA -->
        <asp:ImageButton ImageUrl="~/img/btn_relacionar.gif" ID="btnGravaRelease" 
            ValidationGroup="0" runat="server" Text="Gravar" 
            OnClick="btnGravarRelease_Click" />
    </fieldset>
</asp:Panel>
<asp:Panel ID="pnRelacionar" runat="server" Visible="true" Width="100%">
    <br />
    <br />
    <fieldset id="Fieldset1">
        <legend>Ítem selecionado</legend>&nbsp;&nbsp;
        <br />
        <asp:Label ID="lblTipo" runat="server" Font-Bold="True" Font-Size="Medium"></asp:Label>&nbsp;&nbsp;
        <asp:Label ID="lblNome" runat="server"  Font-Size="Medium"></asp:Label>&nbsp;&nbsp;
       
        <br />
        <asp:Panel ID="pnRelacionados" runat="server" Visible="false" Width="100%">
            <br />
            <!-- LISTA DE CONTEÚDOS RELACIONADOS -->
            <asp:GridView ID="grdRelacionado" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                BorderWidth="1px" DataKeyNames="conteudoId" OnRowDataBound="grdGeral_RowDataBound"
                BackColor="White" BorderColor="#DEDFDE" CellPadding="4" ForeColor="Black" GridLines="Vertical"
                Width="100%" onrowcommand="grdRelacionado_RowCommand">
                <HeaderStyle CssClass="cabecalho" Height="30px" />
                <RowStyle BackColor="#F7F7DE" Height="30px" HorizontalAlign="Center" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:CheckBox runat="server" ID="chkSelect" />
                        </ItemTemplate>
                        <HeaderTemplate>
                            <asp:CheckBox ID="chkAllRelacionado" runat="server" />
                        </HeaderTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="conteudoId" />
                    <asp:TemplateField HeaderText="Título">
                        <ItemTemplate>
                            <asp:Label ID="lblTit" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="tipo" HeaderText="Tipo" />
                </Columns>
                <FooterStyle BackColor="#CCCC99" />
                <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
            <br />
            <asp:ImageButton ImageUrl="~/img/btn_excluir.gif" ID="btnExcluirRelacionamento" 
                runat="server" OnClick="btnExcluirRelacionamento_Click" 
                ValidationGroup="0" Text="Excluir" />
     
            <!-- //LISTA DE CONTEÚDOS RELACIONADOS -->
            <br />
        </asp:Panel>
        <br />
        &nbsp;&nbsp;&nbsp;<asp:Label ID="lblVazio" runat="server" Text="Não existe itens relacionados."
            Visible="false"></asp:Label>
        <br />
    </fieldset>
</asp:Panel>
<br />
