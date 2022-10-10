const {sum} = require("../index.js");
const {expect} = require('chai');
describe('sum', () => {

    it('should return correct result with array of numbers', () =>{

        let array = [1,2,3];
        let result = sum(array);
        expect(result).to.be.equal(6);

    });
    it('nonumber',()=>{
        let array = [1 , '2', true];
        let result = sum(array);
        expect(result).to.be.equal(4);
    })
    it('should', function () {

        let array = '1';
        let result = sum(array);

        expect(result).to.be.equal(1);
    });
})