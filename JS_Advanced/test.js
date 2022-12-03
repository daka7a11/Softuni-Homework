class Person{
  constructor(name,age){
    this.name = name;
    this.age = age;
  }
  toString(){
    return `${this.name} ${this.age}`;
  }
}

class Student extends Person{
  constructor(name,age,course){
    super(name,age);
    this.course = course;
  }
}

const p = new Person('asan', 12);
const s = new Student('asan', 12,'A');

s.toString();