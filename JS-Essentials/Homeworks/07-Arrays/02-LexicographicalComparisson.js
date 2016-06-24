function solve(args) {
    var input = (args[0]).split('\n');
    var out = input[0] < input[1] ? "<" :( input[0] > input[1] ? ">" : "=" );
    console.log(out);
}
solve(["food\nfood"]);
