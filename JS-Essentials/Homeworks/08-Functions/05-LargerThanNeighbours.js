function solve(args) {
    var input = (args[0]).split('\n'),
        n = +input[0],
        arr = input[1].slice(1).split(' ').map(
            function(item) {
                return parseInt(item, 10);
            }),

        count = 0;

    for (var i = 1; i < arr.length - 1; i++) {
        if (arr[i] > arr[i+1] && arr[i] > arr[i-1]) {
            count++;
        }
    }
    console.log(count);
}

solve(["8\n-26 -25 -28 31 2 27"])
