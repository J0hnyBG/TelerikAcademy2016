document.addEventListener("DOMContentLoaded", function (ev) {
    var c = document.getElementById('game'),
        ctx = c.getContext('2d');
    ctx.rect(0, 0, 800, 600);
    ctx.stroke();
    var circles = [
        {
            radius: 20,
            x: 20,
            y: 20,
            direction: {x: 1, y: 1},
            speed: 5,
            color: "#090"
        },
        {
            radius: 30,
            x: 150,
            y: 500,
            direction: {x: 1, y: 1},
            speed: 2,
            color: "#2980b9"
        },
        {
            radius: 10,
            x: 200,
            y: 550,
            direction: {x: -1, y: 1},
            speed: 7,
            color: "#009"
        },
        {
            radius: 20,
            x: 138,
            y: 20,
            direction: {x: 1, y: -1},
            speed: 3,
            color: "#d35400"
        },
        {
            radius: 14,
            x: 200,
            y: 550,
            direction: {x: 1, y: -1},
            speed: 4,
            color: "#8e44ad"
        },
        {
            radius: 7,
            x: 300,
            y: 300,
            direction: {x: -1, y: 1},
            speed: 3.5,
            color: "#2c3e50"
        },
        {
            radius: 18,
            x: 600,
            y: 20,
            direction: {x: 1, y: 1},
            speed: 3,
            color: "#c0392b"
        },
        {
            radius: 8,
            x: 20,
            y: 550,
            direction: {x: -1, y: -1},
            speed: 2,
            color: "#16a085"
        }];
    requestAnimationFrame(repeatOften);
    function repeatOften() {
        drawCircles();
        for (var i = 0; i < circles.length; i++) {
            var cir = circles[i];
            moveCircle(cir);
            checkOutOfBounds(cir);
        }
        requestAnimationFrame(repeatOften);
    }

    function moveCircle(circle) {
        circle.x += circle.direction.x * circle.speed;
        circle.y += circle.direction.y * circle.speed;
    }

    function drawCircles() {
        ctx.clearRect(0, 0, c.width, c.height);
        for (var i = 0; i < circles.length; i++) {
            ctx.beginPath();
            ctx.arc(circles[i].x, circles[i].y, circles[i].radius, 0, 2 * Math.PI, true);
            ctx.closePath();
            ctx.fillStyle = circles[i].color;
            ctx.fill();
        }
    }

    function checkOutOfBounds(actor) {
        if (actor.y + actor.radius > c.height || actor.y - actor.radius < 0) {
            actor.direction.y = -actor.direction.y;
        }
        if (actor.x + actor.radius > c.width || actor.x - actor.radius < 0) {
            actor.direction.x = -actor.direction.x;
        }
    }
});