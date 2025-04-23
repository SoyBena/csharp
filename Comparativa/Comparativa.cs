namespace Negocio;

public class Comparativa {
    private List<Articulo> Articulos = new List<Articulo>();


    public Comparativa (string fichero) {
        string? linea;
        string[] separado;

        if (!File.Exists(fichero))
            throw new ArgumentException($"El fichero \"{fichero}\" no se ha encontrado.");

        using StreamReader sr = File.OpenText(fichero);
        try {
            linea = sr.ReadLine();
            while (linea != null) {
                separado = linea.Split(";");
                AñadirArticulo(separado[0], separado[1], separado[2], Convert.ToDecimal(separado[3]));

                linea = sr.ReadLine();
            }

        } catch (Exception e) {
            System.Console.WriteLine("\n\t\t ----> ERROR: {0}\n", e.Message);
        } 
    }


    public void AñadirArticulo(string negocio, string codigo, string producto, decimal precio) {
        var i = 0;
        Articulo nuevoArticulo = new Articulo(negocio, new Producto(codigo, producto), precio);

        while (i < Articulos.Count && !Articulos[i].Equals(nuevoArticulo))
            i++;

        // Si llego al final es que no he encontrado ningún artículo como el que quiero añadir, por tanto, no se repite
        if (i == Articulos.Count)
            Articulos.Add(nuevoArticulo);
        

    }

    public void ModificarPrecio(string codigo, string vendedor, decimal NuevoPrecio) {
        int i = 0;
        
        while (i < Articulos.Count && Articulos[i].Vendedor != vendedor && Articulos[i].Producto.Codigo != codigo) {
            i++;
        }



        /*
            En este paso podríamos modificar el valor de Articulos[i].Precio,
            pero para hacerlo tendríamos que permitir la modificación
            del atributo de forma pública, es decir, fuera de la propia
            clase Artículo (para poder manipularla desde Comparativa),
            y eso no es una buena idea.

            En su lugar, machacamos y creamos un nuevo objeto Artículo con 
            el neuvo precio.

        */

        if (i != Articulos.Count) {
            Articulos[i] = new Articulo(vendedor, Articulos[i].Producto, NuevoPrecio);
        }
    }


    public void GuardarCSV(string ruta) {
        using StreamWriter sw = File.CreateText(ruta);

        foreach (Articulo art in Articulos) {
            sw.WriteLine($"{art.Vendedor};{art.Producto.Codigo};{art.Producto.Nombre};{art.Precio}");
        }
    }

    public override string ToString()
    {
        string salida = "=== Comparativa de precios ===\n";
        foreach(Articulo art in Articulos) {
            salida += $"{art.Vendedor, -25}\t{"- " + art.Producto.Nombre + " (" + art.Producto.Codigo + "): ", -30}\t{art.Precio + "€", 15}\n";
        }
        return salida;
    }

    public string ListarPreciosDeProducto(string CodigoProducto) {
        string salida = $"=== Precios del producto {CodigoProducto} ===\n";
        foreach(Articulo art in Articulos) {
            if (art.Producto.Codigo == CodigoProducto)
                salida += $"{art.Vendedor + ":", -20}\t{art.Precio, 10}€\n";
        }

        return salida;
    }
}