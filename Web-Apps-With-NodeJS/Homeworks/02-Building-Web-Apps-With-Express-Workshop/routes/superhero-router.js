let express = require("express");
let router = express.Router();
let controller = require("../controllers/superhero-controller");

module.exports = (app) => {
    router.get("/superheroes", controller.allSuperheroes);

    app.use(router);
};