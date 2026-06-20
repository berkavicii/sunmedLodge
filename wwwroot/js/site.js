(() => {
  const slides = document.querySelectorAll(".hero-slide");

  if (slides.length <= 1) {
    return;
  }

  let activeIndex = 0;

  window.setInterval(() => {
    slides[activeIndex].classList.remove("is-active");
    activeIndex = (activeIndex + 1) % slides.length;
    slides[activeIndex].classList.add("is-active");
  }, 10000);
})();
