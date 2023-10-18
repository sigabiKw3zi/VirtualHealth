let slides = document.querySelectorAll('.slide');
let currentIndex = 0;

function nextSlide() {
    slides[currentIndex].style.animation = ''; // Remove previous animation
    currentIndex = (currentIndex + 1) % slides.length;
    slides[currentIndex].style.animation = 'fade 10s infinite';
    setTimeout(zoomOut, 10000); // Zoom out after 10 seconds
}

function zoomOut() {
    slides[currentIndex].style.animation = ''; // Remove previous animation
    slides[currentIndex].style.animation = 'zoom-out 10s infinite';
    setTimeout(nextSlide, 10000); // Show next slide after 10 seconds
}

// Start the slideshow
nextSlide();
