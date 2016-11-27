"use strict";

const User = require("../models/user");
const data = require("../data")({ User });
const passport = require("passport");

module.exports = {
    login(req, res) {
        res.render("login");
    },
    loginUser(req, res, next) {
        passport.authenticate("local", (error, user) => {
            if (error) {
                next(error);
                return;
            }

            if (!user) {
                res.render("error", { message: "Invalid username or password!" });
            }

            req.login(user, error => {
                if (error) {
                    next(error);
                    return;
                }

                res.redirect("/success");
            });
        });
    },
    register(req, res) {
        res.render("register");
    },
    registerUser(req, res) {
        let username = req.body.user.username;
        let password = req.body.user.password;
        data.registerUser(username, password)
            .then(us => {
                console.log(us);
                res.redirect("/");
            })
            .catch(err => {
                console.log(err);
            });
    }
};