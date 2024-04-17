//Seccion Escarabajos ------------------------------------------------------------------------------------------------------------- 
const uri = 'api/escarabajo'

//Obtener a los escarabajos
let escarabajos

async function fetchEscarabajos() {
    try {
        const response = await fetch(uri)
        const data = await response.json()
        escarabajos = data
    } catch (error) {
        console.error('No se puede obtener el array de escarabajos', error)
    }
}
fetchEscarabajos()

//carga los forms
const formAgregarEscarabajo = document.getElementById("formAgregarEscarabajo")
const formEditar = document.getElementById('editarForm')
const cerrarEditar = document.getElementById("cerrarModalEditar")
const cerrarAgregar = document.getElementById('cerrarModalAgregar')
const btnBorrarFormAgregar = document.getElementById('btnBorrarFormAgregar')
//      Se crean los eventos -------------------------------------------------------------------------------
formAgregarEscarabajo.addEventListener("submit", (e) => {
    e.preventDefault()
    agregarEscarabajo()
})

formEditar.addEventListener("submit", (e) => {
    e.preventDefault()
    actualizarEscarabajo()
})

cerrarEditar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById('editarForm').classList.remove('is-active')
})

cerrarAgregar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById('agregarEscarabajo').classList.remove('is-active')
    openModalMostrar()
})

btnBorrarFormAgregar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById("editarEspecie").value = ''
    document.getElementById("editarFamilia").value = ''
    document.getElementById("editarGenero").value = ''
    document.getElementById("editarPatas").value = ''
    document.getElementById("editarTorax").value = ''
    document.getElementById("editarCiclo_vida").value = ''
    document.getElementById("editarNombre_comun").value = ''
    document.getElementById("editarAntena").value = ''
    document.getElementById("editarOjos").value = ''
    document.getElementById("editarMandibula").value = ''
    document.getElementById("editarAlas").value = ''
    document.getElementById("editarElitros").value = ''
    document.getElementById("editarAudios").value = ''
    document.getElementById("editarImagenes").value = ''
})

//      Metodos para trabajar con la API
//          Obtener o GET
function obtenerEscarabajos() {
    fetch(uri)
    .then(response => response.json())
    .then(data => _mostrarEscarabajos(data))
    .catch(error => console.error('No se han podido obtener los elementos. ', error))
}

function _mostrarEscarabajos(data) {
    const tBody = document.getElementById('mostrarEscarabajos')
    tBody.innerHTML = ''

    _displayCount(data.length)

    const boton = document.createElement('button')

    data.forEach(item => {
        let btnEditar = boton.cloneNode(false)
        btnEditar.innerHTML = 'Editar'
        btnEditar.classList.add('button', 'is-small', 'is-warning', 'is-outlined', 'has-text-weight-bold');
        btnEditar.setAttribute('onClick', `mostrarFormEditar("${item.especie_escarabajo}")`)

        let btnEliminar = boton.cloneNode(false)
        btnEliminar.innerHTML = 'Eliminar'
        btnEliminar.classList.add('button', 'is-small', 'is-danger', 'is-outlined', 'has-text-weight-bold');
        btnEliminar.setAttribute('onClick', `eliminarEscarabajo("${item.especie_escarabajo}")`)

        let tr = tBody.insertRow()

        let td1 = tr.insertCell(0)
        let textNode = document.createTextNode(item.especie_escarabajo)
        td1.appendChild(textNode)

        let td2 = tr.insertCell(1)
        let textNode1 = document.createTextNode(item.familia_escarabajo)
        td2.appendChild(textNode1)

        let td3 = tr.insertCell(2)
        let textNode2 = document.createTextNode(item.genero_escarabajo)
        td3.appendChild(textNode2)

        let td4 = tr.insertCell(3)
        let textNode3 = document.createTextNode(item.patas_escarabajo)
        td4.appendChild(textNode3)

        let td5 = tr.insertCell(4)
        let textNode4 = document.createTextNode(item.torax_escarabajo)
        td5.appendChild(textNode4)

        let td6 = tr.insertCell(5)
        let textNode5 = document.createTextNode(item.ciclo_vida_escarabajo)
        td6.appendChild(textNode5)

        let td7 = tr.insertCell(6)
        let textNode6 = document.createTextNode(item.nombre_comun_escarabajo)
        td7.appendChild(textNode6)

        let td8 = tr.insertCell(7)
        let textNode7 = document.createTextNode(item.antena_escarabajo)
        td8.appendChild(textNode7)

        let td9 = tr.insertCell(8)
        let textNode8 = document.createTextNode(item.ojos_escarabajo)
        td9.appendChild(textNode8)

        let td10 = tr.insertCell(9)
        let textNode9 = document.createTextNode(item.mandibula_escarabajo)
         td10.appendChild(textNode9)

        let td11 = tr.insertCell(10)
        let textNode10 = document.createTextNode(item.alas_escarabajo)
        td11.appendChild(textNode10)

        let td12 = tr.insertCell(11)
        let textNode11 = document.createTextNode(item.elitros_escarabajo)
        td12.appendChild(textNode11)

        let td13 = tr.insertCell(12)
        let textNode12 = document.createTextNode(item.audios_escarabajos)
        td13.appendChild(textNode12)   

        let td14 = tr.insertCell(13)
        let textNode13 = document.createTextNode(item.imagenes_escarabajos)
        td14.appendChild(textNode13)

        let td15 = tr.insertCell(14)
        td15.classList.add('has-text-centered')
        td15.appendChild(btnEditar)

        let td16 = tr.insertCell(15)
        td16.classList.add('has-text-centered')
        td16.appendChild(btnEliminar)

    })
}

//          Agregar o POST
function agregarEscarabajo() {
    const especie = document.getElementById('especieEscarabajo')
    const familia = document.getElementById('familiaEscarabajo')
    const genero = document.getElementById('generoEscarabajo')
    const patas = document.getElementById('patasEscarabajo')
    const torax = document.getElementById('toraxEscarabajo')
    const ciclo_vida = document.getElementById('ciclo_vidaEscarabajo')
    const nombre_comun = document.getElementById('nombre_comunEscarabajo')
    const antena = document.getElementById('antenaEscarabajo')
    const ojos = document.getElementById('ojosEscarabajo')
    const mandibula = document.getElementById('mandibulaEscarabajo')
    const alas = document.getElementById('alasEscarabajo')
    const elitros = document.getElementById('elitrosEscarabajo')
    const audios = document.getElementById('audiosEscarabajo')
    const imagenes = document.getElementById('imagenesEscarabajo')

    const escarabajo = {
        Especie_escarabajo: especie.value.trim(),
        Familia_escarabajo: familia.value.trim(),
        Genero_escarabajo: genero.value.trim(),
        Patas_escarabajo: parseInt(patas.value.trim(), 10),
        Torax_escarabajo: torax.value.trim(),
        Ciclo_vida_escarabajo: ciclo_vida.value.trim(),
        Nombre_comun_escarabajo: nombre_comun.value.trim(),
        Antena_escarabajo: parseInt(antena.value.trim(), 10),
        Ojos_escarabajo: ojos.value.trim(),
        Mandibula_escarabajo: mandibula.value.trim(),
        Alas_escarabajo: alas.value.trim(),
        Elitros_escarabajo: elitros.value.trim(),
        Audios_escarabajo: JSON.parse("[" + audios.value.trim() + "]"),
        Imagenes_escarabajo: JSON.parse("[" + imagenes.value.trim() + "]")
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(escarabajo)
    })
        .then(response => response .json())
        .then(() => {
            obtenerEscarabajos()
            especie.value = ''
            familia.value = ''
            genero.value = ''
            patas.value = ''
            torax.value = ''
            ciclo_vida.value = ''
            nombre_comun.value = ''
            antena.value = ''
            ojos.value = ''
            mandibula.value = ''
            alas.value = ''
            elitros.value = ''
            audios.value = ''
            imagenes.value = ''
        })
        .then(() => document.getElementById('agregarEscarabajo').classList.remove('is-active'))
        .then(() => openModalMostrar())
        .catch(error => console.error('No se ha podido crear el escarabajo. ', error))
}

//          Eliminar o DELETE
function eliminarEscarabajo(id) {
    fetch(`${uri}/delete/${id}`, {
        method: 'DELETE'
    })
        .then(() => obtenerEscarabajos())
        .catch(error => console.error('No se ha podido eliminar el escarabajo. ', error))
}

//          Editar o UPDATE
var especieEditar
function mostrarFormEditar(especie) {
    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie_escarabajo === especie);

    document.getElementById("editarEspecie").value = escarabajo.especie_escarabajo;
    document.getElementById("editarFamilia").value = escarabajo.familia_escarabajo;
    document.getElementById("editarGenero").value = escarabajo.genero_escarabajo;
    document.getElementById("editarPatas").value = escarabajo.patas_escarabajo;
    document.getElementById("editarTorax").value = escarabajo.torax_escarabajo;
    document.getElementById("editarCiclo_vida").value = escarabajo.ciclo_vida_escarabajo;
    document.getElementById("editarNombre_comun").value = escarabajo.nombre_comun_escarabajo;
    document.getElementById("editarAntena").value = escarabajo.antena_escarabajo;
    document.getElementById("editarOjos").value = escarabajo.ojos_escarabajo;
    document.getElementById("editarMandibula").value = escarabajo.mandibula_escarabajo;
    document.getElementById("editarAlas").value = escarabajo.alas_escarabajo;
    document.getElementById("editarElitros").value = escarabajo.elitros_escarabajo;
    document.getElementById("editarAudios").value = escarabajo.audios_escarabajos;
    document.getElementById("editarImagenes").value = escarabajo.imagenes_escarabajos;
    document.getElementById('editarForm').classList.add('is-active')

    especieEditar = especie
}

function actualizarEscarabajo() {
    const idEscarabajo = document.getElementById('editarEspecie').value.trim()

    let audios = []
    audios.push(document.getElementById('editarAudios').value.trim())

    let imagenes = []
    imagenes.push(document.getElementById('editarImagenes').value.trim())

    const escarabajo = {
        Especie_escarabajo: idEscarabajo,
        Familia_escarabajo: document.getElementById('editarFamilia').value.trim(),
        Genero_escarabajo: document.getElementById('editarGenero').value.trim(),
        Patas_escarabajo: parseInt(document.getElementById('editarPatas').value.trim(), 10),
        Torax_escarabajo: document.getElementById('editarTorax').value.trim(),
        Ciclo_vida_escarabajo: document.getElementById('editarCiclo_vida').value.trim(),
        Nombre_comun_escarabajo: document.getElementById('editarNombre_comun').value.trim(),
        Antena_escarabajo: parseInt(document.getElementById('editarAntena').value.trim(), 10),
        Ojos_escarabajo: document.getElementById('editarOjos').value.trim(),
        Mandibula_escarabajo: document.getElementById('editarMandibula').value.trim(),
        Alas_escarabajo: document.getElementById('editarAlas').value.trim(),
        Elitros_escarabajo: document.getElementById('editarElitros').value.trim(),
        Audios_escarabajos: audios,
        Imagenes_escarabajos: imagenes
    }

    fetch(`${uri}/put/${especieEditar}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(escarabajo)
    })
        .then(() => obtenerEscarabajos())
        .then(() => document.getElementById('editarForm').classList.remove('is-active'))
        .then(() => window.location.reload())
        .catch(error => console.error('Error al actualizar el escarabajo: ', error))
}

function _displayCount(length) {
    const nombre = (length === 1) ? 'escarabajo' : 'escarabajos'
    document.getElementById('contador').innerText = `${length} ${nombre}`
}

//          Funciones de los modales
function openModalAgregar() {
    const modal = document.getElementById("breadcrumbAgregar")
    modal.classList.add('is-active')

    const modal2 = document.getElementById("breadcrumbMostrar")
    modal2.classList.remove('is-active')

    const modalAgregar = document.getElementById('agregarEscarabajo')
    modalAgregar.classList.add('is-active')
}

function openModalMostrar() {
    const modal = document.getElementById("breadcrumbMostrar")
    modal.classList.add('is-active')

    const modal2 = document.getElementById("breadcrumbAgregar")
    modal2.classList.remove('is-active')
}
//-------------------------------------------------------------------------------------------------------------------------------