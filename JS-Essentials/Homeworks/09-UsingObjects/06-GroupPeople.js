'use strict';
function group(people) {
    var out = {};

    for (var i = 0; i < people.length; i++) {
        if (!out[people[i].age]) {
            out[people[i].age] = [];
        }
        out[people[i].age].push(people[i]);
    }
    return out;
}

var people = [
    { firstname: 'Gosho', lastname: 'Petrov', age: 32 },
    { firstname: 'Bay', lastname: 'Ivan', age: 81 },
    { firstname: 'John', lastname: 'Doe', age: 42 },
    { firstname: 'Pesho', lastname: 'Pesho', age: 22 },
    { firstname: 'Asdf', lastname: 'Xyz', age: 81 },
    { firstname: 'Gosho', lastname: 'Gosho', age: 22 }
];

var groupedByAge = group(people);
var a = 1+2;