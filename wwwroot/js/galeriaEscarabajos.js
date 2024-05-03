
let galleryImages = []
let escarabajos
// Obtén todas las imágenes de la galería
const uri = 'api/escarabajo'

document.addEventListener('DOMContentLoaded', () => {
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
            openModal(image.getAttribute("src"))
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
            parrafo.classList.add('mb-6', 'has-text-justified')
            divInfo.appendChild(parrafo)
            mostrarCoordenadas(escarabajo.especie)
            mostrarImagenes(escarabajo.especie)
        }
    })
}

function mostrarImagenes(especie) {
    const img = document.createElement('img')
    escarabajos.forEach(escarabajo => {
        if (escarabajo.especie === especie) {
            const divFotos = document.getElementById('columna_fotos')
            escarabajo.imagenes.forEach(imagen => {
                divFotos.innerHTML = ''
                let imagenImg = img.cloneNode(false)
                imagenImg.setAttribute('src', `${imagen}`)
                imagenImg.setAttribute('id', 'modal-image')
                imagenImg.style.width = "100%"
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

// Función para abrir el modal
function openModal(clickedImage) {
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