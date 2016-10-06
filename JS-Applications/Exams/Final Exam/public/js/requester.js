/* globals $ Promise */
"use strict";
let requester = {
    getInstance(asyncEngine){
        return {
            get: function(url) {
                return new Promise((resolve, reject) => {
                    asyncEngine.ajax({
                        url: url,
                        method: "GET",
                        success(response) {
                            resolve(response);
                        },
                        error(err) {
                            reject(err);
                        }
                    });
                });
            },
            putJSON: function(url, body, headers = {}) {
                return new Promise((resolve, reject) => {
                    asyncEngine.ajax({
                        url: url,
                        headers: headers,
                        method: "PUT",
                        contentType: "application/json",
                        data: JSON.stringify(body),
                        success(response) {
                            resolve(response);
                        },
                        error(err) {
                            reject(err);
                        }
                    });
                });
            },
            postJSON: function(url, body, headers = {}) {
                return new Promise((resolve, reject) => {
                    asyncEngine.ajax({
                        url: url,
                        headers: headers,
                        method: "POST",
                        contentType: "application/json",
                        data: JSON.stringify(body),
                        success(response) {
                            resolve(response);
                        },
                        error(err) {
                            reject(err);
                        }
                    });
                });
            },
            getJSON: function(url, headers = {}) {
                return new Promise((resolve, reject) => {
                    asyncEngine.ajax({
                        url: url,
                        method: "GET",
                        headers: headers,
                        contentType: "application/json",
                        success(response) {
                            resolve(response);
                        },
                        error(err) {
                            reject(err);
                        }
                    });
                });
            }
        }
    }
};

if (typeof window === 'undefined') {
    module.exports = requester.getInstance;
}
