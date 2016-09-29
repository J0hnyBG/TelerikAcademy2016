/*globals Handlebars*/
var UI = (function () {
    "use strict";
    var $threadsTemplate = $("#threads-container-template").html(),
        $galleryTemplate = $('#gallery-container-tempalte').html(),
        $messagesTemplate = $('#messages-container-template').html(),
        $alertTemplate = $('#alert-template').html();

    function _compileTemplate(sourceHtml, data) {
        var template = Handlebars.compile(sourceHtml);
        var result = template(data);
        return result;
    }

    function generateThreadsHtml(threads) {
        var result = _compileTemplate($threadsTemplate, {threads: [...threads]});
        return result;
    }

    function generateGalleryHtml(data) {
        var items = data.map(x => {
            return {
                thumbnail: x.data.thumbnail,
                title: x.data.title
            };
        });

        var result = _compileTemplate($galleryTemplate, {items: [...items]});
        return result;
    }

    function generateMessagesHtml(data) {
        console.log(data);
        var result;
        if (data.result.messages && data.result.messages.length > 0) {
            result = _compileTemplate($messagesTemplate, {
                title: data.result.title,
                messages: [...data.result.messages],
                id: data.result.id
            });
        }
        else {
            result = _compileTemplate($messagesTemplate, {title: data.result.title, id: data.result.id, messages: ["no messages"]});
        }


        return result;
    }

    function generateUserAlertHtml(msg, type, cssClass) {
        // let container = alertTemplate.clone(true)
        //     .addClass(cssClass).text(`${type}: ${msg}`)
        //     .appendTo(root);
        var message = {
            message: msg,
            type: type,
            cssClass: cssClass
        };
        var result = _compileTemplate($alertTemplate, message);

        return result;
    }

    return {
        generateThreadsHtml,
        generateGalleryHtml,
        generateMessagesHtml,
        generateUserAlertHtml
    }
})();