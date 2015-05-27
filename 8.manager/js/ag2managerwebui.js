/*
* Funções de Upload de arquivo
*/

var AG2ManagerWebUI_OpenRetorno = false;
var AG2ManagerWebUI_btnAdicionar;
var AG2ManagerWebUI_hddRetorno;

function AG2ManagerWebUI_OpenModalUpload(btnAdicionar, ParamFuncaoRetorno, pagina, modulo, idPai, id) {
    
    if (!top.AG2ManagerWebUI_OpenRetorno) {
        var objBtnAdicionar = document.getElementById(btnAdicionar);
        var hddRetorno = document.getElementById(objBtnAdicionar.id + 'Retorno');

        top.AG2ManagerWebUI_OpenModalUpload_TOP(objBtnAdicionar, hddRetorno, pagina, modulo, idPai, id, ParamFuncaoRetorno);
        
    }
    return top.AG2ManagerWebUI_OpenRetorno;
}

function AG2ManagerWebUI_OpenModalUpload_TOP(btnAdicionar, hddRetorno, pagina, modulo, idPai, id, ParamFuncaoRetorno) {
    AG2ManagerWebUI_btnAdicionar = btnAdicionar;
    AG2ManagerWebUI_hddRetorno = hddRetorno;

    pagina += (pagina.indexOf("?", 0) > -1) ? "&" : "?";

    var p = "";
    p += pagina;
    p += ParamFuncaoRetorno + '=' + escape('AG2ManagerWebUI_FuncaoRetornoItensSelacionados_TOP');
    p += '&ExibiMaster=false';
    p += '&md=' + modulo;
    p += '&strIdRegistroPai=' + idPai;
    if (!isNaN(id)) p += '&id=' + id;

    window.setTimeout(function() {
        Shadowbox.open({
            player: 'iframe',
            title: '',
            content: p,
            height: 600,
            width: 800
        });
    }, 100);
}

function AG2ManagerWebUI_FuncaoRetornoItensSelacionados(strValores) {

    AG2ManagerWebUI_OpenRetorno = true;
    window.setTimeout(function() {
        Shadowbox.close();
    }, 100);

    $('#' + AG2ManagerWebUI_btnAdicionar.id + 'Retorno').val(strValores);
    
    AG2ManagerWebUI_btnAdicionar.click();

    AG2ManagerWebUI_OpenRetorno = false;

}

function AG2ManagerWebUI_FuncaoRetornoItensSelacionados_TOP(strValores) {

    AG2ManagerWebUI_OpenRetorno = true;
    window.setTimeout(function() {
        Shadowbox.close();
    }, 100);

    AG2ManagerWebUI_hddRetorno.value = strValores;
    AG2ManagerWebUI_btnAdicionar.click();
    AG2ManagerWebUI_OpenRetorno = false;
}


/*
* Funções de Componente de Idiomas
*/


function AG2ManagerWebUI_IdiomaEnter(obj) {
    var s = new String(obj.id);
    s = s.replace(/_divIdioma/g, '_btnAcao');

    var img = document.getElementById(s);
    img.className = "BotoesIdioma_acao2";
}
function AG2ManagerWebUI_IdiomaLeave(obj) {
    var s = new String(obj.id);
    s = s.replace(/_divIdioma/g, '_btnAcao');

    var img = document.getElementById(s);
    img.className = "BotoesIdioma_acao1";
}

function AG2ManagerWebUI_IdiomaClick(obj, hddObjId, value) {

    var hddObj = document.getElementById(hddObjId);
    hddObj.value = value;

    return true;
}

function AG2ManagerWebUI_AcaoClick(objHddStatus, value) {
    objHddStatus.value = value;
    return true;
}

/*//                                   
* Funções de componente de TreeView    
*///                                   

function TreeViewOnClick(secaoId) {

    if (secaoId == '_1' || secaoId == '_2')return false;
    
    var frm = document.getElementById("frmDetalhes");
    var src = "";

    src += "?ExibiMaster=0";
    src += "&ExibiBotaoList=0";
    src += "&md=secaoConteudoDetalhe";
    src += "&id=" + secaoId;

    frm.src = "edit.aspx" + src;

    return false;
}

function AG2ManagerWebUI_OpenModal(pagina, modulo, idPai, id) {

    pagina += (pagina.indexOf("?", 0) > -1) ? "&" : "?";

    var p = "";
    p += pagina;
    //p += '&ExibiMaster=false';
    //p += "&ExibiBotaoList=0";
    p += '&md=' + modulo;
    p += '&strIdRegistroPai=' + idPai;
    if (!isNaN(id)) p += '&id=' + id;

    window.location.href = p;
    /*
    window.setTimeout(function() {
        Shadowbox.open({
            player: 'iframe',
            title: '',
            content: p,
            height: 600,
            width: 800
        });
    }, 100);
    */
}

function AG2ManagerWebUI_Historico(pagina, modulo, id) {

    pagina += (pagina.indexOf("?", 0) > -1) ? "&" : "?";

    var p = "";
    p += pagina;
    p += 'modulo=' + modulo;
    p += '&id=' + id;

    window.setTimeout(function() {
        Shadowbox.open({
            player: 'iframe',
            title: '',
            content: p,
            height: 600,
            width: 800
        });
    }, 100);
}