class Person{
    constructor(firstName , secondName , age , email) {
    this.firstName = firstName;
    this.lastName = secondName;
    this.age = age;
    this.email = email
    }
    toString(){
        return `${this.firstName} ${this.lastName} (age: ${this.age}, email: ${this.email})`;
    }
}
