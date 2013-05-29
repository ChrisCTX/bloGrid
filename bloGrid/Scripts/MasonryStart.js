$(function () {

    var $tumblelog = $('#tumblelog');

    $tumblelog.imagesLoaded(function () {
        $tumblelog.masonry({
            columnWidth: 10
        });
    });

});