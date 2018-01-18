function shuffle(xs) {
  var i = xs.length, x, rnd;
  while(i) {
    rnd = Math.floor(Math.random() * i);
    i -= 1;
    x = xs[i];
    xs[i] = xs[rnd];
    xs[rnd] = x;
  }
}