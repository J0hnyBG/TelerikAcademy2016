function solve(params) {
    var sizes = params[0].split(' '),
        fieldSize = {rows: +sizes[0], cols: +sizes[1]},
        score = 0,
        visitedCells = [],
        field = [],
        currentCoords = {row: fieldSize.rows - 1, col: fieldSize.cols - 1},
        moves = [
            [-2, 1],  //1
            [-1, 2],  //2
            [1, 2],   //3
            [2, 1],   //4
            [2, -1],  //5
            [1, -2],  //6
            [-1, -2], //7
            [-2, -1]  //8
        ],
        steppedOnPrevious = false,
        jumps = 0;
    //Initialize score and visited matrices & fill field with moves
    for (var row = 0; row < fieldSize.rows; row++) {
        visitedCells[row] = [];
        field[row] = params[row + 1];
        
        for (var col = 0; col < fieldSize.cols; col++) {
            visitedCells[row][col] = false;
        }
    }
    //Main loop
    while (true) {
        collectScore();
        if (currentCellIsVisited()) {
            steppedOnPrevious = true;
            break;
        }
        setVisited();
        var indexOfMove = +field[currentCoords.row][currentCoords.col] - 1;
        movePawn(indexOfMove);
        if (currentCoords.row >= fieldSize.rows || currentCoords.row < 0
            || currentCoords.col >= fieldSize.cols || currentCoords.col < 0) {
            break;
        }
    }
    console.log(steppedOnPrevious ? "Sadly the horse is doomed in " + jumps + " jumps" : "Go go Horsy! Collected " + score + " weeds");

    function collectScore() {
        score += getPoints(currentCoords.row,currentCoords.col);

    }

    function movePawn(indexOfMove) {
        currentCoords.row += moves[indexOfMove][0];
        currentCoords.col += moves[indexOfMove][1];
        jumps++;
    }

    function currentCellIsVisited() {
        return visitedCells[currentCoords.row][currentCoords.col];
    }

    function setVisited() {
        visitedCells[currentCoords.row][currentCoords.col] = true;
    }
    function getPoints(row, col) {
        return Math.pow(2, row) - col;
    }
}
solve([
    '3 5',
    '54561',
    '43328',
    '52388'
]);

solve([
    '3 5',
    '54361',
    '43326',
    '52188'
]);
solve([
    '9 15',
    '543615436154361',
    '433264332643326',
    '521885218852188',
    '543615436154361',
    '433264332643326',
    '433264332643326',
    '543615436154361',
    '433264332643326',
    '433264332643328'
]);