/*globals data console*/
var controllers = (function () {
    "use strict";
    var root = $('#root'),
        contentContainer = root.find('#content'),
        loginForm = $('#login'),
        logoutForm = $('#logout'),
        usernameSpan = $('#span-username'),
        usernameInput = loginForm.find('input');

    (function checkForLoggedUser() {
        data.users.current()
            .then((user) => {
                if (user) {
                    usernameSpan.text(user);
                    loginForm.addClass('hidden');
                    logoutForm.removeClass('hidden');
                }
            });
    })();

    function gallery() {
        data.gallery.get()
            .then(loadGalleryContent)
            .catch(console.log)
    }

    function loadGalleryContent(data) {
        var containerGallery = UI.generateGalleryHtml(data.data.children);
        contentContainer.html('').append(containerGallery);
    }

    function threads() {
        contentContainer.empty();
        data.threads.get()
            .then((data) => {
                loadThreadsContent(data.result)
            })
    }

    function loadThreadsContent(threads) {
        var container = UI.generateThreadsHtml(threads);
        contentContainer.find('#container-thraeds').remove();
        contentContainer.html('').prepend(container);
    }

    function threadById(params) {
        threads();
        $('.container-messages').remove();

        data.threads.getById(params.id)
            .then(loadMessagesContent)
            .catch((err) => showMsg(err, 'Error', 'alert-danger'))
    }

    function loadMessagesContent(data) {
        var container = UI.generateMessagesHtml(data);
        contentContainer.append(container);
    }

    function addThread(title) {
        data.threads.add(title)
            .then(threads())
            .then(showMsg('Successfuly added the new thread', 'Success', 'alert-success'))
            .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    }

    function addMessage(thId, msg) {
        data.threads.addMessage(thId, msg)
            .then(threadById({id: thId}))
            .then(showMsg('Successfuly added the new mssagee', 'Success', 'alert-success'))
            .catch((err) => showMsg(JSON.parse(err.responseText).err, 'Error', 'alert-danger'));
    }

    function showMsg(msg, type, cssClass, delay) {
        let container = UI.generateUserAlertHtml(msg, type, cssClass);
        root.append(container);

        setTimeout(() => {
            root.find('.alert').remove();
        }, delay || 2000)
    }

    function login() {
        let username = usernameInput.val() || 'anonymous';
        data.users.login(username)
            .then((user) => {
                usernameInput.val('')
                usernameSpan.text(user);
                loginForm.addClass('hidden');
                logoutForm.removeClass('hidden');
            })
    }

    function logout() {
        data.users.logout()
            .then(() => {
                usernameSpan.text('');
                loginForm.removeClass('hidden');
                logoutForm.addClass('hidden');
            })
    }

    return {
        gallery,
        threads,
        threadById,
        addThread,
        addMessage,
        login,
        logout
    }
})();
