---
---
(function(d){
  
  "use strict";
  
  var re_http = /^http:/, re_tcx = /^http:\/\/www\.tcx\.be\//;
  
  // set target to _blank for all external hyperlinks
  for (var xs = d.getElementsByTagName('A'), i = xs.length; i--; ){
    var x = xs[i], href = x.href;
    if (re_http.test(href) && !re_tcx.test(href)){
      x.setAttribute('target', '_blank');
    }
  }
  
}(document))