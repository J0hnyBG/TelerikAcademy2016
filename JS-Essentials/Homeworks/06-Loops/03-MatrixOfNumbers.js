function solve(args) {
    var n = +args;

    for (var i = 0; i < n; i++) {
        var out = "";
        for (var j = i + 1; j <= n + i; j++) {
          out += j + " ";
        }
        console.log(out);
    }

}
solve("200");
