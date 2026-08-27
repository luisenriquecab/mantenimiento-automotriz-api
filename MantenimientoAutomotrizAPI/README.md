# API RESTful - Mantenimiento Automotriz

Una API RESTful desarrollada en C# y ASP.NET Core para gestionar el registro de vehículos y su bitácora detallada de mantenimientos preventivos y correctivos. 

El proyecto demuestra la implementación de una arquitectura robusta, operaciones CRUD completas y el manejo de relaciones de base de datos de uno a muchos utilizando el enfoque *Code-First*.

##  Stack Tecnológico
* **Lenguaje:** C# 10.0
* **Framework:** ASP.NET Core Web API
* **ORM:** Entity Framework Core (EF Core)
* **Base de Datos:** SQL Server (LocalDB)
* **Documentación:** Swagger / OpenAPI

##  Características Principales
* **Relaciones Relacionales:** Gestión de llaves foráneas entre la entidad `Vehiculo` y múltiples `Mantenimiento` asociados.
* **Prevención de Ciclos:** Configuración de `ReferenceHandler.IgnoreCycles` en la serialización JSON para evitar bucles infinitos al cargar entidades relacionadas.
* **Validación de Integridad:** Bloqueo de registros de mantenimiento para vehículos inexistentes en la base de datos (Validación en el Controlador).

##  Endpoints de la API

| Método | Ruta | Descripción |
|---|---|---|
| `GET` | `/api/Vehiculos` | Obtiene la lista de todos los vehículos incluyendo su historial de mantenimientos. |
| `POST` | `/api/Vehiculos` | Registra un nuevo vehículo en la base de datos. |
| `POST` | `/api/Mantenimientos` | Añade un nuevo servicio a la bitácora de un vehículo existente. |

## 💻 Ejemplos de Uso (Payloads)

**1. Registrar un Vehículo (POST /api/Vehiculos)**
```json
{
  "marca": "Hyundai",
  "modelo": "Tucson",
  "anio": 2008
}

**2. Registrar un Mantenimiento (POST /api/Mantenimientos)**
```json
{
  "vehiculoId": 1,
  "tipoMantenimiento": "Cambio de Aceite",
  "fecha": "2024-06-15T10:30:00",
  "descripcion": "Cambio de aceite y filtro de aceite."
}
```

## INSTRUCCIONES DE INSTALACION LOCAL
**1. Clonar el repositorio:
```bash git clone [https://github.com/tu-usuario/mantenimiento-automotriz-api.git](https://github.com/tu-usuario/mantenimiento-automotriz-api.git)
**2. Navega al directorio del proyecto: cd MantenimientoAutomotrizAPI
**3. Genera la base de datos y las tablas en SQL Server:dotnet ef database update
**4. Ejecuta la aplicación: dotnet run
**5. Abre tu navegador en https://localhost:<puerto>/swagger para probar la API gráficamente.