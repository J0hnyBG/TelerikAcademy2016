function solve() {
    return function () {
        $.fn.listview = function (data) {
            'use strict';
            var sourceID = $(this).attr('data-template'),
                source   = $('#' + sourceID).html(),
                template = handlebars.compile(source),
                result = '';

            for(let obj of data) {
                result += template(obj);
            }

            $(this).append(result);
            return $(this);
        };
    };
}

module.exports = solve;