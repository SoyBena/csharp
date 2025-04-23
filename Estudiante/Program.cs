using PersonasEstudiantes;


public class Program
{
    public static void Main(string[] args)
    {
        Persona p1 = new Persona("Paco", 21, 12345678, 'Z');
        Estudiante e1 = new Estudiante("Juana", 84, 12345678, 'Z');

        Persona p2 = new Persona(53, 12345678, 'Z');

        e1.Calificar("Biología", (float)8.9);
        e1.Calificar("Lengua", (float)3.1);
        e1.Calificar("Lengua", (float)10);

        Estudiante e2 = new Estudiante("Juana", 84, 12345678, 'Z');
        e2.Calificar("Biología", (float)8.9);
        e2.Calificar("Lengua", (float)3.1);
        e2.Calificar("Lengua", (float)8);


        // System.Console.WriteLine($"{e1.NotaMedia():f02}");
        // System.Console.WriteLine(e1.CompareTo(e2));
        // System.Console.WriteLine(e2.CompareTo(e1));

        System.Console.WriteLine(e1._dni);
        
        System.Console.WriteLine(e1);
        System.Console.WriteLine();
        System.Console.WriteLine(p1);

        // System.Console.WriteLine(p1.Equals(e1));
        // System.Console.WriteLine(e1.Equals(p1));
        // System.Console.WriteLine(p2.Equals(p1));

        // Persona p3 = new Persona(21, 12345678, 'Z');
        // System.Console.WriteLine(p3);


    }
}