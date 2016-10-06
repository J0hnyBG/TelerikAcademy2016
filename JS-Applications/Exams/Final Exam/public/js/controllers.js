/* globals dataService templates $ Handlebars console */
"use strict";
let controllers = {
    getUserControllerInstance(dataService, templates, $) {
        var $mainContainer = $('#container');

        if ($mainContainer.length < 1) {
            toastr.error("No #container found on page!");
            return;
        }

        function _changePageHtml(html) {
            $mainContainer.html(html);
        }

        function _toggleButtonsIfLoggedIn() {
            dataService.isLoggedIn().then(isLoggedIn => {
                if (isLoggedIn) {
                    $(".logged-in").removeClass('hidden');
                    $(".logged-out").addClass('hidden');
                }
                else {
                    $(".logged-in").addClass('hidden');
                    $(".logged-out").removeClass('hidden');
                }
            });
        }

        _toggleButtonsIfLoggedIn();

        function login() {
            templates.compile('login')
                .then(function (html) {
                    _changePageHtml(html);
                    $('#btn-login').on('click', function () {
                        var user = {
                            username: $('#tb-username').val().trim(),
                            password: $('#tb-password').val().trim()
                        };

                        dataService.login(user)
                            .then(response => {
                                if (response.result.err) {
                                    // console.log(response.result);q
                                    toastr.error(response.err);
                                }
                                else {
                                    toastr.success('User Logged in!');
                                    $(location).attr('href', '#/');
                                    _toggleButtonsIfLoggedIn();
                                }
                            })
                            .catch(response => {
                                // console.log(response);
                                toastr.error(response.result.err);
                                $('#tb-password').val('');
                            });
                    });
                });
        }

        function register() {
            templates.compile('register')
                .then(function (html) {
                    _changePageHtml(html);
                    $('#btn-register').on('click', function (ev) {
                        if (!$('#register-form')[0].checkValidity || $('#register-form')[0].checkValidity()) {
                            ev.preventDefault();
                            ev.stopPropagation();

                            //TODO: Add validation!!!
                            // var hashedPass = CryptoJS.SHA3($('#tb-password').val().trim()).toString();
                            // console.log(hashedPass);
                            var user = {
                                "username": $('#tb-username').val().trim(),
                                "password": $('#tb-password').val().trim()//hashedPass
                            };
                            if (!validator.username(user.username) || !validator.password(user.password)) {
                                toastr.error("Invalid username or password!");
                                return;
                            }

                            dataService.register(user)
                                .then(() => {
                                    toastr.success('User registered!');
                                    $(location).attr('href', '#/login');
                                })
                                .catch(res => {
                                    console.log(res);
                                    toastr.error(res.responseJSON.result.err);
                                });
                        }
                        else {
                            toastr.error("Please fill out all fields correctly!")
                        }
                    });
                });
        }

        function logout() {
            dataService.logout()
                .then(() => {
                    toastr.success('User Logged out!');
                    $(location).attr('href', '#/');
                    _toggleButtonsIfLoggedIn();
                });
        }

        function user(params) {
            dataService.user(params.username).then(res => {
                return templates.compile('user', res);
            }).then(html => {
                _changePageHtml(html);
            })
        }

        function addComment(params) {
            let comment = $('#add-comment-input').val().trim();
            dataService.isLoggedIn().then(isLoggedIn => {
                if (isLoggedIn) {
                    dataService.addComment(params.id, comment)
                        .then((res) => {
                                toastr.success("Comment added!");
                                $(location).attr('href', '#/material/' + res.id);
                            }
                        ).catch(res => {
                        toastr.error(res.err);
                    });
                }
                else {
                    toastr.error("You must be logged in to do that!")
                }
            })
        }

        return {
            login,
            register,
            logout,
            user,
            addComment
        };
    },
    getPageControllerInstance(dataService, templates, $) {
        var $mainContainer = $('#container'),
            $searchBtn = $('#search-button'),
            $searchBox = $('#search-input');
        // $searchSelect = $('#search-select');

        $searchBtn.click(ev => {
            $(location).attr('href', `#/search/${$searchBox.val()}`)
        });

        if ($mainContainer.length < 1) {
            toastr.error("No #container found on page!");
            return;
        }

        function _changePageHtml(html) {
            $mainContainer.html(html);
        }

        function home() {
            dataService.getAllMaterials()
                .then(res => {
                    return templates.compile('materials', {materials: res});
                })
                .then(html => {
                    _changePageHtml(html);
                })
        }

        function materialById(params) {
            dataService.materialById(params.id)
                .then(res => {
                    if (res.commentsCount === 0) {
                        res.comments = undefined;
                    }
                    return templates.compile('singlematerial', res);
                })
                .then(html => {
                    _changePageHtml(html);

                    $('#status-select').change(ev => {
                        var status = $('#status-select').val();
                        var currentid = $('#status-select').attr('data-material-id');
                        dataService.setMaterialStatus(status, currentid).then(res => {
                            toastr.success("Material status changed!")
                        })
                    });
                })
        }

        function search(params) {
            dataService.search(params.search)
                .then(res => {
                    return templates.compile('materials', {materials: res});
                })
                .then(html => {
                    _changePageHtml(html)
                });
        }

        function add() {
            templates.compile('add')
                .then(html => {
                    _changePageHtml(html);
                    $('#btn-add-material').click(ev => {
                        if (!$('#add-form')[0].checkValidity || $('#add-form')[0].checkValidity()) {
                            ev.preventDefault();
                            ev.stopPropagation();

                            var material = {
                                "title": $('#tb-title').val().trim(),
                                "description": $('#tb-description').val().trim(),
                                "img": $('#tb-url').val().trim()
                            };

                            if (!validator.stringLength(material.title, 6, 100)) {
                                toastr.error("Material title must be between 6 and 100 characters long!");
                                return;
                            }

                            dataService.addMaterial(material)
                                .then(x => {
                                    toastr.success("Material added!")
                                })
                                .catch(res => {
                                    console.log(res);
                                    toastr.error(res.err);
                                })
                        }
                    })
                })
        }
        return {
            home,
            materialById,
            search,
            add
        }
    }
};

//export {controllers}