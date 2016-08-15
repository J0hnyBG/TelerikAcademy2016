function solve(cols) {
    return function (cols) {
        /* globals $ */
        $.fn.gallery = function (cols) {
            cols = cols || 4;
            var $imageContainers = $('.image-container'),
                $gallery = $('.gallery'),
                $galleryList = $('.gallery-list'),
                $selected = $('.selected'),
                $currentImage = $('#current-image'),
                $previousImage = $('#previous-image'),
                $nextImage = $('#next-image'),
                $background = $('<div></div>'),
                maxImgId = $imageContainers.last().children('img').data('info'),
                minImgId = $imageContainers.first().children('img').data('info'),
                count = 0;


            $imageContainers.each(function (index, image) {
                var $image = $(image);
                count += 1;
                if (count === cols && index < $imageContainers.length - 1) {
                    $image.next().addClass('clearfix');
                    count = 0;
                }
            });

            $selected.hide();

            $galleryList.click(function (e) {
                var $target = $(e.target);
                if ($target.parent().hasClass('image-container') || $target.is('img')) {
                    $gallery.append($background);

                    var imageId = $target.data('info');
                    changeImageSrcById(imageId);

                    toggleSelectedVisibility();
                }
            });
            $currentImage.click(function () {
                toggleSelectedVisibility();
            });

            $nextImage.click(function () {
                var imageId = $(this).data('info');
                changeImageSrcById(imageId);
            });
            $previousImage.click(function () {
                var imageId = $(this).data('info');
                changeImageSrcById(imageId);
            });

            function changeImageSrcById(imageId) {
                var previousImageId = imageId - 1,
                    nextImageId = imageId + 1;

                if (previousImageId < minImgId) {
                    previousImageId = maxImgId;
                }
                if (nextImageId > maxImgId) {
                    nextImageId = minImgId;
                }

                $currentImage.attr('src', 'imgs/' + imageId + '.jpg');
                $currentImage.data('info', imageId);

                $previousImage.attr('src', 'imgs/' + previousImageId + '.jpg');
                $previousImage.data('info', previousImageId);

                $nextImage.attr('src', 'imgs/' + nextImageId + '.jpg');
                $nextImage.data('info', nextImageId);
            }

            function toggleSelectedVisibility() {
                $background.toggleClass('disabled-background');
                $galleryList.toggleClass('blurred');
                $selected.toggle();
            }
        };
    };
}

module.exports = solve;