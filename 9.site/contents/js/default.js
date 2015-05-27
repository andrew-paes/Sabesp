
/* AVALIACAO DE CONTEUDO - COMPARTILHE */
$(".avalieContent a.compartilhe").click(function(evt) {
	$("div.boxSocialMedia").fadeIn();
	evt.preventDefault();
});
$(".avalieContent a.lnkClose").click(function(evt) {
	$("div.boxSocialMedia").fadeOut();
	evt.preventDefault();
});

/**
* ANIMA BANNER - HOME
*/
function animaBanner(obj, tempo) {
	var cont = obj.length;
	var i = 0;
	var lnk = "<a href=''></a>";

	setInterval(
        function() {
        	if (i == cont) {
        		i = 0;
        	}

        	img = "<img src='" + obj[i++][0] + "' />";

        	$("#contentBannersHome").html(img.link(obj[i][1]));
        }, tempo
    );
}


/**
* ABRE EXTERNAL EM NOVA JANELA
*/
$("a[rel*='external']").click(function(e) {
	window.open($(this).attr("href"));
	e.preventDefault();
});

/**
* LIMPA CAMPO NO FOCO
*/
(function(seletor) {
	var limpaCampo = {
		// Foco
		foco: function() {
			var $obj = $(this);
			if ($obj.val() == $obj.attr("title"))
				$obj.val("");
		},
		// Blur
		blur: function() {
			var $obj = $(this);
			if ($obj.val() == "")
				$obj.val($obj.attr("title"));
		}
	}

	// Eventos
	$(seletor).focus(limpaCampo.foco).blur(limpaCampo.blur);
})(".limpaCampo");

/**
* MENU
*/
(function(seletor) {
	$(seletor).each(function() {
		var bgPositionHor = $(this).attr("rel").replace("l", "");

		$(this).css({ backgroundPosition: bgPositionHor + " 0" }).hover(
			function() {
				$(this).stop().animate({ backgroundPosition: "(" + bgPositionHor + " -69px)" }, { duration: 500 });
			},
			function() {
				$(this).stop().animate({ backgroundPosition: "(" + bgPositionHor + " 0)" }, { duration: 200, complete: function() {
					$(this).css({ backgroundPosition: bgPositionHor + " 0" });
				} 
				});
			}
		);
	});
})("#lstMenu a");

/**
* CONTRASTE
*/
(function(seletor) {
	var contraste = {
		toggle: function(e) {
			var $css = $("#cssContraste");

			if ($css.size() > 0) {
				$css.attr("disabled", "true").remove();
			} else {
				var cssRoot = $("#ctl00_cssDefault").attr("href");
				cssRoot = cssRoot.substr(0, cssRoot.lastIndexOf("/"));
				$("head").append('<link type="text/css" rel="Stylesheet" id="cssContraste" href="' + cssRoot + '/contraste.css" />');
			}

			e.preventDefault();
		}
	}

	// Eventos
	$(seletor).click(contraste.toggle);
})("a[id$=lnkContraste]");

/**
* FONT SIZE
*/
(function(seletor) {
	var $wrapper = $("#boxWrapper");
	var limite = 2;
	var size = $wrapper.attr("class").split("fontSize")[1];

	var fontsize = {
		resize: function(e) {
			var $obj = $(this);
			var action = $obj.attr("href").replace("#", "");

			if (action == "aumenta" && size < limite) {
				$wrapper.attr("class", "fontSize" + (++size));
			} else if (action == "diminui" && size > 0) {
				$wrapper.attr("class", "fontSize" + (--size));
			}

			e.preventDefault();
		}
	}

	// Eventos
	$(seletor).click(fontsize.resize);
})("#lnkAumentaFonte, #lnkDiminuiFonte");

/**
* CAROUSEL
*/
/*
(function(seletor) {
$(seletor).jcarousel({
auto: 3, // how many seconds to periodically autoscroll
wrap: 'last', // 'first', 'last' or 'both'
scroll: 3, // The number of items to scroll by
animation: 1000, // The speed of the scroll animation
initCallback: function(carousel) {
// Disable autoscrolling if the user clicks the prev or next button.
carousel.buttonNext.bind('click', function() { carousel.startAuto(0); });
carousel.buttonPrev.bind('click', function() { carousel.startAuto(0); });

// Pause autoscrolling if the user moves with the cursor over the clip.
carousel.clip.hover(function() {
carousel.stopAuto();
}, function() {
carousel.startAuto();
});
} // function that is called right after initialisation of the carousel
});
})("#boxCarrossel ul");
*/

/**
* MENU EXTREMA DIREITA
*/
/*
(function(seletor) {
$(seletor).toggle(
function(){
$(this).parent().addClass("on");
$(this).next().show(200);
},
function(){
$(this).next().hide(200);
$(this).parent().removeClass("on");
}
);
})("#colRightB .menuDireita span");
*/

/**
* SELECT MASK
*/
if (!($.browser.msie && parseInt($.browser.version) == 6))
	$(".boxSelect select").each(function() {
		$(this).before('<var class="value">' + $(this).find("option[selected]").html() + '</var>');
		$(this).change(function() {
			$(this).prev().html($(this).find("option[selected]").html());
		});
		$(this).focus(function() {
			$(this).parent().parent().addClass("foco_select");
		});
		$(this).blur(function() {
			$(this).parent().parent().removeClass("foco_select");
		});
		$(this).keypress(function() { $(this).trigger("change") });
	});

/**
* EXPANSIVEIS
*/
$('.expansivel dt').click(function() {
	lk = $(this);
	tx = $(this).next();

	if (tx.is(':visible')) {
		tx.slideUp(500, function() { lk.removeClass('atv'); });
	} else {
		tx.slideDown(500);
		lk.addClass('atv');
	}
});

/**
* GALERIA DE IMAGENS NEWS
*/
$('.galeria .numeral li a').click(function() {
	var vlr = $(this).html() - 1;
	$('.galeria .numeral li').removeClass('atv');
	$(this).parent().addClass('atv');
	$('.galeria .fotos li').not($('.galeria .fotos li:eq(' + vlr + ')')).fadeOut($('.galeria .fotos li:eq(' + vlr + ')').fadeIn());
})

/**
* COLOCA  A ALTURA DE MAIOR VALOR EM TODOS OS LI´S DA LISTA
*/
var tul = 0;
$('.galeriaList > li').each(function() {
	var tv = $(this).height();

	if (tul <= tv) {
		tul = tv;
	}
});
$('.galeriaList > li').css('height', tul);

/**
* NAV GLOSARIO
*/
$('.listLetra li a').click(function() {
	$('.listLetra li a').removeClass('atv');
	$(this).addClass('atv');
});

/* AVALIACAO DE CONTEUDO - COMPARTILHE */
$(".avalieContent a.compartilhe").click(function(evt){
	$("div.boxSocialMedia").fadeIn();
	evt.preventDefault();
});
$(".avalieContent a.lnkClose").click(function(evt){
	$("div.boxSocialMedia").fadeOut();
	evt.preventDefault();
});

//$('table').addClass('zebrada');

// TABELAS / LISTAS ZEBRADAS
$(".bgrBottomLeft table").addClass("zebrada"); // adiciona a classe 'zebrada' em TODAS as tabelas que estiverem dentro da div bgrBottomLeft (normalmente eh o conteudo de uma div)
$("table.zebrada tbody tr:first-child").addClass("head");
$("table.zebrada tbody tr:odd").addClass("alt");

$("ul.zebrada li:odd").addClass("alt");


/**
* Array de objectos de qual caracter deve substituir seu par com acentos
*/
var specialChars = [
	{ val: "a", let: "áàãâä" },
	{ val: "e", let: "éèêë" },
	{ val: "i", let: "íìîï" },
	{ val: "o", let: "óòõôö" },
	{ val: "u", let: "úùûü" },
	{ val: "c", let: "ç" },
	{ val: "A", let: "ÁÀÃÂÄ" },
	{ val: "E", let: "ÉÈÊË" },
	{ val: "I", let: "ÍÌÎÏ" },
	{ val: "O", let: "ÓÒÕÔÖ" },
	{ val: "U", let: "ÚÙÛÜ" },
	{ val: "C", let: "Ç" },
	{ val: "", let: "?!()" }
];

/**
* Função para substituir caractesres especiais.
* @param {str} string
* @return String
*/
function replaceSpecialChars(str) {
	var $spaceSymbol = '_';
	var regex;
	var returnString = str;
	for (var i = 0; i < specialChars.length; i++) {
		regex = new RegExp("[" + specialChars[i].let + "]", "g");
		returnString = returnString.replace(regex, specialChars[i].val);
		regex = null;
	}
	return returnString.replace(/\s/g, $spaceSymbol);
};


// FORMULARIOS
$("#ctl00_ContentPlaceHolder1_rdoPFouPJ_0").click(function(){
	$("div.boxCNPJ").hide();
	$("div.boxCPF").fadeIn();
});
$("#ctl00_ContentPlaceHolder1_rdoPFouPJ_1").click(function(){
	$("div.boxCPF").hide();
	$("div.boxCNPJ").fadeIn();
});

$(".fldCEP").mask("99.999-999");
$(".fldCPF").mask("999.999.999-99");
$(".fldCNPJ").mask("99.999.999/9999-99");
//$(".fldRG").mask("9999999999");
$(".inpTelefone").mask("(99) 9999-9999");
