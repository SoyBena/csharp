namespace PersonasEstudiantes;

public class Estudiante : Persona, IComparable<Estudiante> {
    private List<Calificacion> Calificaciones;


    public Estudiante(int edad, int num, char letra) : base(edad, num, letra) 
    {
        Calificaciones = new List<Calificacion>();
    }

    public Estudiante(string nombre, int edad, int num, char letra) : base(nombre, edad, num, letra) 
    {
        Calificaciones = new List<Calificacion>();
    }

    public void Calificar(string asig, float nota) {
        Calificacion calif = new Calificacion(asig, nota);
        int i = 0;

        // Uso de la búsqueda lineal para ordenar descendientemente las calificaciones al agregarlas
        while (i < Calificaciones.Count && nota <= Calificaciones[i].Nota)
            i++;

        if (i != Calificaciones.Count) // Si me he salido antes del final es que mi nota es mayor que la actual para Calificaciones[i], así que la meto
            Calificaciones.Insert(i, calif);
        else // Si he llegado al final de la lista sin encontrar nada la agrego al final porque es la mas pequeña
            Calificaciones.Add(calif);
    }


    public float NotaMedia() {
        float media = 0;
        
        foreach (Calificacion calif in Calificaciones)
            media += calif.Nota;
        
        return Calificaciones.Count > 0 ? media / Calificaciones.Count : -1;
    }

    public int CompareTo(Estudiante? otro) {
        int resultado;

        // Cualquier instancia es mayor que null
        if (otro == null || NotaMedia() > otro.NotaMedia()) 
            resultado = 1;
        else if (NotaMedia() < otro.NotaMedia())
            resultado = -1;
        else
            resultado = 0;

        return resultado;
    }
    public override string ToString() {
        string salida = base.ToString() + $"\n - Nota Media: {NotaMedia():f02}\n";
        foreach (Calificacion calif in Calificaciones)
            salida += $"   * {calif}\n";
        
        return salida;
    }

    public override int GetHashCode()
    {
        return (Nombre, Edad, _dni, NotaMedia()).GetHashCode();
    }
}