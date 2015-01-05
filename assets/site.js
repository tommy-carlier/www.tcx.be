(function(d){
  
  "use strict";
  
  var x, h = location.host;
  // set target to _blank for all external hyperlinks
  for (var xs = d.links, i = xs.length; i--; ){
    var x = xs[i];
    if (x.host != h){
      x.target = '_blank';
    }
  }
  
  // set current year in copyright footer
  var q = d.querySelector;
  if (q){
    x = q('body>footer>time');
    if (x){
      x.innerHTML = (new Date()).getFullYear();
    }
  }
  
}(document))