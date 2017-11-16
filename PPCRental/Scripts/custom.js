(function($) {
	"use strict"; 

  $(window).load(function(){

    // Preloader
    $('#status').fadeOut(); 
    $('#preloader').delay(350).fadeOut('slow'); 
    $('body').delay(350).css({'overflow':'visible'});


    // Dropdown Menu
    $('.theme-menu').find('li:has(ul)').addClass('has-menu');
    $('ul.sf-menu').superfish({
      delay: 1000,                           
      animation: { opacity:'show',height:'show' }, 
      speed: 'fast',                         
      autoArrows: false  
    });


    // ScrollTop
    $(window).scroll(function () {
      if ($(this).scrollTop() > 100) {
        $('#toTop').fadeIn();
      } else {
        $('#toTop').fadeOut();
      }
    });

    $("#toTop").click(function(){
      $("html, body").animate({ scrollTop: 0 }, 600);
      return false;
    });  


    // Fade Text
    setTimeout(function(){
      $(".agent-form .sent").fadeOut("slow", function () {
        $(".agent-form .sent").remove();
      });
    }, 7000);


    // Selectbox
    $('.advance-search-block select').select2();


    // Top Slide
    $('a.slide-toggle').click(function() {
      $('.sliding-bar').slideToggle('fast', function() {
        $('a.slide-toggle').toggleClass('open', $(this).is(':visible'));
      });
      return false;
    });


    // Order and Sort
    $('select[name=sortby]').on('change', function () {
      $('.form-sorting-order').submit();
    });

    $('select[name=order]').on('change', function () {
      $('.form-sorting-order').submit();
    });


    // Masonry
    $('.masonry').masonry({
      itemSelector: '.masonry-item',
      columnWidth: 1,
      isResizable: true,
      isAnimated: true,
      isFitWidth: true,
      animationOptions: { //add animations if you want
        duration: 750,
        easing: 'easeInOutExpo'
      }
    });


    // Carousel
    $('.es-carousel-wrapper').elastislide({ imageW: 330, minItems: 1, margin: 45 });


    // Modal
    $('.large-image-popup').magnificPopup({
      type: 'image',
      gallery:{enabled:true}
    });

    $('.modal-popup').magnificPopup({
      type: 'inline',

      fixedContentPos: false,
      fixedBgPos: true,

      overflowY: 'auto',

      closeBtnInside: true,
      preloader: false,

      midClick: true,
      removalDelay: 300,
      mainClass: 'my-mfp-zoom-in'
    });


    // Disable empty get fields
    $(".searchform").submit(function() {
      $(this).find(":input").filter(function(){ return !this.value; }).attr("disabled", "disabled");
      return true; 
    });
    $( ".searchform" ).find( ":input" ).prop( "disabled", false );

  });

})(jQuery);