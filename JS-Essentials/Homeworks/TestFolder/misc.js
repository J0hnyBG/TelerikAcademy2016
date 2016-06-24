//TODO: 90/100
function solve(args) {
    var numbers = (args[0]).split('\n'),
        n = +numbers[0],
        maximalSequence = 1,
        currentSequence = 1;
    numbers.shift();
    var maxNum;

    for (var i = 1; i < numbers.length; i++) {
        if (+numbers[i - 1] === +numbers[i]) {
            currentSequence++;
            if (currentSequence >= maximalSequence) {
                maximalSequence =currentSequence;
                maxNum = numbers[i];
            }
        }
        else {
            currentSequence = 1;
        }
    }
    console.log(maximalSequence);
}
solve(["10\n2\n1\n1\n2\n3\n3\n2\n2\n2\n1"]);