"use strict";

const PORT = 3001;

const app = require("./config/app");

console.log("Sadly, no time to finish it...");
app.listen(PORT, () => console.log(`Server running at:  http://localhost:${PORT}`));

module.exports = app;