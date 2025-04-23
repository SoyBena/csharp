namespace PersonasEstudiantes;
public class DNI {
    public char lDni {get; private set;}

    public int nDni {get; private set;}

    private const string LETRAS = "TRWAGMYFPDXBNJZSQVHLCKE";

    public DNI(int num, char let) {
        let =  char.ToUpper(let);
        if (LetraValida(num) != let)
            throw new ArgumentException("La letra del DNI no se corresponde con el número indicado");

        nDni = num;
        lDni = let;
    }

    public override bool Equals(object? obj) {

        if (obj == null || GetType() != obj.GetType())
            return false;

        DNI otro = (DNI)obj;

        return nDni == otro.nDni;
    }

    public override string ToString()
    {
        return $"{nDni}{lDni}";
    }

    public override int GetHashCode()
    {
        return nDni.GetHashCode();
    }


    private static char LetraValida(int num) {
        return LETRAS[num % 23];
    }

}