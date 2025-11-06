namespace tl2_tp7_2025_jm07_web.Models;

public class Presupuestos
{
    public int IdPresupuesto { get; set; }
    public string NombreDestinatario { get; set; }
    public string FechaCreacion { get; set; }
    public List<PresupuestosDetalle> Detalle { get; set; }

    public Presupuestos() { }

    public Presupuestos(int id, string nombre, string fecha)
    {
        IdPresupuesto = id;
        NombreDestinatario = nombre;
        FechaCreacion = fecha;
        Detalle = new List<PresupuestosDetalle>();
    }

    //Metodos
    public double MontoPresupuesto()
    {
        double monto = 0;
        foreach (var item in Detalle)
        {
            monto += item.producto.precio * item.cantidad;
        }
        return monto;
    }

    public double MontoPresupuestoConIva()
    {
        double montoConIVA = 0;
        foreach (var item in Detalle)
        {
            montoConIVA += item.producto.precio * item.cantidad;
        }
        return montoConIVA * 1.21;
    }

    public int CantidadProductos()
    {
        int cantidad = 0;
        foreach (var item in Detalle)
        {
            cantidad += item.cantidad;
        }
        return cantidad;
    }
}