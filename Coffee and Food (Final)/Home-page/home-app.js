/*Slide-show JS*/

var slideIndex = 1;
showSlides(slideIndex);

function plusSlides(n) {
  showSlides(slideIndex += n);
  //if n = 1, it moves to the right
  //if n = -1, it moves the left
}

function currentSlide(n) {
  showSlides(slideIndex = n);
}

function showSlides(n) {
  var i;
  var slides = document.getElementsByClassName("mySlides");
  var dots = document.getElementsByClassName("dot");
  if (n > slides.length) {slideIndex = 1} //without this...if you are at the 3rd slide and you click next - it will not go back to the 1st slide.
  if (n < 1) {slideIndex = slides.length} //without this...if you are at the 1st slide and you click prev - it will not show the 3rd slide as expected.
  for (i = 0; i < slides.length; i++) {
      slides[i].style.display = "none";
      //this is what makes it a slideshow
      //e.g. going from 1st slide to 2nd slide, the 1st slide's display will be "none" - while 2nd slide is visible. 
  }
  for (i = 0; i < dots.length; i++) {
      dots[i].className = dots[i].className.replace(" active", ""); //active - means the current dot is darker
      //without this...e.g. you visited 1st slide and then the 3rd slide - the 1st dot and 3rd dots will both dark (because it was not 'replace' by the 3rd dot as the " active" one.)
  }
  slides[slideIndex-1].style.display = "block";  //without this...the promo pictures are not even displayed.
  dots[slideIndex-1].className += " active"; //without this...none of the dots will never be active.
}
