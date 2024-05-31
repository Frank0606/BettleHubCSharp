using BettleHubCsharp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace BettleHubCsharp.Data.Seed
{
    public class SeedAyuda : IEntityTypeConfiguration<Ayuda>
    {
        public void Configure(EntityTypeBuilder<Ayuda> builder)
        {
            builder.HasData(
                new Ayuda
                {
                    Id = Guid.NewGuid().ToString(),
                    Titulo = "Documentación sobre la página",
                    Subtitulo = "Información detallada sobre cómo funciona la página y la tecnología detrás de ella.",
                    Contenido = "La página Beetle-finder está diseñada para permitir a los biólogos clasificar y registrar escarabajos de la familia Passalidae de una manera eficiente. Utiliza tecnologías modernas como C# para ofrecer una experiencia fluida y segura."
                },
                new Ayuda
                {
                    Id = Guid.NewGuid().ToString(),
                    Titulo = "Sobre qué trata la aplicación",
                    Subtitulo = "Descripción general de la aplicación y sus objetivos.",
                    Contenido = "Beetle-finder es una aplicación destinada a ayudar a los biólogos en la clasificación y registro de escarabajos, centrándose especialmente en la familia Passalidae. Su objetivo principal es proporcionar una herramienta fácil de usar y eficiente para este propósito."
                },
                new Ayuda
                {
                    Id = Guid.NewGuid().ToString(),
                    Titulo = "Preguntas generales",
                    Subtitulo = "Respuestas a las preguntas más frecuentes sobre el uso de la plataforma.",
                    Contenido = @"1. ¿Qué es Beetle-finder? Beetle-finder es una aplicación diseñada para ayudar a los biólogos en la clasificación y registro de escarabajos, especialmente de la familia Passalidae.
                    2. ¿Por qué solo hablamos de la familia Passalidae? Nos enfocamos en la familia Passalidae porque es una de las familias de escarabajos más diversas y relevantes para la investigación biológica.
                    3. ¿Cómo hago la clasificación de mi escarabajo para identificarlo? Puedes utilizar las funciones de búsqueda y clasificación de Beetle-finder para identificar y clasificar tu escarabajo según características específicas."
                },
                new Ayuda
                {
                    Id = Guid.NewGuid().ToString(),
                    Titulo = "Guía de uso",
                    Subtitulo = "Una pequeña guía paso a paso sobre cómo utilizar las principales características de la aplicación.",
                    Contenido = @"Inicio de Sesión:
                    Para acceder a las funcionalidades de la plataforma, primero debes iniciar sesión.
                    En la página de inicio de sesión, ingresa tu correo electrónico y contraseña. Si no tienes una cuenta, contacta al administrador para obtener acceso.

                    Administración de Biólogos:
                    En esta sección podrás administrar los biólogos registrados en la plataforma.
                    Mostrar:
                    Para visualizar la lista de biólogos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, correos electrónicos, edades y teléfonos de los biólogos.
                    Agregar:
                    Para agregar un nuevo biólogo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo biólogo, como nombre, correo electrónico, edad, teléfono y contraseña.

                    Administración de Escarabajos:
                    En esta sección podrás administrar los escarabajos registrados en la plataforma.
                    Mostrar:
                    Para visualizar la lista de escarabajos registrados, haz clic en el enlace 'Mostrar' ubicado en la barra de navegación. Se abrirá una tabla que muestra los nombres, especies, hábitats y otros datos relevantes de los escarabajos.
                    Agregar:
                    Para agregar un nuevo escarabajo, haz clic en el enlace 'Agregar' ubicado en la barra de navegación. Se abrirá un modal donde podrás ingresar los datos del nuevo escarabajo, como nombre, especie, hábitat y características adicionales.

                    Galería de Escarabajos:
                    En esta sección podrás visualizar imágenes de los escarabajos registrados en la plataforma.
                    Para acceder a la galería, selecciona la opción 'Galería' en la barra de navegación. Aquí podrás ver imágenes y detalles de los escarabajos, facilitando su identificación y estudio.

                    Clasificador:
                    La página de Clasificador permite a los biólogos clasificar los escarabajos a partir de grabaciones de audio. Aquí se describen los pasos para utilizar la página:

                    1. Cargar Audio:
                    Para cargar un archivo de audio, selecciona el botón 'Subir audio'. Se abrirá un diálogo donde podrás elegir el archivo de audio desde tu dispositivo. Asegúrate de que el archivo esté en un formato compatible y que el nombre del archivo se muestre después de seleccionarlo.

                    2. Ingresar Datos:
                    - Biólogo: Este campo muestra el nombre del biólogo que está realizando la clasificación. Está deshabilitado para edición directa.
                    - Coordenadas: Ingrese las coordenadas del lugar donde se registró el audio del escarabajo.

                    3. Previsualización del Audio:
                    Después de cargar el audio, se mostrará un reproductor de audio donde podrás escuchar el archivo cargado.

                    4. Clasificar:
                    Presiona el botón 'Clasificar' para procesar el audio. La aplicación analizará el audio y mostrará los resultados de la clasificación.

                    Resultado:
                    Una vez que se complete la clasificación, se mostrará una imagen del escarabajo clasificado, el nombre científico y el porcentaje de certeza de la clasificación. Si la sección de resultados está oculta, se mostrará al completarse la clasificación."
                }
            );
        }
    }
}
