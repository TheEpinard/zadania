var secondsHand = document.querySelector('.secounds'), //pobierane wskazówek
    minutesHand = document.querySelector('.minutes'),
    hoursHand = document.querySelector('.hours');
    
var now = new Date(); //konstruktor czasu zwraca obeną godzinę 
function setupClock() {
  
    var secs = now.getSeconds();            //pobieranie sekund minut i godzin 
    var mins = now.getMinutes() * 60 + secs;
    var hours = now.getHours() * 3600 + mins;

    secondsHand.style.animationDelay = '-' + secs + 's';
    minutesHand.style.animationDelay = '-' + mins + 's';
    hoursHand.style.animationDelay = '-' + hours + 's';
}


setupClock();
