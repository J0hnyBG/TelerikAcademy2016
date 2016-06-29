function solve(args) {
    var pattern = args[0].toLowerCase(),
        inputString = args[1].toLowerCase(),
        count = 0;

    var indexOfPattern = inputString.indexOf(pattern);

    while (indexOfPattern >= 0) {
        count++;
        indexOfPattern = inputString.indexOf(pattern, indexOfPattern + 1);
    }

    console.log(count);
}

solve([
    'in',
    'We are living in an yellow submarine. We don\'t have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.'
]);