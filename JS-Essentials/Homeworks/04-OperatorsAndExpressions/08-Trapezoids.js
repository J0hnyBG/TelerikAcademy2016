var a = [-2, 1, 33];
solve (a)
function solve(args) {

    var a = +args[0];
    var b = +args[1];
    var h = +args[2];

    console.log((h * ((a + b) / 2)).toFixed(7));

}
