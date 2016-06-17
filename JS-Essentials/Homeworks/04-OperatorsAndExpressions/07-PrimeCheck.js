function solve(number) {
    var isPrime = true;
    if (number < 2) {
        isPrime = false;
    }
    for (i = 2; i <= Math.sqrt(number); i += 1) {
        if (number % i == 0) {
            isPrime = false;
        }
    }
    return console.log(isPrime);
}