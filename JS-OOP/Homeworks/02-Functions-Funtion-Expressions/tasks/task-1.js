/* Task Description */
/* 
	Write a function that sums an array of numbers:
		numbers must be always of type Number
		returns `null` if the array is empty
		throws Error if the parameter is not passed (undefined)
		throws if any of the elements is not convertible to Number	

*/

function sum(argArray) {
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

module.exports = sum;