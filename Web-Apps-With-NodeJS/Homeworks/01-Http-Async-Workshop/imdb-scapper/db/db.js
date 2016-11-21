"use strict";
const MovieDetail = require("../models/movie-details-model");
const SimleMovie = require("../models/simple-movie-model");

module.exports.getAllMovieDetails = function(callback) {
    let q = MovieDetail.find({});
    return q.exec(callback);
};

module.exports.getAllSimpleMovies = function(callback) {
    let q = SimleMovie.find({});
    return q.exec(callback);
};
