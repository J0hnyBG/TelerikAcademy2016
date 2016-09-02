/*Task 2.
 Write a function that finds all the prime numbers in a range
 It should return the prime numbers in an array
 It must throw an Error if any of the range params is not convertible to Number
 It must throw an Error if any of the range params is missing*/

function solve(min, max) {
    "use strict";
    return function (min, max) {
        if (isNaN(min) || isNaN(max)) {
            throw {
                name: "Argument exception",
                message: "Some or all of the parameters cannot be converted to a Number"
            };
        }

        var bottom = +min,
            top = +max,
            result = [];


    }
}