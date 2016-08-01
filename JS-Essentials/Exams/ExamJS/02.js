function solve(params) {
    var rc = params[0].split(' ').map(Number),
        totalRows = rc[0],
        totalCols = rc[1],
        debrisArr = params[1].split(';'),
        tanksArr = [],
        i,
        field = [],
        deadPlayer = '';

    //add Koceto's tanks
    for (i = 0; i < 4; i++) {
        var tank = {row: 0, col: i, dead: false};
        tanksArr.push(tank);
    }
    //add Cuki's tanks
    for (i = 0; i < 4; i++) {
        var tank = {row: totalRows - 1, col: totalCols - i - 1, dead: false};
        tanksArr.push(tank);
    }
    //initialize field
    for (i = 0; i < totalRows; i++) {
        field[i] = [];
    }
    //Place both teams tanks
    for (var j = 0; j < tanksArr.length; j++) {
        var tank = tanksArr[j];
        field[tank.row][tank.col] = tank;
    }
    //Place debris
    for (i = 0; i < debrisArr.length; i++) {
        var debrisCoords = debrisArr[i].split(' ').map(Number);
        field[debrisCoords[0]][debrisCoords[1]] = 'D';
    }

    var numberOfCommands = +params[2];

    for (i = 0; i < numberOfCommands; i++) {
        //do stuff
        var command = params[i + 3];
        if (command.indexOf('mv') > -1) {
            processMove(command);
        }
        else if (command.indexOf('x') > -1) {
            processFire(command);
        }

        if(deadPlayer == 'Cuki') {
            console.log('Cuki is gg');
            break;
        }
        if(deadPlayer == 'Koce') {
            console.log('Koceto is gg');
            break;
        }
    }

    function processFire(command) {
        var splitCmd = command.split(' ');
        var tankId = +splitCmd[1];
        var tank = getTankById(tankId);
        var directionArr = getDirection(splitCmd[2]);
        var projectile = {row: tank.row, col: tank.col};
        while (true) {
            projectile.row += directionArr[0];
            projectile.col += directionArr[1];
            if (isOutSide(projectile)) {
                break;
            }
            if (!isEmpty(field[projectile.row][projectile.col])) {
                var element = field[projectile.row][projectile.col];
                // console.log(element);
                if (typeof (element) === 'object') {
                    element.dead = true;
                    console.log("Tank " + tanksArr.indexOf(element) + " is gg");
                    checkIfPlayerIsDead();
                }

                field[projectile.row][projectile.col] = null;
                break;

            }
        }
    }

    function checkIfPlayerIsDead() {
        var koceTanks = tanksArr.slice(0, 4);
        var cukiTanks = tanksArr.slice(4, tanksArr.length);
        var isCukiDead = cukiTanks.every(function (tank) {
            return tank.dead;
        });
        var isKocetoDead = koceTanks.every(function (tank) {
            return tank.dead;
        });
        if(isCukiDead) {
            deadPlayer = 'Cuki';
        }
        else if(isKocetoDead) {
            deadPlayer = 'Koce';
        }

    }


    function processMove(command) {
        var splitCmd = command.split(' ');
        var tankId = +splitCmd[1];
        var cellsToMove = +splitCmd[2];
        var directionArr = getDirection(splitCmd[3]);
        var tank = getTankById(tankId);
        moveTank(tank, directionArr, cellsToMove);
    }

    function moveTank(tank, directions, cellsToMove) {
        if (tank != null) {
            field[tank.row][tank.col] = null;
            for (var i = 0; i < cellsToMove; i++) {
                if (tank.dead == true) {
                    break;
                }
                tank.row += directions[0];
                tank.col += directions[1];
                if (!isEmpty(field[tank.row][tank.col]) ||
                    isOutSide(tank)) {
                    tank.row -= directions[0];
                    tank.col -= directions[1];
                    break;
                }
            }
            field[tank.row][tank.col] = tank;
        }
    }


    function isEmpty(el) {
        return el == null || typeof(el) == 'undefined';
    }

    function isOutSide(tank) {
        return tank.row >= totalRows || tank.row < 0
            || tank.col >= totalCols || tank.col < 0;
    }

    function getTankById(id) {
        return tanksArr[id];
    }

    function getDirection(dir) {
        switch (dir) {
            case 'u':
                return [-1, 0];
                break;
            case 'd':
                return [1, 0];
                break;
            case 'l':
                return [0, -1];
                break;
            case 'r':
                return [0, 1];
                break;
        }
    }
}
solve([
    '5 5',
    '2 0;2 1;2 2;2 3;2 4',
    '13',
    'mv 7 2 l',
    'x 7 u',
    'x 0 d',
    'x 6 u',
    'x 5 u',
    'x 2 d',
    'x 3 d',
    'mv 4 1 u',
    'mv 4 4 l',
    'mv 1 1 l',
    'x 4 u',
    'mv 4 2 r',
    'x 2 d'
]);
console.log('==========');
solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
]);
console.log('==========');

solve([
    '10 10',
    '1 0;1 1;1 2;1 3;1 4;4 1;4 2;4 3;4 4',
    '8',
    'mv 4 9 u',
    'x 4 l',
    'x 4 l',
    'x 4 l',
    'x 0 r',
    'mv 0 9 r',
    'mv 5 1 r',
    'x 5 u'
]);
console.log('==========');

solve([
    '10 5',
    '1 0;1 1;1 2;1 3;1 4;3 1;3 3;4 0;4 2;4 4',
    '43',
    'mv 6 5 r',
    'mv 0 6 d',
    'x 0 d',
    'x 0 d',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 6 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 7 u',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 3 d',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 4 u',
    'x 0 r',
    'mv 0 6 d',
    'mv 0 9 r',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d',
    'mv 0 1 l',
    'x 0 d'
]);