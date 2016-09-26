/*globals Handlebars*/
var UI = (function() {
    "use strict";
    let $threadsTemplate =$("#threads-container-template").html();

    function _compileTemplate(sourceHtml, data) {
        var template = Handlebars.compile(sourceHtml);
        var result = template(data);
        return result;
    }

    function generateThreadsHtml(threads) {
        var template = Handlebars.compile($threadsTemplate);
        var result = template({threads: [...threads]});
        return result;
    }

    return {
        generateThreadsHtml
    }
})();