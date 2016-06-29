//todo: 66/100
function solve(params) {
        var variables = {};
    Array.prototype.clean = function(deleteValue) {
        for (var i = 0; i < this.length; i++) {
            if (this[i] == deleteValue) {
                this.splice(i, 1);
                i--;
            }
        }
        return this;
    };
    function isArray(obj) {
        return (typeof obj !== 'undefined' &&
        obj && obj.constructor === Array);
    }
    function findSum(arr) {
        var sum = 0;
        if(isArray(arr)) {
            var numArr = arr.map(Number);

            for (var i = 0; i < arr.length; i++) {
                var num = numArr[i];
                if(isNaN(num)) {
                    var nextArr = variables[arr[i]];
                    if (isArray(nextArr)) {
                        num = findSum(nextArr);
                    }
                    else {
                        num = nextArr;
                    }
                }
                sum += num;
            }
        }
        else {
            sum = +arr;
        }
        return sum;
    }
    function findAvg(arr) {
        var sum = 0;
        if(isArray(arr)) {
            var numArr = arr.map(Number);
            for (var i = 0; i < arr.length; i++) {
                var num = numArr[i];
                if (isNaN(num)) {
                    var nextArr = variables[arr[i]];
                    if (isArray(nextArr)) {
                        num = findAvg(nextArr);
                    }
                    else {
                        num = nextArr;
                    }
                }
                sum += num;
            }
        }
        else {
            sum = +arr;
            return sum;
        }
        return Math.floor(sum / numArr.length);
    }
    function findMin(arr) {
        var min = +Infinity;

        if(isArray(arr)) {
            var numArr = arr.map(Number);
            for (var i = 0; i < arr.length; i++) {
                var num = numArr[i];
                if (isNaN(num)) {
                    var nextArr = variables[arr[i]];
                    if (isArray(nextArr)) {
                        num = findMin(nextArr);
                    }
                    else {
                        num = nextArr;
                    }

                }

                min = Math.min(num, min);
            }
        }
        else {
            min = +arr;
        }
        return min;
    }
    function findMax(arr) {
        var max = -Infinity;
        if(isArray(arr)) {
            var numArr = arr.map(Number);
            for (var i = 0; i < arr.length; i++) {
                var num = numArr[i];
                if (isNaN(num)) {
                    var nextArr = variables[arr[i]];
                    if (isArray(nextArr)) {
                        num = findMax(nextArr);
                    }
                    else {
                        num = nextArr;
                    }
                }

                max = Math.max(num, max);
            }
        }
        else {
                max = +arr;
            }
        return max;
    }
    function fillArray(arr) {
        var numArr = arr.map(Number);
        var out = [];
        for (var i = 0; i < arr.length; i++) {
            var num = numArr[i];
            if(isNaN(num)) {
                var nextArr = variables[arr[i]];
                if(isArray(nextArr)) {
                    out = out.concat(nextArr);
                }
                else {
                    num = nextArr;
                    out.push(num);
                }
            }
            else {
                out.push(num);
            }
        }
        return out;
    }

    for (var i = 0; i < params.length; i++) {
        var line = params[i].split(' ');
        line = line.clean('');

        if(line[0] === 'def') {
            var varValue = line.splice(2);
            variables[line[1]] = varValue.join('');
        }
        else {
            for (var property in variables) {
                if (variables.hasOwnProperty(property)) {
                    var splitPropertyValue = variables[property].split('[');
                    var operation = splitPropertyValue[0];
                    var numbers = splitPropertyValue[1].replace(']', '').split(',');

                    if(operation === '') {
                        variables[property] = fillArray(numbers);
                    }
                    else if(operation === 'sum') {
                        variables[property] = findSum(numbers);

                    }
                    else if(operation === 'avg') {
                        variables[property] = findAvg(numbers);

                    }
                    else if(operation === 'min') {
                        variables[property] = findMin(numbers);
                    }
                    else if(operation === 'max') {
                        variables[property] = findMax(numbers);
                    }

                }
            }
        }
    }
    var finalLine = params[params.length - 1].split(' ');
    finalLine = finalLine.clean('').join('');


    finalLine = finalLine.split('[');
    numbers = finalLine[1].replace(']', '').split(',');
    numbers = numbers.clean('');

    operation = finalLine[0];
    var result = 0;
    if(operation === '') {
        console.log(variables[property]);
    }
    else if(operation === 'sum') {
        result = findSum(numbers);
        console.log(result);
    }
    else if(operation === 'avg') {
        result = findAvg(numbers);
        console.log(result);
    }
    else if(operation === 'min') {
        result = findMin(numbers);
        console.log(result);
    }
    else if(operation === 'max') {
        result = findMax(numbers);
        console.log(result);
    }
}



solve([
    'def func sum[5, 3,       7, 2, 6, 3]',
    'def func2 [5, 3, 7, 2,       6, 3]',
    'def          func3      min[func2]',
    'def func4 max[5, 3,          7, 2, 6, 3]',
    'def func5 avg[5, 3, 7, 2, 6, 3]',
    'def func6 sum[func2, func3, func4 ]',
    'sum[func6, func4]'

]);

solve([
    'def func sum[1, 2, 3, -6]',
    'def newList [func, 10, 1]',
    'def newFunc sum[func, 100, newList]',
     '[newFunc]'
]);