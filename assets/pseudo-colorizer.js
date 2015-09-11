(function(){
  
  "use strict";
  
  var d = document;
  
  function colorize(html){
    return html;
  }
  
  function initPage(){
    if (d.querySelectorAll){
      for (var xs = d.querySelectorAll('pre.pseudo'), i = xs.length; i--; ){
        var x = xs[i];
        x.innerHTML = colorize(x.innerHTML);
      }
    }
  }
  
  window.initializers.push(initPage);
  initPage();
}())