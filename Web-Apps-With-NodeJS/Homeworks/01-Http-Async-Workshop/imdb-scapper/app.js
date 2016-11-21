/* globals console require setTimeout Promise */
"use strict";

const constants = require("./config/constants");
const imdbScraper = require("./core/imdb-scraper");
require("./config/mongoose")(constants.connectionString);

// imdbScraper.scrapeSimpleMovies();
// imdbScraper.scrapeMovieDetails();
imdbScraper.scrapeActorDetails();