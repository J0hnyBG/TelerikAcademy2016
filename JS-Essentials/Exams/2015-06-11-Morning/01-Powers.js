function solve(params) {
    var nk = params[0].split(' ').map(Number),
        s = params[1].split(' ').map(Number),
        previous,
        next,
        n = nk[0],
        k = nk[1];
    //Loop through number of transformations
    var result = [];
    for (var j = 0; j < k; j++) {
        //Transformation loop
        for (var i = 0; i < n; i++) {
            var current = s[i];

            if (i === 0) {
                previous = s[n - 1];
            }
            else {
                previous = s[i - 1];
            }
            if (i === n - 1) {
                next = s[0];
            }
            else {
                next = s[i + 1];
            }

            if(current === 0) {
                current = Math.abs(next - previous);
            }
            else if(current === 1) {
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
        s = result.slice();

    }
    // console.log(result.join(" "));
    console.log(result.reduce(function(a, b) {return a + b}, 0));

}

solve(['5 1', '9 0 2 4 1']);
solve(['10 3', '1 9 1 9 1 9 1 9 1 9']);
solve(['10 10', '0 1 2 3 4 5 6 7 8 9']);
solve(['10 1', '1 36 1 36 1 36 1 36 1 36']);