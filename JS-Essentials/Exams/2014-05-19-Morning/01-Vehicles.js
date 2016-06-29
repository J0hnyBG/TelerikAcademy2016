function solve(args) {
    'use strict';
    var target = args[0],
        numbers = [3, 4, 10];


    var targets = [1];
    for (targets[target] = 0, a = 1; a < target; a++) {
        targets[a] = 0;
    }
    for (var i = 0; i < numbers.length; i++) {

        for (var j = numbers[i], a = j; a <= target; a++) {
            targets[a] += targets[a - j]
        }
    }
    console.log(targets[target]);
}

solve([7]);
solve([10]);
solve([40]);
solve([200]);