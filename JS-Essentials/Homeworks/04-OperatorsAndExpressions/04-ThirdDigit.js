function solve(args) {

    var third = String(args);
    var char = third.charAt(third.length - 3);

    var thirdNumber = Number(char);

    return thirdNumber === 7 ? "true" : "false " + thirdNumber;
}