function solve(args) {
    var arr = [];

    for (var i = 0; i < +args[0]; i++) {
      arr[i] = i * 5;
      console.log(arr[i]);
    }
}

solve(["5"]);
