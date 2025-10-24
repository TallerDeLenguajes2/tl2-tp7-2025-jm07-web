namespace tl2_tp7_2025_jm07_web.Models;
public class Productos
{
    public int idProducto {get; set; }
    public string ?descripcion {get; set; }
    public float precio {get; set; }

    public Productos(int id, string descripcion, float precio)
    {
        idProducto = id;
        this.descripcion = descripcion;
        this.precio = precio;
    }
}