/* globals console require setTimeout Promise */
"use strict";

const constants = require("./config/constants");
const imdbScraper = require("./core/imdb-scraper");
require("./config/mongoose")(constants.connectionString);

imdbScraper.scrapeImdb();
// http://www.imdb.com/name/nm1212722/?ref_=tt_cl_t1

// http://www.imdb.com/title/tt1211837/

// const http = require("./utils/http-requester");
// const parser = require("./utils/html-parser");
// http.get("http://www.imdb.com/name/nm1212722/?ref_=tt_cl_t1")
//     .then((result) => {
//         const html = result.body;
//
//         return parser.parseActorDetails(html, "http://www.imdb.com/name/nm1212722/?ref_=tt_cl_t1");
//     })
//     .then(result => {
//         console.log(result);
//     })