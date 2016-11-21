"use strict";

const httpRequester = require("../utils/http-requester");
const htmlParser = require("../utils/html-parser");
const queuesFactory = require("../data-structures/queue");
const modelsFactory = require("../models");
const constants = require("../config/constants");
const wait = require("../utils/wait");
const db = require("../db/db");
const async = require("async");

const _ = require("lodash");
const urlTemplate = _.template(constants.searchUrlTemplate);

module.exports.scrapeMovieDetails = function () {
    db.getAllSimpleMovies((err, result) => {
        if (err) {
            console.log(err);
        } else {
            let urls = result.map((movie) => {
                return `http://www.imdb.com/title/${movie.imdbId}${constants.urlEndString}`;
            });

            // FIXME: Add to queue to prevent outofmemory exception!
            urls.forEach((url) => {
                console.log(constants.workingWithMessage + url);
                httpRequester.get(url)
                    .then((response) => {
                        const html = response.body;
                        return htmlParser.parseMovieDetails(html, url);
                    })
                    .then((movie) => {
                        let dbMovie = modelsFactory.getMovieDetails(movie);
                        dbMovie.save();
                        return wait(constants.requestWaitingPeriod);
                    })
                    .catch(error => {
                        console.dir(error, { colors: true });
                    });
            });

        }
    });
};

module.exports.scrapeActorDetails = function () {
    let dbActors = [];

    function processSingleActor(url, callback) {
        console.log(constants.workingWithMessage + url);
        return httpRequester.get(url)
            .then((response) => {
                const html = response.body;
                return htmlParser.parseActorDetails(html, url);
            })
            .then((actor) => {
                let dbActor = modelsFactory.getActor(actor);
                dbActors.push(dbActor);
                return wait(constants.requestWaitingPeriod);
            })
            .then(() => {
                return callback();
            })
            .catch(error => {
                console.dir(error, { colors: true });
                return callback(error);
            });
    }

    db.getAllMovieDetails((err, result) => {
        if (err) {
            console.log(err);
        } else {
            let urls = result.map((movie) => {
                return movie.actors.map((actor) => {
                    return `http://www.imdb.com${actor.imdbId}`;
                });
            });
            async.forEachLimit(urls, 3,
                (urlArr, callback) => {
                    async.forEachLimit(urlArr, constants.asyncPagesCount, processSingleActor, (error) => {
                        if (error) {
                            console.log(error);
                        }
                        if (dbActors.length > 0) {
                            let actors = dbActors.slice();

                            console.log(`SAVED ${actors.length} actors ---------------------`);
                            modelsFactory.insertManyActors(actors);
                            console.log(actors);
                        }
                        dbActors = [];
                        callback();
                    });
                });
        }
    });
};

module.exports.scrapeSimpleMovies = function () {
    let urlsQueue = queuesFactory.getQueue();
    constants.genres.forEach(genre => {
        for (let i = 0; i < constants.pagesCount; i += 1) {
            let url = urlTemplate({ genre, pageCount: i + 1 });
            urlsQueue.push(url);
        }
    });

    function getMoviesFromUrl(url) {
        console.log(constants.workingWithMessage + url);
        httpRequester.get(url)
            .then((result) => {
                const html = result.body;

                return htmlParser.parseSimpleMovie(constants.selector, html);
            })
            .then(movies => {
                let dbMovies = movies.map(movie => {
                    return modelsFactory.getSimpleMovie(movie.title, movie.url);
                });

                modelsFactory.insertManySimpleMovies(dbMovies);

                return wait(constants.requestWaitingPeriod);
            })
            .then(() => {
                if (urlsQueue.isEmpty()) {
                    return;
                }

                getMoviesFromUrl(urlsQueue.pop());
            })
            .catch((err) => {
                console.dir(err, { colors: true });
            });
    }

    Array.from({ length: constants.asyncPagesCount })
        .forEach(() => getMoviesFromUrl(urlsQueue.pop()));
};