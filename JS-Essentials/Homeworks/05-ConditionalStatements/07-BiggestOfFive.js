function solve(args) {
  var n1 = +args[0],
      n2 = +args[1],
      n3 = +args[2],
      n4 = +args[3],
      n5 = +args[4];

  var max = n1;

  if (max < n2) {
      max = n2;
  }
  if (max < n3) {
      max = n3;
  }
  if (max < n4) {
      max = n4;
  }
  if (max < n5) {
      max = n5;
  }
  console.log(max);

}
