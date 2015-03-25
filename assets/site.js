(function(){
  
  "use strict";
  
  var d = document;
  
  function initPage(){
    var x, h = location.host;
    // set target to _blank for all external hyperlinks
    for (var xs = d.links, i = xs.length; i--; ){
      var x = xs[i];
      if (x.host != h){
        x.target = '_blank';
      }
    }

    // set current year in copyright footer
    if (d.querySelector){
      x = d.querySelector('body>footer>time');
      if (x){
        x.innerHTML = (new Date()).getFullYear();
      }
    }
  }
  
}())