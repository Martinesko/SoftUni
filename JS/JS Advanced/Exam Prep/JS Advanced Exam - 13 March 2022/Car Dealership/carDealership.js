class CarDealership {
constructor(name) {
this.name = name;
this.availableCars = [];
this.soldCars = [];
this.totalIncome = 0;
}
    addCar (model, horsepower, price, mileage){
        if (model === "" || horsepower < 0 || price < 0 || mileage < 0) {
            throw new Error("Invalid input!")
        }
        let car = {model,horsepower,price,mileage}
        this.availableCars.push(car);
        return `New car added: ${model} - ${horsepower} HP - ${mileage.toFixed(2)} km - ${price.toFixed(2)}$`
    }
    sellCar (model, desiredMileage){
    let foundCar = this.availableCars.find(x=>x.model === model)
        let price = 0;
        if (foundCar === undefined|| foundCar === ''||foundCar === null){
            throw new Error(`${model} was not found!`);
        }
        if (foundCar.mileage <= desiredMileage){
            price = foundCar.price;
        }
        else if (foundCar.mileage-desiredMileage <= 40000){
            price = foundCar.price*0.95;
        }
        else if (foundCar.mileage-desiredMileage > 40000){
            price = foundCar.price*0.90;
        }
        this.availableCars.splice(this.availableCars.indexOf(foundCar),1);

        this.soldCars.push({model:foundCar.model,horsepower: foundCar.horsepower , price : price});
        this.totalIncome += price;
        return `${model} was sold for ${price.toFixed(2)}$`
    }
    currentCar (){
        if (this.availableCars.length < 1) {
            return "There are no available cars"
        }
        let result = ["-Available cars:"]
        for (const car of this.availableCars) {
            result.push(`---${car.model} - ${car.horsepower} HP - ${car.mileage.toFixed(2)} km - ${car.price.toFixed(2)}$`)
        }
        return result.join(`\n`);
    }
    salesReport (criteria){
    let result = [`-${this.name} has a total income of ${this.totalIncome.toFixed(2)}$`];
        result.push(`-${this.soldCars.length} cars sold:`);
    if (criteria === 'horsepower'){
        let sortedCars = this.soldCars.sort((a, b) => b.horsepower - a.horsepower)
        for (const sortedCar of sortedCars) {
            result.push(`---${sortedCar.model} - ${sortedCar.horsepower} HP - ${sortedCar.price.toFixed(2)}$`)
        }
    }
   else if (criteria === 'model'){
        let sortedCars = this.soldCars.sort((a, b) => a.model.localeCompare(b.model))
        for (const sortedCar of sortedCars) {
            result.push(`---${sortedCar.model} - ${sortedCar.horsepower} HP - ${sortedCar.price.toFixed(2)}$`)
        }
    }
    else{
        throw new Error("Invalid criteria!");
    }
    return result.join(`\n`);
    }
}
