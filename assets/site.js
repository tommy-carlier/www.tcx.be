(function(){
  
  "use strict";
  
  // add startsWith method to String, if it does not already exist
  if (!String.prototype.startsWith){
    String.prototype.startsWith = function(s){
      return this.slice(0, s.length) == s;
    }
  }
  
  var d = document;
  
  // indicate current tab in page header
  if (d.querySelectorAll && d.classList){
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

  // set current year in copyright footer
  if (d.querySelector){
    var x = d.querySelector('body>footer>time');
    if (x){
      x.textContent = (new Date()).getFullYear();
    }
  }
}())