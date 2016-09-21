var data = (function () {
    "use strict";

    const USERNAME_STORAGE_KEY = 'username-key';

    // start users
    function userLogin(user) {
        localStorage.setItem(USERNAME_STORAGE_KEY, user);
        return Promise.resolve(user);
    }

    function userLogout() {
        localStorage.removeItem(USERNAME_STORAGE_KEY)
        return Promise.resolve();
    }

    function userGetCurrent() {
        return Promise.resolve(localStorage.getItem(USERNAME_STORAGE_KEY));
    }

    // end users

    // start threads
    function threadsGet() {
        return new Promise((resolve, reject) => {
            $.getJSON('api/threads')
                .done(resolve)
                .fail(reject);
        })
    }

    function threadsAdd(title) {
        return new Promise(function (resolve, reject) {
            var body = {
                title: title,
                username: localStorage.getItem(USERNAME_STORAGE_KEY),
                postDate: new Date()
            };
            $.ajax({
                url: 'api/threads',
                method: 'POST',
                data: JSON.stringify(body),
                headers: {
                    'x-authkey': localStorage.getItem(USERNAME_STORAGE_KEY)
                },
                contentType: 'application/json',
                success: function (res) {
                    resolve(res);
                }
            })
        });
    }

    function threadById(id) {
        return new Promise((resolve, reject) => {
            $.getJSON(`api/threads/${id}`)
                .done(resolve)
                .fail(reject);
        })
    }

    function threadsAddMessage(threadId, content) {
        let body = {
            message: content,
            username: localStorage.getItem(USERNAME_STORAGE_KEY),
            postDate: new Date()
        };

        return new Promise(function (resolve, reject) {
            $.ajax({
                url: `api/threads/${threadId}/messages`,
                method: 'POST',
                data: JSON.stringify(body),
                contentType: 'application/json',
                headers: {
                    'x-authkey': localStorage.getItem(USERNAME_STORAGE_KEY)
                },
                success: function (res) {
                    resolve(res);
                }
            });
        });
    }

    // end threads

    // start gallery
    function galleryGet() {
        const REDDIT_URL = `https://www.reddit.com/r/aww.json?jsonp=?`;

        return new Promise((resolve, reject) => {
            $.ajax({
                url: REDDIT_URL,
                dataType: 'jsonp'
            })
                .done(resolve)
                .fail(reject);
        })
    }

    // end gallery

    return {
        users: {
            login: userLogin,
            logout: userLogout,
            current: userGetCurrent
        },
        threads: {
            get: threadsGet,
            add: threadsAdd,
            getById: threadById,
            addMessage: threadsAddMessage
        },
        gallery: {
            get: galleryGet,
        }
    }
})();