/*globals Handlebars*/
var UI = (function () {
    "use strict";
    var $threadsTemplate = $("#threads-container-template").html(),
        $galleryTemplate = $('#gallery-container-tempalte').html(),
        $messagesTemplate = $('#messages-container-template').html();

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
            title: x.data.title};
        });

        var result = _compileTemplate($galleryTemplate, {items: [...items]});
        return result;
    }

    function generateMessagesHtml(data) {
            // let container = $($('#messages-container-template').text()),
            //     messagesContainer = container.find('.panel-body');
            // container.attr('data-thread-id', data.result.id);
            //
            // function getMsgUI(msg, author, date) {
            //     let template = $($('#messages-template').text());
            //     template.find('.message-content').text(msg.message);
            //     template.find('.message-creator').text(msg.username || 'anonymous');
            //     template.find('.message-date').text(msg.postDate || 'unknown');
            //     return template.clone(true);
            // }
            //
            // function getAddNewMsgUI() {
            //     let template = $($('#message-new-template').html());
            //     return template.clone(true);
            // }
            //
            // if (data.result.messages && data.result.messages.length > 0) {
            //     data.result.messages.forEach((msg) => {
            //         messagesContainer.append(getMsgUI(msg))
            //     })
            // } else {
            //     messagesContainer.append(getMsgUI('No messages!'))
            // }
            //
            // messagesContainer.append(getAddNewMsgUI());
            //
            // container.find('.thread-title').text(data.result.title);
            // contentContainer.append(container);

        var result = _compileTemplate($messagesTemplate, {title: data.result.title, messages: [...data.result.messages]});
        return result;
    }

    return {
        generateThreadsHtml,
        generateGalleryHtml,
        generateMessagesHtml
    }
})();