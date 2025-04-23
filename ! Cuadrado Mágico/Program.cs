public class Program
{
    public static void Main(string[] args) {
        Cuadrado_Magico.Inicializar(3);
    }

}

/*
    - PRECONDICIÓN: Numero impar de filas y columnas (y mismo numero de ambas)
    - Empiezas por la fila central en la casilla que está más a la derecha, ahí va el uno
    - Para ir a la siguiente casilla: la siguiente de la última es la pregunta
        - Siguiente columna y siguiente fila si está libre (diagonal)
        - Si la siguiente está ocupada, entonces avanzar es ir hacia atrás SOLO en columnas
*/
public class Cuadrado_Magico {
    public static void Inicializar(int dimensiones) {
        int[,] cuadrado = new int[dimensiones,dimensiones];

        int siguienteNumero = 1;
        int columna = dimensiones - 1;
        int fila = dimensiones / 2;

        int columnaAnterior = columna;
        int filaAnterior = fila;

        do {

            // Compruebo que las coordenadas existan en los límites de la tabla
            if (columna > cuadrado.GetLength(1) - 1) {
                columna = 0;
            }
            
            if (fila > cuadrado.GetLength(0) - 1) {
                fila = 0;
            }

            // Ahora que se que existen, compruebo si la casilla está libre
            if (cuadrado[fila, columna] == 0) {
                Rellenar(ref cuadrado, ref fila, ref columna, ref columnaAnterior, ref filaAnterior, ref siguienteNumero);
            } else {
                columna = columnaAnterior - 1;

                // Si tras retroceder una columna obtenemos un valor negativo
                if (columna < 0)
                    columna = dimensiones - 1;
                fila = filaAnterior;

                Rellenar(ref cuadrado, ref fila, ref columna, ref columnaAnterior, ref filaAnterior, ref siguienteNumero);
            }
            siguienteNumero++;

        } while (siguienteNumero < dimensiones * dimensiones + 1);

        Mostrar(cuadrado);
    }

    private static void Rellenar(ref int[,] cuadrado, ref int fila, ref int columna, ref int columnaA, ref int filaA, ref int num) {
        cuadrado[fila, columna] = num;

        columnaA = columna;
        filaA = fila;

        columna += 1;
        fila += 1;
    }

    private static void Mostrar(int[,] cuadrado) {
        for (int f = 0; f < cuadrado.GetLength(0); f++) {
            for (int c = 0; c < cuadrado.GetLength(1); c++) {
                Console.Write($"{cuadrado[f, c], 5} ");
            }

            Console.WriteLine();
        }
    }
}

/* 
    /    0  1  2

    0    4, 3 ,8
    1    9, 5, 1   (1, 2) -> (2, 3) | (2, 0) -> (3, 1) | (0 , 1) -> (1,2) | (0, 0) -> (1,1)
    2    2, 7, 6

        x, x ,x
        x, x, x
        x, x, x

*/