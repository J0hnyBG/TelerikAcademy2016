function solve(args) {
    var input = args,
        n = +input[0];
    // console.log(input[1]);
    var arr = input[1].split(' ').map(
            function (item) {
                return parseInt(item, 10);
            }),

        out = 0;

    for (var i = 1; i < arr.length - 1; i++) {
        if (arr[i] > arr[i + 1] && arr[i] > arr[i - 1]) {
            out = i;
            break;
        }
    }
    console.log(out);
}
solve(["8", "-26 -25 -28 31 2 27"]);
