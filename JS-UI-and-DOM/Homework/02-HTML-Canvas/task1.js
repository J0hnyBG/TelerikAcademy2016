document.addEventListener("DOMContentLoaded", function (ev) {
    var circles = [],
        c = document.getElementById('game'),
        ctx = c.getContext('2d');
    const numberOfCircles = 25;
    const maxSpeed = 5;
    const minSpeed = 1;
    const maxRadius = 30;
    const minRadius = 4;

    //Initialize circles
    for (var i = 0; i < numberOfCircles; i++) {
        circles[i] = {
            //Get radius between minRadius and maxRadius
            radius: Math.floor(Math.random() * (maxRadius - minRadius)) + minRadius,
            //Initially not positioned, because we need a radius, otherwise they'll get stuck
            x: 0,
            y: 0,
            //Get x and y directions -1 or 1
            direction: {
                x: Math.random() < 0.5 ? -1 : 1,
                y: Math.random() < 0.5 ? -1 : 1
            },
            //Get speed between minSpeed and maxSpeed
            speed: Math.floor((Math.random() * maxSpeed)) + minSpeed,
            color: getRandomColor()
        }
        circles[i].x = Math.floor(Math.random() * (c.width - circles[i].radius * 2 )) + circles[i].radius;
        circles[i].y = Math.floor(Math.random() * (c.height - circles[i].radius * 2 )) + circles[i].radius;
    }

    requestAnimationFrame(mainLogic);

    //Gets random number and converts it to hex color
    function getRandomColor() {
        return '#' + Math.floor(Math.random() * 16777215).toString(16);
    }

    //Contains the animation and movement main logic
    function mainLogic() {
        //Clear canvas for redrawing
        ctx.clearRect(0, 0, c.width, c.height);

        for (var i = 0; i < circles.length; i++) {
            var circle = circles[i];
            drawCircle(circle);
            moveActor(circle);
            changeCircleDirectionIfNessesary(circle);
        }
        requestAnimationFrame(mainLogic);
    }
    //Move a specific circle
    function moveActor(actor) {
        actor.x += actor.direction.x * actor.speed;
        actor.y += actor.direction.y * actor.speed;
    }
    //Draw a specific circle
    function drawCircle(circle) {
        ctx.beginPath();
        ctx.arc(circle.x, circle.y, circle.radius, 0, 2 * Math.PI, true);
        ctx.closePath();
        ctx.fillStyle = circle.color;
        ctx.fill();
    }
    //Inverts direction if the circle has hit a wall
    function changeCircleDirectionIfNessesary(circle) {
        if (circle.y + circle.radius > c.height || circle.y - circle.radius < 0) {
            circle.direction.y = - circle.direction.y;
        }
        if (circle.x + circle.radius > c.width || circle.x - circle.radius < 0) {
            circle.direction.x = - circle.direction.x;
        }
    }
});