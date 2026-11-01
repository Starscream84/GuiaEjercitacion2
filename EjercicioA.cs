using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GuiaEjercitacion2
{
    public class EjercicioA
    {
        // ==============================
        // SECCIÓN A - Pregunta 1
        // Respuesta: c - El constructor private AppLogger() { }.
        // ¿Porqué?: Al ser private evita que otros objetos utilicen el operador new.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 2
        // Respuesta: a - La instancia se crea la primera vez que alguien la pide, no antes.
        // ¿Porqué?: Para ahorrar recursos en caso de que nunca se use.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 3
        // Respuesta: d) Reemplazar un condicional que elige entre variantes de un algoritmo por clases intercambiables.
        // detrás de una interfaz.
        // ¿Porqué?: Si mañana necesitas otra variante del algoritmo, solo agregas una clase nueva. 
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 4
        // Respuesta: b) Usa una estrategia a través de la interfaz y le delega el cálculo, sin saber cuál es.
        // ¿Porqué?: Porque el contexto es independiente de las estrategias concretas. Podes agregar nuevos algoritmos
        // o modificar los existentes sin cambiar el codigo de la clase contexto.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 5
        // Respuesta: c - El medio de pago llega como texto ("QR", "EFECTIVO") desde un ComboBox y desde un JSON, y
        // hay que crear el objeto correcto en varios lugares.
        // ¿Porqué?: Porque permite centralizar la creacion de objetos.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 6
        // Respuesta: a - En Factory Method, una superclase con lógica de negocio declara el método de creación y cada
        // subclase decide qué producto concreto crear.
        // ¿Porqué?: Porque puede ser abstracta a diferencia de Simple Factory que es una clase concreta y no puede intercambiarse.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 7
        // Respuesta: b) Una lista de referencias a objetos que implementan la interfaz suscriptora.
        // ¿Porqué?: Para avisar solo a ellos cuando algo pasa.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 8
        // Respuesta: d) El controller le sigue avisando a un formulario destruido: puede saltar una excepción y el objeto
        // nunca se libera de memoria.

        // ¿Porqué?: Porque la relacion se arma y desarma EN EJECUCION, cerrar el formulario no lo saca de la lista del controller.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 9
        // Respuesta: b - Suscriptor
        // ¿Porqué?: El boton es el notificador, el metodo(btnGuardar_Click), el suscriptor.
        // ==============================

        // ==============================
        // SECCIÓN A - Pregunta 10
        // Respuesta: c) Creás una clase que implementa la interfaz suscriptora y la suscribís en Program.cs
        // ¿Porqué?:Open/Closed: Con cada interesado nuevo, creas una clase nueva sin necesidad de modificar el codigo. 
        // ==============================
    }
}
