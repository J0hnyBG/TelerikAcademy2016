function solve(args) {
    var number = +args[0],
        output = '',
        onesLower = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'],
        onesUpper = ['Zero', 'One', 'Two', 'Three', 'Four', 'Five', 'Six', 'Seven', 'Eight', 'Nine'],
        tensLower = ['', 'ten', 'twenty', 'thirty', 'fourty', 'fifty', 'sixty', 'seventy', 'eighty', 'ninety', ],
        tensUpper = ['', 'Ten', 'Twenty', 'Thirty', 'Fourty', 'Fifty', 'Sixty', 'Seventy', 'Eighty', 'Ninety', ],
        teensLower = ['ten', 'eleven', 'twelve', 'thirteen', 'fourteen', 'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen'],
        teensUpper = ['Ten', 'Eleven', 'Twelve', 'Thirteen', 'Fourteen', 'Fifteen', 'Sixteen', 'Seventeen', 'Eighteen', 'Nineteen'],
        tens = Math.floor((number / 10) % 10),
        hundreds = Math.floor(number / 100),
        ones = number % 10;

    if (hundreds === 0 && tens === 0) {
        output = onesUpper[ones];
    } else if (hundreds === 0) {
        if (tens === 1) {
            output = teensUpper[ones];
        } else {
            if (ones === 0) {
                output = tensUpper[tens];
            } else {
                output = tensUpper[tens] + ' ' + onesLower[ones];
            }
        }
    } else {
        if (tens === 0 && ones === 0) {
            output = onesUpper[hundreds] + ' hundred';
        } else if (ones === 0) {
            output = onesUpper[hundreds] + ' hundred' + ' and ' + tensLower[tens];
        } else if (tens === 0) {
            output = onesUpper[hundreds] + ' hundred' + ' and ' + onesLower[ones];
        } else {
            if (tens === 1 && ones >= 1) {
                output = onesUpper[hundreds] + ' hundred' + ' and ' + teensLower[ones];
            } else {
                output = onesUpper[hundreds] + ' hundred' + ' and ' + tensLower[tens] + ' ' + onesLower[ones];
            }
        }
    }

    return output;
}

console.log(solve(['0']));
console.log(solve(['9']));
console.log(solve(['10']));
console.log(solve(['12']));
console.log(solve(['19']));
console.log(solve(['25']));
console.log(solve(['98']));
console.log(solve(['273']));
console.log(solve(['400']));
console.log(solve(['501']));
console.log(solve(['617']));
console.log(solve(['711']));
console.log(solve(['999']));
