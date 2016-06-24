//TODO: 90/100
function solve(args) {
    var input = (args[0]).split('\n'),
        n = +input[0],
        maximalSequence = 0,
        currentSequence = 0,
        updated = false;

    for (var i = 1; i < n; i++) {
        if (+input[i] === +input[i - 1]) {
            updated = false;
            currentSequence += 1;
        }
        else {
            updated = true;
            maximalSequence = Math.max(maximalSequence, currentSequence);
            currentSequence = 1;
        }
    }

    console.log(updated ? maximalSequence : Math.max(maximalSequence, currentSequence));
}
solve(["10\n2\n1\n1\n2\n3\n3\n2\n2\n2\n1"]);