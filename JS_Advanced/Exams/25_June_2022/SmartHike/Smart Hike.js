class SmartHike {
    constructor(username) {
        this.username = username;
        this.goals = {};
        this.listOfHikes = [];
        this.resources = 100;
    }

    addGoal(peak, altitude) {
        if (this.goals[peak] != undefined) {
            return `${peak} has already been added to your goals`;
        }

        this.goals[peak] = altitude;
        return `You have successfully added a new goal - ${peak}`;
    };

    hike(peak, time, difficultyLevel) {
        if (this.goals[peak] === undefined) {
            throw new Error(`${peak} is not in your current goals`);
        }
        if (this.resources === 0) {
            throw new Error("You don't have enough resources to start the hike");
        }

        const resourcesAfterHike = this.resources - (time * 10);

        if (resourcesAfterHike < 0) {
            return "You don't have enough resources to complete the hike";
        }

        this.listOfHikes.push({ peak, time, difficultyLevel });
        this.resources = resourcesAfterHike;

        return `You hiked ${peak} peak for ${time} hours and you have ${resourcesAfterHike}% resources left`;
    };

    rest(time) {
        this.resources += time * 10;
        if (this.resources > 100) {
            this.resources = 100;
            return `Your resources are fully recharged. Time for hiking!`;
        }

        return `You have rested for ${time} hours and gained ${time * 10}% resources`;
    };

    showRecord(criteria) {
        if (this.listOfHikes.length === 0) {
            return `${this.username} has not done any hiking yet`
        }

        if (criteria === 'all') {
            let result = 'All hiking records:';
            this.listOfHikes.forEach(hike => result += `\n${this.username} hiked ${hike.peak} for ${hike.time} hours`);
            return result;
        }

        const bestHike = this.listOfHikes.filter(x => x.difficultyLevel === criteria).sort((a, b) => a.time - b.time)[0];

        if (bestHike === undefined) {
            return `${this.username} has not done any ${criteria} hiking yet`
        }

        return `${this.username}'s best ${criteria} hike is ${bestHike.peak} peak, for ${bestHike.time} hours`
    }
}