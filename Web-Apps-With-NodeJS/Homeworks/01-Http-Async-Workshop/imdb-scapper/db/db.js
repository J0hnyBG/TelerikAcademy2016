"use strict";
const MovieDetail = require("../models/movie-details-model");

module.exports.getAllMovieDetails = function(callback) {
    let q = MovieDetail.find({});
    return q.exec(callback);
};
