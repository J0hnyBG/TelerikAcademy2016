const mongoose = require("mongoose");
const Schema = mongoose.Schema;
const _ = require("lodash");
const constants = require("../config/constants");
const extractImdbIdFromUrl = require("./utils/extract-id-from-url");

const imdbUrlTemplate = _.template(constants.actorUrlTemplate);

let ActorSchema = new Schema({
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
    biography: {
        type: String,
        required: true
    },
    movies: {
        type: [String],
        required: true
    }
});

let Actor;
ActorSchema.statics.getModel =
    function (name, url, imgUrl, biography, movies) {
        let imdbId = extractImdbIdFromUrl(url);
        return new Actor({ name, imdbId, imgUrl, biography, movies });
    };

ActorSchema.virtual.imdbUrl = function () {
    let url = imdbUrlTemplate({ id: this.imdbId });
    return url;
};

mongoose.model("Actor", ActorSchema);
Actor = mongoose.model("Actor");
module.exports = Actor;