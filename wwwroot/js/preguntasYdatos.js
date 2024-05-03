document.addEventListener("DOMContentLoaded", () => {
    fetch("api/pregunta", {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Error al realizar la solicitud.');
            }
            return response.json();
        })
        .then(data => {
            mostrarPreguntas(data)
        })
        .catch(error => console.error('Error al obtener las preguntas:', error))
})

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

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