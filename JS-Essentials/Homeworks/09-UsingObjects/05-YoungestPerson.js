function solve(args) {
    var youngest,
        minAge = Infinity;

    for (var i = 0; i < args.length; i+= 3) {
        var person = {firstName: args[i], lastName: args[i+1], age: +args[i+2]};
        if (person.age < minAge) {
            minAge = person.age;
            youngest = person;
        }
    }

    console.log(youngest.firstName + ' ' + youngest.lastName);
}

solve( [
    'Gosho', 'Petrov', '32',
    'Bay', 'Ivan', '81',
    'John', 'Doe', '42'
]);
solve( [
    'Penka', 'Hristova', '61',
    'System', 'Failiure', '88',
    'Bat', 'Man', '16',
    'Malko', 'Kote', '72'
]);