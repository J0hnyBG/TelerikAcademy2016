/* globals requester localStorage */
"use strict";
var dataService = {
    getInstance(requester) {
        const HTTP_HEADER_KEY = "x-auth-key",
            KEY_STORAGE_USERNAME = "goodmats-username",
            KEY_STORAGE_AUTH_KEY = "goodmats-authKey";

        function login(user) {
            return requester.putJSON(`./api/users/auth/`, user)
                .then(response => {
                    if (response.result.err) {
                        return Promise.reject(response);
                    }
                    localStorage.setItem(KEY_STORAGE_USERNAME, response.result.username);
                    localStorage.setItem(KEY_STORAGE_AUTH_KEY, response.result.authKey);
                    return response;
                });
        }

        function register(user) {
            return requester.postJSON('./api/users', user);
        }

        function isLoggedIn() {
            return Promise.resolve()
                .then(() => {
                    return !!localStorage.getItem(KEY_STORAGE_AUTH_KEY);
                });
        }

        function logout() {
            localStorage.removeItem(KEY_STORAGE_USERNAME);
            localStorage.removeItem(KEY_STORAGE_AUTH_KEY);
            return Promise.resolve();
        }

        function getAllMaterials() {
            return requester.get('./api/materials').then(res => {
                return res.result;
            })
        }

        function materialById(id) {
            return requester.get('./api/materials/' + id).then(res => {
                return res.result;
            })
        }

        function search(phrase) {
            return requester.get('./api/materials?filter=' + phrase).then(res => {
                return res.result;
            })
        }

        function user(username) {
            return requester.get('./api/profiles/' + username).then(res => {
                return res.result;
            })
        }

        function addMaterial(material) {
            var headers = _getCurrentUserAuthHeader();
            return requester.postJSON('./api/materials/', material, headers).then(res => {
                return res;
            })
        }

        function addComment(id, text) {
            var headers = _getCurrentUserAuthHeader();
            var body = {
                'commentText': text
            };

            return requester.putJSON(`./api/materials/${id}/comments`, body, headers).then(res => {
                return res.result;
            });
        }

        function _getCurrentUserAuthHeader() {
            return {
                'x-auth-key': localStorage.getItem(KEY_STORAGE_AUTH_KEY)
            }
        }

        function setMaterialStatus(status, id) {
            var headers = _getCurrentUserAuthHeader();
            var body =
                {
                    "id": id,
                    "category": status
                };

            return requester.putJSON(`./api/user-materials`, body, headers).then(res => {
                return res.result;
            });
        }

        return {
            login,
            register,
            isLoggedIn,
            logout,
            getAllMaterials,
            search,
            materialById,
            user,
            addMaterial,
            addComment,
            setMaterialStatus
        }
    }
};