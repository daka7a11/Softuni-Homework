//1.	Even Position Element
function evenPositionElement(arr) {
    let result = "";
    arr.forEach((item, index) => {
        index % 2 == 0 ? result += `${item} ` : "";
    });
    console.log(result);
}

//2.	Last K Numbers Sequence
function lastKNumbersSeq(n, k) {
    let result = [1];
    for (let i = 1; i < n; i++) {
        let arrSum = 0;

        for (let j = result.length - 1; j >= result.length - k; j--) {
            if (j < 0) {
                break;
            }
            arrSum += result[j];
        }

        result.push(arrSum);
    }
    return result;
}

//3.	Sum First Last
function sumFirstLast(arr) {
    return Number(arr[0]) + Number(arr[arr.length - 1]);
}

//4.	Negative / Positive Numbers
function negativePositiveNums(arr) {
    const result = [];
    arr.forEach(element => {
        if (element < 0) {
            result.unshift(element);
        }
        else {
            result.push(element);
        }
    });

    console.log(result.join('\n'));
}

//5.	Smallest Two Numbers
function smallestTwoNums(arr) {
    arr = arr.sort((a, b) => a - b);
    console.log(arr[0], arr[1]);
}

//6.	Bigger Half
function biggerHalf(arr) {
    arr = arr.sort((a, b) => a - b);
    return arr.slice(arr.length / 2, arr.length);
}

//7.	Piece of Pie
function pieceOfPie(arr, flav1, flav2) {
    const startIndex = arr.indexOf(flav1);
    const endIndex = arr.indexOf(flav2);

    return arr.slice(startIndex, endIndex + 1);
}

//8.	Process Odd Positions
function processOddPos(arr) {
    // const arr2 = arr.filter((item,index) => index%2 != 0);
    // const arr3 = arr2.map(item => item*2);
    // const arr4 = arr3.reverse();
    const result = arr.filter((item, index) => index % 2 != 0).map(item => item * 2).reverse();

    console.log(result.join(' '));
}

//9.	Biggest Element
function biggestElement(arr) {
    let biggestElement = arr[0][0];
    arr.forEach(currArr => {
        currArr.forEach(item => {
            if (item > biggestElement) {
                biggestElement = item;
            }
        })
    })
    return biggestElement;
}

//10.	Diagonal Sums
function diagonalSums(arr) {
    let firstDiagonal = 0;
    let secondDiagonal = 0;

    for (let i = 0; i < arr.length; i++) {
        firstDiagonal += arr[i][i];
        secondDiagonal += arr[arr.length - 1 - i][i];
    }

    console.log(firstDiagonal, secondDiagonal);
}

//11.	Equal Neighbors
function equalNeighbors(arr) {
    let count = 0;
    for (let row = 0; row < arr.length; row++) {
        for (let col = 0; col < arr[row].length; col++) {
            const currElement = arr[row][col];
            //UP
            if (row - 1 >= 0 && row - 1 < arr.length
                && col >= 0 && col < arr[row].length) {

                const upElement = arr[row - 1][col];
                if (currElement == upElement) {
                    count++;
                }
            }

            //Right
            if (row >= 0 && row < arr.length
                && col + 1 >= 0 && col + 1 < arr[row].length) {

                const rightElement = arr[row][col + 1];
                if (currElement == rightElement) {
                    count++;
                }
            }

            //Down
            if (row + 1 >= 0 && row + 1 < arr.length
                && col >= 0 && col < arr[row].length) {

                const downElement = arr[row + 1][col];
                if (currElement == downElement) {
                    count++;
                }
            }

            //Left
            if (row >= 0 && row < arr.length
                && col - 1 >= 0 && col - 1 < arr[row].length) {

                const leftElement = arr[row][col - 1];
                if (currElement == leftElement) {
                    count++;
                }
            }
        }
    }
    return count / 2;
}

//Test functions
console.log(equalNeighbors([['test', 'yes', 'yo', 'ho'],
['well', 'done', 'yo', '6'],
['not', 'done', 'yet', '5']]
));