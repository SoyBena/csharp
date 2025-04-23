namespace Negocio;

public class Articulo {
    public string Vendedor {get; private set;}
    public Producto Producto {get; private set;}
    public decimal Precio {get; private set;}



    public Articulo(string vendedor, Producto producto, decimal precio) {  
        Vendedor = vendedor;
        Producto = producto;
        Precio = precio;
    }


    public override bool Equals(object? obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;
        Articulo otro = (Articulo)obj;
        return Vendedor.ToLower() == otro.Vendedor.ToLower() && Producto.Codigo.ToLower() == otro.Producto.Codigo.ToLower();
    }

    public override int GetHashCode()
    {
        return (Vendedor.ToLower(), Producto.Codigo.ToLower()).GetHashCode();
    }
}