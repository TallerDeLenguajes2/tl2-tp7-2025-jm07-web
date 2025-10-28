namespace tl2_tp7_2025_jm07_web.Models;

public class Producto
{
    public int idProducto { get; set; }
    public string descripcion { get; set; }
    public int precio { get; set; }

    public Producto() { }

    public Producto(int id, string descripcion, int precio)
    {
        idProducto = id;
        this.descripcion = descripcion;
        this.precio = precio;
    }
}