function solve() {
    return function (selector, isCaseSensitive) {
        var element = document.querySelector(selector),
            addElement = createAddElement(),
            searchElement = createSearchElement(),
            resultsElement = createResultsElement();

        isCaseSensitive = isCaseSensitive || false;

        element.className += ' items-control';
        element.appendChild(addElement);
        element.appendChild(searchElement);
        element.appendChild(resultsElement);

        function createAddElement() {
            var el = document.createElement('div');
            el.className += ' add-controls';
            var label = document.createElement('label'),
                text = document.createTextNode('Enter text'),
                input = document.createElement('input'),
                button = document.createElement('button');
            button.className += ' button';
            button.innerHTML = 'Add';

            button.addEventListener('click', addNewListItem, false);

            label.appendChild(text);
            el.appendChild(label);
            el.appendChild(input);
            el.appendChild(button);
            return el;
        }

        function createSearchElement() {
            var el = document.createElement('div');
            el.className += ' search-controls';

            var text = document.createTextNode('Search');
            var label = document.createElement('label');
            label.appendChild(text);

            var input = document.createElement('input');
            input.addEventListener('input', searchListItems, false);
            el.appendChild(label);
            el.appendChild(input);
            return el;
        }

        function createResultsElement() {
            var el = document.createElement('div');
            el.className += ' result-controls';
            var list = document.createElement('ul');
            list.className += ' items-list';
            list.addEventListener('click', deleteParent, false);
            el.appendChild(list);
            return el;
        }

        function addNewListItem(ev) {
            var list = document.querySelector('.items-list');
            var listItem = document.createElement('li');
            listItem.className += ' list-item';

            var text = document.createElement('strong');
            text.innerHTML = ev.target.previousSibling.value;
            var button = document.createElement('button');
            button.innerHTML = 'X';
            button.className += ' button';

            listItem.appendChild(button);
            listItem.appendChild(text);
            list.appendChild(listItem);
            ev.target.previousSibling.value = '';
        }

        function searchListItems(ev) {
            var listItems = document.getElementsByClassName('list-item');
            var textToSearch = ev.target.value;

            for (var i = 0; i < listItems.length; i++) {
                var item = listItems[i],
                    contentToSearch = item.lastElementChild.innerHTML.trim();

                if (!isCaseSensitive) {
                    textToSearch = textToSearch.toLowerCase();
                    contentToSearch = contentToSearch.toLowerCase();
                }

                if (contentToSearch.indexOf(textToSearch) < 0) {
                    item.style.display = 'none';
                }
                else {
                    item.style.display = '';
                }
            }
        }

        function deleteParent(ev) {
            var parent = ev.target.parentNode;
            var target = ev.target;
            if (target.tagName === 'BUTTON') {
                parent.outerHTML = '';
            }
        }
    };
}
module.exports = solve;