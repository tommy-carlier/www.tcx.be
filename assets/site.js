---
---
(function(d){
  
  "use strict";
  
  // set target to _blank for all external hyperlinks
  var h = location.host;
  for (var xs = d.links, i = xs.length; i--; ){
    var x = xs[i];
    if (x.host != h){
      x.target = '_blank';
    }
  }
  
}(document))