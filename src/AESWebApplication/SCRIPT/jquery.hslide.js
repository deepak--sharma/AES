/////////////////////////////////////////////////////////////////////
// jQuery Horizontal Slider Plugin
//
// Version 1.0
//
// Yusuf Najmuddin
// 4/20/2011
//
// Usage: $('#slide').hslide( options )
//
// Options:  interval          - the interval of slideshow
//           animation         - the duration of sliding animation
//
// Example:
//
//		<body>
//		<style>
//			#slider {width: 450px; height: 250px; padding:0; border:0;}
//			#slider img {padding: 0; margin:0; border:0;}
//			#slider .clicker a {width: 11px; height: 11px; background: #fff; margin-right: 2px;}
//			#slider .clicker a.active {background: #ff0;}
//		</style>
//
//		<script src="http://code.jquery.com/jquery-1.5.2.min.js"></script> 
//		<script src="jquery.hslide.js"></script> 
//		<script>
//			$(function(){
//				$('#slider').hslide();
//			});
//		</script>
//
//		<div id="slider">
//			<div><img src="http://placehold.it/450x250&text=1"></img></div>
//			<div><img src="http://placehold.it/450x250&text=2"></img></div>
//			<div><img src="http://placehold.it/450x250&text=3"></img></div>
//			<div><img src="http://placehold.it/450x250&text=4"></img></div>
//			<div><img src="http://placehold.it/450x250&text=5"></img></div>
//		</div>
//		</body>
//
//
// TERMS OF USE
// 
// This plugin is dual-licensed under the GNU General Public License and the MIT License and
// is copyright 2011 Yusuf Najmuddin http://ynzi.com 
//


(function($){
	var items;
	var width;
	var it;
	var next=0;
	var t, td, tc;
	var args = {
		interval: 5000,
		animation: 800
	};

	function slide(i) { $(td).animate({'left':-1 * i * width}, args.animation); };

	function showdot(i) {
		$(tc).find('a').removeClass('active');
		$(tc).find('a:nth-child('+(i+1)+')').addClass('active');
	};

	function show(i) {
		i = i * 1;
		clearInterval(it);
		showdot(i);
		slide(i);
		it = setInterval(function(){
			i++;
			if (i==items) i=0;
			showdot(i);
			slide(i);
		}, args.interval);
	};
	
	$.fn.hslide = function(o){
		$.extend(args, o);
		t = this;
		$(t).css({position: 'relative', overflow: 'hidden'});

		width = $(this).width();
		height = $(this).height();
		items = $(this).children('div').length;

		$(t).children('div').wrapAll('<div></div>');
		td = $(this).children('div').first().css({position:'absolute', width: width * items});
		$(td).children('div').css({width: width, height: height, overflow:'hidden', 'float': 'left', padding: 0, margin: 0});

		tc = $('<span class="clicker"></span>').prependTo(t).css({position: 'absolute',right:'10px',bottom:'0px','z-index':1000});
		for (var j=0;j< items ;j++ ) {
			$('<a rel="'+j+'"></a>').click(function(){
				show($(this).attr('rel'));
			}).appendTo(tc);
		}
		$(tc).find('a').css({cursor:'pointer','float':'left'});
		show(0);
	};

})(jQuery);

