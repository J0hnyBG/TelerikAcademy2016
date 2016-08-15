$.fn.tabs = function () {
    let $tabItems = $('.tab-item');
    $tabItems.first().addClass('current');
    let $tabItemContents = $('.tab-item-content');
    $tabItemContents.hide();
    $tabItemContents.first().show();

    $tabItems.click(function (a) {
        var $target = $(a.target);
        
        if ($target.hasClass('tab-item-title')) {
            $tabItems.removeClass('current');
            $target.parent().addClass('current');
            $tabItemContents.hide();
            $target.siblings().show();
        }
    });
    return this;
};