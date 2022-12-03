//1.Sort Array
function sortArray(...args) {
    const arr = args[0];
    const sortOpt = args[1];

    if (sortOpt === 'asc') {
        return arr.sort((a, b) => a - b);
    }
    else if (sortOpt === 'desc') {
        return arr.sort((a, b) => b - a);
    }
}

//2.Argument Info
function argumentInfo(...args) {
    const argsInfo = [];

    for (let arg of args) {
        const argInfo = argsInfo.find(x => x.type === typeof (arg));

        console.log(`${typeof (arg)}: ${arg}`);

        if (argInfo === undefined) {
            argsInfo.push({
                type: typeof (arg),
                arguments: [arg]
            });
        }
        else {

            argInfo.arguments.push(arg);
        }
    }

    argsInfo.sort((a, b) => b.arguments.length - a.arguments.length)
        .forEach(x => console.log(`${x.type} = ${x.arguments.length}`));
}

//3.Fibonacci
function fibonacci() {
    let lastValue = 0;
    let currValue = 0;

    function fib() {
        const newValue = lastValue + currValue;
        lastValue = currValue;
        currValue = newValue;

        if (newValue === 0) {
            currValue = 1;
        }

        return currValue;
    }

    return fib;
}

//4.Breakfast Robot
function breakfastRobot() {
    const microelements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }
    const recipes = {
        apple:
        {
            carbohydrate: 1,
            flavour: 2,
            order: ['carbohydrate', 'flavour'],
        },
        lemonade:
        {
            carbohydrate: 10,
            flavour: 20,
            order: ['carbohydrate', 'flavour'],
        },
        burger:
        {
            carbohydrate: 5,
            fat: 7,
            flavour: 3,
            order: ['carbohydrate', 'fat', 'flavour'],
        },
        egg:
        {
            protein: 5,
            fat: 1,
            flavour: 1,
            order: ['protein', 'fat', 'flavour'],
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10,
            order: ['protein', 'carbohydrate', 'fat', 'flavour'],
        }
    }
    function restock(...args) {
        microelements[args[0]] += Number(args[1]);
        return 'Success';
    }
    function prepare(...args) {
        const recipe = Object.assign({}, recipes[args[0]]);

        for (let micEl of recipe['order']) {
            recipe[micEl] *= Number(args[1]);

            if (microelements[micEl] < recipe[micEl]) {
                return `Error: not enough ${micEl} in stock`;
            }
        }

        for (let micEl of recipe.order) {
            microelements[micEl] -= recipe[micEl];
        }

        return `Success`;

        console.log(recipe);
    }
    function report() {
        return `protein=${microelements.protein} carbohydrate=${microelements.carbohydrate} fat=${microelements.fat} flavour=${microelements.flavour}`;
    }

    const commands = {
        restock,
        prepare,
        report
    }

    function manager(input) {
        const temp = input.split(' ');

        return commands[temp[0]](temp[1], temp[2]);
    }

    return manager;
}

//5.Functional Sum
function functionalSum(a) {

    function innerFnc(b) {
        a += b;
        return innerFnc;
    }

    innerFnc.toString = () => a;

    return innerFnc;
}

//6.Monkey Patcher *
/*
post = {
  id: <id>,
  author: <author name>,
  content: <text>,
  upvotes: <number>,
  downvotes: <number>
}

*/
function monkeyPatcher(argument) {

    function upvote() {
        this.upvotes++;
    }
    function downvote() {
        this.downvotes++;
    }
    function score() {
        let upVotes = this.upvotes;
        let downVotes = this.downvotes;
        let balance = upVotes - downVotes;
        let totalVotes = upVotes + downVotes;

        if (totalVotes > 50) {
            const greaterValue = Math.ceil((Math.max(this.upvotes, this.downvotes)) * 0.25);
            upVotes += greaterValue;
            downVotes += greaterValue;
            totalVotes = upVotes + downVotes;
        }

        let rating = '';

        if (totalVotes < 10) {
            rating = 'new';
        }
        else if (balance < 0) {
            rating = 'unpopular';
        }
        else if (((upVotes * 100) / totalVotes) > 66) {
            rating = 'hot';
        }
        else if (balance >= 0 && totalVotes > 100) {
            rating = 'controversial';
        }

        return [upVotes, downVotes, balance, rating];
    }

    const commands = {
        upvote,
        downvote,
        score,
    }

    return commands[argument].call(this);
}