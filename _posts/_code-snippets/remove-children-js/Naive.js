function removeAllChildren(e) {
  while(e.firstChild) {
    e.removeChild(e.firstChild);
  }
}