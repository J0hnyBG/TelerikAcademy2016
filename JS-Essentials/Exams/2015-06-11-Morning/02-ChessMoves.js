function solve(params) {
    var totalRows = parseInt(params[0]),
        totalCols = parseInt(params[1]),
        tests = parseInt(params[totalRows + 2]),
        board = [],
        currentRow,
        currentCol,
        nextRow,
        nextCol,
        chessPiece,
        direction = [],
        move,
        isValid = true;

    function setDirection() {
        if (currentRow > nextRow) {
            direction[0] = -1;
        }
        else if (currentRow < nextRow) {
            direction[0] = 1;
        }
        else {
            direction[0] = 0;
        }
        if (currentCol > nextCol) {
            direction[1] = -1;
        }
        else if (currentCol < nextCol) {
            direction[1] = 1;
        }
        else {
            direction[1] = 0;
        }
    }

    function movePiece() {
        currentRow += direction[0];
        currentCol += direction[1];
    }

    function isInvalidPosition() {
        return chessPiece != '-' || typeof(chessPiece) === 'undefined' || chessPiece === null;
    }

    function isOutSide() {
        return currentCol >= totalCols || currentCol < 0 || currentRow >= totalRows || currentRow < 0;
    }

    function loopThroughMove() {
        while (currentCol != nextCol || currentRow != nextRow) {
            movePiece();
            if (isOutSide()) {
                isValid = false;
                break;
            }
            chessPiece = board[currentRow][currentCol];
            if (isInvalidPosition()) {
                isValid = false;
                break;
            }
        }
    }

    for (var j = 2, i = 0; j < totalRows + 2; j++, i++) {
        board[i] = params[j];
    }
    board.reverse();

    for (i = 0; i < tests; i++) {
        isValid = true;
        move = params[totalRows + 3 + i];
        currentRow = +move[1] - 1;
        currentCol = move.charCodeAt(0) - 97;
        nextRow = +move[4] - 1;
        nextCol = move.charCodeAt(3) - 97;

        if (currentCol === nextCol && currentRow === nextRow) {
            isValid = false;
            console.log('no');
            continue;
        }
        chessPiece = board[currentRow][currentCol];

        setDirection();

        switch (chessPiece) {
            case 'Q': //queen movement
                loopThroughMove();
                break;
            case 'B': //bishop movement
                if (direction[0] === 0 || direction[1] === 0) {
                    isValid = false;
                }
                else {
                    loopThroughMove();
                }
                break;
            case 'R': //rook movement
                if (direction[0] != 0 && direction[1] != 0) {
                    isValid = false;
                }
                else {
                    loopThroughMove();
                }
                break;
            default: //if '-'
                isValid = false;
                break;
        }

        if (isValid) {
            console.log('yes');
        }
        else {
            console.log('no');
        }
    }
}
//
solve([
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3',
    'a1 a3',
    'c3 b2',
    'a1 c1',
    'a1 b2',
    'a1 c3',
    'a2 b3',
    'd2 c1',
    'b1 b2',
    'c3 b1',
    'a2 a3',
    'd1 d3'
]);
console.log("***");
solve([
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d5',
    'b3 a2',
    'b3 d1',
    'b3 a4',
    'c2 c5'

]);
console.log("***");
solve([
    '8',
    '10',
    '-----R----',
    '----------',
    '---Q-----B',
    '----------',
    '-Q--------',
    '-------B--',
    '---------R',
    '-B--------',
    '9',
    'f8 g1',
    'f8 f1',
    'b4 e1',
    'b4 d5',
    'b1 e2',
    'b1 a3',
    'd6 f5',
    'd6 j8',
    'h3 a6'
]);
console.log("***");
solve([
    '5',
    '5',
    'Q---Q',
    '-----',
    '-B---',
    '--R--',
    'Q---Q',
    '10',
    'a1 a1',
    'a1 d4',
    'e1 b4',
    'a5 d2',
    'e5 b2',
    'b3 d5',
    'b3 a2',
    'b3 d1',
    'b3 a4',
    'c2 c5'

]);