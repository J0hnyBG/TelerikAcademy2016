function solve() {
    return function (selector, isCaseSensitive) {
        var element = document.querySelector(selector);
        isCaseSensitive = isCaseSensitive || false;
        var addElement = createAddElement();
        var searchElement = createSearchElement();
        var resultsElement = createResultsElement();
        element.className += ' items-control';
        element.appendChild(addElement);
        element.appendChild(searchElement);
        element.appendChild(resultsElement);

        function createResultsElement() {
            var el = document.createElement('div');
            el.className += ' result-controls';
            var list = document.createElement('ul');
            list.className += ' items-list';
            el.appendChild(list);
            return el;
        }

        function createAddElement() {
            var el = document.createElement('div');
            el.className += ' add-controls';
            var label = document.createElement('label'),
                text = document.createTextNode('Enter text'),
                input = document.createElement('input'),
                button = document.createElement('button');
            button.className += ' button';
            button.innerHTML = 'Add';

            button.addEventListener('click', addNewListItem);

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
            input.addEventListener('input', searchListItems);
            el.appendChild(label);
            el.appendChild(input);
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

            button.addEventListener('click', deleteParent);

            listItem.appendChild(button);
            listItem.appendChild(text);
            list.appendChild(listItem);
            ev.target.previousSibling.value = '';
        }

        function searchListItems(ev) {
            var listItems = document.getElementsByClassName('list-item');
            var searchInput = ev.target;

            for (var i = 0; i < listItems.length; i++) {
                var item = listItems[i],
                    search = searchInput.value,
                    textToSearch = item.innerText.substr(1).trim();

                if (!isCaseSensitive) {
                    search = search.toLowerCase();
                    textToSearch = textToSearch.toLowerCase();
                }

                if (textToSearch.indexOf(search) < 0) {
                    item.style.display = 'none';
                }
                else {
                    item.style.display = '';
                }
            }
        }

        function deleteParent(ev) {
            var parent = ev.target.parentNode;
            parent.parentNode.removeChild(parent);
        }
    };
}
module.exports = solve;