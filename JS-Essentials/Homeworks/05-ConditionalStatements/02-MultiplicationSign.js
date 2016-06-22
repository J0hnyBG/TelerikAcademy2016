function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2];
    var out;
    if (a === 0 || b === 0 || c === 0) {
        out = "0";
        return out;
    }
    var lessThanZero = 0;
    for (var i = 0; i < args.length; i++) {
        if (args[i] < 0) {
            lessThanZero++;
        }
    }

    if (lessThanZero % 2 === 0) {
        out = "+"
    } else {
        out = "-"
    }
    return out;
}
