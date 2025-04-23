namespace PersonasEstudiantes;

public class Calificacion {
    public string NombreAsignatura {get; private set;}
    public float Nota {get; private set;}


    public Calificacion(string nombre, float nota) {
        if (nota < 0 || nota > 10)
            throw new ArgumentException("La nota tiene que estar entre 0 y 10");

    
        NombreAsignatura = nombre;
        Nota = nota;
    }

    public override string ToString()
    {
        return $"{NombreAsignatura}: {Nota}";
    }
}