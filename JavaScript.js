const slider = document.querySelector('.slider');
const prevBtn = document.querySelector('.prev');
const nextBtn = document.querySelector('.next');
let counter = 1;

prevBtn.addEventListener('click', () => {
  counter--;
  if (counter < 1) {
    counter = 3;
  }
  slider.style.transform = `translateX(${-100 * counter}%)`;
});

nextBtn.addEventListener('click', () => {
  counter++;
  if (counter > 3) {
    counter = 1;
  }
  slider.style.transform = `translateX(${-100 * counter}%)`;
});

setInterval(() => {
  counter++;
  if (counter > 3) {
    counter = 1;
  }
  slider.style.transform = `translateX(${-100 * counter}%)`;
}, 5000);
