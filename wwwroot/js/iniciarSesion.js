const uri = 'api/cuenta'

const formIniciarSesion = document.getElementById("formIniciarSesion")

formIniciarSesion.addEventListener("submit", (e) => {
    e.preventDefault()
    iniciarSesion()
})

function iniciarSesion() {
    const usuario = document.getElementById("usuarioLogin").value.trim()
    const contrasena = document.getElementById("contrasenaLogin").value.trim()

    const usuarioLogin = {
        Usuario_biologo: usuario,
        Contrasena_biologo: contrasena
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuarioLogin)
    })
        .then(response => console.log(response.json()))
        .then(() => window.location.href = "paginaPrincipalB.html")
        .catch(error => console.error('No se pudo iniciar sesion. ', error))
        // document.cookie = "expires=Mon, 29 Apr 2024 12:00:00 UTC; path=/; user=" + JSON.stringify(response.json())
}