"use strict";
const express = require("express"),
    session = require("express-session"),
    cookieParser = require("cookie-parser"),
    bodyParser = require("body-parser"),
    logger = require("morgan"),
    path = require("path");

const app = express();

app.use(logger("dev"));
app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: true }));
app.use(cookieParser());
app.use(session({ secret: "asdasdasdasdasds" }));
app.use(express.static(path.join(__dirname, "../../public")));

app.set("views", path.join(__dirname, "../../views"));
app.set("view engine", "pug");

const config = require("../config");
require("../mongoose")(config.development);

const User = require("../../models/user");
const Superhero = require("../../models/superhero");
const Fraction = require("../../models/fraction");

const data = require("../../data")({ Superhero, User, Fraction });

// let as = new User({username: "Test123", password: "123456", })

require("../auth/")(app, data);
require("../../routes")(app, data);

module.exports = app;