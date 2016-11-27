let express = require("express");
let router = express.Router();
let controller = require("../controllers/user-controller");

module.exports = (app, data) => {
    router.get("/", (req, res, next) => {
        res.render("index");
    });

    router.get("/login", controller.login);
    router.post("/login", controller.loginUser);

    router.get("/register", controller.register);
    router.post("/register", controller.registerUser);


    app.use(router);
};