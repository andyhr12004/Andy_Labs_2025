// JavaScript source code

function agregar() { //agrega nuevo elemento a la lista y toma el numero anterio y le suma 1
    const lista = document.getElementById('lista');
    // determinar el numero del elemento
    const elementoNumero = lista.children.length + 1;
    // crea una nueva lista de elementos
    const nuevoElemento = document.createElement('li');
    nuevoElemento.textContent = `Elemento${elementoNumero}`;
    // agrega nuevo elemento a la lista 
    lista.appendChild(nuevoElemento);
}

// funcion de cambiar color de fondo
function cambiarFondo() {
    const body = document.body;
    // se fija que color hay puesto y lo cambia por el otro, en este caso rojoo
    if (body.style.backgroundColor === 'red') {
        body.style.backgroundColor = 'white';
    } else {
        body.style.backgroundColor = 'red';
    }
}

// Funcion que elimina el ultimo elemento
function borrar() {
    const lista = document.getElementById('lista');
    // borra el ultimo espacio si este no está vacío
    if (lista.children.length > 0) {
        lista.removeChild(lista.lastElementChild);
    }
}