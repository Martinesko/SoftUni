function cookingByNumbers(par1,par2,par3,par4,par5,par6) {
    let number = Number(par1);
    const arr = [par2,par3,par4,par5,par6];
    for (let i = 0; i < arr.length; i++) {
        let command = arr[i]
        switch (command){
            case 'chop':
                number /= 2;
                break;
            case 'dice':
                number = Math.sqrt(number);
                break;
            case 'spice':
                number++;
                break;
            case 'bake':
                number *= 3;
                break;
            case 'fillet':
                number = number - number*0.2;
                break;
        }
        console.log(number);
    }
}
cookingByNumbers('9', 'dice', 'spice', 'chop', 'bake', 'fillet');