var templates = {
    get: (name) => {
        let url = `./templates/${name}.html`;
        return requester.getJSON(url);
    }
}