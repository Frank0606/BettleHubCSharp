let audioFile
const uri = "api/file"

document.addEventListener('DOMContentLoaded', () => {
    // Metodos para el manejo del nombre del biologo en el input
    const jwtDecodificado = jwt_decode(getCookie('userToken'))

    const userName = jwtDecodificado["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];

    const inputBiologo = document.getElementById("biologoClasificar")
    inputBiologo.value = userName

    // Metodos para la clasificacion del audio
    document.getElementById('audioInput').addEventListener('change', function(event) {
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
})

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)')
    return cookieValue ? cookieValue.pop() : ''
}

function clasificarAudio(){
    if (audioFile) {
        const fileAudio = new FormData(audioFile)
        fetch(uri, {
            method: 'POST',
            body: fileAudio
        })
            .then(response => response.json())
            .then(data => console.log(data))
            .catch(error => alert("Error al clasificar el audio"))
    } else {
        alert("Por favor, selecciona un archivo de audio primero.")
    }
}