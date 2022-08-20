//1.	Echo Function
function echoFunction(str) {
    console.log(str.length);
    console.log(str);
}

//2.	String Length
function stringLength(str, str2, str3) {
    let sumLength = str.length + str2.length + str3.length
    console.log(sumLength);
    console.log(Math.floor((sumLength) / 3));
}

//3.	Largest Number
function largestNumber(num, num2, num3) {
    let result = Math.max(num, num2, num3);
    console.log(`The largest number is ${result}.`);
}

//4.	Circle Area
function circleArea(input) {
    let inputType = typeof (input);
    if (inputType == 'number') {
        let area = Math.PI * (Math.pow(input, 2))
        console.log(area.toFixed(2));
    }
    else {
        console.log(`We can not calculate the circle area, because we receive a ${inputType}.`);
    }
}

//5.	Math Operations
function mathOperations(num, num2, op) {
    let cases = {
        '+': (a, b) => { return a + b },
        '-': (a, b) => { return a - b },
        '*': (a, b) => { return a * b },
        '/': (a, b) => { return a / b },
        '%': (a, b) => { return a % b },
        '**': (a, b) => { return a ** b }
    }

    console.log(cases[op](num, num2));
}

//6.	Sum of Numbers N…M
function sumOfNumbers(start, end) {
    let sum = 0;
    let num1 = Number(start);
    let num2 = Number(end);

    for (let i = num1; i <= num2; i++) {
        sum += i;
    }
    console.log(sum);
}

//7.	Day of Week
function dayOfWeek(input) {
    let cases = {
        'Monday': 1,
        'Tuesday': 2,
        'Wednesday': 3,
        'Thursday': 4,
        'Friday': 5,
        'Saturday': 6,
        'Sunday': 7,
    }
    console.log(cases[input] == undefined ? 'error' : cases[input]);
}

//8.	Days in a month
function daysInAMonth(month, year) {
    console.log(new Date(year, month, 0).getDate());
}

//9.	Square of Stars
function squareOfStars(size) {
    if (size == undefined) {
        size = 5;
    }
    for (let row = 0; row < size; row++) {
        for (let col = 0; col < size; col++) {
            process.stdout.write('* ');
        }
        console.log();
    }
}

//10.	Aggregate Elements
function aggregateElements(arr) {
    let sum = 0;
    let sum2 = 0;
    let concat = '';

    for (let i = 0; i < arr.length; i++) {
        const currItem = arr[i];
        sum += currItem;
        sum2 += 1 / currItem;
        concat += currItem;
    }

    console.log(sum);
    console.log(sum2);
    console.log(concat);
}

//Test functions
aggregateElements([2, 4, 8, 16]);