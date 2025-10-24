public class PresupuestosDetalle
{
    public Productos ?producto {get; set; }
    public int cantidad {get; set; }

    public PresupuestosDetalle(Productos produc, int cant)
    {
        producto = produc;
        cantidad = cant;
    }
}