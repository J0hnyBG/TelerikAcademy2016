function solve(args) {
    function parseURL(url) {
        var parser = {};
        var splitUrl = url.split(':');
        parser['protocol'] = splitUrl[0];

        splitUrl = url.split('//');
        splitUrl = splitUrl[1].split('/');
        parser['server'] = splitUrl[0];

        splitUrl.shift();
        splitUrl[0] =  '/' + splitUrl[0];
        parser['resource'] = splitUrl.join('/');

        return parser;
    }

    var url = parseURL(args[0]);

    console.log("protocol: " + url.protocol);
    console.log("server: " + url.server);
    console.log("resource: " + url.resource);
}

solve([ 'http://telerikacademy.com/Courses/Courses/Details/239' ]);