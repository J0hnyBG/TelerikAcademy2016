"use strict";

const LocalStrategy = require("passport-local");

module.exports = function (passport, data) {
    const authStrategy = new LocalStrategy(
        (username, password, done) => {
            data.findUserByUsername(username)
                .then(user => {
                    if (user && user.comparePassword(password)) {
                        done(null, user);
                    } else {
                        done(null, false);
                    }
                })
                .catch(error => done(error, false));
        });

    passport.use(authStrategy);
};