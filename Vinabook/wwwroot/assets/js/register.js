// header fixed
window.onscroll = function() {myFunction()};

var header = document.querySelector(".header-mid");
var stickyHeader = header.offsetTop;

function myFunction() {
  if (window.scrollY > stickyHeader) {
    header.style.setProperty("display","flex");
    header.classList.add("header-mid_fixed");
  } else{
    header.classList.remove("header-mid_fixed");
  }

}

