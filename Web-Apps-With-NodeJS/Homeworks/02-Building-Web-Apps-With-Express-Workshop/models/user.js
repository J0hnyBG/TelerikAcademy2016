/* mongoose global */
"use strict";
const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const constants = require("../config/constants");
const passHasher = require("../utils/salt-hash-password");

let UserSchema = new Schema({
    username: {
        type: String,
        required: true,
        index: { unique: true },
        validate: {
            validator: (v) => {
                return v.length >= constants.usernameMinLength;
            },
            message: "{VALUE} is not a valid username!"
        }
    },
    password: {
        type: String,
        required: true
    },
    salt: {
        type: String,
        required: true,
        validate: {
            validator: (v) => {
                return v.length === constants.saltLength;
            },
            message: "{VALUE} is not a valid salt!"
        }
    }
});

UserSchema.query.byName = function (name) {
    return this.find({ username: name });
};

UserSchema.methods.comparePassword = function (password) {
    return this.password === passHasher.getHash(password, this.salt);
};

UserSchema.statics.generateHash = function (password) {
    return passHasher.saltThenHash(password);
};

let User;
mongoose.model("User", UserSchema);
User = mongoose.model("User");
module.exports = User;
