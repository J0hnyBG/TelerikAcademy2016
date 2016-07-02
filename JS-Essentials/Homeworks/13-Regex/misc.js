function solve(args) {
    String.prototype.bind = function (data) {
        var out = this,
            index,
            regex = /data-bind-(.*?)="(.*?)"/gm,
            matches;

        while (matches = regex.exec(this)) {
            index = out.indexOf('>');

            if (out[index - 1] === '/') {
                index--;
            }
            if (matches[1] === 'content') {
                out = out.slice(0, index + 1) + data[matches[2]] + out.slice(index + 1);
            }
            else {
                out = out.slice(0, index) + " " + matches[1] + '="' + data[matches[2]] + '"' + out.slice(index);
            }
        }
        return out;
    };

    var obj = JSON.parse(args[0]),
        html = args[1],
        result = html.bind(obj);


    console.log(result);
}

solve([
    '{ "name": "Steven" }',
    '<div data-bind-content="name"></div>'
]);

solve([
    '{ "name": "Elena", "link": "http://telerikacademy.com" }',
    '<a data-bind-href="link" data-bind-class="name" data-bind-content="name"></а>'
]);