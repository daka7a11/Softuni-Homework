//1.	Person
{
    class Person {
        constructor(fName, lName) {
            this.firstName = fName;
            this.lastName = lName;
        }
        get fullName() {
            return `${this.firstName} ${this.lastName}`;
        }
        set fullName(fName) {
            const [firstName, lastName] = fName.split(' ');
            if (firstName === undefined || lastName === undefined) {
                return;
            }

            this.firstName = firstName;
            this.lastName = lastName;
        }
    }
}

//2.    Person and Teacher
function personAndTeacher() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }
    }

    return {
        Person,
        Teacher
    }
}

//3.	Inheriting and Replacing ToString
function inheritingAndReplacingToString() {
    class Person {
        constructor(name, email) {
            this.name = name;
            this.email = email;
        }

        toString() {
            const className = this.constructor.name;
            return `${className} (name: ${this.name}, email: ${this.email}${className === 'Person' ? ')' : ''}`;
        }
    }

    class Student extends Person {
        constructor(name, email, course) {
            super(name, email);
            this.course = course;
        }

        toString() {
            return `${super.toString()}, course: ${this.course})`
        }
    }

    class Teacher extends Person {
        constructor(name, email, subject) {
            super(name, email);
            this.subject = subject;
        }

        toString() {
            return `${super.toString()}, subject: ${this.subject})`
        }
    }

    return {
        Person,
        Student,
        Teacher
    }
}

//4.	Extend Prototype
function extendPrototype(classToExtend) {
    classToExtend.prototype.species = 'Human';
    classToExtend.prototype.toSpeciesString = function () {
        return `I am a ${this.species}. ${this.toString()}`;
    }
}


class Person {
    constructor(name, email) {
        this.name = name;
        this.email = email;
    }

    toString() {
        const className = this.constructor.name;
        return `${className} (name: ${this.name}, email: ${this.email}${className === 'Person' ? ')' : ''}`;
    }
}

//5.	Class Hierarchy - METHOD 1
// function classHierarchy() {
//     const mmTransferTo = {
//         'mm': function (val) { return val },
//         'cm': function (val) { return val / 10 },
//         'm': function (val) { return val / 1000 },
//         undefined: function(val){return val}
//     }
//     const cmTransferTo = {
//         'mm': function (val) { return val * 10},
//         'cm': function (val) { return val },
//         'm': function (val) { return val / 1000 },
//         undefined: function(val){return val}
//     }
//     const mTransferTo = {
//         'mm': function (val) { return val * 1000 },
//         'cm': function (val) { return val * 10 },
//         'm': function (val) { return val },
//         undefined: function(val){return val}
//     }

//     class Figure {
//         constructor(units = 'cm') {
//             this.units = units;
//         }

//         get area() {
//             return Error('Not implemented!');
//         }

//         changeUnits(newUnits = 'cm') {
//             this.changePropsToUnits(this,newUnits);
//             this.units = newUnits;
//         }

//         toString() {
//             return `Figures units: ${this.units}`;
//         }

//         changePropsToUnits(obj, newUnits) {
//             const objKeys = Object.keys(obj).filter(x => x != 'units');

//             if(this.units === 'm'){
//                 objKeys.forEach(key => {
//                     obj[key] = mTransferTo[newUnits](obj[key]);
//                 });
//             }
//             else if(this.units ==='cm'){
//                 objKeys.forEach(key => {
//                     obj[key] = cmTransferTo[newUnits](obj[key]);
//                 });
//             }
//             else {
//                 objKeys.forEach(key => {
//                     obj[key] = mmTransferTo[newUnits](obj[key]);
//                 });
//             }
//         }
//     }

//     class Circle extends Figure {
//         constructor(radius, units) {
//             super(units);
//             this.radius = radius;
//             this.units = 'cm';
//             this.changeUnits(units);
//         }

//         get area() {
//             return Math.PI * (this.radius * this.radius);
//         }

//         toString() {
//             return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`
//         }
//     }

//     class Rectangle extends Figure {
//         constructor(width, height, units) {
//             super(units);
//             this.width = width;
//             this.height = height;
//             this.units = 'cm';
//             this.changeUnits(units);
//         }

//         get area() {
//             return this.width * this.height;
//         }

//         toString() {
//             return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
//         }
//     }

//     return {
//         Figure,
//         Circle,
//         Rectangle
//     }
// }
//5.	Class Hierarchy - METHOD 2
function classHierarchy() {
    class Figure {
        constructor(units = 'cm') {
            this.units = units;
        }

        get area() {
            return Error('Not implemented!');
        }

        changeUnits(newUnits = 'cm') {
            this.units = newUnits;
        }

        toString() {
            return `Figures units: ${this.units}`;
        }

        tranformValToUnits(val){
            return this.units === 'm' ? val / 100 
            : this.units === 'mm' ? val * 10 
            : val;
        }
    }

    class Circle extends Figure {
        constructor(radius, units) {
            super(units);
            this.radius = radius;
        }

        _radius = null;

        set radius(newVal){
            this._radius = newVal;
        }

        get radius(){
            return this.tranformValToUnits(this._radius);
        }

        get area() {
            return Math.PI * (this.radius * this.radius);
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`
        }
    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super(units);
            this.width = width;
            this.height = height;
        }

        _width = null;
        _height = null;

        set width(newVal){
            this._width = newVal;
        }

        get width(){
            return this.tranformValToUnits(this._width);
        }

        set height(newVal){
            this._height = newVal;
        }

        get height(){
            return this.tranformValToUnits(this._height);
        }

        get area() {
            return this.width * this.height;
        }

        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`;
        }
    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

classHierarchy();