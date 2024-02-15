using System;

// Clase abstracta Alumno
public abstract class Alumno
{
    public string Nombre { get; set; }
    public string NumeroCuenta { get; set; }
    public string Email { get; set; }

    // Método para datos del alumno y asignatura
    public abstract void Imprimir();
}

// Clase Asignatura que hereda de Alumno
public class Asignatura : Alumno
{
    public string NombreAsignatura { get; set; }
    public string Horario { get; set; }
    public string Docente { get; set; }

    // Implementación del método Imprimir
    public override void Imprimir()
    {
        Console.WriteLine($"Datos del alumno:\nNombre: {Nombre}\nNúmero de cuenta: {NumeroCuenta}\nEmail: {Email}");
        Console.WriteLine($"Datos de la asignatura:\nNombre: {NombreAsignatura}\nHorario: {Horario}\nDocente: {Docente}");
    }
}

// Interfaz INota
public interface INota
{
    double CalcularNotaFinal(double nota1, double nota2, double nota3);
    string MensajeNota(double notaFinal);
}

// Clase Nota que implementa INota
public class Nota : INota
{
    private double nota1;
    private double nota2;
    private double nota3;

    // Constructor con parámetros
    public Nota(double nota1, double nota2, double nota3)
    {
        this.nota1 = nota1;
        this.nota2 = nota2;
        this.nota3 = nota3;
    }

    // Constructor sin parámetros
    public Nota()
    {
        // Puedes inicializar las notas aquí si es necesario
    }

    // Implementación del método CalcularNotaFinal
    public double CalcularNotaFinal(double nota1, double nota2, double nota3)
    {
        return (nota1 + nota2 + nota3) / 3;
    }

    // Implementación del método MensajeNota
    public string MensajeNota(double notaFinal)
    {
        if (notaFinal >= 90)
            return "Sobresaliente";
        else if (notaFinal >= 80)
            return "Muy Bueno";
        else if (notaFinal >= 60)
            return "Bueno";
        else
            return "Reprobado";
    }
}

class Program
{
    static void Main()
    {
        try
        {
            // Captura los datos del alumno y la asignatura
            Asignatura asignatura = new Asignatura
            {
                Nombre = "Juan Pérez",
                NumeroCuenta = "123456",
                Email = "carlos@unitec.edu",
                NombreAsignatura = "Programación II",
                Horario = "6:00 pm - 7:30 pm",
                Docente = "ing. "
            };

            // Captura las notas parciales
            double nota1 = 28;
            double nota2 = 35;
            double nota3 = 42;

            // Validación de notas
            if (nota1 > 30 || nota2 > 30 || nota3 > 40)
            {
                Console.WriteLine("Error: Las notas no deben exceder los límites.");
                return;
            }

            // Cálculo de la nota final
            Nota notas = new Nota(nota1, nota2, nota3);
            double notaFinal = notas.CalcularNotaFinal(nota1, nota2, nota3);

            // Mensaje según rango de notas
            string mensaje = notas.MensajeNota(notaFinal);
            Console.WriteLine($"Nota final: {notaFinal:F2} ({mensaje})");

            // Imprimir datos del alumno y asignatura
            asignatura.Imprimir();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
