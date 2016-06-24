function solve(args) {

    var input = (args[0]).split('\n').map(
        function(item) {
            return parseInt(item, 10);
        }),
        n = input[0],
        x = input[input.length - 1],
        arr = input.slice(1, input.length - 1),
        low = 0,
        high = n-1;


    while (true) {
        if (high < low) {
            console.log("-1");
            break;
        }
        var mid = low + Math.floor((high - low) / 2);

        if (arr[mid] < x) {
            low = mid + 1;
        }
        else if (arr[mid] > x) {
            high = mid - 1;
        }
        else {
            console.log(mid);
            break;
        }
    }
}
solve(["10\n1\n2\n4\n8\n16\n31\n32\n64\n77\n99\n32"]);
