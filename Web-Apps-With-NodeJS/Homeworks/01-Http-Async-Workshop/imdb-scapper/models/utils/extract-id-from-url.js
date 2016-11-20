const constants = require("../../config/constants");

// /title/tt0067992/?ref_=adv_li_tt
function extractImdbIdFromUrl(url) {
    let replaced = url.replace("http://www.imdb.com", "");
    let index = replaced.indexOf(constants.urlEndString);
    return replaced.substring(constants.titleInUrl.length, index);
}

module.exports = extractImdbIdFromUrl;