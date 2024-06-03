function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

const cuentaEscarabajos = document.getElementById("cuentaEscarabajos")
contarEscarabajos()
const cuentaBiologos = document.getElementById("cuentaBiologos")
contarBiologos()

function contarEscarabajos(){
    fetch("api/escarabajo", {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => response.json())
        .then(data => {
            if (getCookie('userRol') === 'Administrador') {
                cuentaEscarabajos.textContent = `El número de escarabajos actuales es de ${data.length}`
            } else {
                mostrarErrorServidor()
            }
        })
        .catch(error => {
            mostrarErrorServidor()
        })
}

function contarBiologos(){
    fetch("api/biologo", {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => response.json())
        .then(data => {
            if (getCookie('userRol') === 'Administrador') {
                cuentaBiologos.textContent = `El número de biologos registrados es de ${data.length}`
            } else {
                mostrarErrorServidor()
            }
        })
        .catch(error => {
            mostrarErrorServidor()
        })
}

function mostrarErrorServidor() {
    const txtAdmin = document.getElementById("adminLabel")
    txtAdmin.classList.add("is-hidden")

    const btnCerrarSesion = document.getElementById("cerrarSesion")
    btnCerrarSesion.classList.add("is-hidden")

    const divPrincipal = document.getElementById("ContenidoPrincipal");
    divPrincipal.innerHTML = "";

    const divError = document.createElement("div");
    divError.classList.add("has-text-centered");
    divError.style.width = "100%";

    const titulo = document.createElement("p");
    titulo.classList.add("label", "has-text-black", "is-size-3", "my-4");
    titulo.textContent = "Fallas en el sistema";

    const texto = document.createElement("p");
    texto.classList.add("has-text-black", "is-size-4", "mb-5");
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