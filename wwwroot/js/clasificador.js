let audioFile
const uri = "api/file/audio"

function mostrarErrorServidor() {
    const btnCerrarSesion = document.getElementById("cerrarSesion")
    btnCerrarSesion.classList.add("is-hidden")

    const divPrincipal = document.getElementById("ContenidoPrincipal");
    divPrincipal.innerHTML = "";

    const divError = document.createElement("div");
    divError.classList.add("has-text-centered");
    divError.style.width = "100%";

    const titulo = document.createElement("p");
    titulo.classList.add("label", "has-text-white", "is-size-3", "my-4");
    titulo.textContent = "Fallas en el sistema";

    const texto = document.createElement("p");
    texto.classList.add("has-text-white", "is-size-4", "mb-5");
    texto.textContent = "Lo sentimos. Tenemos problemas para comunicarnos con el sistema.";

    const imagenContainer = document.createElement("div");
    imagenContainer.classList.add("is-flex", "is-justify-content-center", "mb-6");

    const imagen = document.createElement("img");
    imagen.src = "./css/resources/images/escarabajoError.webp";
    imagen.classList.add("image", "is-128x128");

    imagenContainer.appendChild(imagen);

    divError.appendChild(titulo);
    divError.appendChild(texto);
    divError.appendChild(imagenContainer);

    divPrincipal.appendChild(divError);
}

document.addEventListener('DOMContentLoaded', () => {
    if (getCookie("userToken") && getCookie("userRol") === "Biologo") {
        // Metodos para el manejo del nombre del biologo en el input
        const jwtDecodificado = jwt_decode(getCookie('userToken'))

        const userName = jwtDecodificado["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

        const inputBiologo = document.getElementById("biologoClasificar")
        inputBiologo.value = userName

        // Metodos para la clasificacion del audio
        document.getElementById('audioInput').addEventListener('change', function (event) {
            audioFile = event.target.files[0]
            if (audioFile) {
                document.getElementById('fileName').textContent = audioFile.name
            }
        })

        const btnClasificar = document.getElementById("btnClasificar")
        btnClasificar.addEventListener('click', (e) => {
            e.preventDefault()
            clasificarAudio()
        })
    } else {
        mostrarErrorServidor()
    }
})

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)')
    return cookieValue ? cookieValue.pop() : ''
}

function clasificarAudio() {
    if (audioFile) {
        const formData = new FormData();
        formData.append('audio', audioFile);
        document.getElementById('btnClasificar').classList.add('is-loading')

        fetch(uri, {
            method: 'POST',
            headers: {
                'Authorization': 'Bearer ' + getCookie('userToken')
            },
            body: formData
        })
        .then(response => response.json())
        .then(data => {
            jsonObj = JSON.parse(data.message)
            especie = jsonObj.especie
            porcentaje = jsonObj.porcentaje
            document.getElementById('btnClasificar').classList.remove('is-loading')
            mostrarClasificacion(especie, porcentaje)
        })
        .catch(error => alert("Error al clasificar el audio"));
    } else {
        alert("Por favor, selecciona un archivo de audio primero.");
    }
}

function mostrarClasificacion(especie, porcentaje){
    imgClasificacion = document.getElementById('imgClasificacion')
    imgClasificacion.setAttribute("src", `./css/resources/images/${especie}.webp`)

    especieClasificacion = document.getElementById('especieClasificacion')
    especieClasificacion.textContent = especie

    porcentajeClasificacion = document.getElementById('porcentajeClasificacion')
    porcentajeClasificacion.textContent = porcentaje.toFixed(2) + "%";

    divClasificacion = document.getElementById("divClasificacion")
    divClasificacion.classList.remove('is-hidden')
}