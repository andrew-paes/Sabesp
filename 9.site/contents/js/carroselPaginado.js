

    var qtd = $('.boxCarrossel > li').size() / 4;
    qtd = Math.ceil(qtd);

    for (y = 0; y < qtd; y++) {
        $('.jcarousel-control').append('<a href="#">' + (y * 4) + '</a>');
    }

    $('.jcarousel-control a:first').addClass('atv');
    
    function mycarousel_initCallback(carousel) {
        jQuery('.jcarousel-control a').bind('click', function() {
            $('.jcarousel-control a').removeClass('atv');
            $(this).addClass('atv');
            carousel.scroll(jQuery.jcarousel.intval(jQuery(this).text()));
            return false;
        });
    }
    jQuery(document).ready(function() {
        jQuery('#carroselAgua').jcarousel({
            scroll: 5,
            initCallback: mycarousel_initCallback,
            // This tells jCarousel NOT to autobuild prev/next buttons
            buttonNextHTML: null,
            buttonPrevHTML: null
        });
    });
