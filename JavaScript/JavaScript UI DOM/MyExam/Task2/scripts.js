/// <reference path="jquery.min.js" />
$.fn.gallery = function (columns) {
    var $this = $(this);
    var $container = $this;

    columns = columns || 4;

    $container.addClass('gallery');
    var $containerWidth = $container.width();

    var $imageContainer = $('.image-container');
    $imageContainer.css('width', $containerWidth / columns - 20);

    $imageContainer.on('click', function () {
            $this = $(this);

            var $previousImage = $this.prev();
            var $nextImage = $this.next();
            var $imageSrc = $this.children('img').attr('src');
            var $previousSrc = $previousImage.children('img').attr('src');
            var $nextSrc = $nextImage.children('img').attr('src');

            var $selectedContainer = $('.selected');
            var $currentSelected = $('#current-image');
            var $previousSelected = $('#previous-image');
            var $nextSelected = $('#next-image');

            $currentSelected.attr('src', $imageSrc);
            $previousSelected.attr('src', $previousSrc);
            $nextSelected.attr('src', $nextSrc);

            $this.parent().addClass('blurred');
            $this.parent().addClass('disabled-background');
        }
    );

    var $previousImageContainer = $('.previous-image');

    $previousImageContainer.on('click', function () {
            $this = $(this);
            var $previousImageSrc = $this.children('img').attr('src');

            $this.parent().parent().find('.blurred').removeClass('blurred');
            $this.parent().parent().find('.disabled-background').removeClass('disabled-background');

            var $prevImg = $this.parent().parent().find($previousImageSrc);

            var $previousPreviousImage = $prevImg.prev();
            var $nextPreviousImage = $prevImg.next();

            var $previousPreviousSrc = $previousPreviousImage.children('img').attr('src');
            var $nextPreviousSrc = $nextPreviousImage.children('img').attr('src');
        }
    );

    var $nextImageContainer = $('.next-image');

    $nextImageContainer.on('click', function () {
            $this = $(this);
            var $nextImageSrc = $this.children('img').attr('src');

            $this.parent().parent().find('.blurred').removeClass('blurred');
            $this.parent().parent().find('.disabled-background').removeClass('disabled-background');
            
            var $prevImg = $this.parent().parent().find($nextImageSrc);
        
            var $nextPreviousImage = $prevImg.prev();
            var $nextNextImage = $prevImg.next();
            
            var $nextPreviousSrc = $nextPreviousImage.children('img').attr('src');
            var $nextNextSrc = $nextNextImage.children('img').attr('src');

        }
    );

    return $this;
};