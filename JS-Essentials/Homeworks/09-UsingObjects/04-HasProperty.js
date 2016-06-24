function hasProperty(obj, prop) {
    return obj.hasOwnProperty(prop);
}
var ivan = {name: 'Ivan', age: 25};

console.log(hasProperty(ivan, "lastName"));
console.log(hasProperty(ivan, "name"));
console.log(hasProperty(ivan, "age"));
