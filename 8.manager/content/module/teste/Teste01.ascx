<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Teste01.ascx.cs" Inherits="content_module_teste_Teste01" %>
<p>
    Este é um teste!!!!</p>
<ag2:SubForm 
    runat="server" 
    ID="subform1" 

    SqlStringCommand="Select * From arquivo Where arquivoId = @arquivoId"
    DataValueField="arquivoId"
    DataTextField="nomeArquivo"
    
    QtdMaxItens="1"
    
    ModuloSubForm="arquivo"
    
     />
    
<br />
<br />

<asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click"  />
