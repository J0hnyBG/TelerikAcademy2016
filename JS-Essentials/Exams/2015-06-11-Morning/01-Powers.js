function solve(params) {
    var nk = params[0].split(' ').map(Number),
        array = params[1].split(' ').map(Number),
        previous,
        next,
        n = nk[0],
        k = nk[1],
        result = array.slice();

    //Loop through number of transformations
    for (var j = 0; j < k; j++) {
        //Transformation loop
        for (var i = 0; i < n; i++) {
            var current = array[i];

            if (i === 0) {
                previous = array[n - 1];
            }
            else {
                previous = array[i - 1];
            }
            if (i === n - 1) {
                next = array[0];
            }
            else {
                next = array[i + 1];
            }

            if (current === 0) {
                current = Math.abs(next - previous);
            }
            else if (current === 1) {
                current = next + previous;
            }
            else if (current % 2 === 0) {
                current = Math.max(next, previous);
            }
            else {
                current = Math.min(next, previous);
            }
            result[i] = current;
        }
        array = result.slice();

    }
    console.log(result.reduce(function (a, b) {
        return a + b
    }, 0));

}

//215
solve(['65 0', '2 2 6 0 1 3 6 3 7 7 0 6 3 3 1 1 2 0 4 4 1 0 4 1 1 3 2 0 8 1 9 0 9 3 5 7 4 5 6 4 3 9 6 1 1 0 9 6 0 0 7 5 5 8 4 8 0 0 0 1 0 7 0 1 0']);
solve(['10 3', '1 9 1 9 1 9 1 9 1 9']);
solve(['10 10', '0 1 2 3 4 5 6 7 8 9']);
solve(['10 1', '1 36 1 36 1 36 1 36 1 36']);