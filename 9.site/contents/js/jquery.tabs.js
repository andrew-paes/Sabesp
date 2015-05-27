/**
 * Tabs
 * @autor Leandro Barbosa
 *
 * Version: 1.0
 */

(function($) {
    $.fn.extend({
        // Tabs
        tabs: function() {

            $(this).each(function() {
                $obj = $(this);
                $btnAbas = $obj.find("a");
                $itmAbas = $obj.find("li");
                $abaContent = $obj.find(".abaContent");

                $btnAbas.click(function(e) {
                    $botao = $(this);
                    var $aba = $($botao.attr('href'));
                    if ($botao.attr('href').toString().substring(0, 1) == '#') {
                        $itmAbas.removeClass("on");
                        $botao.parent().parent().addClass("on");

                        $abaContent.removeClass("on");
                        $aba.addClass("on");

                        e.preventDefault();
                    }
                });
            });

        }
    });
})(jQuery);

$(".abas").tabs();