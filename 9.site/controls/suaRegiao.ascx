<%@ Control Language="C#" AutoEventWireup="true" CodeFile="suaRegiao.ascx.cs" Inherits="CltSuaRegiao" %>
<div class="boxGray">
	<h3>
		<asp:Literal ID="Literal1" runat="server">Sua Região</asp:Literal></h3>
	<div class="bgrBottomRight">
		<div class="bgrBottomLeft boxBorderP">
			<p>
				<asp:Literal ID="Literal2" runat="server">Veja o que a Sabesp fez onde você mora. Digite o nome do seu município.</asp:Literal></p>
			<div class="form after">
				<table width="100%">
					<tr>
						<td class="tdLeft">
							<asp:TextBox ID="txtMunicipio" runat="server" Text="Digite aqui" ToolTip="Digite aqui"
								CssClass="limpaCampo"></asp:TextBox>
						</td>
						<td class="tdRight">
							<asp:ImageButton ID="imgBtnIr" AlternateText="Ir" runat="server" ImageUrl="~/contents/img/spacer.gif"
								CssClass="btIr" OnClick="imgBtnIr_Click" />
						</td>
					</tr>
				</table>
			</div>
		</div>
	</div>
</div>

<script type="text/javascript" language="javascript">
	$(document).ready(function() {
		$("input[id$='txtMunicipio']").autocomplete('<%=ResolveUrl("~/AutoCompleteMunicpios.aspx") %>', {
			delay: 10,
			minChars: 1,
			cacheLength: 10,
			matchCase: false,
			matchSubset: false,
			matchContains: false,
			mustMatch: false,
			autoFill: false

			//			,formatItem: function(data, i, n, value) {
			//				return value.split("-")[0];
			//			}
		});

		//		$("input[id$='txtMunicipio']").result(function(event, data, formatted) {
		//			var employeeId = data.toString().split("-")[1];
		//			window.location = "../interna/Municipio.aspx?secaoId=18&id=" + employeeId
		//		});
		
		$(".bgrBottomLeft .form table").removeClass("zebrada");
	});


</script>

