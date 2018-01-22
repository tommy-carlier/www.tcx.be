var removeAllChildren = document.createRange
  ? function(e) {
    var r = document.createRange();
    r.selectNodeContents(e);
    r.deleteContents();
    r.detach();
  } : function(e) {
    while(e.firstChild) {
      e.removeChild(e.firstChild);
    }
  };