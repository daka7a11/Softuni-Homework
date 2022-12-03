//1.	Person
function Person(firstName, lastName, age, email){
    return {
        firstName,
        lastName,
        age,
        email,
        toString() {
            return `${firstName} ${lastName} (age: ${age}, email: ${email})`;
        }
    }
}

//2.	Get Persons
function Person(firstName, lastName, age, email){
    return {
        firstName,
        lastName,
        age,
        email,
        toString() {
            return `${firstName} ${lastName} (age: ${age}, email: ${email})`;
        }
    }
}

function getPersons(){

    class Person{
        constructor(firstName, lastName, age, email){
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.email = email;
        }

        toString(){
            return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
        }
    };

    const persons = [];
    persons.push(new Person('Anna', 'Simpson', 22, 'anna@yahoo.com'));
    persons.push(new Person('SoftUni'));
    persons.push(new Person('Stephan', 'Johnson', 25,));
    persons.push(new Person('Gabriel', 'Peterson', 24, 'g.p@gmail.com'));

    return persons;
};


//3.	Circle
class Circle{
    constructor(radius){
        this.radius = radius;
    }

    get diameter(){
        return this.radius * 2;
    }
    set diameter(d){
        this.radius = d / 2;
    }

    get area(){
        return Math.PI * (this.radius*this.radius);
    }

}

//4.	Point Distance
class Point{
    constructor(x,y){
        this.x = x;
        this.y = y;
    }
    static distance(a,b){
        return Math.sqrt(Math.pow((a.x - b.x),2) + Math.pow((a.y - b.y),2));
    }
}

//Test
let p1 = new Point(5, 5);
let p2 = new Point(9, 8);
console.log(Point.distance(p1, p2));

