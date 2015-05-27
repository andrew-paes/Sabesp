<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="_default" %>

<%@ Register TagPrefix="ag2" TagName="Header" Src="~/ctl/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
	<title>.: Manager - AG2 :.</title>

	<script src="js/jquery-1.3.2.js" type="text/javascript"></script>

	<script src="js/default.js" type="text/javascript"></script>

	<script src="js/sifr.js" type="text/javascript"></script>

	<script src="js/jquery.blockUI.js" type="text/javascript"></script>

	<script src="js/progress.js" type="text/javascript"></script>

	<link rel="stylesheet" href="css/home.css" type="text/css" />
	<link rel="stylesheet" href="css/cliente.css" type="text/css" />
</head>
<body>
	<div id="estilo">
		<ag2:Header ID="Header1" runat="server" />
		<div id="login">
			<form method="post" runat="server" id="formLogin">
			<asp:ScriptManager ID="ScriptManager1" EnableScriptGlobalization="true" runat="server">
			</asp:ScriptManager>
			<asp:UpdatePanel ID="updLogin" runat="server">
				<ContentTemplate>
					<asp:Login ID="managerLogin" runat="server">
						<LayoutTemplate>
							Para voc� acessar este servi�o, voc� deve ser um usu�rio cadastrado no sistema.<br />
							Forne�a seu login e senha nos campos abaixo.
							<div id="usuario">
								Usu�rio:<asp:TextBox ID="UserName" runat="server" CssClass="usuario"></asp:TextBox></div>
							<div id="senha">
								Senha:<asp:TextBox ID="Password" runat="server" CssClass="senha" TextMode="Password"></asp:TextBox>
								<asp:ImageButton ID="LoginButton" runat="server" ImageUrl="img/btn_entrar.gif" CssClass="entrar"
									OnClick="sendLogin_Click" /></div>
							<asp:Label ID="FailureText" ForeColor="Red" runat="server" Style="margin-left: 45px" />
						</LayoutTemplate>
					</asp:Login>
				</ContentTemplate>
			</asp:UpdatePanel>
			<div id="duvidas">
				<img src="img/ttl_em_caso_duvidas.gif" width="254" height="21" border="0" alt="Em Caso de D�vidas"
					style="margin: 0 0 11px 0;" /><br />
				<ol>
					<li>Entre em contato, <strong><a href="mailto:suporte@ag2.com.br" class="txt">suporte@ag2.com.br</a></strong></li>
					<li>Ligue para n�s:<br />
						S�o Paulo: <strong>55.11.2196-2600</strong><br />
						Porto Alegre: <strong>55.51.2136-9300</strong><br />
						Pelotas: <strong>55.53.3225-8333</strong></li>
				</ol>
			</div>
			</form>
			<div id="ag2">
				AG2 CONTENT MANAGER - Todos os direitos reservados
				<asp:Literal ID="ltrBuild" runat="server"></asp:Literal></div>
		</div>
	</div>
</body>
</html>
