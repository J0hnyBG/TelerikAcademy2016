function solve(args) {
    var obj = JSON.parse(args[0]),
        output = args[1];

    for (var property in obj) {
        if (obj.hasOwnProperty(property)) {
            var re = new RegExp("#{" + property + "}");
            var match = output.match(re);
            while (match != null) {
                output = output.replace(re, obj[property]);
                match = output.match(re);

            }

        }
    }
    console.log(output);
}

solve([
    '{ "name": "John", "age": 13 }', // options as JSON
    'My name is #{name} and I am #{age}-years-old' // template
]);