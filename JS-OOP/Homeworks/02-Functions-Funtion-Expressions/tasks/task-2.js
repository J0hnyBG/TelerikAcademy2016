/* Task description */
/*
	Write a function that finds all the prime numbers in a range
		1) it should return the prime numbers in an array
		2) it must throw an Error if any on the range params is not convertible to `Number`
		3) it must throw an Error if any of the range params is missing
*/

function findPrimes(min, max) {
		"use strict";
		if(min === null || typeof min === 'undefined' || min === "") {
			throw {
				name: "Argument exception",
				message: "Argument min is missing"
			}
		}

		if(max === null || typeof max === 'undefined' || max === "") {
			throw {
				name: "Argument exception",
				message: "Argument max is missing"
			}
		}

		if (isNaN(min) || isNaN(max)) {
			throw {
				name: "Argument exception",
				message: "Some or all of the parameters cannot be converted to a Number"
			};
		}
		var isPrime,
			i,
			j,
			bound,
			upper = +max,
			lower = +min,
			result = [];

		for (i = Math.max(lower, 2); i <= upper; i += 1) {
			isPrime = true;
			bound = Math.floor(Math.sqrt(i));

			for (j = 2; j <= bound; j += 1) {
				if (i % j === 0) {
					isPrime = false;
					break;
				}
			}

			if (isPrime) {
				result.push(i);
			}
		}
		return result;
}

module.exports = findPrimes;
