function solve(params) {
    var nums = params[0].split(' ').map(Number),
        currSum = nums[0],
        maxSum = -Infinity;
    // console.log("Curr: " + currSum);

    for (var i = 0; i < nums.length; i++) {
        currSum += nums[i];

        while (nums[i] < nums[i + 1] || nums[i] < nums[i - 1]) {
            i++;
            currSum += nums[i];
            // console.log("Curr: " + currSum);

        }
        // console.log("Max: " + maxSum);

        maxSum = Math.max(currSum, maxSum);
        currSum = nums[i];

    }
    maxSum = Math.max(currSum, maxSum);
    console.log(maxSum);

}
solve(["5 1 7 4 8"]);
solve(["5 1 7 6 5 6 4 2 3 8"]);
