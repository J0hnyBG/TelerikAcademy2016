//TODO: 80/100
function solve(args) {

    var input = (args[0]).split('\n').map(
        function(item) {
            return parseInt(item, 10);
        }),
        n = input[0],
        arr = input.slice(1);
    arr.sort();

    var previous = null;
    var maxElem = null;
    var count = 0;
    var max = 0;
    for (var i = 0; i < arr.length; i++) {
        if (arr[i] != previous) {
            if (count > max) {
                max = count;
                maxElem = previous;
            }
            previous = arr[i];
            count = 1;
        } else {
            count++;
        }
    }
    console.log(maxElem + " (" + max +  " times)");
}
solve(["13\n4\n1\n1\n4\n2\n3\n4\n4\n1\n2\n4\n9\n3"]);