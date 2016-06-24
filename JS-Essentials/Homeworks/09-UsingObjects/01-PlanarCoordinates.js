function solve(args) {
    var line1 = {start: {x: +args[0], y: +args[1]}, end: {x: +args[2], y: +args[3]}},
        line2 = {start: {x: +args[4], y: +args[5]}, end: {x: +args[6], y: +args[7]}},
        line3 = {start: {x: +args[8], y: +args[9]}, end: {x: +args[10], y: +args[11]}};

    line1.length = Math.sqrt(Math.pow(Math.abs(line1.start.x - line1.end.x), 2) + Math.pow(Math.abs(line1.start.y - line1.end.y), 2));
    line2.length = Math.sqrt(Math.pow(Math.abs(line2.start.x - line2.end.x), 2) + Math.pow(Math.abs(line2.start.y - line2.end.y), 2));
    line3.length = Math.sqrt(Math.pow(Math.abs(line3.start.x - line3.end.x), 2) + Math.pow(Math.abs(line3.start.y - line3.end.y), 2));
    console.log(line1.length.toFixed(2));
    console.log(line2.length.toFixed(2));
    console.log(line3.length.toFixed(2));

    if (line1.length + line2.length > line3.length
        && line1.length + line3.length > line2.length
        && line2.length + line3.length > line1.length) {
        console.log("Triangle can be built");
    } else {
        console.log("Triangle can not be built");

    }
}

solve( [
    '5', '6', '7', '8',
    '1', '2', '3', '4',
    '9', '10', '11', '12'
]);
solve( [
    '7', '7', '2', '2',
    '5', '6', '2', '2',
    '95', '-14.5', '0', '-0.123'
]);
