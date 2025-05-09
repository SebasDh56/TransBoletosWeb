# TransporteBoletos

**TransporteBoletos** es una aplicación web desarrollada con ASP.NET Core que permite gestionar un sistema de venta y administración de boletos de transporte. Facilita la creación, edición y eliminación de rutas, pasajeros y boletos, con una interfaz sencilla y funcional.

## Características

- **Gestión de Rutas**: Administra rutas de transporte con origen y destino.
- **Gestión de Pasajeros**: Registra pasajeros, asociándolos a una ruta (opcional).
- **Gestión de Boletos**: Emite boletos vinculados a un pasajero y una ruta.
- **Operaciones CRUD**: Crea, lee, actualiza y elimina rutas, pasajeros y boletos.
- **Base de Datos**: Usa SQL Server (LocalDB) con Entity Framework Core.
- **Relaciones**: Maneja relaciones entre entidades (rutas, pasajeros, boletos) con claves foráneas.
- **Validaciones**: Incluye restricciones para campos obligatorios y eliminación segura.

## Tecnologías Utilizadas

- **Framework**: ASP.NET Core 8.0 (MVC)
- **Base de Datos**: SQL Server LocalDB (`(localdb)\MSSQLLocalDB`)
- **ORM**: Entity Framework Core 8.0
- **Lenguaje**: C#
- **Interfaz**: Vistas Razor (`.cshtml`)
- **Herramientas**:
  - Visual Studio 2022 (o superior)
  - SQL Server Management Studio (SSMS) para inspeccionar la base de datos
  - .NET CLI (`dotnet` commands)

## Requisitos Previos

Antes de ejecutar el proyecto, asegúrate de tener instalado lo siguiente:

1. **.NET SDK 8.0**  
   Descarga e instala desde [https://dotnet.microsoft.com/download/dotnet/8.0](https://dotnet.microsoft.com/download/dotnet/8.0).

2. **Visual Studio 2022** (opcional)  
   Asegúrate de incluir las cargas de trabajo para desarrollo web y soporte de SQL Server.

3. **SQL Server LocalDB**  
   Viene incluido con Visual Studio, pero puedes instalarlo por separado si es necesario.

4. **SQL Server Management Studio (SSMS)** (opcional)  
   Para inspeccionar y administrar la base de datos. Descarga desde [https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms).

## Instalación y Configuración

Sigue estos pasos para configurar y ejecutar el proyecto localmente:

### 1. Clonar el Repositorio (si está en GitHub)

Si el proyecto está en un repositorio, clónalo:

```bash
git clone https://github.com/<tu-usuario>/TransporteBoletos.git
cd TransporteBoletos
```

Si no, simplemente copia los archivos del proyecto a tu máquina.

### 2. Verificar Dependencias

Asegúrate de que el archivo `TransporteBoletos.csproj` incluya las dependencias necesarias:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="8.0.8" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Design" Version="8.0.8">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
  <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.8" />
  <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.8">
    <PrivateAssets>all</PrivateAssets>
    <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  </PackageReference>
</ItemGroup>
```

Restaura las dependencias ejecutando:

```bash
dotnet restore
```

### 3. Configurar la Cadena de Conexión

Asegúrate de que el archivo `appsettings.json` tenga la cadena de conexión correcta:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=TransporteBoletosDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.EntityFrameworkCore": "Debug"
    }
  },
  "AllowedHosts": "*"
}
```

- **Nota**: Si usas una instancia diferente de SQL Server (por ejemplo, SQL Server Express), ajusta la cadena de conexión. Ejemplo para SQL Server Express:
  ```json
  "DefaultConnection": "Server=.\\SQLEXPRESS;Database=TransporteBoletosDb;Trusted_Connection=True;MultipleActiveResultSets=true"
  ```

### 4. Crear la Base de Datos

Aplica las migraciones para crear la base de datos y las tablas:

```bash
dotnet ef database update
```

Esto creará la base de datos `TransporteBoletosDb` con las tablas `Rutas`, `Pasajeros`, y `Boletos`, incluyendo datos iniciales (seeder).

- **Verificación**:
  - Abre SSMS y conéctate a `(localdb)\MSSQLLocalDB`.
  - Busca la base de datos `TransporteBoletosDb` y verifica las tablas y datos.

### 5. Ejecutar la Aplicación

Inicia la aplicación:

```bash
dotnet run --urls "http://localhost:5000"
```

O abre el proyecto en Visual Studio y presiona `F5`.

- **Nota**: Si el puerto `5000` está en uso, cámbialo (por ejemplo, `http://localhost:5001`).

La aplicación estará disponible en `http://localhost:5000`.

## Uso

Una vez que la aplicación esté ejecutándose, puedes acceder a las siguientes rutas:

- **Rutas**:
  - `/Rutas`: Lista todas las rutas.
  - `/Rutas/Create`: Crea una nueva ruta.
  - `/Rutas/Edit/{id}`: Edita una ruta existente.
  - `/Rutas/Details/{id}`: Muestra los detalles de una ruta.
  - `/Rutas/Delete/{id}`: Elimina una ruta.

- **Pasajeros**:
  - `/Pasajeros`: Lista todos los pasajeros.
  - `/Pasajeros/Create`: Crea un nuevo pasajero, seleccionando una ruta (opcional).
  - `/Pasajeros/Edit/{id}`: Edita un pasajero.
  - `/Pasajeros/Details/{id}`: Muestra los detalles de un pasajero.
  - `/Pasajeros/Delete/{id}`: Elimina un pasajero.

- **Boletos**:
  - `/Boletos`: Lista todos los boletos.
  - `/Boletos/Create`: Crea un nuevo boleto, seleccionando un pasajero y una ruta.
  - `/Boletos/Edit/{id}`: Edita un boleto.
  - `/Boletos/Details/{id}`: Muestra los detalles de un boleto.
  - `/Boletos/Delete/{id}`: Elimina un boleto.

### Datos Iniciales

La base de datos incluye datos iniciales para pruebas:

- **Rutas**:
  - "Ciudad A - Ciudad B" (Id: 1)
  - "Ciudad B - Ciudad C" (Id: 2)
- **Pasajeros**:
  - "Juan Pérez", Documento: "12345678", Ruta: "Ciudad A - Ciudad B" (Id: 1)
- **Boletos**:
  - Número: "B001", Fecha: 2025-05-08, Pasajero: "Juan Pérez", Ruta: "Ciudad A - Ciudad B" (Id: 1)

## Estructura del Proyecto

- **Controllers/**: Contiene los controladores (`BoletosController`, `PasajerosController`, `RutasController`).
- **Models/**: Define los modelos (`Boleto`, `Pasajero`, `Ruta`).
- **Data/**: Contiene el `DbContext` (`TransporteBoletosDbContext.cs`) y las configuraciones de la base de datos.
- **Views/**: Archivos Razor para la interfaz (`Boletos/`, `Pasajeros/`, `Rutas/`).
- **Migrations/**: Archivos de migraciones generados por EF Core.
- **wwwroot/**: Archivos estáticos (CSS, JS, imágenes).
- **Program.cs**: Punto de entrada y configuración de la aplicación.
- **appsettings.json**: Configuración general, incluyendo la cadena de conexión.

## Solución de Problemas

### 1. **Error: "Failed to bind to address"**
El puerto está en uso. Libéralo o usa otro puerto:

```bash
# Encontrar el proceso que usa el puerto
netstat -aon | findstr :5000

# Terminar el proceso (reemplaza 12345 con el PID)
taskkill /PID 12345 /F

# O ejecuta con otro puerto
dotnet run --urls "http://localhost:5001"
```

### 2. **Error: "Cannot connect to the database"**
- Verifica la cadena de conexión en `appsettings.json`.
- Asegúrate de que `(localdb)\MSSQLLocalDB` esté instalado:
  ```bash
  sqllocaldb info
  ```
- Prueba la conexión manualmente en SSMS.

### 3. **Error: "Invalid column name 'RutaId'"**
La base de datos no tiene las columnas esperadas. Recrea la base de datos:

```bash
dotnet ef database drop --force
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. **Base de Datos No Aparece en SSMS**
- Conéctate a `(localdb)\MSSQLLocalDB` en SSMS.
- Haz clic derecho en "Databases" > "Refresh".

## Contribuciones

Si deseas contribuir al proyecto:
1. Haz un fork del repositorio.
2. Crea una rama para tu funcionalidad (`git checkout -b feature/nueva-funcionalidad`).
3. Realiza tus cambios y haz commit (`git commit -m "Agrega nueva funcionalidad"`).
4. Sube los cambios a tu repositorio (`git push origin feature/nueva-funcionalidad`).
5. Crea un Pull Request.

## Mejoras Futuras

- **Validaciones Adicionales**: Agregar unicidad al `NumeroBoleto` y más reglas de negocio.
- **Diseño**: Mejorar la interfaz con Bootstrap o CSS personalizado.
- **Autenticación**: Agregar login para administradores.
- **Reportes**: Implementar reportes de ventas y estadísticas.

## Licencia

Este proyecto está bajo la licencia MIT. Consulta el archivo `LICENSE` para más detalles.