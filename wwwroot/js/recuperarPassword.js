document.addEventListener('DOMContentLoaded', () => {
    const formEmail = document.getElementById('formulario');
    const formCodigo = document.getElementById('form_codigo');
    const emailInput = document.getElementById('email');
    const codigoInput = document.getElementById('codigo');
    const mensajeConfirmacion = document.getElementById('mensaje_confirmacion');
    const uriEnviarCorreo = 'api/email/enviarCorreo';
    const uriVerificarCodigo = 'api/email/verificarCodigo';

    formEmail.addEventListener('submit', async (e) => {
        e.preventDefault();
        const email = emailInput.value;

        try {
            const response = await fetch(uriEnviarCorreo, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email })
            });

            if (response.ok) {
                mensajeConfirmacion.classList.remove('is-hidden');
                formCodigo.classList.remove('is-hidden');
                emailInput.disabled = true;
                console.log('Correo electrónico enviado');
            } else {
                console.error('Error al enviar el correo electrónico');
            }
        } catch (error) {
            console.error('Error al enviar la petición', error);
        }
    });

    formCodigo.addEventListener('submit', async (e) => {
        e.preventDefault();
        const email = emailInput.value;
        const codigo = codigoInput.value;

        try {
            const response = await fetch(uriVerificarCodigo, {
                method: 'POST',
                headers: {
                    'Accept': 'application/json',
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({ email, codigo })
            });

            if (response.ok) {
                console.log('Código verificado');
                window.location.href = 'restablecerPassword.html';
            } else {
                console.error('Código incorrecto');
            }
        } catch (error) {
            console.error('Error al enviar la petición', error);
        }
    });
});