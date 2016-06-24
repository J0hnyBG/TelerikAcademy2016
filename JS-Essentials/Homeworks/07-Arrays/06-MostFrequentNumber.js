function solve(args) {

    var input = (args[0]).split('\n').map(
        function(item) {
            return parseInt(item, 10);
        }),
        n = input[0],
        arr = input.slice(1);
    arr.sort();
    var currentCount = 1,
        maxCount = 1,
        mostFrequentNum = arr[0];

    for (var i = 0; i < arr.length - 1; i++) {
        if (arr[i] == arr[i + 1]) {
            currentCount++;
            if (maxCount <= currentCount) {
                maxCount = currentCount;
                mostFrequentNum = arr[i];
            }
        }
        else {
            currentCount = 1;
        }
    }

    console.log(mostFrequentNum + " (" + maxCount +  " times)");
}
solve(["13\n4\n1\n1\n4\n2\n3\n4\n4\n1\n2\n4\n9\n3"]);