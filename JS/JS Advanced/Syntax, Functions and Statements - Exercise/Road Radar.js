function roadRadar(speed , area) {
    let limit = 0;
    switch (area) {
        case 'motorway':
            limit = 130;
            break;
            case 'interstate':
            limit = 90;
            break;
            case 'city':
            limit = 50;
            break;
            case 'residential':
            limit = 20;
            break;
    }
    if(limit >= speed) {
        console.log(`Driving ${speed} km/h in a ${limit} zone`)
    }
    else{
        let status = '';
        if(speed - 20 <= limit) {
            status = 'speeding';
        }
        else if(speed - 40 <= limit) {
            status = 'excessive speeding';
        }
        else {
            status = 'reckless driving';
        }
console.log(`The speed is ${Math.abs(limit-speed)} km/h faster than the allowed speed of ${limit} - ${status}`)
    }
}
roadRadar(21, 'residential')