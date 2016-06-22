function solve(args) {
    var a = +args[0],
        b = +args[1],
        c = +args[2];

    var x1 = (-b + Math.sqrt((b * b) - (4 * a * c))) / (2 * a);
    var x2 = (-b - Math.sqrt((b * b) - (4 * a * c))) / (2 * a);

    if (isNaN(x1) && isNaN(x2)) {
        console.log("no real roots");
    } else if (isNaN(x1)) {
        console.log(x2.toFixed(2));
    } else if (isNaN(x2)) {
        console.log(x1.toFixed(2));
    } else {
        if (x1 < x2) {
            console.log("x1=" + x1.toFixed(2) + "; x2=" + x2.toFixed(2));
        } else if (x1 > x2) {
            console.log("x1=" + x2.toFixed(2) + "; x2=" + x1.toFixed(2));
        } else {
            console.log("x1=x2=" + x2.toFixed(2));
        }
    }
}
