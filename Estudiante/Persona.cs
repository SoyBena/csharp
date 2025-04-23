namespace PersonasEstudiantes;

public class Persona {
    public string Nombre {get; protected set;}
    public int Edad {get; protected set;}
    public DNI _dni {get; private set;}

    public Persona(string nombre, int edad, int num, char letra) : this(edad, num, letra) {
        Nombre = nombre;
    }

    public Persona(int edad, int num, char letra) {
        if (edad < 0)
            throw new ArgumentException("La edad no puede ser negativa");
        
        Nombre = "Desconocido";
        Edad = edad;
        _dni = new DNI(num, letra);

    }

    public override bool Equals(object? obj) {
        if (obj == null || !(obj is Persona))
            return false;
        
        Persona otro = (Persona)obj;
        return _dni.Equals(otro._dni);
    }

    public override string ToString()
    {
        return $"{Nombre}, {Edad} años. [{_dni}]";
    }

    public override int GetHashCode()
    {
        return _dni.GetHashCode();
    }

}