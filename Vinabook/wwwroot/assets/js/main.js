// menu click
var headerbot__listbooks = document.querySelector(".header-bot__listbooks");
var listbooks__list = document.querySelector(".listbooks-list");
headerbot__listbooks.onclick = function(){
    listbooks__list.classList.toggle("listbooks_none");
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