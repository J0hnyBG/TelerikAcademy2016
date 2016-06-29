//TODO: all
function solve(args) {
    const openingUp= '<upcase>',
        closingUp = '</upcase>',
        openingLow = '<lowcase>',
        closingLow = '</lowcase>',
        openingOrg = '<orgcase>',
        closingOrg = '</orgcase>';

    var input = args[0].slice(),
        startIndex = input.indexOf(openingUp),
        endIndex = input.indexOf(closingUp);

    while (startIndex >= 0 || endIndex >= 0) {
        var upperCaseStr = input.substr(startIndex + openingUp.length, endIndex - startIndex - openingUp.length).toUpperCase();
        var toBeReplaced  = input.substr(startIndex + openingUp.length, endIndex - startIndex - openingUp.length);
        input = input.replace(toBeReplaced, upperCaseStr);
        // input = input.remove(startIndex, endIndex - startIndex + closingUp.length);

    }

    console.log(input);
}

solve([ 'We are <orgcase>liViNg</orgcase> in a <upcase>yellow submarine</upcase>. We <orgcase>doN\'t</orgcase> have <lowcase>anything</lowcase> else.' ]);