//Seccion Biologos ------------------------------------------------------------------------------------------------------------- 
const uri = 'api/biologo'

let biologos = []

const formAgregarBiologo = document.getElementById("formAgregarBiologo")

formAgregarBiologo.addEventListener("submit", (e) => {
    e.preventDefault();
    agregarBiologo();
})

function obtenerBiologos() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _displayItems(data))
        .catch(error => console.error('No se han podido obtener los elementos. ', error));
}

function agregarBiologo() {
    
}

function _displayItems(data) {
    const tBody = document.getElementById('mostrarBiologos')
    tBody
}
//-------------------------------------------------------------------------------------------------------------------------------