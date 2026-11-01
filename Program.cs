using EjercicioB1;
using EjercicioB2;
using EjercicioB3;
using EjercicioC1;
using EjercicioC2;
using EjercicioC3;
using EjercicioD1;
using EjercicioD2;
using GuiaEjercitacion2.EjercicioF.Observer;
using GuiaEjercitacion2.EjercicioF.Singleton;
using System;

public class Program {

    public static void Main(String[]args) {

        Console.WriteLine(" Ejercicio B1");
        Console.WriteLine(" -----------");
        var a = Contador.Instancia;
        var b = Contador.Instancia;
        Console.WriteLine(a.Siguiente());
        Console.WriteLine(b.Siguiente());
        Console.WriteLine(Contador.Instancia.Siguiente());
        Console.WriteLine(ReferenceEquals(a, b));

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio B2");
        Console.WriteLine(" -----------");
        var cuenta = new Cuenta(new SinPropina());
        cuenta.Mostrar(20000);
        cuenta.CambiarPropina(new Propina10());
        cuenta.Mostrar(20000);
        cuenta.CambiarPropina(new PropinaFija(1500));
        cuenta.Mostrar(20000);

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio B3");
        Console.WriteLine(" -----------");
        var canal = new Canal();
        var lu = new Fan("Lu");
        canal.Suscribir(lu);
        canal.Suscribir(new Fan("Tomi"));
        canal.Suscribir(new Estadisticas());
        canal.Publicar("Patrones en C#");
        canal.Desuscribir(lu);
        canal.Publicar("Observer en WinForms");

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio C1");
        Console.WriteLine(" -----------");
        var alarma = new Alarma();
        alarma.Suscribir(new AvisoUnico());
        alarma.Suscribir(new Luz());
        alarma.Sonar();

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio C2");
        Console.WriteLine(" -----------");
        var envio = new CalculadoraEnvio(new EnvioMoto());
        Console.WriteLine(envio.Calcular(7));

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio c3");
        Console.WriteLine(" -----------");
        var notificacion = new NotificadorMail();
        notificacion.Enviar("juan@gmail.com", "hola juan");

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio D1");
        Console.WriteLine(" -----------");
        var termo = new Termometro();
        termo.Suscribir(new PantallaCocina());
        termo.Suscribir(new AlarmaCalor());
        termo.Medir(25);
        termo.Medir(34);

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio D2");
        Console.WriteLine(" -----------");
        string tipoElegido = "JUBILADO";
        IDescuento descuento = DescuentoFactory.Crear(tipoElegido);
        Console.WriteLine(descuento.Aplicar(10000m).ToString("0")); // debe imprimir 8500

        Console.WriteLine("\n");

        Console.WriteLine(" Ejercicio F");
        Console.WriteLine(" -----------");
        var playa = new Playa(10);
        var pantalla = new PantallaLugares();
        playa.Suscribir(pantalla);
        playa.Suscribir(new CajaObserver());
        playa.Suscribir(new AlertaOcupacionObserver());
        playa.Suscribir(new BitacoraObserver());
        // ... ingresan 8 vehículos con distintos códigos de tarifa ...
        playa.Ingresar("AB123CD", "HORA");
        playa.Ingresar("AC456EF", "ESTADIA");
        playa.Ingresar("AD789GH", "NOCHE");
        // ...
        playa.Egresar("AB123CD", 150); // HORA, 2 h 30 min -> $ 3.600
        playa.Egresar("AC456EF", 900); // ESTADIA, 15 h -> $ 9.600
        playa.Desuscribir(pantalla); // la pantalla deja de mostrar
        playa.Egresar("AD789GH", 600); // NOCHE -> $ 4.500
        try { playa.Ingresar("AZ999ZZ", "SEMANAL"); }
        catch (ArgumentException ex) { Console.WriteLine("Error: " + ex.Message); }
        Bitacora.Instancia.MostrarTodo();
        Console.ReadKey();
    }
}