<%@ Control Language="C#" AutoEventWireup="true" CodeFile="arquivoEvento.ascx.cs"
	Inherits="content_module_arquivoevento_arquivoevento" %>

<script type="text/javascript">
	$(document).ready(function() {

		$("input[id$='txtOrdem']").setMask('9999');

		// ##
		var btExecute = parent.document.getElementById('ctl00_holderPrincipal_btnExecute');
		var objFechar = top.document.getElementById('shadowbox_nav_close');
		$(objFechar).attr('onclick', '');

		$(objFechar).click(function() {
			$("#loading").slideDown();
			submeteRedireciona();
		});

		$("[id$='btnListar']").click(function() {
			$("#loading").slideDown();
			submeteRedireciona();
		});

		function submeteRedireciona() {
			var t = setTimeout("top.document.location.reload(true)", 500);
			$(btExecute).trigger('click');
		}

	});
        
</script>

<asp:HiddenField ID="hddArquivoId" runat="server" />
<strong>Imagem:</strong>
<br />
<ag2:UploadField runat="server" ID="uplField" TargetFolder="evento/galeria/" MaxFileLength="50000" />
<br />
<br />
<strong>Descrição: </strong>
<br />
<ag2:HtmlTextBox ID="txtDescricao" runat="server" />
<br />
<br />
<strong>Ordem: </strong>
<br />
<asp:TextBox ID="txtOrdem" MaxLength="10" runat="server" Width="400px" />
<br />
<br />
<div class="boxesc" style="vertical-align: bottom;">
	<asp:ImageButton ID="btnExecute" runat="server" ImageUrl="~/img/btn_executar.gif"
		Width="73" Height="20" BorderWidth="0" AlternateText="Executar" ImageAlign="AbsMiddle"
		CausesValidation="true" OnClick="btnExecute_Click" ValidationGroup="1" />
</div>
