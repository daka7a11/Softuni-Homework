//1.	Print an Array with a Given Delimiter
function printArrayGivenDelimiter(arr, del) {
    console.log(arr.join(del));
}

//2.	Print Every N-th Element from an Array
function printEveryNElement(arr, n) {
    return arr.filter((item, index) => index % n == 0);
}

//3.	Add and Remove Elements
function addRemoveElemets(commands) {
    const arr = [];
    for (let i = 0; i < commands.length; i++) {
        if (commands[i] == 'add') {
            arr.push(i + 1);
        }
        else if (commands[i] == 'remove') {
            arr.pop();
        }
    }

    arr.length == 0 ? console.log('Empty') : console.log(arr.join('\n'));
}

//4.	Rotate Array
function rorateArray(arr, num) {
    const count = num >= arr.length ? num % arr.length : num;

    for (let i = 0; i < count; i++) {
        arr.unshift(arr.pop());
    }

    console.log(arr.join(' '));
}

//5.	Extract Increasing Subset from Array
function extractIncresingSubset(arr) {
    const result = [arr[0]];

    arr.reduce((prev, curr) => {
        if (curr >= result[result.length - 1]) result.push(curr)
    });

    return result;
}

//6.	List of Names
function listNames(arr) {
    let i = 1;
    arr.sort().forEach(x => {
        console.log(`${i++}.${x}`);
    });
}

//7.	Sorting Numbers
function sortingNumbers(arr) {
    const result = [];
    arr.sort((a, b) => a - b);
    for (let i = 0; i < arr.length / 2; i++) {
        result.push(arr[i]);
        result.push(arr[arr.length - 1 - i]);
    }

    if (arr.length % 2 != 0) arr.push(arr[arr.length / 2 + 1]);

    return result;
}

//8.	Sort an Array by 2 Criteria
function sortByTwoCriteria(arr) {
    return arr.sort((a, b) => a.length - b.length || a.localeCompare(b)).join('\n');
}

//9.	Magic Matrices
function magicMatrices(arr) {
    let isMagic = true;
    let firstSum = 0;
    for (let row = 0; row < arr.length; row++) {
        //Sum rows
        let currRowSum = 0;
        let currColSum = 0;
        for (let col = 0; col < arr[row].length; col++) {
            currRowSum += arr[row][col];
            currColSum += arr[col][row];
        }

        if(row == 0){
            firstSum = currRowSum;
        }

        if(firstSum != currRowSum || firstSum != currColSum){
            isMagic = false;
            break;
        }
    }

    console.log(isMagic);
}

//Test functions
magicMatrices([[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
   );