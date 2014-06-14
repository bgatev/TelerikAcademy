function createSlider(index) {
    var $container = $('#container');

    var $prevBtn = $('<button />');
    $prevBtn.attr('id', 'prevImage');
    $prevBtn.html('Previous');

    var $imageElement = $('<img />');

    var $nextBtn = $('<button />');
    $nextBtn.attr('id', 'nextImage');
    $nextBtn.html('Next');
    
    $($prevBtn).css({ float: 'left', position: 'absolute', top: $imageElement.height() / 2 + '%' });
    $($nextBtn).css({ position: 'absolute', top: $imageElement.height() / 2 + '%', left: '460px' });
        
    $imageElement.attr('src', images[index]);
    $($imageElement).css({ position: 'relative', left: '70px' });

    $('#container').append($prevBtn);
    $('#container').append($imageElement);
    $('#container').append($nextBtn);

    return $imageElement;
}

function slide($currentImage, index) {
    
    if (index > 5) index = 0;
    else if (index < 0) index = 5;

    $currentImage.attr('src', images[index]);

    $('#nextImage').on("click", setTimeout(function () {
        var currentIndex = index;
        slide($currentImage,currentIndex + 1);
    }, 5000));

    /*$('#prevImage').on("click", setTimeout(function () {
        var currentIndex = index;
        slide(currentIndex - 1);
    }, 5000));*/
}