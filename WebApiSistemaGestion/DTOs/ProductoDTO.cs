namespace WebApiSistemaGestion.DTOs
{
    //DTO es un objeto plano de transferencia.

    //Lo que se refleja en el DTO se refleja en lo basico de service es decir estas propiedades deben ser igual en service y en el DTO

    //Las propiedades de DTO son los mismos datos de la BD todos los demas datos que vemos en services son de las relaciones que genero entity framework para poder trabajar con el mapeo de objetos. para abstrer como se manipula una base de datos.

    //Como no siempre uno que crea un producto necesita mas informacion que la basica para crearlo se crea el DTO donde si vamos a productoService se vera que tiene mas elementos. al crear un producto si dejamos solo el service nos pedira agregar aparte ventas y otras cosas mas.
    //En algun momento uno necesita crear solo un producto sin necesidad de agregar todas las otras entidades.
    public class ProductoDTO
    {
        public int Id { get; set; }
        public string Descripciones { get; set; } = null!; // descripcion al no tener ? no acepta valores null
        public decimal? Costo { get; set; } // dice que puede ser nuleable osea que acepta valores null
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
