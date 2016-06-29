function solve(args) {
    var brackets = 0;

    for (var i = 0; i< args[0].length; i++) {
        switch (args[0][i]) {
            case '(':
                brackets++;
                break;
            case ')':
                brackets--;
                break;
        }
        if (brackets >= 0) continue;
        console.log('Incorrect');
        return;
    }

    console.log((brackets === 0 ? "Correct" : 'Incorrect'));
}

solve(['((a+b)/5-d)']);
solve([ ')(a+b))' ]);