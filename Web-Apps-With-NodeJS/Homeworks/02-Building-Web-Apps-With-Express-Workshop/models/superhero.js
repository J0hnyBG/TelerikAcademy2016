"use strict";
const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const constants = require("../config/constants");

let SimplePowerSchema = new Schema({
    name: {
        type: String,
        index: { unique: true },
        minLength: constants.nameMinLength,
        maxlength: constants.powerMaxLength
    }
});

let SuperheroSchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: constants.nameMinLength,
        maxlength: constants.superheroNameMaxLength
    },
    secretIdentity: {
        type: String,
        required: true,
        index: { unique: true },
        minLength: constants.nameMinLength,
        maxlength: constants.superheroIdentityMaxLength
    },
    alignment: {
        type: String,
        enum: constants.alignments,
        required: true

    },
    story: {
        type: String,
        required: true,
        minLength: 1
    },
    image: { type: String },
    powers: { type: [SimplePowerSchema] }
});

SuperheroSchema.query.bySecretIdentity = function (secretIdentity) {
    return this.find({ secretIdentity });
};

let Superhero;
mongoose.model("Superhero", SuperheroSchema);
Superhero = mongoose.model("Superhero");
module.exports = Superhero;
