//TODO: 90/100
function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        currCoords = {row: 0, col: 0},
        nextCoords = {row: 0, col: 0},
        direction = {x: 0, y: 0},
        chessPiece,
        board = [],
        move,
        knightMoves = [[-2, 1], [-1, 2], [1, 2], [2, 1],
            [2, -1], [1, -2], [-1, -2], [-2, -1]];


    for (var j = 2, i = 0; j < rows + 2; j++, i++) {
        board[i] = params[j];
    }
    board.reverse();
    
    for (i = 0; i < tests; i++) {
        var isValid = true;

        move = params[rows + 3 + i];
        currCoords.row = +move[1] - 1;
        currCoords.col = move.charCodeAt(0) - 97;

        nextCoords.row = +move[4] - 1;
        nextCoords.col = move.charCodeAt(3) - 97;

        if (currCoords.col === nextCoords.col && currCoords.row === nextCoords.row) {
            isValid = false;
            console.log('no');
            continue;
        }

        chessPiece = board[currCoords.row][currCoords.col];

        setDirection();

        if (chessPiece === 'Q') {
            while (currCoords.col != nextCoords.col || currCoords.row != nextCoords.row) {
                movePiece();
                if(isOutSide()) {
                    isValid = false;
                    break;
                }
                chessPiece = board[currCoords.row][currCoords.col];
                if (isInvalidPosition()) {
                    isValid = false;
                    break;
                }

            }
        }
        else if (chessPiece === 'K') {
            if (board[nextCoords.row][nextCoords.col] != '-' || (direction.x === 0 || direction.y === 0)) {
                isValid = false;
            }
            else {
                var next = [nextCoords.row - currCoords.row, nextCoords.col - currCoords.col];

                for (var k = 0; k < knightMoves.length; k++) {
                    var knightMove = knightMoves[k];
                    if(knightMove[0] === next[0] && knightMove[1] === next[1]) {
                        isValid = true;
                        break;
                    }
                    isValid = false;
                }
            }
        }
        else { //if chessPiece === '-'
            isValid = false;
        }
        if (isValid) {
            console.log('yes');
        }
        else {
            console.log('no');
        }
    }

    function setDirection() {
        if (currCoords.row > nextCoords.row) {
            direction.x = -1;
        }
        else if (currCoords.row < nextCoords.row) {
            direction.x = 1;
        }
        else {
            direction.x = 0;
        }
        if (currCoords.col > nextCoords.col) {
            direction.y = -1;
        }
        else if (currCoords.col < nextCoords.col) {
            direction.y = 1;
        }
        else {
            direction.y = 0;
        }
    }
    function isOutSide() {
        return currCoords.col >= cols || currCoords.col < 0 || currCoords.row >= rows || currCoords.row < 0;
    }

    function movePiece() {
        currCoords.row += direction.x;
        currCoords.col += direction.y;
    }

    function isInvalidPosition() {
        return chessPiece != '-' || typeof(chessPiece) === 'undefined' || chessPiece === null;
    }
}


solve(['3',
    '4',
    '--K-',
    'K--K',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 c1',
    'd2 b1',
    'b1 b2',
    'c3 a3',
    'a2 a3',
    'd1 d3'
]);
console.log('==================');
solve(['5',
    '5',
    'Q---Q',
    '-----',
    '-K---',
    '--K--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d4',
    'b3 c1',
    'b3 d1',
    'c2 a3',
    'c2 b4'
]);
