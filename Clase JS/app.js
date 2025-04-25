function saludar(queDice){
    return function(name){
       console.log(queDice + " "+ name);

    };
}
var saluda2 = saludar("hola");
saluda2("Andy");
