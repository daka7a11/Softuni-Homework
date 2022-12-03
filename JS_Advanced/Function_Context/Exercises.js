//2.Add
function add(initNum) {
    const number = initNum;

    function sol(numToAdd) {
        return number + numToAdd;
    }

    return sol;
}

//4.Filter Employees
function filterEmployees(dataAsJSON, criteria) {
    const dataAsObjects = JSON.parse(dataAsJSON);
    const splitedCriteria = criteria.split('-');
    const criteriaName = splitedCriteria[0];
    const criteriaValue = splitedCriteria[1];

    const matchedElements = dataAsObjects.filter(x => x[criteriaName] === criteriaValue);

    matchedElements.forEach((x, i) => console.log(`${i}. ${x.first_name} ${x.last_name} - ${x.email}`));
}

//5.Command Processor
function commandProcessor() {
    let result = "";

    const commands = {
        append,
        removeStart,
        removeEnd,
        print
    };

    function append(input) {
        result += input;
    }
    function removeStart(n) {
        result = result.slice(n);
    }
    function removeEnd(n) {
        result = result.slice(0, result.length - n);
    }
    function print() {
        console.log(result);
    }

    return commands;
}

//6.List Processor
function listProcessor(input) {
    let items = [];

    let processObj = {
        add,
        remove,
        print,
    }

    function add(str) {
        items.push(str);
    }
    function remove(str) {
        const itemIndex = items.findIndex(x => x === str);
        items.splice(itemIndex, 1);
    }
    function print() {
        console.log(items.join(','));
    }

    function iterateInput() {
        input.forEach(x => {
            const objMethods = Object.getOwnPropertyNames(processObj);

            const splitedX = x.split(' ');
            const operation = splitedX[0]

            if (!(objMethods.some(m => m === operation))) {
                return;
            }

            if (splitedX.length === 2) {
                const str = splitedX[1];
                processObj[operation](str);
            }
            else if (splitedX.length === 1) {
                processObj[operation]();
            }
        });
    }

    iterateInput();

    return iterateInput;
}

//7.Cars 
function cars(input) {
    class Car {
        constructor(name) {
            this.name = name;
            this.parent = null;
        }
    }
    const cars = [];

    const commandObj = {
        create,
        set,
        print,
    }

    function create(args) {
        const name = args[0];
        const inheritName = args[2];

        const newCar = new Car(name);
        if (inheritName != undefined) {
            const parent = cars.find(x => x.name === inheritName);
            newCar.parent = parent;
        }
        cars.push(newCar);
    }
    function set(args) {
        const name = args[0];
        const prop = args[1];
        const value = args[2];
        const car = cars.find(x => x.name === name);

        car[prop] = value;
    }
    function print(args) {
        const name = args[0];
        const car = cars.find(x => x.name === name);

        let propertiesAndValues = [];

        getPropertiesAndValues(car);

        propertiesAndValues = propertiesAndValues.filter(x => x.prop != 'name').filter(x => x.prop != 'parent');

        let result = '';
        propertiesAndValues.forEach((x, i) => {
            result += i == propertiesAndValues.length - 1 ? `${x.prop}:${x.value}` : `${x.prop}:${x.value},`;
        });

        console.log(result);

        function getPropertiesAndValues(car) {
            const propNames = Object.getOwnPropertyNames(car);
            propNames.forEach(prop => {
                const value = car[prop];

                if (!propertiesAndValues.some(x => x.prop === prop)) {
                    propertiesAndValues.push({ prop, value });
                }

            });

            if (car.parent == null) {
                return;
            }

            getPropertiesAndValues(car.parent);
        }
    }

    function iterateInput() {
        input.forEach(inputCommand => {
            const splitedInput = inputCommand.split(' ');
            const cmd = splitedInput[0];
            commandObj[cmd](splitedInput.slice(1));
        })
    }

    iterateInput();

    return iterateInput;
}

cars(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']
);