function solve(params) {
    var nums = params[0].split(' ').map(Number),
        currRocks = 1,
        maxRocks = -Infinity;

    for (var i = 1; i < nums.length - 1; i++) {
        while (nums[i + 1] > nums[i] || nums[i - 1] > nums[i]) {
            currRocks++;
            i++;
        }
        maxRocks = Math.max(currRocks, maxRocks);
        currRocks = 1;
    }
    maxRocks = Math.max(currRocks, maxRocks);
    console.log(maxRocks);
}

solve(['5 1 7 4 8']);
console.log('================');
solve(['5 1 7 6 3 6 4 2 3 8']);
console.log('================');
solve(['10 1 2 3 4 5 4 3 2 1 10']);
console.log('================');
solve(['10 1 2 3 4 5 4 3 2 1 10 4 3 2 10']);
console.log('================');
solve(['10 9 8 7 6 5 4 3 2 1 10']);