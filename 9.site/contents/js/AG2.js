/* Zebra 1.0:	====================================================================================================
	* Plugin criado para criar zebrados em elementos diferentes, sendo padrão as classes "odd" e "even"
	*
	* Exemplo:
	*	CSS: 
	*	.odd {background:#DDD;}
	*	.even {background:#EEE;}
	*
	*	JS:
	*	$("table").zebra("tr","even");
	*	$("table").zebra("tr","odd");
	*
	*/
	jQuery.fn.extend({
	  zebra: function(tag,selector) {
		if(selector == "odd" || selector == "even")
			$(this).find(tag+":"+selector).addClass(selector);
		else
			alert("Invalid selector , please use 'odd' or 'even'.\nExample: $('table').zebra('tr','odd');");
	  }
	});
/* =============================================================================================================== */

/* Popup 1.0:	================================================================================================
	* Serve para os links em popup, sendo que os parametros são passados no rev.
	*
	* Exemplo:
	*	<a href="javascript:;" rel="popup" rev="width=500,height=500,directories=0,location=0,menubar=0,resizable=1,scrollbars=0,status=0,toolbar=0,marginleft=0,margintop=0,left=0,top=0">Link Pop-Up</a>
	*/
	$(function(){ 
		$('a[rel="popup"]').click(function(){
			var n = $('a[rel="popup"]').index(this);
			var oW = window.open($(this).attr("href"),'PopUp_'+n,$(this).attr("rev"));
			return false;
		});
	});
/* =============================================================================================================== */

/* Links Inativos:	================================================================================================
	* Serve para desabilitar um link, ou seja matar o click do link.
	*
	* Exemplo:
	*	<a href="javascript:;" class="off">Link Off</a>
	*/
	$(function(){ 
		$('.off').click(function(){return false;});
	});
/* =============================================================================================================== */

/* Links Externo:	================================================================================================
	* Serve para os links externos, pois não utilizamos mais o target em nossos códigos.
	*
	* Exemplo:
	*	<a href="javascript:;" rel="external">Link Externo</a>
	*/
	$(function(){
		$('a[rel="external"]').click(function(){
			window.open($(this).attr('href'));
			return false;
		});
	});
/* =============================================================================================================== */

/* AG2ToolTip 1.0:	================================================================================================
	* Plugin criado para tooltips simples, onde a primeira variável é a classe de estilo do tooltip, 
	* a segunda é posição horizontal do tooltip em relação ao link e a terceira é a posição vertical
	* do tooltip em relação ao link.
	*
	* Exemplo:
	*	CSS: 
	*	.contentToolTip {width:100px;background:#EEE;border:solid 1px #333;}
	*
	*	JS:
	*	$(".lnkToolTip").AG2ToolTip("contentToolTip","left","top");
	*
	*	HTML:
	*	<a href="javascript:;" class="lnkToolTip" title="Lorem dolor met lorem ipsum dolor ipsum dolor met.">Tooltip</a>
	*
	*/
	jQuery.fn.extend({
	  AG2ToolTip: function(classe,posL,posT){
		var tp = $('<div></div>');
		var c;
		$(this).hover(function(){			
			c = $(this).attr("title");
			var w = $(this).width();
			var h = $(this).height();
			var l = $(this).offset().left;
			var t = $(this).offset().top;
			var pl = 0;
			var pt = 0;

			$(this).attr("title","");
			$(tp).addClass(classe).html(c);
			$("body").append(tp);

			var wo = $(tp).width();
			var ho = $(tp).height();

			switch(posL){
				case "left":
					pl = l- wo;
					break;
				case "right":
					pl = l+w;
					break;
				default: 
					alert("Horizontal position is invalid, use 'left' or 'right'.");
					pl = l+w;
			}
			switch(posT){
				case "top":
					pt = t-ho;
					break;
				case "bottom":
					pt = t+h;
					break;
				default: 
					alert("Vertical position is invalid, use 'top' or 'left'.");
					pt = t+h;
			}
			$(tp).css({position: "absolute",left: pl+"px",top: pt+"px"});			
		},function(){
			$(tp).remove();
			$(this).attr("title",c);
		});		
	  }
	});
/* =============================================================================================================== */

/* Abas 1.0: =======================================================================================================
	* Funcionalidade de abas, sendo que são representadas por duas listas indefinidas (ul).
	* Sempre é selecionada a primeira aba da lista, isso se não for indicado no caminho da página
	* o ID que é para vir aberto. Exemplo: http://[URL]/default.aspx#ID -> Maiores detalhes no repositório HTML
	*
	* Exemplo:
	*	CSS:
	*	.abas li {float:left;background:#EEE;margin-left:10px;padding:5px;}
	*	.abas li.on {background:#DDD;}
	*	.contentAbas {clear:both;background:#DDD;width:200px;}
	*	.contentAbas li {display:none;}
	*	.contentAbas li.on {display:block;}
	*
	*	JS:
	*	$(".abas").abas(".contentAbas");
	*
	*	HTML:
	*	<ul class="abas">
	*		<li><a href="#lorem1">Lorem</a></li>
	*		<li><a href="#lorem2">Lorem</a></li>
	*	</ul>
	*	<ul class="contentAbas">
	*		<li id="lorem1">
	*			Lorem 1 ipsum dolor met, lorem isopum met dolor met ipsum dolor met, lorem isopum met dolor met.
	*		</li>
	*		<li id="lorem2">
	*			Lorem 2 ipsum dolor met, lorem isopum met dolor met ipsum dolor met, lorem isopum met dolor met.
	*		</li>
	*	</ul>
	*/
	jQuery.fn.extend({
		abas: function(classContentAbas){
			var href = location.href;
			if(href.indexOf("#") > 0){
				var arrHref = href.split('#');
				$("a[href='#"+arrHref[1]+"']").parent("li").addClass("on");
				$('#'+arrHref[1]).addClass("on");
				
				if($(this).find("li.on").length < 1){
					$(this).find("li:first").addClass("on");
					$($(this).find("li:first a").attr("href")).addClass("on");
				}
			}
			else{
				$(this).find("li:first").addClass("on");
				$($(this).find("li:first a").attr("href")).addClass("on");
			}
			$(this).find("li a").click(function(){
				$(this).parent("li").parent("ul").find("li").removeClass("on");
				$(classContentAbas).find("li").removeClass("on");
				$(this).parent("li").addClass("on");
				$($(this).attr("href")).addClass("on");
				return false;
			});
		}
	});
/* =============================================================================================================== */

/* Expansive 1.0: =======================================================================================================
	* Funcionalidade de abre e fecha, sendo que é representada por uma lista definida (dl).
	* O ID que é utilizado se por caso houver a necessidade de vir aberto um box, 
	* então esse ID deve ser especificado na URL como o da funcionalidade de abre e fecha acima.
	*
	* Exemplo:
	*	CSS:
	*	.expansive {width:200px;}
	*	.expansive dt {background:#EEE;}
	*	.expansive dt.on {background:#DDD;font-weight:bold;}
	*	.expansive dd {display:none;background:#DDD;}
	*	.expansive dd.on {display:block;}
	*
	*	JS:
	*	$(".expansive").expansive();
	*
	*	HTML:
	*	<dl class="expansive">
	*		<dt><a href="#box1">Link Abre Fecha</a></dt>
	*		<dd id="box1">
	*			Lorem ipsum dolor met, lorem isopum met dolor met ipsum dolor met, lorem isopum met dolor met.
	*		</dd>
	*
	*			<dt><a href="#box2">Link Abre Fecha</a></dt>
	*		<dd id="box2">
	*			Lorem ipsum dolor met, lorem isopum met dolor met ipsum dolor met, lorem isopum met dolor met.
	*		</dd>
	*	</dl>
	*/
	jQuery.fn.extend({
		expansive: function(){
			var href = location.href;
			if(href.indexOf("#") > 0){
				var arrHref = href.split('#');
				$("a[href='#"+arrHref[1]+"']").parent("dt").addClass("on");
				$('#'+arrHref[1]).addClass("on");
			}
			$(this).find("dt a").click(function(){
				$(this).parent("dt").toggleClass("on");
				$(this).parent("dt").next("dd").toggleClass("on");
				return false;
			});
		}
	});
/* =============================================================================================================== */

/* slideShow 1.0: =======================================================================================================
	* Funcionalidade de slideshow simples, sendo que é passado 3 variaveis: classe do botão próximo ,
	* a classe do botão anterior e se o slideshow é infinito (true/false)
	*
	* Exemplo:
	*	CSS:
	*	.slideShow {background:#FFF;width:280px;border:solid 1px #DDD;padding:20px;}
	*	.slideShow:after {content: ".";display: block;height: 0;clear: both;visibility: hidden;overflow:hidden;}
	*	.slideShow .next {display:block;float:left;background:url(../img/btn_next.gif) top left no-repeat;text-indent:-9999px;width:16px;height:31px;margin-left:10px;margin-top:30px;}
	*	.slideShow .previous {display:block;float:left;background:url(../img/btn_previous.gif) top left no-repeat;text-indent:-9999px;width:16px;height:31px;margin-right:10px;margin-top:30px;}
	*	.slideShow .container {width:145px;float:left;padding:0px;background:url(../img/bgr_container_slideshow.jpg) top left no-repeat;}
	*	.slideShow .container li {font-size:85%;padding:15px;display:none;}
	*	.slideShow .off {filter:alpha(opacity=50);opacity: 0.5;}
	*
	*	JS:
	*	$(".slideShow").slideShow({
	*		classNext: "next",
	*		classPrevious: "previous",
	*		infinit: false
	*	});
	*
	*	HTML:
	*	<div class="slideShow">
	*		<ul class="container">
	*			<li>
	*				This is a "vanilla plain" jqModal window. Behavior and appeareance extend far beyond this.
	*				The demonstrations on this page will show off a few possibilites. I recommend walking
	*				through each one to get an understanding of jqModal <em>before</em> using it.
	*			</li>
	*			<li>
	*				Clicking the overlay will have no effect if the "modal" parameter is passed, or if the
	*				overlay is disabled.
	*			</li>
	*			<li>
	*				"You start with 10 lines of jQuery that would have been 20 lines of tedious DOM JavaScript. By the time you are done it's down to two or three lines and it couldn't get any shorter unless it read your mind."
	*			</li>
	*			<li>
	*				Adds more elements, matched by the given expression, to the set of matched elements. Example: Finds all divs and makes a border. Then adds all paragraphs to the jQuery object to set their backgrounds yellow.
	*			</li>
	*		</ul>
	*	</div>
	*/
	jQuery.fn.extend({
		slideShow: function(v){
			v = $.extend(
				{
				classNext		: 'next',
				classPrevious	: 'previous',
				infinit			: true
				} , v
			);

			var name = $(this).attr("class");
			var n = $('<a href="javascript:;" title="Pr&oacute;ximo" class="'+v.classNext+'">Pr&oacute;ximo</a>');
			if(v.infinit == true){
				var p = $('<a href="javascript:;" title="Anterior" class="'+v.classPrevious+'">Anterior</a>');
			}
			else{
				var p = $('<a href="javascript:;" title="Anterior" class="'+v.classPrevious+' off">Anterior</a>');
			}
			$(this).append(n);
			$(this).prepend(p);
			$(this).find("ul li:first").fadeIn().addClass('on');

			$('.'+v.classNext).click(function(){
				var b = $(this).parent('.'+name);
				$(b).find('.'+v.classPrevious).removeClass("off");
				if(v.infinit == true){
					$(b).find('ul li.on').fadeOut(function(){
						var num = $(b).find('ul li').index(this);
						var lg = $(b).find('ul li').length;
						if(num == lg - 1){
							$(b).find('ul li:first').fadeIn(function(){ $(this).addClass('on') });
						}
						else{
							$(this).next('li').fadeIn(function(){ $(this).addClass('on') });
						}
					}).removeClass('on');
				}
				else{
					var q = $(b).find('ul li').index($(b).find('ul li.on'));
					var l = $(b).find('ul li').length;
					if(q+1 == l - 1){
						$(this).addClass('off');
					}
					if(q < l - 1){
						$(b).find('ul li.on').fadeOut(function(){
							$(this).next('li').fadeIn(function(){ $(this).addClass('on') });
						}).removeClass('on');
					}
				}
			});

			$('.'+v.classPrevious).click(function(){
				var b = $(this).parent('.'+name);
				$(b).find('.'+v.classNext).removeClass("off");
				if(v.infinit == true){
					$(b).find('ul li.on').fadeOut(function(){
						var num = $(b).find('ul li').index(this);
						if(num == 0){
							$(b).find('ul li:last').fadeIn(function(){ $(this).addClass('on') });
						}
						else{
							$(this).prev('li').fadeIn(function(){ $(this).addClass('on') });
						}
					}).removeClass('on');
				}
				else{
					var q = $(b).find('ul li').index($(b).find('ul li.on'));
					if(q-1 == 0){
						$(this).addClass('off');
					}
					if(q > 0){
						$(b).find('ul li.on').fadeOut(function(){
							$(this).prev('li').fadeIn(function(){ $(this).addClass('on') });
						}).removeClass('on');
					}
				}
			});
		}
	});
/* =============================================================================================================== */