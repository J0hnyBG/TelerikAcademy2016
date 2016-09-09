/* globals document, window, console */
function solve() {
    return function (selector, initialSuggestions) {
        var element = document.querySelector(selector),
            searchInput = element.querySelector(".tb-pattern"),
            addButton = element.querySelector(".btn-add"),
            suggestionsList = element.querySelector(".suggestions-list"),
            suggestionsArray = initialSuggestions ? JSON.parse(JSON.stringify(initialSuggestions)) : [];

        Array.prototype.unique = function () {
            var a = [];
            for (i = 0; i < this.length; i++) {
                var current = this[i].toLowerCase();
                if (a.indexOf(current) < 0) {
                    a.push(current);
                }
                else {
                    this.splice(i, 1);
                }
            }
            return this;
        };

        suggestionsArray = suggestionsArray.unique();

        for (var i = 0; i < suggestionsArray.length; i++) {
            var suggestion = createSuggestion(suggestionsArray[i]);
            suggestion.style.display = 'none';
            suggestionsList.appendChild(suggestion);
            hideAllSuggestions();
        }

        searchInput.addEventListener('input', function () {
                var pattern = searchInput.value.toLowerCase();

                var suggestions = document.getElementsByClassName('suggestion');

                for (var i in suggestions) {
                    // if (suggestions.hasOwnProperty(i)) {

                        if (pattern == '') {
                            suggestions[i].style.display = 'none';
                            continue;
                        }
                        if (suggestions[i].firstElementChild.innerText.toLowerCase().indexOf(pattern) >= 0) {
                            suggestions[i].style.display = 'block';
                        }
                        else {
                            suggestions[i].style.display = 'none';
                        }
                    // }

                }

            }
        );

        addButton.addEventListener('click', function () {
            var suggestionText = searchInput.value;

            if (suggestionsArray.some(function (item) {
                    return item.toLowerCase() == suggestionText.toLowerCase();
                })) {
                // searchInput.value = '';
                // hideAllSuggestions();
                return;
            }

            suggestionsArray.push(suggestionText);
            var suggestion = createSuggestion(suggestionText);
            suggestionsList.appendChild(suggestion);
            // searchInput.value = '';

            // hideAllSuggestions();
        });

        suggestionsList.addEventListener('click', function (ev) {
            var target = ev.target;
            if (target.firstElementChild.className.indexOf('suggestion-link') >= 0
            ) {
                searchInput.value = target.firstElementChild.innerText;
                hideAllSuggestions();
            }
            console.log(searchInput.value);

        });
        function hideAllSuggestions() {
            var suggestions = suggestionsList.getElementsByClassName('suggestion');
            for (var i = 0; i < suggestions.length; i++) {
                suggestions[i].style.display = 'none';

            }
        }

        function createSuggestion(content) {
            var suggestionLi = document.createElement('li'),
                hyperLink = document.createElement('a');

            suggestionLi.className = 'suggestion';
            hyperLink.className = 'suggestion-link';
            hyperLink.href = '#';
            hyperLink.innerHTML = content;

            suggestionLi.appendChild(hyperLink);
            return suggestionLi;
        }
    };
}

module.exports = solve;

/*
 *<li class="suggestion">
 <a href="#" class="suggestion-link">Apple</a>
 </li>
 *
 * */