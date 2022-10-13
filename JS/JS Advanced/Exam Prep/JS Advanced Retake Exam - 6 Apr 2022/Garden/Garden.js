class Garden{
    constructor(spaceAvailable) {
        this.spaceAvailable = spaceAvailable;
        this.plants =  [];
        this.storage =  [];
    }

    addPlant (plantName, spaceRequired){
        if (Number(this.spaceAvailable) < Number(spaceRequired)){
            throw new Error("Not enough space in the garden.")
        }
        this.plants.push(new Plant(plantName,spaceRequired));
        this.spaceAvailable -= spaceRequired;
        return `The ${plantName} has been successfully planted in the garden.`;
    }

    ripenPlant (plantName, quantity){
     let plant = this.plants.find(x=>x.PlantName === plantName);
    if (quantity < 0){
throw new Error("The quantity cannot be zero or negative.");
    }
    if (plant === undefined){
        throw new Error(`There is no ${plantName} in the garden.`);
    }
    if (plant.IsRipe === true){
        throw new Error(`The ${plantName} is already ripe.`);
    }
    if (quantity > 1){
        plant.Quantity -= quantity;
        if (plant.Quantity<=0){
            plant.Quantity = 0;
            plant.IsRipe = true;
        }

        return `${quantity} ${plantName}s have successfully ripened.`
    }
    if(quantity === 1){
        plant.Quantity -= quantity;
        if (plant.Quantity<=0){
            plant.Quantity = 0;
            plant.IsRipe = true;
        }
        return `${quantity} ${plantName} has successfully ripened.`
    }
    }

    harvestPlant(plantName){
        let plant = this.plants.find(x=>x.PlantName === plantName);
        if (plant === undefined){
            throw new Error(`There is no ${plantName} in the garden.`);
        }
        if (plant.IsRipe === false){
            throw new Error(`The ${plantName} cannot be harvested before it is ripe.`)
        }
        let indexRemove = this.plants.indexOf(plant);
        this.plants.slice(indexRemove , 1);
        if (!this.storage.contain)
        this.spaceAvailable += plant.SpaceRequired;
        return `The ${plantName} has been successfully harvested.`;
    }

    generateReport(){
        let plantsNames = [];
        let storageNames = [];
        for (const plant of this.plants) {
            plantsNames.push(plant.PlantName);
        }
        for (const plant of this.storage) {
            let storage = `${plant.PlantName} (${plant.Quantity})`
            storageNames.push(storage);
        }
        let output = `The garden has ${this.spaceAvailable} free space left.\nPlants in the garden:${plantsNames.join(', ')}\n`;
        if (this.storage === 0){
            output += `Plants in storage: The storage is empty.`;
        }
        else{
            output+= `Plants in storage: ${storageNames.join(', ')}`
        }
       return output;
    }

}
class Plant{
    constructor(plantName,spaceRequired) {
        this.PlantName = plantName;
        this.SpaceRequired = spaceRequired;
        this.IsRipe = false;
        this.Quantity = 0;
    }
}

const myGarden = new Garden(250)
console.log(myGarden.addPlant('apple', 20));
console.log(myGarden.addPlant('orange', 200));
console.log(myGarden.addPlant('raspberry', 10));
console.log(myGarden.ripenPlant('apple', 10));
console.log(myGarden.ripenPlant('orange', 1));
console.log(myGarden.harvestPlant('orange'));
console.log(myGarden.generateReport());
