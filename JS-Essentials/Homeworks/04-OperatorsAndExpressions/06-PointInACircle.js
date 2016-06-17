function solve(args) {

    var x = args[0];
    var y = args[1];

    var calc = x*x + y*y;
    var radius = 2;

    if (calc <= radius*radius) {
        return "yes " +  Math.sqrt(calc).toFixed(2);
    }
    else {
        return "no " + Math.sqrt(calc).toFixed(2);
    }
}
