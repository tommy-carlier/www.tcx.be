(function(){
  
  "use strict";
  
  var d = document;
  
  function initPage(){
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

    // set current year in copyright footer
    if (d.querySelector){
      x = d.querySelector('body>footer>time');
      if (x){
        x.innerHTML = (new Date()).getFullYear();
      }
    }
  }
  
  initPage();
  
}())