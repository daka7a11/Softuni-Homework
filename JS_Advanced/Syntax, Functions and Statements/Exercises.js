//1.	Fruit
function fruit(fruitType, grams, pricePerKg) {
    let weight = grams / 1000;
    let money = weight * pricePerKg;

    console.log(`I need $${money.toFixed(2)} to buy ${weight.toFixed(2)} kilograms ${fruitType}.`);
}

//2.	Greatest Common Divisor - GCD
function gretestCommonDivisor(a, b) {
    if (b > a) {
        var temp = a;
        a = b;
        b = temp;
    }
    while (true) {

        if (b == 0) {
            console.log(a);
            break;
        };

        a %= b;

        if (a == 0) {
            console.log(b);
            break;
        }

        b %= a;
    }
}

//3.	Same Numbers
function sameNumbers(num) {

    let numAsString = num.toString();
    let firstDigit = numAsString[0];
    let digitsSum = 0;
    let isDigitsSame = true;

    for (let i = 0; i < numAsString.length; i++) {
        if (numAsString[i] != firstDigit) {
            isDigitsSame = false;
        }
        digitsSum += Number(numAsString[i]);
    }

    console.log(isDigitsSame);
    console.log(digitsSum);
}

//4.	Previous Day
function previousDay(year, month, day) {
    let date = new Date(year, month - 1, day);

    date.setDate(date.getDate() - 1);

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

//5.	Time to Walk
function timeToWalk(steps, footprintMeters, speed) {
    const distance = steps * footprintMeters;
    let time = Math.round(distance / speed * 3.60); //km/h to m/s
    time += Math.floor(distance / 500) * 60;

    const seconds = time % 60;
    time -= seconds;
    time /= 60;

    const minutes = time % 60;
    time -= minutes;
    time /= 60;

    const hours = time;

    console.log(`${pad(hours)}:${pad(minutes)}:${pad(seconds)}`)

    function pad(num) {
        if (num < 10) {
            return '0' + num;
        }
        return num;
    }
}

//6.	Road Radar
function roadRadar(speed, zone) {

    const zones = {
        'motorway': 130,
        'interstate': 90,
        'city': 50,
        'residential': 20
    };

    const limitInZone = zones[zone];

    let message;

    if (speed > limitInZone) {

        const overspeed = speed - limitInZone;

        let status;

        if (overspeed > 40) {
            status = 'reckless driving';
        }
        else if (overspeed > 20) {
            status = 'excessive speeding';
        }
        else {
            status = 'speeding';
        }

        message = `The speed is ${overspeed} km/h faster than the allowed speed of ${limitInZone} - ${status}`;
    }
    else {
        message = `Driving ${speed} km/h in a ${limitInZone} zone`;
    }

    console.log(message);
}

//7.	Cooking by Numbers
function cookingByNumbers(...args) {
    let num = Number(args[0]);

    for (let i = 1; i < args.length; i++) {
        const currOperation = args[i];
        if (currOperation == 'chop') {
            num /= 2;
        }
        else if (currOperation == 'dice') {
            num = Math.sqrt(num);
        }
        else if (currOperation == 'spice') {
            num++;
        }
        else if (currOperation == 'bake') {
            num *= 3;
        }
        else if (currOperation == 'fillet') {
            num -= num * 0.2;
        }
        console.log(num);
    }
}

//8.	Validity Checker
function validityChecker(x1, y1, x2, y2){

}

//9.	*Words Uppercase
function wordsUppercase(){

    const regex = '[a-zA-Z]';
    const str = 'aaa aaa geichi! pidal!chi';

    let arr = str.match(regex);
    console.log(arr.length);
}


//Test functions
wordsUppercase();