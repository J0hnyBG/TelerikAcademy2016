/* globals module require */
"use strict";

const SimpleMovie = require("./simple-movie-model");
const MovieDetail = require("./movie-details-model");
const Actor = require("./actor-model");

module.exports = {
    getSimpleMovie(name, url) {
        return SimpleMovie.getSimpleMovieByNameAndUrl(name, url);
    },
    insertManySimpleMovies(movies) {
        SimpleMovie.insertMany(movies);
    },
    getMovieDetails(movie) {
        return MovieDetail.getModel(movie.name, movie.url, movie.imgUrl, movie.description, movie.categories, movie.releaseDate, movie.actors);
    },
    insertManyMovieDetails(movies) {
        MovieDetail.insertMany(movies);
    },
    getActor(actor) {
        return Actor.getModel(actor.name, actor.url, actor.imgUrl, actor.biography, actor.movies);
    },
    insertManyActors(actors) {
        Actor.insertMany(actors, (err, res) => {
            if (err) {
                console.log(err);
            }
        });
    }
};