(function(){
  
  "use strict";
  
  // add startsWith method to String, if it does not already exist
  if (!String.prototype.startsWith){
    String.prototype.startsWith = function(s){
      return this.slice(0, s.length) == s;
    }
  }
  
  var d = document, inits = [];
  window.initializers = inits;
  
  // initializer to manipulate all hyperlinks
  inits.push(function(){
    var h = location.host, t;
    for (var xs = d.links, i = xs.length; i--; ){
      var x = xs[i], m = x.getAttribute('data-m');
      if (m) {
        // de-obfuscate e-mail hyperlink
        m = m.replace(/[\/]/g, '@').replace(/,/g, '.');
        x.href = 'mailto:' + m;
        if ((t = x.firstChild) && x.nodeType == 3){
          t.data = m;
        }
      } else if (x.host != h){
        // set target to _blank for all external hyperlinks
        x.target = '_blank';
      }
    }
  });
  
  // initializer to indicate current tab in page header
  inits.push(function(){
    if (d.querySelectorAll){
      var xs = d.querySelectorAll('body>header>nav>a'), href = location.href;
      for(var i = 1, n = xs.length; i < n; i++){
        var x = xs[i];
        if (href.startsWith(x.href)){
          x.classList.add('current');
        } else {
          x.classList.remove('current');
        }
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
