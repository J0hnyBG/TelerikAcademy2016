let requesterInstance = requester.getInstance($);
let templateInstance = templates.getInstance(requesterInstance, Handlebars);
let dataServiceInstance = dataService.getInstance(requesterInstance);

let userControllerInstance = controllers.getUserControllerInstance(dataServiceInstance, templateInstance, $);
let pageControllerInstance = controllers.getPageControllerInstance(dataServiceInstance, templateInstance, $);

let router = new Navigo(null, true);
router
    .on("/login", userControllerInstance.login)
    .on('/register', userControllerInstance.register)
    .on("/logout", userControllerInstance.logout)
    .on("/users/:username", userControllerInstance.user)
    .on("/add", pageControllerInstance.add)
    .on("/material/:id", pageControllerInstance.materialById)
    .on("/material/:id/comment", userControllerInstance.addComment)
    .on("/search/:search", pageControllerInstance.search)
    .on('/', pageControllerInstance.home)
    .resolve();