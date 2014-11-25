---
---
(function(d){
  
  "use strict";
  
  // set target to _blank for all external hyperlinks
  var hn = location.hostname;
  for (var xs = d.links, i = xs.length; i--; ){
    var x = xs[i];
    if (x.hostname != hn){
      x.target = '_blank';
    }
  }
  
}(document))