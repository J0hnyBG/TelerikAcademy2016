function solve(e) {
    var width = e[0];
    var height = e[1];

    var perimeter = ((2 * width) + (2 * height)).toFixed(2);
    var area = (width * height).toFixed(2);

    return area + " " + perimeter;
}