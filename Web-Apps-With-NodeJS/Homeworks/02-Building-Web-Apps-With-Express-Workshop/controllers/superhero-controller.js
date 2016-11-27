"use strict";

const Superhero = require("../models/superhero");
const data = require("../data")({
    Superhero
});


module.exports = {
    allSuperheroes(req, res) {
        data.getAllSuperheroes()
            .then(superheroes => {
                res.render("all-superheroes", {superheroes});
            });
    }
};
