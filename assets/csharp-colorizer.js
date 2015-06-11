(function(){
  
  "use strict";
  
  var d = document;
  
  function initPage(){
    if (d.querySelectorAll){
      for (var xs = d.querySelectorAll('pre.csharp'), i = xs.length; i--; ){
        var x = xs[i];
        x.innerHTML = x.innerHTML
          .replace(/(\/\/\s*)(.*)/g, '<span class=c-cm>$1<span class=c-t>$2</span></span>');
      }
    }
  }
  
  window.initializers.push(initPage);
  initPage();
}())