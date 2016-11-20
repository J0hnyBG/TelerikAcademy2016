module.exports = {
    connectionString: "mongodb://localhost/moviesDb",
    genres: ["action", "sci-fi", "fantasy", "horror", "comedy"],
    pagesCount: 50,
    searchUrlTemplate: "http://www.imdb.com/search/title?genres=<%= genre %>&title_type=feature&0sort=moviemeter,asc&page=<%= pageCount %>&view=simple&ref_=adv_nxt",
    requestWaitingPeriod: 500,
    workingWithMessage: "Working with ",
    selector: ".col-title span[title] a",
    asyncPagesCount: 5,
    urlEndString: "/?ref",
    titleInUrl: "/title/",
    simpleMovieUrlTemplate: "http://imdb.com/title/<%= id %>/?ref_=adv_li_tt",
    actorUrlTemplate: "http://www.imdb.com/name/<%= id %>/?ref_=tt_cl_t1"
};