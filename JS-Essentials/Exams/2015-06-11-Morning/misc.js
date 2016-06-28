function solve(params) {
    var rows = parseInt(params[0]),
        cols = parseInt(params[1]),
        tests = parseInt(params[rows + 2]),
        board = [],
        currentRow,
        currentCol,
        nextRow,
        nextCol,
        chessPiece,
        direction = [],
        move;

    function setDirection() {
        if (currentRow > nextRow) {
            direction[0] = -1;
        }
        else if(currentRow < nextRow) {
            direction[0] = 1;
        }
        else {
            direction[0] = 0;
        }
        if (currentCol > nextCol) {
            direction[1] = -1;
        }
        else if(currentCol < nextCol) {
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
    for (var j = 2, i = 0; j < rows + 2; j++, i++) {

        board[i] = params[j];

    }
    board.reverse();

    for (i = 0; i < tests; i++) {
        var isValid = true;
        move = params[rows + 3 + i];
        currentRow = +move[1] - 1;
        currentCol = move.charCodeAt(0) - 97;
        nextRow = +move[4] - 1;
        nextCol = move.charCodeAt(3) - 97;

        if(currentCol === nextCol && currentRow === nextRow) {
            isValid = false;
            console.log('no');
            continue;
        }
        chessPiece = board[currentRow][currentCol];

        setDirection();

        //queen movement
        if(chessPiece === 'Q') {
            while (currentCol != nextCol || currentRow != nextRow) {
                movePiece();

                chessPiece = board[currentRow][currentCol];

                if (isInvalidPosition()) {
                    isValid = false;
                    break;
                }

            }
        }
        //bishop movement
        else if(chessPiece === 'B') {
            if(direction[0] === 0 || direction[1] === 0) {
                isValid = false;
            }
            else {
                while (currentCol != nextCol || currentRow != nextRow) {
                    movePiece();

                    chessPiece = board[currentRow][currentCol];
                    if (isInvalidPosition()) {
                        isValid = false;
                        break;
                    }
                }
            }
        }
        //rook movement
        else if(chessPiece === 'R') {
            if (direction[0] != 0 && direction[1] != 0) {
                isValid = false;
            }
            else {
                while (currentCol != nextCol || currentRow != nextRow) {
                    movePiece();

                    chessPiece = board[currentRow][currentCol];
                    if (isInvalidPosition()) {
                        isValid = false;
                        break;
                    }
                }
            }
        }
        else { //if '-'
            isValid = false;
        }

        if(isValid) {
            console.log('yes');
        }
        else {
            console.log('no');
        }

    }
}


solve([
    '3',
    '4',
    '--R-',
    'B--B',
    'Q--Q',
    '12',
    'd1 b3', //yes
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