    public class Program {
        public static void Main(string[] args) {
            ADN cadena1 = new ADN("ATGCGTAT");
            ADN cadena2 = new ADN("ATATGCGT");
            System.Console.WriteLine(cadena1.Equals(cadena2));
            System.Console.WriteLine(cadena2.Equals(cadena1));
        }
    }