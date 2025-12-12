using SQLite;

namespace ProveedoresApp.Models;

public class Proveedor
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string Nombre { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Ciudad { get; set; } = string.Empty;
    public string Ruc { get; set; } = string.Empty;
}