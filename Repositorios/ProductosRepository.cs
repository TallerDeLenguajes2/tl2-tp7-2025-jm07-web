using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;
using tl2_tp7_2025_jm07_web.Models;

namespace tl2_tp7_2025_jm07_web.Repositorios;

public class ProductosRepository
{
    //Conexion con mi base de datos
    private string connectionString = "Data Source=DB/Tienda.db;";

    public void Create(Productos producto)
    {
        var query = $"INSERT INTO productos (nombre, precio) VALUES (@nombre,@precio)";
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();
            var command = new SQLiteCommand(query, connection);
            command.Parameters.Add(new SQLiteParameter("@nombre", producto.descripcion));
            command.Parameters.Add(new SQLiteParameter("@precio", producto.precio));
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}
