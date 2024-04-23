document.addEventListener("DOMContentLoaded", () => {
    fetch("api/pregunta", {
        method: 'GET'
    })
        .then(response => response.json())
        .then(data => mostrarPreguntas(data))
})

function mostrarPreguntas(data) {
    const carrousel = document.getElementById("carrousel")

    data.forEach(pregunta => {
        
    })
}