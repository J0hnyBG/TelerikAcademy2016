function solve(args) {
    var output = args[0];

    output = output.split(' ').join('&nbsp;');

    console.log(output);
}

solve(['This text contains 4 spaces!!']);
