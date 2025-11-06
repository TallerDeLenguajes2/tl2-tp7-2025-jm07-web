using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_jm07_web.Models;
using tl2_tp7_2025_jm07_web.Repositorios;

namespace tl2_tp7_2025_jm07_web.Controllers;

[ApiController]
[Route("[controller]")]
public class PresupuestosController: ControllerBase
{
    private PresupuestosRepository presupuestosRepository;
    public PresupuestosController()
    {
        presupuestosRepository = new PresupuestosRepository();
    }
    //A partir de aquí van todos los Action Methods (Get, Post,etc.)

    [HttpPost("AltaPresupuesto")]
    public ActionResult<string> AltaPresupuesto(Presupuestos nuevoPresupuesto)
    {
        presupuestosRepository.CrearPresupuesto(nuevoPresupuesto);
        return Ok("Presupuesto dado de alta exitosamente");
    }

    [HttpGet("ListarPresupuestos")]
    public ActionResult<List<Producto>> ListarPresupuestos()
    {
        List<Presupuestos> listadoProsupuestos;
        listadoProsupuestos = presupuestosRepository.ListarTodosLosPresupuestos();
        return Ok(listadoProsupuestos);
    }

    [HttpGet("ObtenerPresepuesto")]
    public ActionResult<List<Producto>> ObtenerPresupuesto(int id)
    {
        Presupuestos? P = presupuestosRepository.ObtenerPorId(id);
        if (P != null)
        {
            return Ok(P);
        }
        return NotFound($"No se ha encontrado un presupuesto con el ID {id} ingresado.");
    }

    [HttpPost("AgregarProductoYCantidadEnPresupuesto")]
    public ActionResult AgregarProductoYCantidadEnPresupuesto(int idPresupuesto, int idProducto, int cant)
    {
        bool exito = presupuestosRepository.InsertarProductoYCantidadEnPresupuesto(idPresupuesto, idProducto, cant);
        if (exito)
        {
            return Ok("Presupuesto dado de alta exitosamente");
        } else
        {
            return BadRequest("Los IDs ingresados deben exitir y la cantidad debe ser positiva.");
        }  
    }

    [HttpDelete("EliminarPresupuesto")]
    public ActionResult EliminarPresupuesto(int id)
    {
        bool eliminado = presupuestosRepository.EliminarPresupuesto(id);
        if (eliminado)
        {
            return NoContent();// HTTP 204 (Eliminación exitosa)
        }
        else
        {
            return NotFound($"No se encontró el presupuesto con ID {id} para eliminar.");
        }
    }
}