/* globals require module Promise */
"use strict";
module.exports = function (models) {
    let { User } = models;

    return {
        registerUser(username, password) {
            let passInfo = User.generateHash(password);
            let passHash = passInfo.password;
            let salt = passInfo.salt;

            let user = new User({
                username,
                password: passHash,
                salt
            });

            return new Promise((resolve, reject) => {
                user.save((err) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(user);
                });
            });
        },
        findUserByUsername(username) {
            return new Promise((resolve, reject) => {
                User.findOne()
                    .byName(username)
                    .exec((err, user) => {
                        if (err) {
                            return reject(err);
                        }

                        return resolve(user);
                    });
            });
        },
        findUserById(id) {
            return new Promise((resolve, reject) => {
                User.findById(id).exec((err, user) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(user);
                });
            });
        },
        getAllUsers() {
            return new Promise((resolve, reject) => {
                User.find((err, users) => {
                    if (err) {
                        return reject(err);
                    }

                    return resolve(users);
                });
            });
        }
    };
};
