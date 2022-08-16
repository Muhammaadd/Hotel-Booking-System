// hide aside on close icon click 
var aside = document.querySelector("aside div");
function asideToggle(){
    aside.classList.toggle("asideMargin");
};
$(document).ready(function(){
    $("#barIcon").click(asideToggle);
});
$(document).ready(function(){
    $("#closeIcon").click(asideToggle);
});
// Main content Slider
var imagesSrc = ['slider_2.jpg','slider_1.jpg'];
var mainSection = document.querySelector(".main-section");
var index = 0;
setInterval(function(){
    mainSection.style.backgroundImage = `url(/images/${imagesSrc[index]})`;
    if(index==imagesSrc.length-1)
        index =0;
    else
        index++;
},4000)
// show search nav on click
var searchNav = document.getElementById("serchNav");
function searchNavToggle(){
    searchNav.classList.toggle("searchNavMargin");
};
    $("#searchBtn").click(function () {
        searchNav.classList.toggle("searchNavMargin")
    });
$(document).ready(function(){
    $("#minimizeIcon").click(searchNavToggle);
});
// auto scroll to render body 
(function () {
    window.location.hash = '#RenderBody'
})();