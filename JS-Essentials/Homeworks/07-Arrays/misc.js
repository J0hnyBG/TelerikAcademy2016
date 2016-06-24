function solve(args) {

    var input = (args[0]).split('\n').map(
        function(item) {
            return parseInt(item, 10);
        }),
        n = input[0],
        arr = input.slice(1);

    for (var i = 0; i < n - 1; i++) {
        var iMin = i;

        for (var j = i + 1; j < n; j++) {
            if (arr[j] < arr[iMin]) {
                iMin = j;
            }
        }
        if (iMin != i) {
            var temp = arr[i];
            arr[i] = arr[iMin];
            arr[iMin] = temp;
        }

    }

    for (var k = 0; k < n; k++) {
        console.log(arr[k]);
    }
}
solve(["10\n36\n10\n1\n34\n28\n38\n31\n27\n30\n20"]);
