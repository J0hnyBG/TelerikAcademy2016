function solve(args) {
    var a = +args[0];
    var b = +args[1];
    var c = +args[2];

    if (a < b) {
        var temp = a;
        a = b;
        b = temp;
    }
    if (b < c) {
        var temp = b;
        b = c;
        c = temp;
    }
    if (a < b) {
        var temp = a;
        a = b;
        b = temp;
    }
    console.log(a + " " + b + " " + c);
}
