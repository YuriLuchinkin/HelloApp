var el = this.document.getElementById("content");

class User {
    name: string;
    age: number;
    constructor(_name: string, _age: number) {

        this.name = _name;
        this.age = _age;
    }
}
var tom: User = new User("Tom", 29);
el.innerHTML = "Name: " + tom.name + " age: " + tom.age;