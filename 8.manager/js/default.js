/// <reference path="~/js/jquery-1.3.2-vsdoc.js" />

//Controle a modal de mensagens do sistema
var showMsg = false;

var formIsChanged = false;

// Função Popup: <a href="arquivo.ext" onclick="popup(this.href,'360','535','1'); return false;"></a>
function popup(url, w, h, s) {
    var oW = window.open(url, 'popup', 'width=' + w + ',height=' + h + ',directories=0,location=0,menubar=0,resizable=0,scrollbars=' + s + ',status=0,toolbar=0,marginleft=0,margintop=0,left=' + (((screen.availWidth - w) / 2) + -10) + ',top=' + (((screen.height - h) / 2) + -10));
}

//Função para mostrar/ocultar menu

imgDivisorAberto = new Image();
imgDivisorAberto.src = "../../img/img_divisor.gif";
imgDivisorFechado = new Image();
imgDivisorFechado.src = "../../img/img_divisor_fechado.gif";

function mostra(item) {
    if (document.getElementById(item).style.display == "block") {
        document.getElementById(item).style.display = "none";
        if (document.images) {
            document.images["seta_divisor"].src = eval("imgDivisorFechado.src");
        }
    } else {
        document.getElementById(item).style.display = "block";
        if (document.images) {
            document.images["seta_divisor"].src = eval("imgDivisorAberto.src");
        }
    }
}

//Função para mostrar/ocultar submenus
var SubMenuAnt;
var bltSubMenuAnt;
imgMenuMenos = new Image();
imgMenuMenos.src = "../img/blt_menos.gif";
imgMenuMais = new Image();
imgMenuMais.src = "../img/blt_mais.gif";

function mostrasub(item) {
    if (SubMenuAnt == "submenu_" + item) {
        if ($("#submenu_" + item).height() > 0) {
            $("#submenu_" + item).show();
            $("#submenu_" + item).attr("src", eval("imgMenuMais.src"));
        }
    } else {
        if (SubMenuAnt != undefined) {
            $("#" + SubMenuAnt).hide();
            document.images[bltSubMenuAnt].src = eval("imgMenuMais.src");
        }
        $("#submenu_" + item).show();
        document.images["bltmenu" + item].src = eval("imgMenuMenos.src");
        SubMenuAnt = "submenu_" + item;
        bltSubMenuAnt = "bltmenu" + item
    }
}


//Função para selecionar todas as checkboxes
var checkboxes = 1;

function seleciona(thisForm) {
    if (checkboxes == 1) {
        selecionacheck(thisForm);
        checkboxes = 0;
    } else {
        selecionauncheck(thisForm);
        checkboxes = 1;
    }
}

function selecionacheck(thisForm) {
    for (i = 0; i < thisForm.linha.length; i++)
        thisForm.linha[i].checked = true;
}

function selecionauncheck(thisForm) {
    for (i = 0; i < thisForm.linha.length; i++)
        thisForm.linha[i].checked = false;
}

//Funções do menu
function IEHoverPseudo() {
    if (document.getElementById("menu") != null) {
        var navItems = document.getElementById("menu").getElementsByTagName("li");
        for (var i = 0; i < navItems.length; i++) {
            if (navItems[i].className == "menuparent") {
                navItems[i].onmouseover = function() { this.className += " over"; escondeSelect(); }
                navItems[i].onmouseout = function() { this.className = "menuparent"; exibeSelect(); }
            }
        }
    }

}
window.onload = IEHoverPseudo;

function escondeSelect() {
    var doc = document.getElementsByTagName("select");
    for (var i = 0; i < doc.length; i++) {
        doc[i].style.visibility = "hidden";
    }
}

function exibeSelect() {
    var doc = document.getElementsByTagName("select");
    for (var i = 0; i < doc.length; i++) {
        doc[i].style.visibility = "visible";
    }
}


function SelectAllCheckboxes(spanChk) {

    // Added as ASPX uses SPAN for checkbox
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ?
    spanChk : spanChk.children.item[0];
    xState = theBox.checked;
    elm = theBox.form.elements;

    for (i = 0; i < elm.length; i++)
        if (elm[i].type == "checkbox" &&
          elm[i].id != theBox.id) {
        //elm[i].click();
        if (elm[i].checked != xState)
            elm[i].checked = !elm[i].checked;
        //elm[i].click();
        //elm[i].checked=xState;
    }
}

function SelectAllCheckboxesGrid(spanChk, grid) {

    // Added as ASPX uses SPAN for checkbox
    var oItem = spanChk.children;
    var theBox = (spanChk.type == "checkbox") ?
    spanChk : spanChk.children.item[0];
    xState = theBox.checked;
    elm = theBox.form.elements;
    gridpai = String(grid);
    for (i = 0; i < elm.length; i++)
        if (elm[i].type == "checkbox" &&
            elm[i].id != theBox.id &&
            String(grid) == String(elm[i].id).substring(0, gridpai.length)) {
        //elm[i].click();
        if (elm[i].checked != xState)
            elm[i].checked = !elm[i].checked;
        //elm[i].click();
        //elm[i].checked=xState;
    }
}

//variavel global
var haveItensSelected = false;
var filterBoxFx;

function abre_fecha_box(id) {
    d = document.getElementById(id);
    seta = document.getElementById("seta_" + id);
    if (d.style.display == "block") {
        d.style.display = "none";
        seta.src = "../../img/blt_seta_down.gif";
    }
    else {
        d.style.display = "block";
        seta.src = "../../img/blt_seta_up.gif";
    }
}

function showFilter(buttonFilter, show) {
    var display = "";
    var src = "";
    if (show) {
        display = "block";
        src = "../img/btn_aplicar_filtro_des.gif";
    } else {
        display = "none";
        src = "../img/btn_aplicar_filtro.gif";
    }

    document.getElementById("ctl00_holderPrincipal_IsShwoFilterBox").value = (show == true ? "S" : "N");

    buttonFilter = document.getElementById("ctl00_holderPrincipal_showFilter");

    table = document.getElementById("ctl00_holderPrincipal_tableFilter");
    table.style.display = display;
    buttonFilter.src = src;
}

function ExibeFiltro() {
    var divFiltroProduto = document.getElementById("ctl00_holderPrincipal_divFiltroProduto");
    var btnFiltroProduto = document.getElementById("btnFiltroProduto");

    if (divFiltroProduto.style.display == 'none') {
        divFiltroProduto.style.display = 'block';
        btnFiltroProduto.src = "../img/btn_aplicar_filtro_des.gif";
    }
    else {
        divFiltroProduto.style.display = 'none';
        btnFiltroProduto.src = "../img/btn_aplicar_filtro.gif";
    }
}

$(document).ready(function() {

    $("#managerLogin_UserName").focus();

    $(".barraflags").click(function() {
        $("#ctl00_hdnIdioma").val($(this).attr("rel"));
        
        if (formIsChanged) {
            return confirm("Você alterou os dados do formulário mas não salvou ainda!\nDeseja mudar o idioma mesmo assim?");
        }
    });

    //VERIFICA SE O FORM FOI MODIFICADO
    $("#aspnetForm *").bind("change", function() {
        formIsChanged = true;
    });

    $("#holderPrincipal1").hide();
    $("#holderPrincipal1").slideDown(500);

    //AJUSTA POSIÇAO DO MENU
    var strHeight = document.body.scrollHeight;
    $("#trBorda").prepend('<td style="height:' + strHeight + 'px;" class="borda2"><div class="borda2"><!-- //--></div></td>');

    //MONSTRA O TD DO MENU
    $(".menu").show();

});

function RedirectEdit(url, obj) {
    $("#ctl00_hdnIdioma").val($(obj).attr("rel"));
}

