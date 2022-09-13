function aggregateElements(numbers) {
    agg(numbers, 0, (a, b) => a + b);
    agg(numbers, 0, (a, b) => a + 1 / b);
    agg(numbers, '', (a, b) => a + b);


    function agg(arr, initVal, func) {
        let val = initVal;
        for (let i = 0; i < arr.length; i++)
            val = func(val, arr[i]);
        console.log(val);
    }
}
    aggregateElements([1, 2, 3]);