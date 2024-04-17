//Seccion Biologos ------------------------------------------------------------------------------------------------------------- 
const uri = 'api/biologo'

//Obtener a los biologos
let biologos

async function fetchBiologos() {
    try {
        const response = await fetch(uri);
        const data = await response.json();
        biologos = data;
    } catch (error) {
        console.error('No se puede obtener el array de biologos', error);
    }
}
fetchBiologos()

//carga los forms
const formAgregarBiologo = document.getElementById("formAgregarBiologo")
const formEditar = document.getElementById('editarForm')
const cerrarEditar = document.getElementById("cerrarModalEditar")
const cerrarAgregar = document.getElementById('cerrarModalAgregar')
const btnBorrarFormAgregar = document.getElementById('btnBorrarFormAgregar')
//      Se crean los eventos -------------------------------------------------------------------------------
formAgregarBiologo.addEventListener("submit", (e) => {
    e.preventDefault();
    agregarBiologo();
})

formEditar.addEventListener("submit", (e) => {
    e.preventDefault()
    actualizarBiologo()
})

cerrarEditar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById('editarForm').classList.remove('is-active')
})

cerrarAgregar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById('agregarBiologo').classList.remove('is-active')
    openModalMostrar()
})

btnBorrarFormAgregar.addEventListener("click", (e) => {
    e.preventDefault()
    document.getElementById('nombreBiologo').value = ''
    document.getElementById('correoBiologo').value = ''
    document.getElementById('edadBiologo').value = ''
    document.getElementById('telefonoBiologo').value = ''
    document.getElementById('usuarioBiologo').value = ''
    document.getElementById('contrasenaBiologo').value = ''
})

//      Metodos para trabajar con la API
//          Obtener o GET
function obtenerBiologos() {
    fetch(uri)
        .then(response => response.json())
        .then(data => _mostrarBiologos(data))
        .catch(error => console.error('No se han podido obtener los elementos. ', error));
}

function _mostrarBiologos(data) {
    const tBody = document.getElementById('mostrarBiologos')
    tBody.innerHTML = ''

    _displayCount(data.length)

    const boton = document.createElement('button')

    data.forEach(item => {
        let btnEditar = boton.cloneNode(false)
        btnEditar.innerHTML = 'Editar'
        btnEditar.classList.add('button', 'is-small', 'is-warning', 'is-outlined', 'has-text-weight-bold');
        btnEditar.setAttribute('onClick', `mostrarFormEditar(${item.id_biologo})`)

        let btnEliminar = boton.cloneNode(false)
        btnEliminar.innerHTML = 'Eliminar'
        btnEliminar.classList.add('button', 'is-small', 'is-danger', 'is-outlined', 'has-text-weight-bold');
        btnEliminar.setAttribute('onClick', `eliminarBiologo(${item.id_biologo})`)

        let tr = tBody.insertRow()

        let tdNombre = tr.insertCell(0)
        let textNodeNombre = document.createTextNode(item.nombre_biologo)
        tdNombre.appendChild(textNodeNombre)

        let tdCorreo = tr.insertCell(1)
        let textNodeCorreo = document.createTextNode(item.correo_biologo)
        tdCorreo.appendChild(textNodeCorreo)

        let tdEdad = tr.insertCell(2)
        let textNodeEdad = document.createTextNode(item.edad_biologo)
        tdEdad.classList.add('has-text-centered')
        tdEdad.appendChild(textNodeEdad)

        let tdTelefono = tr.insertCell(3)
        let textNodeTelefono = document.createTextNode(item.telefono_biologo)
        tdTelefono.classList.add('has-text-centered')
        tdTelefono.appendChild(textNodeTelefono)

        let tdUsuario = tr.insertCell(4)
        let textNodeUsuario = document.createTextNode(item.usuario_biologo)
        tdUsuario.appendChild(textNodeUsuario)

        let tdContrasena = tr.insertCell(5)
        let textNodeContrasena = document.createTextNode(item.contrasena_biologo)
        tdContrasena.appendChild(textNodeContrasena)

        let tdEditar = tr.insertCell(6)
        tdEditar.classList.add('has-text-centered')
        tdEditar.appendChild(btnEditar)

        let tdEliminar = tr.insertCell(7)
        tdEliminar.classList.add('has-text-centered')
        tdEliminar.appendChild(btnEliminar)
    })
}

//          Agregar o POST
function agregarBiologo() {
    const nombre = document.getElementById('nombreBiologo')
    const correo = document.getElementById('correoBiologo')
    const edad = document.getElementById('edadBiologo')
    const telefono = document.getElementById('telefonoBiologo')
    const usuario = document.getElementById('usuarioBiologo')
    const contrasena = document.getElementById('contrasenaBiologo')

    const biologo = {
        Nombre_biologo: nombre.value.trim(),
        Correo_biologo: correo.value.trim(),
        Edad_biologo: edad.value.trim(),
        Telefono_biologo: telefono.value.trim(),
        Usuario_biologo: usuario.value.trim(),
        Contrasena_biologo: contrasena.value.trim()
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(biologo)
    })
        .then(response => response .json())
        .then(() => {
            obtenerBiologos()
            nombre.value = ''
            correo.value = ''
            edad.value = ''
            telefono.value = ''
            usuario.value = ''
            contrasena.value = ''
        })
        .then(() => document.getElementById('agregarBiologo').classList.remove('is-active'))
        .then(() => openModalMostrar())
        .catch(error => console.error('No se ha podido crear el biologo. ', error))
}

//          Eliminar o DELETE
function eliminarBiologo(id) {
    fetch(`${uri}/${id}`, {
        method: 'DELETE'
    })
        .then(() => obtenerBiologos())
        .catch(error => console.error('No se ha podido eliminar el biologo. ', error))
}

//          Editar o UPDATE
function mostrarFormEditar(id) {
    const biologo = biologos.find(biologo => biologo.id_biologo === id)

    document.getElementById('editarId').value = biologo.id_biologo
    document.getElementById('editarNombre').value = biologo.nombre_biologo
    document.getElementById('editarCorreo').value = biologo.correo_biologo
    document.getElementById('editarEdad').value = biologo.edad_biologo
    document.getElementById('editarTelefono').value = biologo.telefono_biologo
    document.getElementById('editarUsuario').value = biologo.usuario_biologo
    document.getElementById('editarContrasena').value = biologo.contrasena_biologo
    document.getElementById('editarForm').classList.add('is-active')
}

function actualizarBiologo() {
    const idbiologo = parseInt(document.getElementById('editarId').value.trim(), 10)
    
    const biologo = {
        Id_biologo: idbiologo,
        Nombre_biologo: document.getElementById('editarNombre').value.trim(),
        Correo_biologo: document.getElementById('editarCorreo').value.trim(),
        Edad_biologo: parseInt(document.getElementById('editarEdad').value.trim(), 10),
        Telefono_biologo: parseInt(document.getElementById('editarTelefono').value.trim(), 10),
        Usuario_biologo: document.getElementById('editarUsuario').value.trim(),
        Contrasena_biologo: document.getElementById('editarContrasena').value.trim()
    }

    fetch(`${uri}/${idbiologo}`, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(biologo)
    })
        .then(() => obtenerBiologos())
        .then(() => document.getElementById('editarForm').classList.remove('is-active'))
        .then(() => window.location.reload())
        .catch(error => console.error('No se ha podido editar el biologo. ', error))
        
    
}

//          Funciones extras
function _displayCount(length) {
    const nombre = (length === 1) ? 'biologo' : 'biologos'
    document.getElementById('contador').innerText = `${length} ${nombre}`
}

//          Funciones para los modales
function openModalAgregar() {
    const modal = document.getElementById("breadcrumbAgregar")
    modal.classList.add('is-active')

    const modal2 = document.getElementById("breadcrumbMostrar")
    modal2.classList.remove('is-active')

    const modalAgregar = document.getElementById('agregarBiologo')
    modalAgregar.classList.add('is-active')
}

function openModalMostrar() {
    const modal = document.getElementById("breadcrumbMostrar")
    modal.classList.add('is-active')

    const modal2 = document.getElementById("breadcrumbAgregar")
    modal2.classList.remove('is-active')
}
//-------------------------------------------------------------------------------------------------------------------------------