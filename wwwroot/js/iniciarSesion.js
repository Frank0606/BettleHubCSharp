const uri = 'api/cuenta'

document.addEventListener("keyup", function (event) {
    const btnIniciarSesion = document.getElementById("btnIniciarSesion")
    if (event.key === 13) {
        btnIniciarSesion.click();
    }
});

const formIniciarSesion = document.getElementById("formIniciarSesion")

formIniciarSesion.addEventListener("submit", (e) => {
    e.preventDefault()
    document.getElementById("btnIniciarSesion").classList.add('is-loading')
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

                const rol = result["rol"]
                const tokenCookie = "userToken=" + accessToken + "; expires=Mon, 01 Jul 2024 12:00:00 GMT; SameSite=strict";
                document.cookie = tokenCookie;
                const rolCookie = "userRol=" + rol + "; expires=Mon, 01 Jul 2024 12:00:00 GMT; SameSite=strict";
                document.cookie = rolCookie;
                
                if(getCookie('userRol') === "Administrador") {
                    window.location.href = "paginaPrincipalA.html";
                } else {
                    if (getCookie('userRol') === "Biologo") {
                    window.location.href = "paginaPrincipalB.html";
                    } else {
                        console.log("No tiene un rol")
                    }
                }
            } else if (response.status === 401) {
                console.error('Credenciales incorrectas.');
                alert("Usuario o contraseña incorrecta")
            } else {
                console.error('Error desconocido al iniciar sesión.');
                alert("Hubo un error en el sistema")
            }
        })
        .catch(error => console.error('No se pudo iniciar sesión. ', error));
}

function getCookie(name) {
    const cookieValue = document.cookie.match('(^|[^;]+)\\s*' + name + '\\s*=\\s*([^;]+)');
    return cookieValue ? cookieValue.pop() : '';
}