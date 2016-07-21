module.exports = function () {
    return function(element, contents) {
        var i =0;

        if (typeof element !== 'string' && !isElement(element)) {
            throw 'The provided first parameter is neither string or existing DOM element';
        }

        if (typeof element === 'string') {
            element = document.getElementById(element);
        }

        if (element == null) {
            throw 'The provided id does not select anything (there is no element that has such an id)';
        }

        if(contents.constructor !== Array) {
            throw 'The second parameter is not an array!';
        }
        for (i = 0; i < contents.length; i++) {
            if (typeof contents[i] !== 'string' && typeof contents[i] !== 'number') {
                throw 'Item in array is not a string or number!';
            }
        }

        element.innerHTML = '';

        for (i = 0; i < contents.length; i++) {
            var child = document.createElement('div');
            child.appendChild(document.createTextNode(contents[i]));
            element.appendChild(child);
        }

        return element;

        function isElement(o) {
            return (
                typeof HTMLElement === "object" ? o instanceof HTMLElement : //DOM2
                o && typeof o === "object" && o !== null && o.nodeType === 1 && typeof o.nodeName === "string"
            );
        }

    };
};