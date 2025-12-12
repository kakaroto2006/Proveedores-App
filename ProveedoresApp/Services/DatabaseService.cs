using SQLite;
using System.IO;
using System.Threading.Tasks;
using ProveedoresApp.Models;

namespace ProveedoresApp.Services;

public class DatabaseService
{
    private readonly SQLiteAsyncConnection _db;

    public DatabaseService()
    {
        var dbPath = Path.Combine(FileSystem.AppDataDirectory, "proveedores.db3");
        _db = new SQLiteAsyncConnection(dbPath);
        _db.CreateTableAsync<Proveedor>().Wait();
    }

    public Task<List<Proveedor>> GetAllAsync() => _db.Table<Proveedor>().ToListAsync();
    public Task<int> AddAsync(Proveedor p) => _db.InsertAsync(p);
    public Task<int> UpdateAsync(Proveedor p) => _db.UpdateAsync(p);
    public Task<int> DeleteAsync(Proveedor p) => _db.DeleteAsync(p);
}