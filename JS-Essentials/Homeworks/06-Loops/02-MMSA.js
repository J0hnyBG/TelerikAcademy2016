function solve(args) {
  var min = +args[0],
      max = +args[0],
      sum = 0,
      avg;

      for (var i = 0; i < args.length; i++) {
        sum += +args[i];
        if (min > +args[i]) {
          min = +args[i]
        }
        if (max < +args[i]) {
          max = +args[i];
        }
      }
      avg = sum / args.length;
      console.log("min=" + min.toFixed(2));
      console.log("max=" + max.toFixed(2));
      console.log("sum=" + sum.toFixed(2));
      console.log("avg=" + avg.toFixed(2));

}
solve([2, -1 ,4])
