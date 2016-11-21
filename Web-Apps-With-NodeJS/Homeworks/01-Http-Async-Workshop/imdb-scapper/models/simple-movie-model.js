/* globals require module */
"use strict";

const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const _ = require("lodash");
const constants = require("../config/constants");
const extractImdbIdFromUrl = require("./utils/extract-id-from-url");

const imdbUrlTemplate = _.template(constants.simpleMovieUrlTemplate);

let SimpleMovieSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    imdbId: {
        type: String,
        required: true,
        unique: true
    }
});

let SimpleMovie;
SimpleMovieSchema.statics.getSimpleMovieByNameAndUrl =
    function (name, url) {
        let imdbId = extractImdbIdFromUrl(url);
        return new SimpleMovie({ name, imdbId });
    };

SimpleMovieSchema.virtual.imdbUrl = function () {
    let url = imdbUrlTemplate({ id: this.imdbId });
    return url;
};

mongoose.model("SimpleMovie", SimpleMovieSchema);
SimpleMovie = mongoose.model("SimpleMovie");
module.exports = SimpleMovie;