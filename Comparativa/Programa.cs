using Negocio;

public class Programa {
    public static void Main() {
        Comparativa comp = new Comparativa("HojaCalculo.csv");
        comp.AñadirArticulo("MediaMarkt", "P002", "Smartphone", (decimal)599.99);

        comp.AñadirArticulo("OtroVendedor", "P001", "Laptop", (decimal)1200.50);
        comp.AñadirArticulo("OtroVendedor", "P001", "Laptop", (decimal)1200.50);
        
        comp.ModificarPrecio("P001", "Amazon", (decimal)1150.00);

        System.Console.WriteLine(comp);
        Console.WriteLine(comp.ListarPreciosDeProducto("P001"));
        Console.WriteLine(comp.ListarPreciosDeProducto("P002"));

        comp.GuardarCSV("datos_actualizados.csv");
    }
}