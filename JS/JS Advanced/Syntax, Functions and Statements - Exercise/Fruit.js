function fruit(name,grams,money) {
    let kg = grams/1000
console.log(`I need $${(money*kg).toFixed(2)} to buy ${kg.toFixed(2)} kilograms ${name}.`)
}
fruit('orange' ,2500, 1.80)