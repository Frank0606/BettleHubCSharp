
let galleryImages = []
let escarabajos
// Obtén todas las imágenes de la galería
const uri = 'api/escarabajo'

document.addEventListener('DOMContentLoaded', () => {
    
    // const userTokenValue = document.cookie.split('; ')
    // .find(row => row.startsWith('userToken='))
    // ?.split('=')[1];

    // console.log(document.cookie.split('=')[1])
    // console.log(userTokenValue)

    fetch(uri, {
        method: 'GET',
        Authorization: `Bearer ${document.cookie.split('=')[1]}`
    })
        .then(response => response.json())
        .then(data => {
            escarabajos = data
            _mostrarEscarabajoGaleria(escarabajos)
            galleryImages = document.querySelectorAll('.img')
            cargarMetodoImagenesModal()
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

        divImag.setAttribute('src', `${item.imagenes[num]}`)
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
            // Abre el modal
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

            for (let i = 0; i < Object.keys(escarabajo).length-6; i++) {
                const atributo = Object.values(escarabajo)[i];
                let labelAtributo = document.createElement('label')
                labelAtributo.classList.add('has-text-weight-bold')
                labelAtributo.textContent = Object.keys(escarabajo)[i]
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
                imagenImg.setAttribute('src', `${imagen}`)
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

            // if(map != undefined) {map.remove();}
            //     var map = L.map('map').setView([${x}, ${y}], ${z})
                

            //     L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png', {
            //         maxZoom: 19,
            //         attribution: '&copy <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            //     }).addTo(map)

            //     L.marker([${x}, ${y}]).addTo(map)

            divMap.appendChild(script)
        }
    })
}

function mostrarGradoInvestigacion(especie) {
    escarabajos.forEach(escarabajo => {
        if(escarabajo.especie === especie) {
            const barraProgress = document.getElementById("id_barra_investigacion")
            barraProgress.innerText = ''
            if(escarabajo.Estado_investigacion) {
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
    escarabajos.forEach(escarabajo => {
        if(escarabajo.especie === especie) {
            const btnDescargar = document.getElementById("btnDescargarEspecie")
            btnDescargar.addEventListener('click', () => {
                const modal = document.getElementById('downloadModal');
                modal.classList.add('is-active');
                const btn = document.getElementById("downloadButton")
                btn.setAttribute("onclick", `descargarRecursos("${escarabajo.especie}")`)
            })
        }
    })
}

function descargarRecursos(especie) {
    const archivosSeleccionados = [];
    const audioCheckbox = document.getElementById("audioCheckbox")
    const spectrogramCheckbox = document.getElementById("spectrogramCheckbox")
    const imagesCheckbox = document.getElementById("imagesCheckbox")
    const techSheetCheckbox = document.getElementById("techSheetCheckbox")

    escarabajos.forEach(escarabajo => {
        if(escarabajo.especie === especie) {
            if (audioCheckbox.checked) {
                escarabajo.audios.forEach(audio => {
                    archivosSeleccionados.push({ ruta: audio, carpeta: "audios" })
                })
            }
            // if (spectrogramCheckbox.checked) {
            //     escarabajo.espectogramas.forEach(espectograma => {
            //         archivosSeleccionados.push({ ruta: espectograma, carpeta: "espectrogramas" })
            //     })
            // }
            if (imagesCheckbox.checked) {
                escarabajo.imagenes.forEach(imagen => {
                    archivosSeleccionados.push({ ruta: imagen, carpeta: "imagenes" })
                })
            }
            // if (techSheetCheckbox.checked) {
                
            //     archivosSeleccionados.push({ ruta: "resources/ficha_tecnica.txt", carpeta: "fichas_tecnicas" })
            // }
            // Uso la libreria de JSZIP para pasar de json a archivos zip
            const zip = new JSZip()
            const promesas = []

            // Entra a cada uno de los datos que se quieren descargar
            archivosSeleccionados.forEach(archivo => {
                // Se guardan los dos argumentos json en una constante ruta y otra carpeta
                const { ruta, carpeta } = archivo
                // Se obtiene el nombre dle archivo a partir de la ruta
                const nombreArchivo = ruta.split("/").pop()
                // Se crea el folder de cada una de los recursos
                const folder = zip.folder(carpeta)
        
                
                const promise = fetch(ruta)
                    .then(response => response.blob())
                    .then(blob => {
                        // Agregar el archivo a la carpeta correspondiente dentro del ZIP
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
                    console.error("Error al cargar los archivos:", error)
                })
        }

        closeModalDescargas()
    })
}

// Función para abrir el modal
function openModal() {
    // Obtener el modal por su id
    const modal = document.getElementById('modal')

    // Agregar la clase 'is-active' al modal para mostrarlo
    modal.classList.add('is-active')
}

// Función para cerrar el modal
function closeModal() {
    // Obtener el modal por su id
    const modal = document.getElementById('modal')

    // Remover la clase 'is-active' del modal para ocultarlo
    modal.classList.remove('is-active')
}

function closeModalDescargas() {

    const modal = document.getElementById('downloadModal')
    const audioCheckbox = document.getElementById("audioCheckbox")
    const spectrogramCheckbox = document.getElementById("spectrogramCheckbox")
    const imagesCheckbox = document.getElementById("imagesCheckbox")
    const techSheetCheckbox = document.getElementById("techSheetCheckbox")

    audioCheckbox.checked = false
    spectrogramCheckbox.checked = false
    imagesCheckbox.checked = false
    techSheetCheckbox.checked = false

    modal.classList.remove('is-active')
}