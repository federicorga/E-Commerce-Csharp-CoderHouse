

using AplicacionConsola.Clases;

Usuario usuario1 = new Usuario(12, "Fede", "Garea", "Altair", 1234,"federico.garea@gmail.com");

Producto producto1 = new Producto(1, "Pera", "Es una pera", 21.15, 23.22, 5, usuario1.Id);

Venta venta1 = new Venta(14, "Se vendio una Pera", usuario1.Id);

ProductoVendido productoVendido1 = new ProductoVendido(1, producto1.Id, 2, venta1.Id);

Console.WriteLine("USUARIO:");
MostrarObjeto(usuario1);
Console.WriteLine("\n");
Console.WriteLine("PRODUCTO:");
MostrarObjeto(producto1);
Console.WriteLine("\n");
Console.WriteLine("VENTA:");
MostrarObjeto(venta1);
Console.WriteLine("\n");
Console.WriteLine("PRODUCTO VENDIDO:");
MostrarObjeto(productoVendido1);


void MostrarObjeto(object objeto)
{
    Type tipoObjeto = objeto.GetType();
    foreach (var propiedad in tipoObjeto.GetProperties())
    {
        Console.WriteLine($"{propiedad.Name}: {propiedad.GetValue(objeto)}");
    }
}