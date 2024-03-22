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

// combobox/filter

var filterCombobox = document.querySelector(".filter-combobox");
var filterBox = document.querySelector(".category-right__filter-box");
function comboboxOpen() {
  filterCombobox.classList.toggle("filter-combobox_none");
  filterBox.classList.toggle("filter-combobox_active");
}
