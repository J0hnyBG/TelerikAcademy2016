function solve() {
    return function (selector) {
        var element,
            buttons,
            contents;

        if (selector == null || typeof selector == 'undefined') {
            throw 'Selector is null or undefined!'
        }
        if (typeof selector == 'string') {
            element = document.getElementById(selector);
        }
        if (element == null || typeof element == 'undefined') {
            throw 'No element with this id in document!'
        }
        buttons = element.getElementsByClassName('button');
        contents = element.getElementsByClassName('content');
        if (buttons.length == 0 || contents.length == 0) {
            return;
        }
        for (var u = 0; u < buttons.length; u++) {
            buttons[u].innerHTML = 'hide';
            buttons[u].addEventListener('click', function () {
                toggleContentVisibility(this)
            });
        }

        function toggleContentVisibility(button) {
            var content = button.nextElementSibling;
            while (content && content.className.indexOf('content') < 0) {
                content = content.nextElementSibling;
            }

            if (content == null || button == null ||
                content.className.indexOf('content') < 0 ) {
                return;
            }

            if (content.style.display == 'none') {
                content.style.display = '';
                button.innerHTML = 'hide';
            }
            else if(content.style.display == '') {
                content.style.display = 'none';
                button.innerHTML = 'show';
            }
        }
    };
}

module.exports = solve;