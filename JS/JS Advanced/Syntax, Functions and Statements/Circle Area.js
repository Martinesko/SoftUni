function CircleArea(radius){
    let type = typeof(radius);
    let result
    if(type === 'number'){
        result = Math.PI*(Math.pow(radius,2))
        console.log(result.toFixed(2));
    }

else{
    result = `We can not calculate the circle area, because we receive a ${type}.`
    console.log(result);
}
}
CircleArea(5);