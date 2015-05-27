<%@ Control Language="C#" AutoEventWireup="true" CodeFile="secaoConteudo.ascx.cs"
    Inherits="content_module_secaoConteudo_secaoConteudo" %>

<script language="jscript">

</script>


<div style="width: 800px; height: 600px; border: 0px solid black;">
    <div style="width: 100%; height: 40px; border: 0px solid black;">
        <h1>
            Cadastro de Conteúdo</h1>
    </div>
    
    <div style="width: 100%; height: 520px; border: 0px solid black; position:relative;">
        <div style="width: 250px; height: 520px; overflow: scroll; position:absolute; top:0px; left:0px;">
            <ag2:TreeView ID="tvwSecoes" runat="server" OnClientClick="TreeViewOnClick" />
        </div>
        <div style="width: 850px; height: 520px; position:absolute; top:0px; left:250px;">
            <iframe id="frmDetalhes" style="width: 100%; height: 100%;" frameborder="0" scrolling="yes"></iframe>
        </div>
    </div>
    
</div>
