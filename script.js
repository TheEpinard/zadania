var secondsHand = document.querySelector('.secounds'),
    minutesHand = document.querySelector('.minutes'),
    hoursHand = document.querySelector('.hours');

function setupClock() {
    var now = new Date();

    var secs = now.getSeconds();
    var mins = now.getMinutes() * 60 + secs;
    var hours = now.getHours() * 3600 + mins;

    secondsHand.style.animationDelay = '-' + secs + 's';
    minutesHand.style.animationDelay = '-' + mins + 's';
    hoursHand.style.animationDelay = '-' + hours + 's';
}

setupClock();
