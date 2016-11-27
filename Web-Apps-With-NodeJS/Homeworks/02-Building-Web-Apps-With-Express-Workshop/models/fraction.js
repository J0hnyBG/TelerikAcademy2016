"use strict";
const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const constants = require("../config/constants");

let CitySchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: constants.planetNameMinLength,
        maxlength: constants.planetNameMaxLength,
        index: { unique: true }
    }
});

let CountrySchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: constants.planetNameMinLength,
        maxlength: constants.planetNameMaxLength,
        index: { unique: true }
    },
    cities: {
        type: [CitySchema],
        required: true
    }
});

let PlanetSchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: constants.planetNameMinLength,
        maxlength: constants.planetNameMaxLength,
        index: { unique: true }
    },
    countries: {
        type: [CountrySchema],
        required: true
    }
});

let SimpleHeroSchema = new Schema({
    _id: {
        type: Schema.Types.ObjectId,
        ref: "Superhero",
        required: true
    },
    name: {
        type: String,
        required: true,
        minLength: constants.nameMinLength,
        maxlength: constants.superheroNameMaxLength
    },
    secredIdentity: {
        type: String,
        required: true,
        index: { unique: true },
        minLength: constants.nameMinLength,
        maxlength: constants.superheroIdentityMaxLength
    }
});

let FractionSchema = new Schema({
    name: {
        type: String,
        required: true,
        minLength: constants.nameMinLength,
        maxlength: constants.fractionNameMaxLength
    },
    alignment: {
        type: String,
        enum: constants.alignments,
        required: true

    },
    planets: { type: [PlanetSchema] },
    heroes: { type: [SimpleHeroSchema] }
});

FractionSchema.query.byName = function (name) {
    return this.find({ name });
};

let Fraction;
mongoose.model("Fraction", FractionSchema);
Fraction = mongoose.model("Fraction");
module.exports = Fraction;
