let galleryImages = []
let escarabajos
// Obtén todas las imágenes de la galería
const uri = 'api/escarabajo'

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

function mostrarErrorServidor() {
    const btnCerrarSesion = document.getElementById("cerrarSesion")
    btnCerrarSesion.classList.add("is-hidden")

    const divPrincipal = document.getElementById("div_gallery");
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
                _mostrarEscarabajoGaleria(escarabajos)
                galleryImages = document.querySelectorAll('.img')
                cargarMetodoImagenesModal()
                if (getCookie('especieBusqueda')) {
                    const especie = getCookie('especieBusqueda')
                    mostrarDescripcion(especie)
                    openModal()
                    document.cookie = 'especieBusqueda=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
                }
            }
        })
        .catch(error => {
            mostrarErrorServidor()
        })
})

function _mostrarEscarabajoGaleria(data) {
    const tBody = document.getElementById('div_gallery')
    tBody.innerHTML = ''

    const divCollum = document.createElement('div')
    const divCell = document.createElement('div')
    const divImagen = document.createElement('img')

    data.forEach(item => {
        let divCol = divCollum.cloneNode(false)
        divCol.classList.add('column', 'is-one-third', 'm-0', 'p-0')

        let divCeld = divCell.cloneNode(false)
        divCeld.classList.add('cell', 'is-flex', 'is-justify-content-center', 'is-align-content-center', 'is-fullheight', 'm-0', 'p-0')
        divCeld.style.height = "100%"

        let divImag = divImagen.cloneNode(false)
        let num = Math.floor(Math.random() * item.imagenes.length)

        let fullPath = item.imagenes[num]
        let pathParts = fullPath.split('/css/');
        if (pathParts.length < 2) {
            pathParts = fullPath.split('\\css\\');
        }
        let relativePath = '/css/' + pathParts[1];

        divImag.setAttribute('src', relativePath);
        divImag.setAttribute('alt', `${item.especie}`)
        divImag.setAttribute('onClick', `mostrarDescripcion("${item.especie}")`)
        divImag.classList.add('image', 'is-fullwidth', 'img', `class${item.especie}`)
        divImag.style.height = "100%"
        divImag.style.objectFit = "cover"

        tBody.appendChild(divCol)
        divCol.appendChild(divCeld)
        divCeld.appendChild(divImag)
    })
}

// Agrega un evento de clic a cada imagen
function cargarMetodoImagenesModal() {
    galleryImages.forEach(image => {
        image.addEventListener('click', () => {
            openModal()
        })
    })
}

function mostrarDescripcion(especie) {
    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            let divInfo = document.getElementById('div-info')
            divInfo.innerHTML = ''

            let parrafo = document.createElement('p')
            parrafo.textContent = escarabajo.descripcion
            parrafo.classList.add('mb-2', 'has-text-justified')
            divInfo.appendChild(parrafo)

            for (let i = 0; i < Object.keys(escarabajo).length - 6; i++) {
                const atributo = Object.values(escarabajo)[i];
                let labelAtributo = document.createElement('label')
                labelAtributo.classList.add('has-text-weight-bold')
                labelAtributo.textContent = Object.keys(escarabajo)[i]
                labelAtributo.style.textTransform = "uppercase"
                let pArtributo = parrafo.cloneNode(false)
                pArtributo.textContent = atributo
                divInfo.appendChild(labelAtributo)
                divInfo.appendChild(pArtributo)
            }

            mostrarCoordenadas(escarabajo.especie)
            mostrarImagenes(escarabajo.especie)
            mostrarGradoInvestigacion(escarabajo.especie)
            agregarBtnDescargar(escarabajo.especie)
        }
    })
}

function mostrarImagenes(especie) {
    const img = document.createElement('img')
    const p = document.createElement('p')
    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            const divFotos = document.getElementById('columna_fotos')
            escarabajo.imagenes.forEach(imagen => {
                divFotos.innerHTML = ''
                let pInner = p.cloneNode(false)
                pInner.classList.add("is-size-3", "has-text-white", "has-text-centered", "mb-5", "has-text-weight-bold")
                pInner.textContent = `${escarabajo.especie}`
                let imagenImg = img.cloneNode(false)

                let fullPath = imagen
                let pathParts = fullPath.split('/css/');
                if (pathParts.length < 2) {
                    pathParts = fullPath.split('\\css\\');
                }
                let relativePath = '/css/' + pathParts[1];

                imagenImg.setAttribute('src', relativePath)
                imagenImg.setAttribute('id', 'modal-image')
                imagenImg.style.width = "100%"
                divFotos.appendChild(pInner)
                divFotos.appendChild(imagenImg)
            })
        }
    })
}

function mostrarCoordenadas(especie) {
    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            const divMap = document.getElementById('map')
            var scriptElement = divMap.querySelector('script_map');

            if (scriptElement) {
                divMap.removeChild(scriptElement);
            }

            let coordenadasArray = escarabajo.coordenadas[0].split(',')
            let x = parseFloat(coordenadasArray[0])
            let y = parseFloat(coordenadasArray[1])
            let z = parseInt(coordenadasArray[2])

            const script = document.createElement('script')
            script.classList.add('script_map')
            script.textContent = `
                if(map != undefined) {map.remove();}
                var map = L.map('map').setView([${x}, ${y}], ${z})

                L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
                    maxZoom: 19,
                    attribution: '&copy <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                }).addTo(map)

                L.marker([${x}, ${y}]).addTo(map)
            `

            divMap.appendChild(script)
        }
    })
}

function mostrarGradoInvestigacion(especie) {
    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            const barraProgress = document.getElementById("id_barra_investigacion")
            barraProgress.innerText = ''
            if (escarabajo.Estado_investigacion) {
                barraProgress.setAttribute("value", "100")
                barraProgress.innerText = '100%'
            } else {
                barraProgress.setAttribute("value", "0")
                barraProgress.innerText = '0%'
            }
        }
    })
}

function agregarBtnDescargar(especie) {
    const btnDescargar = document.getElementById("btnDescargarEspecie");
    btnDescargar.onclick = () => {
        const modal = document.getElementById('downloadModal');
        modal.classList.add('is-active');
        const btn = document.getElementById("downloadButton");
        btn.onclick = () => {
            descargarRecursos(especie);
        };
    };
}

function descargarRecursos(especie) {
    const archivosSeleccionados = [];
    const audioCheckbox = document.getElementById("audioCheckbox")
    const spectrogramCheckbox = document.getElementById("spectrogramCheckbox")
    const imagesCheckbox = document.getElementById("imagesCheckbox")
    const techSheetCheckbox = document.getElementById("techSheetCheckbox")

    boolAudio = audioCheckbox.checked
    boolImagenes = imagesCheckbox.checked
    // boolTechSheet = techSheetCheckbox.checked

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
            // if (techSheetCheckbox.checked) {

            //     archivosSeleccionados.push({ ruta: "resources/ficha_tecnica.txt", carpeta: "fichas_tecnicas" })
            // }
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

        closeModalDescargas()
    })
}

// Función para abrir el modal
function openModal() {
    const modal = document.getElementById('modal')
    modal.classList.add('is-active')
}

// Función para cerrar el modal
function closeModal() {
    const modal = document.getElementById('modal')

    modal.classList.remove('is-active')
}

function closeModalDescargas() {

    const modal = document.getElementById('downloadModal')
    const audioCheckbox = document.getElementById("audioCheckbox")
    const imagesCheckbox = document.getElementById("imagesCheckbox")
    // const techSheetCheckbox = document.getElementById("techSheetCheckbox")

    audioCheckbox.checked = false
    imagesCheckbox.checked = false
    // techSheetCheckbox.checked = false

    modal.classList.remove('is-active')
}

function descargarTxt(especie) {
    var fs = CreateObject("Scripting.FileSystemObject")
    const writeStream = fs.createWriteStream('beetles_data.txt');
    const escarabajo = escarabajos.find(escarabajo => escarabajo.especie === especie)

    escarabajo.forEach(atributo => {
        writeStream.write(`${atributo}`);
    });

    return writeStream
}

function aplicarFiltros() {
    const filtroFamilia = document.getElementById('filtroFamilia').value.toLowerCase();
    const filtroPatas = document.getElementById('filtroPatas').value;
    const filtroAntenas = document.getElementById('filtroAntenas').value;
    const filtroInvestigacion = document.getElementById('filtroInvestigacion').value;

    const datosFiltrados = escarabajos.filter(item => {
        let coincideFamilia = true;
        let coincidePatas = true;
        let coincideAntenas = true;
        let coincideInvestigacion = true;

        if (filtroFamilia) {
            coincideFamilia = item.familia.toLowerCase().includes(filtroFamilia);
        }

        if (filtroPatas) {
            coincidePatas = item.patas === parseInt(filtroPatas);
        }

        if (filtroAntenas) {
            coincideAntenas = item.antena === parseInt(filtroAntenas);
        }

        if (filtroInvestigacion) {
            coincideInvestigacion = item.estado_investigacion === (filtroInvestigacion === '1');
        }

        return coincideFamilia && coincidePatas && coincideAntenas && coincideInvestigacion;
    });

    _mostrarEscarabajoGaleria(datosFiltrados);
    galleryImages = document.querySelectorAll('.img');
    cargarMetodoImagenesModal();
}

function configurarEventosModales() {
    const imagenes = document.querySelectorAll('.img');
    imagenes.forEach(imagen => {
        imagen.addEventListener('click', function () {
            const especie = this.getAttribute('alt');
            mostrarDescripcion(especie);
        });
    });
}

function limpiarFiltros() {
    const filtroFamilia = document.getElementById('filtroFamilia');
    const filtroPatas = document.getElementById('filtroPatas');
    const filtroAntenas = document.getElementById('filtroAntenas');
    const filtroInvestigacion = document.getElementById('filtroInvestigacion');

    filtroFamilia.value = '';
    filtroPatas.value = '';
    filtroAntenas.value = '';
    filtroInvestigacion.value = '';

    fetch("api/escarabajo/filtrar", {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => response.json())
        .then(data => {
            _mostrarEscarabajoGaleria(data);
            galleryImages = document.querySelectorAll('.img');
            cargarMetodoImagenesModal();
        })
        .catch(error => {
            mostrarErrorServidor();
        });
}