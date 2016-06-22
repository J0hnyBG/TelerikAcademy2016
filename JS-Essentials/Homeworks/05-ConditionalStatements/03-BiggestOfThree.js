function solve(args) {
  var max = +args[0];
  if (+args[1] > +args[0]) {
      max = +args[1];
  }
  if (+args[2] > max) {
      max = +args[2];
  }
  return max;

}
