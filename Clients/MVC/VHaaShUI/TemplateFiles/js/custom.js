/************************************************
Template Name: Insurance-Press Boostrap Template
Author: BoostrapMart
Develop By: BoostrapMart
Developer URL: http://info@bootstrapmart.com
************************************************/

// jQuery to collapse the navbar on scroll
function collapseNavbar() {
    if ($(window).scrollTop() > 50) {
        $(".navbar-fixed-top").addClass("top-nav-collapse");
    } else {
        $(".navbar-fixed-top").removeClass("top-nav-collapse");
    }
}

$(window).scroll(collapseNavbar);
$(document).ready(collapseNavbar);


// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function() {
  if ($(this).attr('class') != 'dropdown-toggle active' && $(this).attr('class') != 'dropdown-toggle') {
    $('.navbar-toggle:visible').click();
  }
});



$(window).load(function(){
    
	// defalt show testimonial tab
	$('.testimonial-tab .testimonial-con').fadeOut();
	$('.testimonial-tab #testimonial-tab3').fadeIn();
    $('.testimonials-tab-content #testimonial-tab3').addClass('active');
	
    
	// Flex Slider
	$('.flexslider').flexslider({
		animation: "fade",
		start: function(slider){
		  $('body').removeClass('loading');
		}
	});
    
    
    // Owl Slider
    var owl = $(".partner-slider");
	owl.owlCarousel({
		items : 3, //10 items above 1000px browser width
		itemsDesktop : [1190,3], //5 items between 1900px and 591px
        itemsDesktopSmall : [1024,3], // 3 items betweem 1020px and 861px
		itemsTablet: [980,2], //2 items between 860 and 0;
        itemsTabletSmall:[767,1], //2 items between 860 and 0;
		itemsMobile : [428,1], // itemsMobile disabled - inherit from itemsTablet option
		paginationNumbers : false,
		navigation  : true,
		navigationText : false,
		rewindNav:false,
		scrollPerPage : true
	});
    
    
});


// Vertical TAB
$(document).ready(function() {
    // Accordion
    function close_accordion_section() {
		$('.accordion .accordion-section-title').removeClass('active');
		$('.accordion .accordion-section-content').slideUp(300).removeClass('open');
	};

	$('.accordion-section-title').click(function(e) {
		// Grab current anchor value
		var currentAttrValue = $(this).attr('href');

		if($(e.target).is('.active')) {
			close_accordion_section();
		}else {
			close_accordion_section();

			// Add active class to section title
			$(this).addClass('active');
			// Open up the hidden content panel
			$('.accordion ' + currentAttrValue).slideDown(300).addClass('open'); 
		}

		e.preventDefault();
	});
    
    $('#parentVerticalTab').easyResponsiveTabs({
        type: 'vertical', //Types: default, vertical, accordion
        width: 'auto', //auto or any width like 600px
        fit: true, // 100% fit in a container
        closed: 'accordion', // Start closed if in accordion view
        tabidentify: 'hor_1', // The tab groups identifier
        activate: function(event) { // Callback function if tab is switched
            var $tab = $(this);
            var $info = $('#nested-tabInfo2');
            var $name = $('span', $info);
            $name.text($tab.text());
            $info.show();
        }
    });
	
	// show testimonial tab
	$('.testimonials-tab-list ul li a').click(function() {
		$('.testimonials-tab-list ul li').removeClass('active');
        $('.testimonials-tab-content .testimonial-con').removeClass('active');
		$('.testimonials-tab-content .testimonial-con').fadeOut('fast');
		$(this).parent().addClass('active');
		$('.testimonial-tab #testimonial-'+$(this).attr('data-tab')).fadeIn(1000).addClass('active');
	});
    
    
    
    
});
