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

// cart click
var headermid_cart = document.querySelector(".header-mid__cart");
var cart_box = document.querySelector(".cart-box");
headermid_cart.onclick = function(){
  cart_box.classList.toggle("cart-box-none");
}

// Login Form

var loginForm = document.getElementById("loginForm");

function openLogin() {
  loginForm.style.setProperty("display","flex")
}

function closeLoginForm() {
  loginForm.style.setProperty("display","none")
}


var listbooks__list = document.querySelector(".listbooks-list");
listbooks__list.classList.remove("listbooks_none");


// alert close
var alertClose = document.getElementById("alertClose");
function closeAlert() {
  alertClose.style.setProperty("display","none")
}
