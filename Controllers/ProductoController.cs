using Microsoft.AspNetCore.Mvc;
using tl2_tp7_2025_jm07_web.Models;
using tl2_tp7_2025_jm07_web.Repositorios;

namespace tl2_tp7_2025_jm07_web.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductosController: ControllerBase
{
    private ProductoRepository productoRepository;
    public ProductosController()
    {
        productoRepository = new ProductoRepository();
    }
    //A partir de aquí van todos los Action Methods (Get, Post,etc.)
    [HttpPost("AltaProducto")]
    public ActionResult<string> AltaProducto(Producto nuevoProducto)
    {
        productoRepository.CrearProducto(nuevoProducto);
        return Ok("Producto dado de alta exitosamente.");
    }

    [HttpPut("ModificarNombreProducto")]
    public ActionResult<string> ModificarNombreProducto(int id, Producto producto)
    {
        productoRepository.ModificarProducto(id, producto);
        return Ok("Nombre del producto modificado exitosamente.");
    }

    [HttpGet("ListarProductos")]
    public ActionResult<List<Producto>> ListarProductos()
    {
        List<Producto> listadoProductos;
        listadoProductos = productoRepository.ListarTodosLosProductos();
        return Ok(listadoProductos);
    }

    [HttpGet("ObtenerDetalleProducto")]
    public ActionResult<List<Producto>> ObtenerDetalleProducto(int id)
    {
        Producto? P = productoRepository.ObtenerPorId(id);
        if (P != null)
        {
            return Ok(P);
        }
        return NotFound($"No se ha encontrado un producto con el ID {id} ingresado.");
    }

    [HttpDelete("EliminarProducto")]
    public ActionResult EliminarProducto(int id)
    {
        bool eliminado = productoRepository.EliminarProducto(id);
        if (eliminado)
        {
            return NoContent();// HTTP 204 (Eliminación exitosa)
        }
        else
        {
            return NotFound($"No se encontró el producto con ID {id} para eliminar.");
        }
    }
}
