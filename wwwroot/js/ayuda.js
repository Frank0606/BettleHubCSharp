uri = "api/ayuda"
let ayudas

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}

document.addEventListener('DOMContentLoaded', () => {
    fetch(uri, {
        method: 'GET',
        headers: {
            'Authorization': 'Bearer ' + getCookie('userToken')
        }
    })
        .then(response => response.json())
        .then(data => {
            ayudas = data
            crearSeccionesAyudas(ayudas)
        })
        .catch(error => console.log("No se obtuvieron los datos de ayuda: ", error))
})

function crearSeccionesAyudas(ayudas) {

    const divSection = document.createElement('div')
    divSection.classList.add('section')
    const divContainer = document.createElement('div')
    divContainer.classList.add('container')
    const label = document.createElement('label')
    label.classList.add('subtitle')
    const p = document.createElement('p')

    const divAyuda = document.querySelector('.div-ayuda')

    let contador = 0

    ayudas.forEach(ayuda => {
        const labelInner = label.cloneNode(false)
        labelInner.textContent = ayuda.titulo

        const pInner = p.cloneNode(false)
        pInner.textContent = ayuda.contenido

        const divContainerInner = divContainer.cloneNode(false)
        divContainerInner.appendChild(labelInner)
        divContainerInner.appendChild(pInner)

        const divSectionInner = divSection.cloneNode(false)
        
        if((contador % 2) === 0) {
            divSectionInner.classList.add('has-background-white')
        } else {
            divSectionInner.classList.add('has-background-light')
        }

        divSectionInner.appendChild(divContainerInner)

        divAyuda.appendChild(divSectionInner)

        contador++
    })
}