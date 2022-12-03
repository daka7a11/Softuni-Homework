//1.	Array Extension - IIFE
(function arrayExtension() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }
    Array.prototype.skip = function (n) {
        const newArr = [];
        for (let i = n; i < this.length; i++) {
            newArr.push(this[i]);
        }
        return newArr;
    }
    Array.prototype.take = function (n) {
        const newArr = [];
        for (let i = 0; i < n; i++) {
            newArr.push(this[i]);
        }
        return newArr;
    }
    Array.prototype.sum = function () {
        return this.reduce((acc, curr) => {
            acc += curr;
            return acc;
        }, 0);
    }
    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
})();

//2. String Extension
(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        return this.startsWith(str) ? this.toString()
            : str + this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        return this.endsWith(str) ? this.toString()
            : this.toString() + str;
    };

    String.prototype.isEmpty = function () {
        return this.toString() === '' ? true : false;
    };

    String.prototype.truncate = function (n) {
        const currString = this.toString();

        if (currString.length < n) {
            return currString;
        }

        let result = '';
        for (let i = n - 1; i >= 0; i--) {
            if (currString[i] === ' ') {
                result = currString.slice(0, i) + '...';
                return result;
            }
        }

        if (n < 4) {
            for (let i = 0; i < n; i++) {
                result += '.';
            }
        }
        else {
            result = currString.slice(0, n - 3) + '...';
        }

        return result;
    };

    String.format = function (str, ...params) {
        const words = str.split(' ');
        const pHoldersWithIndex = {};


        for (let i = 0; i < words.length; i++) {
            const currWord = words[i];
            if (currWord[0] === '{' && currWord[2] === '}') {
                const pHolder = Number(currWord[1]);
                pHoldersWithIndex[pHolder] = i;
            }
        }

        for (let i = 0; i < params.length; i++) {
            const indexToReplace = pHoldersWithIndex[i];
            words[indexToReplace] = params[i];
        }

        return words.join(' ');
    }
})();

//3. Extensible Object
function extensibleObject() {
    const obj = {};
    const protoObj = Object.getPrototypeOf(obj);

    obj.extend = function (temp) {
        const propNames = Object.getOwnPropertyNames(temp);

        propNames.forEach(propName => {
            if (typeof (temp[propName]) === 'function') {
                protoObj[propName] = temp[propName];
            }
            else {
                obj[propName] = temp[propName];
            }
        });
    };

    return obj;
};

//4. Balloons
function balloons() {
    class Balloon {
        constructor(color, weight) {
            this.color = color;
            this.hasWeight = weight;
        }
    }

    class PartyBalloon extends Balloon {
        _ribbon = {
            color: null,
            length: null
        }

        constructor(color, weight, ribbonColor, ribbonLenght) {
            super(color, weight);
            this._ribbon.color = ribbonColor;
            this._ribbon.length = ribbonLenght;
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, weight, ribbonColor, ribbonLenght, text) {
            super(color, weight, ribbonColor, ribbonLenght);
            this.text = text;
        }
    }

    return {
        Balloon: Balloon,
        PartyBalloon: PartyBalloon,
        BirthdayBalloon: BirthdayBalloon
    }
}

//5. People
function people() {
    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
            this.currTaskIndex = 0;
        }

        work() {
            console.log(this.tasks[this.currTaskIndex]);
            this.currTaskIndex++;
            if (this.currTaskIndex > this.tasks.length - 1) {
                this.currTaskIndex = 0;
            }
        }
        collectSalary() {
            console.log(`${this.name} received ${this.salary + (this.dividend === undefined ? 0 : this.dividend)} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a simple task.`);
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} is working on a complicated task.`);
            this.tasks.push(`${this.name} is taking time off work.`);
            this.tasks.push(`${this.name} is supervising junior workers.`);
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.tasks.push(`${this.name} scheduled a meeting.`);
            this.tasks.push(`${this.name} is preparing a quarterly report.`);
            this.dividend = 0;
        }
    }

    return {
        Employee: Employee,
        Junior: Junior,
        Senior: Senior,
        Manager: Manager
    }
}

//6. Posts
function posts() {
    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`;
        }
    }
    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.comments = [];
        }
        addComment(comment) {
            this.comments.push(comment);
        }

        toString() {
            let result = super.toString();
            result += `\nRating: ${this.likes - this.dislikes}`;
            if (this.comments.length != 0) {
                result += '\nComments:'
                this.comments.forEach(c => {
                    result += `\n * ${c}`;
                });
            }
            return result;
        }
    }
    class BlogPost extends Post {
        constructor(title, content) {
            super(title, content);
            this.views = 0;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return super.toString() + `\nViews: ${this.views}`;
        }
    }

    return {
        Post: Post,
        SocialMediaPost: SocialMediaPost,
        BlogPost: BlogPost
    }
}

//7. Computer *
function computer() {
    class Product {
        constructor(manufacturer) {
            this.manufacturer = manufacturer;
            checkIfAbstractClass(this.constructor);
        }
    }
    class Keyboard extends Product {
        constructor(manufacturer, responseTime) {
            super(manufacturer);
            this.responseTime = responseTime;
        }
    }
    class Monitor extends Product {
        constructor(manufacturer, width, height) {
            super(manufacturer);
            this.width = width;
            this.height = height;
        }
    }
    class Battery extends Product {
        constructor(manufacturer, expectedLife) {
            super(manufacturer);
            this.expectedLife = expectedLife;
        }
    }
    class Computer extends Product { //ABSTRACT!!!
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
            super(manufacturer);

            this.processorSpeed = processorSpeed;
            this.ram = ram;
            this.hardDiskSpace = hardDiskSpace;
        }
    }
    class Laptop extends Computer {
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace,
            weight, color, battery) {
            super(manufacturer, processorSpeed, ram, hardDiskSpace);
            this.weight = weight;
            this.color = color;
            this.battery = battery;
        }

        _battery;

        set battery(newValue) {
            if (newValue.constructor.name.toLowerCase() === Object.keys({battery})[0]) {
                this._battery = newValue;
            }
            else {
                throw new TypeError(`Passed value is not ${Object.keys({battery})[0]} class!`);
            }
        }

        get battery() {
            return this._battery;
        }
    }
    class Desktop extends Computer{
        _keyboard;
        _monitor;
        constructor(manufacturer, processorSpeed, ram, hardDiskSpace,
            keyboard, monitor) {
                super(manufacturer,processorSpeed,ram,hardDiskSpace);
                this.keyboard = keyboard;
                this.monitor = monitor;
        }

        set keyboard(newValue){
            if (newValue.constructor.name.toLowerCase() === Object.keys({keyboard})[0]) {
                this._keyboard = newValue;
            }
            else {
                throw new TypeError(`Passed value is not ${Object.keys({keyboard})[0]} class!`);
            }
        }
        get keyboard(){
            return this._keyboard;
        }

        set monitor(newValue){
            if (newValue.constructor.name.toLowerCase() === Object.keys({monitor})[0]) {
                this._monitor = newValue;
            }
            else {
                throw new TypeError(`Passed value is not ${Object.keys({monitor})[0]} class!`);
            }
        }
        get monitor(){
            return this._monitor;
        }
    }

    function checkIfAbstractClass(constructor) {
        if (constructor.name === 'Product' || constructor.name === 'Computer') {
            throw new Error('Abstract class can\'t be instantiated');
        }
    }

    return {
        Product: Product,
        Keyboard: Keyboard,
        Monitor: Monitor,
        Battery: Battery,
        Computer: Computer,
        Laptop: Laptop,
        Desktop: Desktop
    }
}

let classes = computer();
let Computer = classes.Computer;
let Laptop = classes.Laptop;
let Desktop = classes.Desktop;
let Monitor = classes.Monitor;
let Battery = classes.Battery;
let Keyboard = classes.Keyboard;

let keyboard = new Keyboard('Logitech',70);
let monitor = new Monitor('Benq',28,18);
let desktop = new Desktop("JAR Computers",3.3,8,1,keyboard,monitor);
console.log(desktop);