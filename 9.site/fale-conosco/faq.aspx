<%@ Page Title="" Language="C#" MasterPageFile="~/masterpages/MasterPage.master"
	AutoEventWireup="true" CodeFile="faq.aspx.cs" Inherits="atendimento_faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
	<div class="colLeft faq">
		<h2>
			<asp:Literal ID="ltrTituloPerguntasFrequentes" runat="server" Text="Perguntas Frequentes" /></h2>
		<div class="colContent">
			<%--EXPANSIVEL--%>
			<asp:Repeater ID="rptFAQ" runat="server" OnItemDataBound="rptFAQ_ItemDataBound">
				<ItemTemplate>
					<dl class="expansivel">
						<%--<dt class="menor">
							<asp:Label ID="lblQuestion" runat="server" /></dt>--%>
						<asp:Literal ID="ltlQuestion" runat="server"></asp:Literal>	
						<dd>
							<div class="bgBottom">
								<div class="ddC">
									<asp:Literal ID="ltlAnswer" runat="server" />
									<br />
									<br />
								</div>
							</div>
						</dd>
					</dl>
				</ItemTemplate>
			</asp:Repeater>
			<%--
			<dl class="expansivel">
                <dt><span>Link do menu</span> </dt>
                <dd>
                    <div class="bgBottom">
                        <div class="ddC">
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                        </div>
                    </div>
                </dd>
            </dl>
            <dl class="expansivel">
                <dt><span>Link do menu</span> </dt>
                <dd>
                    <div class="bgBottom">
                        <div class="ddC">
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                            <p>
                                Etiam mollis commodo tellus. Nullam ultricies dui eu diam. Praesent scelerisque
                                varius diam. Sed venenatis porta quam. Nam lacinia. Proin quis sem. Praesent ultrices
                                imperdiet tellus. Maecenas dictum. Fusce lorem. Nulla facilisi. Praesent fringilla
                                fermentum nulla. Curabitur sagittis. Suspendisse et turpis lacinia massa mattis
                                rutrum.</p>
                        </div>
                    </div>
                </dd>
            </dl>--%>
		</div>
		<div class="colModules">
			<sabesp:faqCategoria ID="faqCategoria1" runat="server" />
		</div>
	</div>
	<div class="colRight">
		<sabesp:menuDireita ID="menuDireita" runat="server" />
		<%--<sabesp:atendimento runat="server" ID="atendimento" />
		<sabesp:redeSociais runat="server" ID="redeSociais" />--%>
		<sabesp:segundaColunaDinamica ID="segundaColunaDinamica1" runat="server" />
	</div>
</asp:Content>
