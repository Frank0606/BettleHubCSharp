let escarabajos
const uri = 'api/escarabajo'

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

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
    fetch(uri, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => {
            const newToken = response.headers.get('Set-Authorization');
            if (newToken) {
                const tokenCookie = "userToken=" + newToken + "; expires=Mon, 01 Jul 2024 12:00:00 GMT; SameSite=strict";
                document.cookie = tokenCookie;
            }
            return response.json()
        })
        .then(data => {
            if (data.message) {
                swal("Problema - Escarabajos", data.message, "error", {
                    button: "Aceptar"
                });
            } else {
                escarabajos = data
                mostrarEspeciesSelect()
            }
        })
        .catch(error => {
            mostrarErrorServidor()
        })
})

function mostrarEspeciesSelect() {
    const selectElement = document.getElementById('especieRecurso');
    escarabajos.forEach(escarabajo => {
        const option = document.createElement('option');
        option.text = escarabajo.especie;
        selectElement.appendChild(option);
    })
    const imgElement = document.getElementById('imgClasificacion');
    selectElement.addEventListener('change', (event) => {
        document.getElementById('divRecursos').classList.remove('is-hidden')
        const especieSeleccionada = event.target.value
        escarabajos.forEach(escarabajo => {
            if (escarabajo.especie === especieSeleccionada) {
                let num = Math.floor(Math.random() * escarabajo.imagenes.length)
                imgElement.src = escarabajo.imagenes[num]
                agregarBtnDescargar(escarabajo.especie)
            }
        })
    })
}

function descargarRecursos(especie) {
    const archivosSeleccionados = [];
    const audioCheckbox = document.getElementById("checkboxAudios")
    const imagesCheckbox = document.getElementById("checkboxImagenes")

    boolAudio = audioCheckbox.checked
    boolImagenes = imagesCheckbox.checked

    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            if (boolAudio) {
                escarabajo.audios.forEach(audio => {
                    archivosSeleccionados.push({ ruta: audio, carpeta: "audios" })
                })
            }
            if (boolImagenes) {
                escarabajo.imagenes.forEach(imagen => {
                    archivosSeleccionados.push({ ruta: imagen, carpeta: "imagenes" })
                })
            }

            const zip = new JSZip()
            const promesas = []

            archivosSeleccionados.forEach(archivo => {
                const { ruta, carpeta } = archivo
                const nombreArchivo = ruta.split("/").pop()
                const folder = zip.folder(carpeta)


                const promise = fetch(ruta)
                    .then(response => response.blob())
                    .then(blob => {
                        folder.file(nombreArchivo, blob)
                    })

                promesas.push(promise)
            })

            Promise.all(promesas)
                .then(() => {
                    zip.generateAsync({ type: "blob" })
                        .then(blob => {
                            const link = document.createElement("a")
                            link.href = URL.createObjectURL(blob)
                            link.download = `${especie}Recursos.zip`
                            link.click()
                        });
                })
                .catch(error => {
                    alert("Error al cargar los archivos para descargar")
                    console.error("Error al cargar los archivos:", error)
                })
        }
    })
}

function agregarBtnDescargar(especie) {
    const btnDescargar = document.getElementById("downloadButton");
    btnDescargar.onclick = () => {
        descargarRecursos(especie)
    };
}