//Seccion Escarabajos ------------------------------------------------------------------------------------------------------------- 
const uri = 'api/escarabajo'

//Obtener a los escarabajos
let escarabajos
const { jsPDF } = window.jspdf

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

async function fetchEscarabajos() {
    try {
        const response = await fetch(uri, {
            method: 'GET',
            headers: {
                'Authorization': 'Bearer ' + getCookie('userToken')
            }
        },)
        const data = await response.json()
        if(getCookie('userRol')==='Administrador'){
            escarabajos = data
        } else {
            alert("No eres administardor")
        }
    } catch (error) {
        console.error('No se puede obtener el array de escarabajos', error)
    }
}
fetchEscarabajos()

document.addEventListener('DOMContentLoaded', () => {
    obtenerEscarabajos()
})

//carga los forms
const formAgregarEscarabajo = document.getElementById("formAgregarEscarabajo")
const formEditar = document.getElementById('editarForm')
const cerrarEditar = document.getElementById("cerrarModalEditar")
const cerrarAgregar = document.getElementById('cerrarModalAgregar')
const cerrarImagenes = document.getElementById('cerrarModalImagenes')
const cerrarAudios = document.getElementById('cerrarModalAudios')
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

cerrarImagenes.addEventListener('click', (e) => {
    e.preventDefault()
    document.getElementById('modalImagenes').classList.remove('is-active')
})

cerrarAudios.addEventListener('click', (e) => {
    e.preventDefault()
    document.getElementById('modalAudios').classList.remove('is-active')
})

//      Metodos para trabajar con la API
//          Obtener o GET
function obtenerEscarabajos() {
    fetch(uri, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => response.json())
        .then(data => _mostrarEscarabajos(data))
        .catch(error => alert("Error al obtener los datos de escarabajos"))
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
        btnEditar.setAttribute('onClick', `mostrarFormEditar("${item.especie}")`)

        let btnEliminar = boton.cloneNode(false)
        btnEliminar.innerHTML = 'Eliminar'
        btnEliminar.classList.add('button', 'is-small', 'is-danger', 'is-outlined', 'has-text-weight-bold');
        btnEliminar.setAttribute('onClick', `eliminarEscarabajo("${item.especie}")`)

        let btnAudios = boton.cloneNode(false)
        btnAudios.innerHTML = 'Audios'
        btnAudios.classList.add('button', 'is-small', 'is-primary', 'is-outlined', 'has-text-weight-bold');
        btnAudios.setAttribute('onClick', `abrirModalAudios("${item.especie}")`)

        let btnImagenes = boton.cloneNode(false)
        btnImagenes.innerHTML = 'Imagenes'
        btnImagenes.classList.add('button', 'is-small', 'is-primary', 'is-outlined', 'has-text-weight-bold');
        btnImagenes.setAttribute('onClick', `abrirModalImagenes("${item.especie}")`)

        let tr = tBody.insertRow()

        let td1 = tr.insertCell(0)
        let textNode = document.createTextNode(item.especie)
        td1.appendChild(textNode)

        let td2 = tr.insertCell(1)
        let textNode1 = document.createTextNode(item.familia)
        td2.appendChild(textNode1)

        let td3 = tr.insertCell(2)
        let textNode2 = document.createTextNode(item.genero)
        td3.appendChild(textNode2)

        let td4 = tr.insertCell(3)
        let textNode3 = document.createTextNode(item.patas)
        td4.appendChild(textNode3)

        let td5 = tr.insertCell(4)
        let textNode4 = document.createTextNode(item.torax)
        td5.appendChild(textNode4)

        let td6 = tr.insertCell(5)
        let textNode5 = document.createTextNode(item.ciclo_vida)
        td6.appendChild(textNode5)

        let td7 = tr.insertCell(6)
        let textNode6 = document.createTextNode(item.nombre_comun)
        td7.appendChild(textNode6)

        let td8 = tr.insertCell(7)
        let textNode7 = document.createTextNode(item.antena)
        td8.appendChild(textNode7)

        let td9 = tr.insertCell(8)
        let textNode8 = document.createTextNode(item.ojos)
        td9.appendChild(textNode8)

        let td10 = tr.insertCell(9)
        let textNode9 = document.createTextNode(item.mandibula)
        td10.appendChild(textNode9)

        let td11 = tr.insertCell(10)
        let textNode10 = document.createTextNode(item.alas)
        td11.appendChild(textNode10)

        let td12 = tr.insertCell(11)
        let textNode11 = document.createTextNode(item.elitros)
        td12.appendChild(textNode11)

        let td13 = tr.insertCell(12)
        td13.classList.add('has-text-centered')
        td13.appendChild(btnAudios)

        let td14 = tr.insertCell(13)
        td14.classList.add('has-text-centered')
        td14.appendChild(btnImagenes)

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
    const descripcion = document.getElementById('descripcionEscarabajo')
    const audios = document.getElementById('audiosEscarabajo')
    const imagenes = document.getElementById('imagenesEscarabajo')
    const coordenadas = document.getElementById('coordenadasEscarabajo')

    const escarabajo = {
        Especie: especie.value.trim(),
        Familia: familia.value.trim(),
        Genero: genero.value.trim(),
        Patas: parseInt(patas.value.trim(), 10),
        Torax: torax.value.trim(),
        Ciclo_vida: ciclo_vida.value.trim(),
        Nombre_comun: nombre_comun.value.trim(),
        Antena: parseInt(antena.value.trim(), 10),
        Ojos: ojos.value.trim(),
        Mandibula: mandibula.value.trim(),
        Alas: alas.value.trim(),
        Elitros: elitros.value.trim(),
        Descripcion: descripcion.value.trim(),
        Estado_investigacion: false,
        Audios: audios ? JSON.parse("[" + audios.value.trim() + "]") : JSON.parse("[null]"),
        Imagenes: imagenes ? JSON.parse("[" + imagenes.value.trim() + "]") : JSON.parse("[null]"),
        Coordenadas: coordenadas ? JSON.parse("[" + coordenadas.value.trim().toString() + "]") : JSON.parse("[null]")
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + getCookie('userToken')
        },
        body: JSON.stringify(escarabajo)
    })
        .then(response => response.json())
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
        })
        .then(() => document.getElementById('agregarEscarabajo').classList.remove('is-active'))
        .then(() => openModalMostrar())
        .catch(error => alert("No se pudo crear el escarabajo"))
}

//          Eliminar o DELETE
function eliminarEscarabajo(id) {
    fetch(`${uri}/delete/${id}`, {
        method: 'DELETE', 
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(() => obtenerEscarabajos())
        .catch(error => alert("No se pudo eliminar al escarabajo"))
}

//          Editar o UPDATE
var especieEditar
function mostrarFormEditar(especie) {
    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie === especie);

    console.log(escarabajo)

    document.getElementById("editarEspecie").value = escarabajo.especie;
    document.getElementById("editarFamilia").value = escarabajo.familia;
    document.getElementById("editarGenero").value = escarabajo.genero;
    document.getElementById("editarPatas").value = escarabajo.patas;
    document.getElementById("editarTorax").value = escarabajo.torax;
    document.getElementById("editarCiclo_vida").value = escarabajo.ciclo_vida;
    document.getElementById("editarNombre_comun").value = escarabajo.nombre_comun;
    document.getElementById("editarAntena").value = escarabajo.antena;
    document.getElementById("editarOjos").value = escarabajo.ojos;
    document.getElementById("editarMandibula").value = escarabajo.mandibula;
    document.getElementById("editarAlas").value = escarabajo.alas;
    document.getElementById("editarElitros").value = escarabajo.elitros;
    document.getElementById("editarCoordenadas").value = escarabajo.coordenadas;
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
        Especie: idEscarabajo,
        Familia: document.getElementById('editarFamilia').value.trim(),
        Genero: document.getElementById('editarGenero').value.trim(),
        Patas: parseInt(document.getElementById('editarPatas').value.trim(), 10),
        Torax: document.getElementById('editarTorax').value.trim(),
        Ciclo_vida: document.getElementById('editarCiclo_vida').value.trim(),
        Nombre_comun: document.getElementById('editarNombre_comun').value.trim(),
        Antena: parseInt(document.getElementById('editarAntena').value.trim(), 10),
        Ojos: document.getElementById('editarOjos').value.trim(),
        Mandibula: document.getElementById('editarMandibula').value.trim(),
        Alas: document.getElementById('editarAlas').value.trim(),
        Elitros: document.getElementById('editarElitros').value.trim(),
        Audioss: audios,
        Imageness: imagenes
    }

    fetch(`${uri}/put/${especieEditar}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + getCookie('userToken')
        },
        body: JSON.stringify(escarabajo)
    })
        .then(() => obtenerEscarabajos())
        .then(() => document.getElementById('editarForm').classList.remove('is-active'))
        .then(() => window.location.reload())
        .catch(error => alert("No se pudo editar al escarabajo '" + escarabajo.Especie + "'"))
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

function abrirModalImagenes(especie) {
    document.getElementById('modalImagenes').classList.add('is-active')
    const body = document.getElementById('bodyModalImagenes')
    body.innerHTML = ''
    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie === especie)
    const imagenes = escarabajo.imagenes
    imagenes.forEach(imagen => {

    })
}

function abrirModalAudios(especie) {
    document.getElementById('modalAudios').classList.add('is-active')
    const body = document.getElementById('bodyModalAudios')

    body.innerHTML = ''

    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie === especie)
    const audios = escarabajo.audios

    const div = document.createElement('div')
    div.setAttribute('id', 'audio-preview')
    div.classList.add('audio-preview')

    audios.forEach(audioSrc => {
        const divPreview = div.cloneNode(false)
        const audioPreview = document.createElement('audio')
        audioPreview.setAttribute('controls', '')

        audioPreview.src = audioSrc

        divPreview.appendChild(audioPreview)
        body.appendChild(divPreview)
    });

}
//-------------------------------------------------------------------------------------------------------------------------------

function mostrarDatosPDF() {

    const doc = new jsPDF()
    doc.setFontSize(12)
    doc.text('Datos de los Escarabajos', 10, 10)

    const headers = Object.keys(escarabajos)
    const data = escarabajos.map(item => [item.especie, item.familia, item.genero, item.patas, item.torax, item.ciclo_vida, item.nombre_comun, item.antena, item.ojos, item.mandibula, item.alas, item.elitros, item.descripcion, item.estado_investigacion]);
    console.log(data)
    doc.autoTable({
        head: [headers],
        body: data,
        startY: 20,
        theme: 'grid',
        columnStyles: {
            0: { fontStyle: 'bold' },
        }
    })

    doc.save('datos_escarabajos.pdf');
}

function descargarTxt(especie) {
    var fs = CreateObject("Scripting.FileSystemObject")
    const writeStream = fs.createWriteStream('beetles_data.txt');
    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie === especie)

    escarabajo.forEach(atributo => {
        writeStream.write(`${atributo}`);
    });

    console.log('Data written to file successfully!');
}