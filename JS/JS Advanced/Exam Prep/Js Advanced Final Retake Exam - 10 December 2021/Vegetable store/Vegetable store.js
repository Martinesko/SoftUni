class VegetableStore{
    constructor(owner , location) {
        this.owner = owner;
        this.location = location;
        this.availableProducts = [];
    }
    loadingVegetables (vegetables){
        for (const vegetable of vegetables) {
            let vegeArray = vegetable.split(' ');
            let isInside = false;
            let type = vegeArray[0];
            let quantity = vegeArray[1];
            let price = vegeArray[2];
            let _vegetable = this.availableProducts.find(x=>x.type === type);
            if (_vegetable === undefined){
            this.availableProducts.push({ type : type , quantity : Number(quantity) , price : Number(price) } );
            }
            else{
                _vegetable.quantity += Number(quantity);
            }
        }
        return `Successfully added ${vegArray.join(', ')}`;
    }
}
let vegStore = new VegetableStore("Jerrie Munro", "1463 Pette Kyosheta, Sofia");
console.log(vegStore.loadingVegetables(["Okra 2.5 3.5", "Beans 10 2.8", "Celery 5.5 2.2", "Celery 0.5 2.5"]));
