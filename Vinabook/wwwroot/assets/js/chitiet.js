// fixed
window.onscroll = function() {myFunction()};

var header = document.querySelector(".header-mid");
var stickyHeader = header.offsetTop;
var tab_detail = document.querySelector(".tab-detail");
var stickyTab = tab_detail.offsetTop;



var tab_info = document.querySelector(".information__title");
var infoTab = tab_info.offsetTop;
var tabPrevew = document.getElementById("tabReview");
var tabInfo = document.getElementById("tabInfo");
var tab_rate = document.querySelector(".comment__title");
var infoRate = tab_rate.offsetTop;

function myFunction() {
  if (window.scrollY > stickyHeader) {
    header.style.setProperty("display","flex");
    header.classList.add("header-mid_fixed");
  } else{
    header.classList.remove("header-mid_fixed");
  }
  
  if (window.scrollY > stickyTab) {
    header.style.setProperty("display","none");
    tabPrevew.classList.add("tab-detail__item--active");
    tab_detail.classList.add("tab-detail_fixed");
  } else {
    tab_detail.classList.remove("tab-detail_fixed");
  }
  
  if (window.scrollY > infoTab) {
    tabPrevew.classList.remove("tab-detail__item--active");
    tabInfo.classList.add("tab-detail__item--active");
  } else {
    tabInfo.classList.remove("tab-detail__item--active");
  }

  if (window.scrollY > infoRate) {
    tabInfo.classList.remove("tab-detail__item--active");
    tabRate.classList.add("tab-detail__item--active");
  } else {
    tabRate.classList.remove("tab-detail__item--active");
  }
}



