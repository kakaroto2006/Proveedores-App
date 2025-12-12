Proyecto ProveedoresApp - .NET MAUI (skeleton)
--------------------------------------------

Archivos incluidos:
- ProveedoresApp.csproj
- App.xaml / App.xaml.cs
- MauiProgram.cs, Program.cs
- Views/MainPage.xaml + MainPage.xaml.cs
- ViewModels/ProveedoresViewModel.cs
- Models/Proveedor.cs
- Services/DatabaseService.cs

Instrucciones:
1. Abrir la carpeta ProveedoresApp en Visual Studio 2022/2023 con workload .NET MAUI instalado.
2. Restaurar paquetes (nuget).
3. Ejecutar en el emulador/dispositivo deseado.

Notas:
- Este es un proyecto de ejemplo con la lógica CRUD en el ViewModel usando CommunityToolkit.Mvvm.
- sqlite-net-pcl usa FileSystem.AppDataDirectory para colocar la base de datos localmente en cada plataforma.