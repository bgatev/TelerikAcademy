function readCookie(name) {
  var allCookies = document.cookie.split(";");
  
  for (var i = 0; i < allCookies.length; i++) {
    var cookie = allCookies[i];
    var trailingZeros = 0;
    for (var j = 0; j < cookie.length; j++) {
      if (cookie[j] !== " ") {
        break;
      }
    }
    cookie = cookie.substring(j);
    if (cookie.startsWith(name + "=")) {
      return cookie;
    }
 }
}
console.log(readCookie());
