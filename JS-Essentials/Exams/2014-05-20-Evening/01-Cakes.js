function solve(params) {
    var s = params[0],
        c1 = params[1], c2 = params[2], c3 = params[3],
        max = -Infinity;

    for (var i = 0; i <= s / c1; i++) {
        var firstProduct = i * c1;
        for (var j = 0; j <= s / c2; j++) {
            var secondProduct = j * c2;
            for (var k = 0; k <= s / c3; k++) {
                var thirdProduct = k * c3;
                var currentSum = firstProduct + secondProduct + thirdProduct;
                if (currentSum <= s) {
                    max = Math.max(max, currentSum);

                }
            }
        }
    }
    console.log(max);
}
solve([110, 13, 15, 17]);
solve([20, 11, 200, 300]);
solve([110, 19, 29, 39]);


