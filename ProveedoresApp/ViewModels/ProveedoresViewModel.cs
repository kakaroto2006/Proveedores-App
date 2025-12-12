using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using ProveedoresApp.Models;
using ProveedoresApp.Services;

namespace ProveedoresApp.ViewModels;

public partial class ProveedoresViewModel : ObservableObject
{
    private readonly DatabaseService _db;

    public ObservableCollection<Proveedor> Proveedores { get; } = new();

    [ObservableProperty]
    private string nombre = string.Empty;
    [ObservableProperty]
    private string telefono = string.Empty;
    [ObservableProperty]
    private string email = string.Empty;
    [ObservableProperty]
    private string ciudad = string.Empty;
    [ObservableProperty]
    private string ruc = string.Empty;

    [ObservableProperty]
    private Proveedor? selectedProveedor;

    public ProveedoresViewModel(DatabaseService db)
    {
        _db = db;
        LoadAllCommand.Execute(null);
    }

    [RelayCommand]
    private async Task LoadAllAsync()
    {
        Proveedores.Clear();
        var list = await _db.GetAllAsync();
        foreach (var p in list) Proveedores.Add(p);
    }

    [RelayCommand]
    private async Task AddAsync()
    {
        var p = new Proveedor
        {
            Nombre = Nombre,
            Telefono = Telefono,
            Email = Email,
            Ciudad = Ciudad,
            Ruc = Ruc
        };
        await _db.AddAsync(p);
        await LoadAllAsync();
        ClearFields();
    }

    [RelayCommand]
    private async Task UpdateAsync()
    {
        if (SelectedProveedor == null) return;
        SelectedProveedor.Nombre = Nombre;
        SelectedProveedor.Telefono = Telefono;
        SelectedProveedor.Email = Email;
        SelectedProveedor.Ciudad = Ciudad;
        SelectedProveedor.Ruc = Ruc;
        await _db.UpdateAsync(SelectedProveedor);
        await LoadAllAsync();
        ClearFields();
    }

    [RelayCommand]
    private async Task DeleteAsync()
    {
        if (SelectedProveedor == null) return;
        await _db.DeleteAsync(SelectedProveedor);
        await LoadAllAsync();
        ClearFields();
    }

    [RelayCommand]
    private Task ClearAsync()
    {
        ClearFields();
        return Task.CompletedTask;
    }

    partial void OnSelectedProveedorChanged(Proveedor? value)
    {
        if (value == null) return;
        Nombre = value.Nombre;
        Telefono = value.Telefono;
        Email = value.Email;
        Ciudad = value.Ciudad;
        Ruc = value.Ruc;
    }

    private void ClearFields()
    {
        Nombre = string.Empty;
        Telefono = string.Empty;
        Email = string.Empty;
        Ciudad = string.Empty;
        Ruc = string.Empty;
        SelectedProveedor = null;
    }
}