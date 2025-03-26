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

