class SummerCamp{
    constructor(organizer , location) {
    this.organizer = organizer;
    this.location = location;
    this.priceForTheCamp = {"child": 150, "student": 300, "collegian": 500};
    this.listOfParticipants = [];
    }
    registerParticipant (name, condition, money) {
        let price = 0;
        if (condition !== 'child' && condition !== 'student' && condition !== "collegian") {
            throw new Error('Unsuccessful registration at the camp.');
        }
        let NameTest = this.listOfParticipants.find(x => x.name === name)
        if(NameTest !== undefined){
            return (`The ${name} is already registered at the camp.`)
        }
        if(condition === 'child'){
            price = this.priceForTheCamp.child;
        }
        else if(condition === 'student'){
            price = this.priceForTheCamp.student;
        }
        else if(condition === 'collegian'){
            price = this.priceForTheCamp.collegian;
        }
        if (money < price){
            return `The money is not enough to pay the stay at the camp.`;
        }
        this.listOfParticipants.push({name, condition, power: 100, wins: 0});
        return `The ${name} was successfully registered.`;
    }
    unregisterParticipant (name){
        let removedPerson = this.listOfParticipants.find(x=>x.name === name);
        if(removedPerson === undefined){
            throw new Error(`The ${name} is not registered in the camp.`);
        }
        this.listOfParticipants.splice(this.listOfParticipants.indexOf(removedPerson));
        return `The ${name} removed successfully.`;
    }
    timeToPlay (typeOfGame, participant1, participant2){
        if(typeOfGame === `WaterBalloonFights`){
            let firstParticipant = this.listOfParticipants.find(x=>x.name === participant1);
            let secondParticipant = this.listOfParticipants.find(x=>x.name === participant2);
            if (firstParticipant === undefined || secondParticipant === undefined){
                throw new Error(`Invalid entered name/s.`);
            }
            if (firstParticipant.condition !== secondParticipant.condition){
            throw new Error(`Choose players with equal condition.`);
            }
            if (firstParticipant.power > secondParticipant.power){
                firstParticipant.wins++;
                return `The ${firstParticipant.name} is winner in the game ${typeOfGame}.`
            }
            else{
                secondParticipant.wins++;
                return `The ${secondParticipant.name} is winner in the game ${typeOfGame}.`
            }
        }
        else if(typeOfGame === 'Battleship'){
            let participant = this.listOfParticipants.find(x=>x.name === participant1);
            if (participant === undefined ){
                throw new Error(`Invalid entered name/s.`);
            }
            participant.power += 20;
            return `The ${participant.name} successfully completed the game ${typeOfGame}.`
        }
    }
    toString (){
        let output = `${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`
        let sorted = this.listOfParticipants.sort(x=>x.wins).reverse();
        for (const sortedElement of sorted) {
            output += `\n${sortedElement.name} - ${sortedElement.condition} - ${sortedElement.power} - ${sortedElement.wins}`;
        }
        return output;
    }
}
