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
        Nombre: usuario,
        Contrasena: contrasena
    }

    fetch(uri, {
        method: 'POST',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(usuarioLogin)
    })
        .then(async response => {
            if (response.ok) {
                const result = await response.json();
                const accessToken = await result["accessToken"];
                if (!accessToken) {
                    console.error('El token de acceso no está presente en la respuesta.');
                    return;
                }
                const userCookie = "userToken=" + accessToken + "; expires=Mon, 01 Jul 2024 12:00:00 GMT; samesite=strict";
                document.cookie = userCookie;
                window.location.href = "paginaPrincipalB.html";
            } else if (response.status === 401) {
                console.error('Credenciales incorrectas.');
            } else {
                console.error('Error desconocido al iniciar sesión.');
            }
        })
        .catch(error => console.error('No se pudo iniciar sesión. ', error));
    
    
}