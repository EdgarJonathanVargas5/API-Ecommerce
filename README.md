# API Ecommerce

API REST desarrollada en ASP.NET Core para gestionar productos, categorías y usuarios de un ecommerce. Incluye autenticación JWT, versionado de API, paginación, búsqueda y documentación con Swagger.

## Características

- CRUD de productos y categorías
- Búsqueda de productos por categoría, nombre o descripción
- Compra de productos con actualización automática de stock
- Registro e inicio de sesión de usuarios con JWT
- Roles de acceso: Admin y User
- Paginación de resultados
- Documentación interactiva con Swagger / OpenAPI
- Base de datos SQL Server con soporte para Docker

## Tecnologías utilizadas

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Bearer Authentication
- Swagger / Swashbuckle
- Mapster
- Docker Compose

## Estructura del proyecto

- Controllers: define los endpoints HTTP
- Repository: lógica de acceso a datos y reglas de negocio
- Models: entidades y DTOs
- Data: DbContext y seeding inicial de datos
- Migrations: migraciones de Entity Framework
- Properties: configuraciones de ejecución

## Requisitos previos

- .NET SDK 10.0
- Docker Desktop (opcional, pero recomendado para SQL Server)
- SQL Server o un contenedor Docker corriendo

## Configuración rápida

### 1) Levantar SQL Server con Docker

```bash
docker compose up -d
```

### 2) Configurar la conexión a la base de datos

Configurar `appsettings.json` en la raíz del proyecto con el siguiente contenido de ejemplo:

```json
{
  "ConnectionStrings": {
    "ConexionSql": "Server=localhost,1433;Database=ecommerce_db;User Id=sa;Password=TU_PASSWORD;TrustServerCertificate=True;"
  },
  "ApiSettings": {
    "SecretKey": "TU_SECRET_KEY"
  }
}
```

> Si prefieres usar otro motor o credenciales, ajusta la cadena de conexión según tu entorno.

### 3) Aplicar las migraciones

```bash
dotnet ef database update
```

### 4) Ejecutar la API

```bash
dotnet run
```

La API quedará disponible en:

- HTTP: http://localhost:5075
- HTTPS: https://localhost:7130

Swagger estará disponible en:

- http://localhost:5075/swagger
- https://localhost:7130/swagger

## Usuarios de prueba

La aplicación incluye datos semilla al iniciar:

- Administrador
  - Usuario: `admin@admin.com`
  - Contraseña: `Admin123!`
- Usuario regular
  - Usuario: `user@user.com`
  - Contraseña: `User123!`

## Endpoints principales

### Autenticación

- `POST /api/v1/Users/Login` Inicia sesión y devuelve un token JWT
- `POST /api/v1/Users` Registra un nuevo usuario

### Productos

- `GET /api/v1/Products` Obtiene todos los productos
- `GET /api/v1/Products/{productId}` Obtiene un producto por ID
- `GET /api/v1/Products/Paged` Obtiene productos paginados
- `POST /api/v1/Products` Crea un producto (requiere rol Admin)
- `PUT /api/v1/Products/{productId}` Actualiza un producto (requiere rol Admin)
- `DELETE /api/v1/Products/{productId}` Elimina un producto (requiere rol Admin)
- `PATCH /api/v1/Products/buyProduct/{name}/{quantity}` Reduce el stock de un producto

### Categorías

- `GET /api/v1/Categories` Obtiene categorías en la versión 1
- `GET /api/v2/Categories` Obtiene categorías en la versión 2
- `POST /api/v1/Categories` Crea una categoría (requiere rol Admin)
- `PATCH /api/v1/Categories/{id}` Actualiza una categoría (requiere rol Admin)
- `DELETE /api/v1/Categories/{id}` Elimina una categoría (requiere rol Admin)

## Uso de autenticación

Para consumir endpoints protegidos, agrega el token JWT en el header `Authorization`:

```http
Authorization: Bearer <token>
```

## Notas adicionales

- El proyecto usa `UseSeeding` para cargar datos iniciales al crear la base de datos.
- Los archivos de imagen de productos se almacenan dentro de `wwwroot/ProductsImages`.