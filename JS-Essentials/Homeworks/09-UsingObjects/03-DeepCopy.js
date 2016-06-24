function deepCopy(object) {

    var copy = JSON.parse(JSON.stringify(object));
    return copy;
}

var string  = "I'm a string!";
var a = deepCopy(string);
a = "I'm copied string!";
var ivan = {name: 'Ivan', age: 25};
var b = deepCopy(ivan);
b.name = "Pesho";
var array = [1,2,3,4,5];
var c = deepCopy(array);
c[0] = 5;
c[1] = 4;
c[2] = 3;
c[3] = 2;
c[4] = 1;
