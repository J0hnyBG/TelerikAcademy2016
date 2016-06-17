var a = [1, 2];
solve(a);
function solve(args) {
    var rectangleTopOffset = 1;
    var rectangleLeftOffset = -1;
    var rectangleWidth = 6;
    var rectangleHeight = 2;

    var circleX = 1;
    var circleY = 1;
    var circleRadius = 1.5;

    var x = +args[0];
    var y = +args[1];

    var isInsideCircle = Math.pow(x - circleX, 2) + Math.pow(y - circleY, 2) <= circleRadius * circleRadius;
    var isInsideRectangle = !(rectangleLeftOffset < x && x <= rectangleLeftOffset + rectangleWidth && rectangleTopOffset < y && y <= rectangleTopOffset + rectangleHeight);
    var output = "";
    if (isInsideCircle) {
        output += "inside circle ";
    }
    else {
        output += "outside circle ";
    }
    if (isInsideRectangle) {
        output += "inside rectangle";
    }
    else {
        output += "outside rectangle";
    }

    console.log(output);
}
