function solve(params) {
    var rc = params[0].split(' ').map(Number),
        totalRows = rc[0],
        totalCols = rc[1],
        debrisArr = params[1].split(';'),
        tanksArr = [],
        i,
        field = [],
        deadPlayer = '',
        koceTanks = tanksArr.slice(0, 4),
        cukiTanks = tanksArr.slice(4, tanksArr.length),
        numberOfCommands = +params[2];

    //add Koceto's tanks
    for (i = 0; i < 4; i++) {
        var koceTank = {row: 0, col: i, dead: false};
        tanksArr.push(koceTank);
    }
    //add Cuki's tanks
    for (i = 0; i < 4; i++) {
        var cukiTank = {row: totalRows - 1, col: totalCols - i - 1, dead: false};
        tanksArr.push(cukiTank);
    }
    //initialize field
    for (i = 0; i < totalRows; i++) {
        field[i] = [];
    }
    //Place both teams tanks
    for (i = 0; i < tanksArr.length; i++) {
        var tank = tanksArr[i];
        field[tank.row][tank.col] = tank;
    }
    //Place debris
    for (i = 0; i < debrisArr.length; i++) {
        var debrisCoords = debrisArr[i].split(' ').map(Number);
        field[debrisCoords[0]][debrisCoords[1]] = 'D';
    }
    //main loop
    for (i = 0; i < numberOfCommands; i++) {
        var command = params[i + 3];
        if (command.indexOf('mv') > -1) {
            processMove(command);
        }
        else if (command.indexOf('x') > -1) {
            processFire(command);
        }

        if (deadPlayer == 'Cuki') {
            console.log('Cuki is gg');
            break;
        }
        if (deadPlayer == 'Koce') {
            console.log('Koceto is gg');
            break;
        }
    }

    function processFire(command) {
        var splitCmd = command.split(' ');
        var tankId = +splitCmd[1];
        var tank = tanksArr[tankId];
        var directions = getDirection(splitCmd[2]);
        var projectile = {row: tank.row, col: tank.col};
        while (true) {
            moveActor(projectile, directions);
            if (isOutSide(projectile)) {
                break;
            }

            if (!isEmpty(field[projectile.row][projectile.col])) {
                var element = field[projectile.row][projectile.col];
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
        var isCukiDead = cukiTanks.every(function (tank) {
            return tank.dead;
        });
        if (isCukiDead) {
            deadPlayer = 'Cuki';
            return;
        }
        var isKocetoDead = koceTanks.every(function (tank) {
            return tank.dead;
        });
        if (isKocetoDead) {
            deadPlayer = 'Koce';
        }
    }

    function processMove(command) {
        var splitCmd = command.split(' ');
        var tankId = +splitCmd[1];
        var cellsToMove = +splitCmd[2];
        var directions = getDirection(splitCmd[3]);
        var tank = tanksArr[tankId];
        moveTank(tank, directions, cellsToMove);
    }

    function moveTank(tank, directions, cellsToMove) {
        if (tank != null) {
            field[tank.row][tank.col] = null;
            for (var i = 0; i < cellsToMove; i++) {
                if (tank.dead == true) {
                    break;
                }
                moveActor(tank, directions);
                if (!isEmpty(field[tank.row][tank.col]) || isOutSide(tank)) {
                    moveActor(tank, [-directions[0], -directions[1]]);
                    break;
                }
            }
            field[tank.row][tank.col] = tank;
        }
    }

    function moveActor(actor, dir) {
        actor.row += dir[0];
        actor.col += dir[1];
    }

    function isEmpty(el) {
        return el == null || typeof(el) == 'undefined';
    }

    function isOutSide(actor) {
        return actor.row >= totalRows || actor.row < 0
            || actor.col >= totalCols || actor.col < 0;
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