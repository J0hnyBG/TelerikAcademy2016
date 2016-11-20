/* globals module require Promise */
"use strict";

const jsdom = require("jsdom").jsdom,
    doc = jsdom(),
    window = doc.defaultView,
    $ = require("jquery")(window);

function parseSimpleActors(selector, html) {
    $("body").html(html);
    let items = [];
    $(selector).each((index, item) => {
        const $item = $(item);
        let imgUrl = $item.find("td.primary_photo > a > img").attr("src");
        let name = $item.find("td.itemprop > a > span").html();
        let imdbId = $item.find("td.itemprop > a").attr("href");
        let role = $item.find("td.character > div > a").html();

        items.push({
            role,
            name,
            imgUrl,
            imdbId
        });
    });

    return items;
}

module.exports.parseSimpleMovie = (selector, html) => {
    $("body").html(html);
    let items = [];
    $(selector).each((index, item) => {
        const $item = $(item);

        items.push({
            title: $item.html(),
            url: $item.attr("href")
        });
    });

    return Promise.resolve()
        .then(() => {
            return items;
        });
};

module.exports.parseMovieDetails = (html, url) => {
    const $item = $("body");
    $item.html(html);

    const imgUrl = $item.find("#title-overview-widget > div.vital > div.slate_wrapper > div.poster > a > img").attr("src");
    const description = $item.find("#titleStoryLine > div.inline.canwrap > p").html();
    const categories = $item.find("#title-overview-widget > .vital .title_wrapper > .subtext > a > span")
        .each((i, link) => {
            let $link = $(link);
            let cat = $link.html();
            return cat;
        })
        .toArray();
    const releaseDate = $item.find("#title-overview-widget > .vital .title_wrapper > .subtext > a > meta")
        .last()
        .attr("content");
    const name = $item.find("#title-overview-widget > div.vital > div.title_block > div > div.titleBar > div.title_wrapper > h1").text();

    let movie = {
        name,
        url,
        imgUrl,
        description,
        categories,
        releaseDate,
        actors: parseSimpleActors("#titleCast > table.cast_list tr.odd, #titleCast > table.cast_list tr.even", html)
    };

    return Promise.resolve()
        .then(() => {
            return movie;
        });
};

module.exports.parseActorDetails = (html, url) => {
    const $item = $("body");
    $item.html(html);

    const name = $item.find("#overview-top > h1 > span").html();
    const imgUrl = $item.find("#name-poster").attr("src");
    const biography = $item.find("#name-bio-text > div > div").text();
    const movies = $item.find("#filmography > .filmo-category-section > .filmo-row > b > a")
        .map((i, link) => {
            let $link = $(link);
            let cat = $link.text();
            return cat;
        })
        .toArray();

    let actor = {
        name,
        url,
        imgUrl,
        biography,
        movies
    };

    return Promise.resolve()
        .then(() => {
            return actor;
        });
};