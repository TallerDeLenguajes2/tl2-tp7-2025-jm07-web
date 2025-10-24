namespace tl2_tp7_2025_jm07_web.Models;
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