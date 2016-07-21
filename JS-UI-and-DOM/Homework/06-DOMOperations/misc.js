function solve(element, contents) {

    if (typeof element !== 'string' && !isElement(element)) {
        throw 'The provided first parameter is neither string or existing DOM element';
    }

    if (typeof element === 'string') {
        element = document.getElementById(element);
    }

    if (element == null) {
        throw 'The provided id does not select anything (there is no element that has such an id)';
    }

    element.innerHTML = '';

    for (var item in contents) {
        var child = document.createElement('div');
        child.appendChild(document.createTextNode(item));
        element.appendChild(child);
    }
    return element;

    function isElement(o) {
        return (
            typeof HTMLElement === "object" ? o instanceof HTMLElement : //DOM2
            o && typeof o === "object" && o !== null && o.nodeType === 1 && typeof o.nodeName === "string"
        );
    }
}
var expect = require('chai').expect;
var jsdom = require('jsdom');
var jq = require('jquery');
var result = require('./tasks/task-1')();

global.window = window;
global.document = window.document;
var element = document.createElement('div');
var contents = ['first', 'second', 'third'];
solve(element, contents);