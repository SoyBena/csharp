public class ADN {
	public string Secuencia {get; private set;}

	private static int LONG_CADENA = 8;
	public ADN(string secuencia) {
		if (secuencia.Length != LONG_CADENA)
			throw new ArgumentException($"La cadena debe de tener {LONG_CADENA} caracteres");
		Secuencia = secuencia.ToUpper();
	}

	public override bool Equals(object? obj)
	{
		if (obj == null || GetType() != obj.GetType())
			return false;

		ADN otro = (ADN)obj;
		if (Secuencia.Length != otro.Secuencia.Length)
			return false;

		bool resultado = false;
		int i, j;

		for (i = 0; i < Secuencia.Length && !resultado; i++)
		{
			j = 0;

			/* 
				* El uso del módulo nos sirve para asegurarnos que,
				* una vez llegemos la final de la primera secuencia,
				* si los valores coinciden continúe buscando por el principio.

				* Siendo la longitud 8, si la posición que se está comprobando
				* alcanza la última posición válida, es decir, 7, cuando j incremente, 
				* la posición a comprobar sería 8, pero el módulo de la división entera
				* de 8 entre 8 es 0: pasamos a comprobar por el principio de la cadena.

				* De esta forma, la siguiente para i + j sería 9, pero 9 % 8 = 1, por tanto
				* estariamos comprobando la posición 1 de la cadena.
			*/


			while (j < Secuencia.Length && Secuencia[(i + j) % Secuencia.Length] == otro.Secuencia[j])
				j++;
			

			// Si al llegar al final de la búsqueda j llegó al final entonces todos los caracteres coindicieron
			if (j == Secuencia.Length)
				resultado = true;
		}
		return resultado;
	}

	public override int GetHashCode() {
		return (Secuencia).GetHashCode();
	}
}
	