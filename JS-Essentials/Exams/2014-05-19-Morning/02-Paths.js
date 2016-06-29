function solve(args) {
    var rowsCols = args[0].split(' '),
        rows = +rowsCols[0],
        cols = +rowsCols[1],
        boolMatrix = [],
        directionMatrix = [],
        i,
        direction = [0, 0],
        currCoords = [0, 0],
        score = 1;

    for (i = 1; i < rows + 1; i++) {
        directionMatrix[i] = args[i].split(' ');
        boolMatrix.push([]);
    }
    directionMatrix.shift();
    boolMatrix[0][0] = true;

    while (true) {
        switch (directionMatrix[currCoords[0]][currCoords[1]]) {
            case "dr":
                direction[0] = 1;
                direction[1] = 1;
                break;
            case "dl":
                direction[0] = 1;
                direction[1] = -1;
                break;
            case "ur":
                direction[0] = -1;
                direction[1] = 1;
                break;
            case "ul":
                direction[0] = -1;
                direction[1] = -1;
                break;
        }
        movePawn();
        if (currCoords[0] === rows || currCoords[1] === cols || currCoords[0] < 0 || currCoords[1] < 0) {
            console.log('successed with ' + score);
            break;
        }

        if (IsVisited() === true) {
            console.log('failed at (' + currCoords[0] + ', ' + currCoords[1] + ')');
            break;
        }
        else {
            score += calculateScore();
        }

        boolMatrix[currCoords[0]][currCoords[1]] = true;
    }
    function movePawn() {
        currCoords[0] += direction[0];
        currCoords[1] += direction[1];
    }

    /**
     * @return {boolean}
     */
    function IsVisited() {
        return boolMatrix[currCoords[0]][currCoords[1]];
    }

    function calculateScore() {
        return Math.pow(2, currCoords[0]) + currCoords[1];

    }
}

var params = [
    '3 5',
    'dr dl dr ur ul',
    'dr dr ul ur ur',
    'dl dr ur dl ur'
];

solve(params);

params = [
    '3 5',
    'dr dl dl ur ul',
    'dr dr ul ul ur',
    'dl dr ur dl ur'
];
solve(params);
