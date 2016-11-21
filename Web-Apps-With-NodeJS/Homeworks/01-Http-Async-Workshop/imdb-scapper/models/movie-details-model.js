const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const _ = require("lodash");
const constants = require("../config/constants");
const extractImdbIdFromUrl = require("./utils/extract-id-from-url");

const imdbUrlTemplate = _.template(constants.simpleMovieUrlTemplate);

let SimpleActorSchema = new Schema({
    role: {
        type: String,
        required: false
    },
    name: {
        type: String,
        required: true
    },
    imgUrl: {
        type: String,
        required: false
    },
    imdbId: {
        type: String,
        required: true,
        unique: true
    }
});

let MovieDetailsSchema = new Schema({
    name: {
        type: String,
        required: true
    },
    imdbId: {
        type: String,
        required: true
    },
    imgUrl: {
        type: String,
        required: false
    },
    description: {
        type: String,
        required: true
    },
    categories: {
        type: [String],
        required: true
    },
    releaseDate: {
        type: Date,
        required: false
    },
    actors: {
        type: [SimpleActorSchema],
        required: true
    }
});

let MovieDetails;
MovieDetailsSchema.statics.getModel =
    function (name, url, imgUrl, description, categories, releaseDate, actors) {
        if (!Array.isArray(actors)) {
            throw new Error("Actors must be array!");
        }
        let imdbId = extractImdbIdFromUrl(url);
        return new MovieDetails({ name, imdbId, imgUrl, description, categories, releaseDate, actors });
    };

MovieDetailsSchema.virtual.imdbUrl = function () {
    let url = imdbUrlTemplate({ id: this.imdbId });
    return url;
};

mongoose.model("MovieDetails", MovieDetailsSchema);
MovieDetails = mongoose.model("MovieDetails");
module.exports = MovieDetails;