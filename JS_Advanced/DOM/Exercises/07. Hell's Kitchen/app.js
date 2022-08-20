function solve() {
   document.querySelector('#btnSend').addEventListener('click', onClick);

   class Employee {
      constructor(name, salary) {
         this.name = name;
         this.salary = salary;
      }
   }

   class Restaurant {
      constructor(name, employees) {
         this.name = name;
         this.employees = employees;
      }

      getAverageSalary() {
         let totalSalary = 0;
         for (let i = 0; i < this.employees.length; i++) {
            totalSalary += this.employees[i].salary;
         }

         return totalSalary / this.employees.length;
      }

      getBestSalary() {
         const salaries = this.employees.map(x => x.salary);
         return Math.max(...salaries);
      }
   }

   function onClick() {
      const inputText = document.querySelector('#inputs textarea').value;
      const textForEachRestaurant = inputText.split('"').map(x => x.trim()).filter(x => x.length > 1);

      const restaurants = []

      for (let i = 0; i < textForEachRestaurant.length; i++) {
         const tokens = textForEachRestaurant[i].split(' - ');

         const restaurantName = tokens[0];
         const employeesText = tokens[1].split(', ');

         const employeeList = [];
         for (let j = 0; j < employeesText.length; j++) {
            const employeeTokens = employeesText[j].split(' ');
            const employeeName = employeeTokens[0];
            const employeeSalary = Number(employeeTokens[1]);

            const employee = new Employee(employeeName, employeeSalary);
            employeeList.push(employee);
         }

         let restaurant = restaurants.find(x => x.name == restaurantName);

         if (restaurant == undefined) {
            restaurant = new Restaurant(restaurantName, employeeList);
            restaurants.push(restaurant);
         }
         else{
            restaurant.employees.push(...employeeList);
         }

         
      }

      let bestRestaurant = null;
      for (let i = 0; i < restaurants.length; i++) {
         if (bestRestaurant == null) {
            bestRestaurant = restaurants[i]
            continue;
         }

         const currRestaurant = restaurants[i];
         if (currRestaurant.getAverageSalary() > bestRestaurant.getAverageSalary()) {
            bestRestaurant = currRestaurant;
         }
      }

      const outputBestRestP = document.querySelector('#bestRestaurant p');
      const outputEmployeesP = document.querySelector('#workers p');
      outputEmployeesP.innerHTML = "";

      outputBestRestP.innerHTML = `Name: ${bestRestaurant.name} Average Salary: ${bestRestaurant.getAverageSalary().toFixed(2)} Best Salary: ${bestRestaurant.getBestSalary().toFixed(2)}`;

      bestRestaurant.employees =  bestRestaurant.employees.sort((a,b) => b.salary - a.salary);

      for (let i = 0; i < bestRestaurant.employees.length; i++) {
         const employeeName = bestRestaurant.employees[i].name;
         const employeeSalary = bestRestaurant.employees[i].salary;

         outputEmployeesP.innerHTML.length > 0 
         ? outputEmployeesP.innerHTML += ` Name: ${employeeName} With Salary: ${employeeSalary}`
         : outputEmployeesP.innerHTML += `Name: ${employeeName} With Salary: ${employeeSalary}`;
      }
   }
}