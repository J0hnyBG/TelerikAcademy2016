/*Task 1.
 Write a function that sums an array of numbers:
 Numbers must be always of type Number
 Returns null if the array is empty
 Throws Error if the parameter is not passed (undefined)
 Throws if any of the elements is not convertible to Number*/

function solve(argArray) {
    return function (argArray) {
        "use strict";
        if (!argArray) {
            throw {
                message: "No argument passed!",
                name: "Undefined argument"
            };
        }

        if (argArray.constructor !== Array) {
            throw {
                message: "Passed argument is not an array!",
                name: "Argument exception"
            };
        }

        if (argArray.length === 0) {
            return null;
        }

        let arr = JSON.parse(JSON.stringify(argArray)),
            sum = 0;

        arr.forEach(function (item) {
            item = +item;
            if (isNaN(item)) {
                throw {
                    message: "Array parameter contains items which are not convertible to number!",
                    name: "Argument exception"
                }
            }

            sum += item;
        });

        return sum;
    }
}

if (module.exports) {
    module.exports = solve;
}