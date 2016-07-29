document.addEventListener("DOMContentLoaded", function (ev) {
    var circles = [],
        c = document.getElementById('game'),
        ctx = c.getContext('2d'),
        canvasWidth = c.clientWidth,
        canvasHeight = c.clientHeight;
    const numberOfCircles = 25;
    const maxSpeed = 5;
    const minSpeed = 1;
    const maxRadius = 30;
    const minRadius = 4;

    c.setAttribute('width', canvasWidth);
    c.setAttribute('height', canvasHeight);
    //Initialize circles
    for (var i = 0; i < numberOfCircles; i++) {
        circles[i] = {
            //Get radius between minRadius and maxRadius
            radius: getRandomInt(minRadius, maxRadius),
            //Initially not positioned, because we need a radius, otherwise they'll get stuck
            x: 0,
            y: 0,
            //Get x and y directions -1 or 1
            direction: {
                x: getRandomPositiveOrNegative(1),
                y: getRandomPositiveOrNegative(1)
            },
            //Get speed between minSpeed and maxSpeed
            speed: getRandomInt(minSpeed, maxSpeed),
            color: getRandomColor()
        }
        circles[i].x = getRandomPositionOnAxis(canvasWidth, circles[i].radius);
        circles[i].y = getRandomPositionOnAxis(canvasHeight, circles[i].radius);
    }

    requestAnimationFrame(mainLogic);

    //Contains the animation and movement main logic
    function mainLogic() {
        //Clear canvas for redrawing
        ctx.clearRect(0, 0, canvasWidth, canvasHeight);
        for (var i = 0; i < circles.length; i++) {
            var circle = circles[i];
            drawCircle(circle);
            moveActor(circle);
            changeCircleDirectionIfNessesary(circle);
        }
        
        requestAnimationFrame(mainLogic);
    }

    //Gets a random position on any axis, taking into account the actor width/height
    function getRandomPositionOnAxis(max, actorSize) {
        return Math.floor(Math.random() * (max - actorSize * 2)) + actorSize;
    }
    //Gets random number and converts it to hex color
    function getRandomColor() {
        return '#' + Math.floor(Math.random() * 16777215).toString(16);
    }
    //Gets random int between two values
    function getRandomInt(min, max) {
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }
    //Flip the sign of a given number at random
    function getRandomPositiveOrNegative(num) {
        return Math.random() < 0.5 ? -num : num;
    }
    //Move a specific actor
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
        if (circle.y + circle.radius > canvasHeight || circle.y - circle.radius < 0) {
            circle.direction.y = - circle.direction.y;
        }
        if (circle.x + circle.radius > canvasWidth || circle.x - circle.radius < 0) {
            circle.direction.x = - circle.direction.x;
        }
    }
});