function solve() {
    return function (fileContentsByName) {
        var $itemsList = $('.items').first(),
            $fileContent = $('.file-content'),
            $addButton = $('.add-btn'),
            $inputElement = $addButton.siblings('input');

        $itemsList.click(function(ev) {
            var $target = $(ev.target);
            if ($target.hasClass('item-name')) {
                var $parent = $($target.parent());
                if($parent.hasClass('dir-item')) {
                    $parent.toggleClass('collapsed');
                }
                else if($parent.hasClass('file-item')) {
                    var content = fileContentsByName[$target.html()];
                    $fileContent.text(content);
                }
            }
            else if ($target.hasClass('del-btn')) {
                $($target.parent()).remove();
                delete fileContentsByName[$target.html()];
            }

        });
        $addButton.click(function (ev) {
            var $this = $(this);
            $this.removeClass('visible');
            $inputElement.addClass('visible');
        });

        $inputElement.keydown(function(ev) {
            var keycode = (ev.keyCode ? ev.keyCode : ev.which);
            if(keycode == 13) {
                var value = $inputElement.val();
                fileContentsByName[value] = '';
                $addButton.addClass('visible');
                $inputElement.val('');
                $inputElement.removeClass('visible');
                var $li = $('<li></li>');
                $li.addClass('file-item');
                $li.addClass('item');

                var $a = $("<a></a>");
                $a.addClass('item-name');
                $a.text(value);
                var $deleteA = $('<a></a>');
                $deleteA.addClass('del-btn');

                $li.append($a);
                $li.append($deleteA);
                $itemsList.append($li);
            }
        });

        return fileContentsByName;
    }
}

if (typeof module !== 'undefined') {
    module.exports = solve;
}