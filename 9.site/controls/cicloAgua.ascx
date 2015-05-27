<%@ Control Language="C#" AutoEventWireup="true" CodeFile="cicloAgua.ascx.cs" Inherits="CtlAgencias" %>
<div class="boxDestaques w195">
	<div class="bgrTopRight">
		<div class="bgrTopLeft">
			<div class="content">
				<h3 class="mt5 mb5">
					Ciclo da Água</h3>
                    Veja como a água chega até a sua casa.
			</div>
		</div>
	</div>
	<div class="w200">
        <asp:ImageButton ID="ImageButton1" ImageUrl="~/contents/img/img_cicloagua.gif"
	        Width="196" Height="125" runat="server" PostBackUrl="~/interna/Default.aspx?secaoId=42" />
        <br class="clr" />
	</div>
</div>
