function solve(params) {
    var N = parseInt(params[0]);
    params.shift();
    var numbers = params.map(Number);

    function findMaxConsecutive(arr) {
        var max = -Infinity,
            temp = -Infinity;

        for (var i = 0; i < arr.length; i++) {
            temp = Math.max(+arr[i], temp + +arr[i]);
            max = Math.max(max, temp);
        }

        return max;
    }

    var answer = findMaxConsecutive(numbers);
    console.log(answer);
}
solve(['8',
    '1',
    '6',
    '-9',
    '4',
    '4',
    '-2',
    '10',
    '-1'
]);

solve(['-9', '-8', '-8', '-7', '-6', '-5', '-1', '-7', '-6']);