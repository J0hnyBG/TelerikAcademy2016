function solve(params) {
    var rowsCols = params[0].split(' ');
    const boardSize = {rows: +rowsCols[0], cols: +rowsCols[1]};
    rowsCols = params[1].split(' ');
    var currCoords = {x: +rowsCols[0], y: +rowsCols[1]},
        direction = {x: 0, y: 0},
        cellScores = [],
        inc = 1,
        totalScore = 0,
        steps = 0;

    for (var i = 0; i < boardSize.rows; i++) {
        cellScores[i] = [];
        for (var j = 0; j < boardSize.cols; j++) {
            cellScores[i][j] = inc ;
            inc++;
        }
    }
    function movePawn() {
        currCoords.x += direction.x;
        currCoords.y += direction.y;
        steps++;
    }
    function setDirection(dir) {
        switch(dir) {
            case 'd':
                direction.x = 1;
                direction.y = 0;
                break;
            case 'u':
                direction.x = -1;
                direction.y = 0;
                break;
            case 'l':
                direction.x = 0;
                direction.y = -1;
                break;
            case 'r':
                direction.x = 0;
                direction.y = 1;
                break;
        }
    }

    function collectScore() {
        totalScore += cellScores[currCoords.x][currCoords.y];
        cellScores[currCoords.x][currCoords.y] = 0;
    }
    params.shift();
    params.shift();
    var board = params;

    collectScore();

    while(true) {
        setDirection(board[currCoords.x][currCoords.y]);
        movePawn();

        if (currCoords.x >= boardSize.rows || currCoords.x < 0
            || currCoords.y >= boardSize.cols || currCoords.y < 0) {
            console.log('out ' + totalScore);
            break;
        }
        if(cellScores[currCoords.x][currCoords.y] === 0) {
            console.log('lost ' + steps);
            break;
        }
        collectScore();
    }
}
solve([
    "3 4",
    "1 3",
    "lrrd",
    "dlll",
    "rddd"]
);

solve([
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "durlddud",
    "urrrldud",
    "ulllllll"]
);
solve([
    "5 8",
    "0 0",
    "rrrrrrrd",
    "rludulrd",
    "lurlddud",
    "urrrldud",
    "ulllllll"]
);