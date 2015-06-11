(function(){
  
  "use strict";
  
  var d = document, inits = [];
  window.initializers = inits;
  
  // initializer to manipulate all hyperlinks
  inits.push(function(){
    var x, h = location.host;
    for (var xs = d.links, i = xs.length; i--; ){
      var x = xs[i], m = x.getAttribute('data-m');
      if (m) {
        // de-obfuscate e-mail hyperlink
        m = m.replace(/[\/]/g, '@').replace(/,/g, '.');
        x.href = 'mailto:' + m;
        if ((x = x.firstChild) && x.nodeType == 3){
          x.data = m;
        }
      } else if (x.host != h){
        // set target to _blank for all external hyperlinks
        x.target = '_blank';
      }
    }
  });

  // initializer to set current year in copyright footer
  inits.push(function(){
    if (d.querySelector){
      var x = d.querySelector('body>footer>time');
      if (x){
        x.innerHTML = (new Date()).getFullYear();
      }
    }
  });
  
  
  function initPage(){
    // call all initializers
    for(var i = 0, n = inits.length; i < n; i++){
      inits[i]();
    }
  }
  
  initPage();
  
}())