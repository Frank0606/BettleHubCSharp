const uri = 'api/escarabajo'

//Obtener a los escarabajos
let escarabajos

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
        escarabajos = data
    } catch (error) {
        alert("Error al obtener los escarabajos")
        console.error('No se puede obtener el array de escarabajos', error)
    }
}

document.addEventListener("DOMContentLoaded", () => {
    fetchEscarabajos()
    fetch("api/pregunta", {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => {
            if (!response.ok) {
                alert("Error con el carrusel")
            }
            return response.json();
        })
        .then(data => {
            mostrarPreguntas(data)
        })
        .catch(error => console.error('Error al obtener las preguntas:', error))
})

function mostrarPreguntas(data) {

    const slider = document.getElementById("slider")
    const inputRadio = document.createElement('input')

    // const inner = document.querySelector(".inner")
    const divSlide = document.createElement("div")
    const divSlideContent = document.createElement("div")
    const divColumn = document.createElement("div")
    const labelTitle = document.createElement("label")
    const pContenido = document.createElement("p")
    let contador = 1

    data.forEach(pregunta => {
        let inputRadioInner = inputRadio.cloneNode(false)

        inputRadioInner.setAttribute('type', 'radio')
        inputRadioInner.setAttribute('name', 'slider')
        inputRadioInner.setAttribute('id', `slide${contador}`)

        if(contador === 1){
            inputRadioInner.setAttribute('checked', '')
        }

        slider.appendChild(inputRadioInner)

        contador = contador + 1
    })

    const slides = document.createElement('div')
    slides.setAttribute('id', 'slides')
    slides.classList.add('p-3')

    const overflow = document.createElement('div')
    overflow.setAttribute('id', 'overflow')

    const inner = document.createElement('div')
    inner.classList.add('inner')
    
    overflow.appendChild(inner)
    slides.appendChild(overflow)
    slider.appendChild(slides)

    contador = 1

    data.forEach(pregunta => {
        const divSlideInner = divSlide.cloneNode(false)
        divSlideInner.classList.add('slide', `slide_${contador}`, 'is-align-content-center')

        const divSlideContentInner = divSlideContent.cloneNode(false)
        divSlideContentInner.classList.add('slide-content', 'columns')
        divSlideContentInner.style.height = "100%"

        const divColumnTInner = divColumn.cloneNode(false)
        divColumnTInner.classList.add('column', 'is-align-content-center', 'has-background-primary-soft')

        let labelTitleInner = labelTitle.cloneNode(false)
        labelTitleInner.classList.add('has-text-white', 'has-text-weight-bold', 'is-size-4', 'px-6')
        labelTitleInner.textContent = pregunta.pregunta_pregunta

        const divColumnPInner = divColumn.cloneNode(false)
        divColumnPInner.classList.add('column', 'is-align-content-center')

        let pContenidoInner = pContenido.cloneNode(false)
        pContenidoInner.classList.add('px-6', 'is-size-5', 'has-text-black')
        pContenidoInner.textContent = pregunta.respuesta_pregunta

        divColumnPInner.appendChild(pContenidoInner)
        divColumnTInner.appendChild(labelTitleInner)
        divSlideContentInner.appendChild(divColumnTInner)
        divSlideContentInner.appendChild(divColumnPInner)
        divSlideInner.appendChild(divSlideContentInner)
        inner.append(divSlideInner)

        contador = contador + 1
    })

    inner.style.width = `calc((${contador} - 1) * 100%)`
    const divControls = document.createElement('div')
    divControls.setAttribute('id', 'controls')

    slider.appendChild(divControls)

    const divBullets = document.createElement('div')
    divBullets.setAttribute('id', 'bullets')

    const label = document.createElement('label')

    contador = 1

    data.forEach(preguntas => {
        let labelInner = label.cloneNode(false)

        labelInner.setAttribute('for', `slide${contador}`)

        contador = contador + 1

        divBullets.appendChild(labelInner)
    })

    slider.appendChild(divBullets)
}

const grande = document.querySelector(".grande")
const punto = document.querySelectorAll(".punto")

punto.forEach( (cadaPunto, i) => {
    punto[i].addEventListener('click', () => {
        let posicion = i
        let operacion = posicion * -50

        grande.style.transform = `translateX(${operacion}%)`

        punto.forEach( (cadaPunto, i ) => {
            punto[i].classList.remove('activo')
        })

        punto[i].classList.add('activo')
    })
})

const botonBusqueda = document.getElementById('botonBusqueda')
const cajaBusqueda = document.getElementById('campoBusqueda')
const lista = document.getElementById('sugerencia')

cajaBusqueda.addEventListener('input', function () {
    const input = cajaBusqueda.value.toLowerCase();

    // Filtra los escarabajos basándote en la entrada del usuario
    const filtro = escarabajos.filter(escarabajo =>
        escarabajo.especie.toLowerCase().startsWith(input)
    );

    // Limpia la lista antes de añadir los nuevos elementos
    lista.innerHTML = "";

    // Si la entrada está vacía, asegúrate de que la lista también esté vacía
    if (input === "") {
        return;
    }

    // Añade los elementos filtrados a la lista
    filtro.forEach(escarabajo => {
        const li = document.createElement('li');
        li.classList.add('has-background-primary-soft', 'has-text-white', 'p-3')

        const a = document.createElement('a')
        a.textContent = escarabajo.especie
        a.setAttribute('src', `mostrarDescripcion(${escarabajo.especie})`)

        li.appendChild(a)
        lista.appendChild(li);
    });
});

function mostrarDescripcion(especie){
    document.cookie = 'especieBusqueda=; expires=Thu, 01 Jan 1970 00:00:00 UTC; path=/;';
    let date = new Date();
    date.setTime(date.getTime() + (2 * 60 * 60 * 1000));
    let expires = "expires=" + date.toUTCString();
    especieCookie = "especieBusqueda=" + especie + ";" + expires + "; SameSite=strict";
    document.cookie = especieCookie
}