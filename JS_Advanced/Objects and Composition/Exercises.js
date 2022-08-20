//1.	City Record

function cityRecord(name, population, treasury) {
    class City {
        constructor(name, population, treasury) {
            this.name = name;
            this.population = population;
            this.treasury = treasury;
        }
    }
    return new City(name, population, treasury);
}

//2.	Town Population
function townPopulation(arr) {
    class Town {
        constructor(name, population) {
            this.name = name;
            this.population = population;
        }
    }

    const towns = [];

    arr.forEach(item => {
        const splitedItem = item.split("<->").map(x => x.trim());
        const townName = splitedItem[0];
        const townPopulation = Number(splitedItem[splitedItem.length - 1]);
        const town = towns.find(x => x.name === townName);
        if (town === undefined) {
            towns.push(new Town(townName, townPopulation));
            return;
        }
        town.population += townPopulation;
    });

    towns.forEach(item => console.log(`${item.name} : ${item.population}`));

}

//Test functions
townPopulation(['Istanbul <-> 100000',
'Honk Kong <-> 2100004',
'Jerusalem <-> 2352344',
'Mexico City <-> 23401925',
'Istanbul <-> 1000']
);