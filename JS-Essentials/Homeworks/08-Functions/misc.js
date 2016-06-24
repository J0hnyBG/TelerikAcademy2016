function solve(args) {
    var input = (args[0]).split('\n'),
        n = +input[0],
        arr = input[1].split(' ').map(
            function (item) {
                return parseInt(item, 10);
            });
    console.log(arr.sort().join(' '));
}
solve(["6\n3 4 1 5 2 6"]);
/**
 * Created by Ivan on 24.06.2016 г..
 */
