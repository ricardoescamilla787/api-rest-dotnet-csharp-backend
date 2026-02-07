# Relación entre proyectos

- Backend API: https://github.com/ricardoescamilla787/api-rest-dotnet-csharp-backend
- Frontend Web: https://github.com/ricardoescamilla787/api-rest-dotnet-csharp-frontend

# API REST – Sistema de Censo, Gestión de Usuarios y Control de Acceso (ASP.NET C#)

API REST desarrollada en **ASP.NET Web API (C#)** que expone endpoints para la gestión de un sistema de censo, la 
administración de usuarios, autenticación y consultas avanzadas, incluyendo operaciones CRUD, validación de conexión
a base de datos MySQL y pruebas de consumo mediante herramientas como Postman y 
comunicación directa con una base de datos **MySQL** mediante procedimientos almacenados.

Este proyecto forma parte de un sistema cliente-servidor donde el backend es consumido por un frontend web mediante peticiones HTTP.

---

## Tecnologías utilizadas

- **ASP.NET Web API (C#)**
- **.NET Framework**
- **MySQL**
- **MySql.Data**
- **JSON**
- **Postman** (para pruebas)
- **Visual Studio Community**

---

## Arquitectura del proyecto

El proyecto sigue una estructura basada en **controladores, modelos y configuración centralizada**:

```text
apiRESTCenso/
│
├── App_Start/
│ ├── BundleConfig.cs
│ ├── FilterConfig.cs
│ ├── RouteConfig.cs
│ └── WebApiConfig.cs
│
├── Controllers/
│ ├── AdminBdController.cs
│ ├── CensoController.cs
│ ├── HomeController.cs
│ ├── UsuarioController.cs
│ └── ValuesController.cs
├── database
|└── control_acceso.sql
│
├── Models/
│ ├── clsApiStatus.cs
│ ├── clsCensoDatos.cs
│ └── clsUsuario.cs
│
├── Web.config
├── Global.asax
└── README.md
```
---

## Configuración de rutas

Las rutas principales de la API están definidas en `WebApiConfig.cs`:

config.Routes.MapHttpRoute(
    name: "DefaultApi",
    routeTemplate: "full/{controller}/{id}",
    defaults: new { id = RouteParameter.Optional }
);

Esto permite consumir los endpoints bajo la ruta base:

http://localhost:{puerto}/full/{controller}

## ENDPOINTS PRINCIPALES

### Verificar Conexion a MySQL
 **GET** 

/full/adminbd/checkmysqlconnection

### Consultar Usuarios (vista)
**GET** 

/full/usuario/vwrptusuario

## GESTIÓN DE CENSO

### Obtener registro por ID
**GET**

/full/censo/{id}

### Crear registro
**POST**

/full/censo

Body (JSON):

{
  "id": 1,
  "nombre": "Juan",
  "apellidoPaterno": "Pérez",
  "rol": "Ciudadano"
}

### Actualizar registro
**PUT**

/full/censo/{id}

### Eliminar registro
**DELETE**

/full/censo/{id}

## ENDPOINTS DE GESTIÓN DE USUARIOS Y CONTROL DE ACCESO

### Registrar usuario
**POST**

/full/usuario/spinsusuario

Body (JSON):

{
  "nombre": "Juan",
  "apellidoPaterno": "Pérez",
  "apellidoMaterno": "López",
  "usuario": "jperez",
  "contraseña": "12345",
  "ruta": "/home",
  "tipo": 1
}

### Validar acceso (login)
**POST**

/full/usuario/spvalidaracceso

Body (JSON):

{
  "usuario": "jperez",
  "contraseña": "12345"
}

### Consultar todos los usuarios
**GET**

/full/usuario/vwrptusuario

### Consultar usuarios con filtro
**GET**

/full/usuario/vwrptusuariofiltro?nomFiltro=Juan

### Consultar tipos de usuario
**GET**

/full/usuario/vwtipousuario

### Eliminar usuario
**DELETE**

/full/usuario/delete?id=5

### Actualizar usuario
**PUT**

/api/usuario/update

Body (JSON):

{
  "cve": 5,
  "nombre": "Juan",
  "apellidoPaterno": "Pérez",
  "apellidoMaterno": "López",
  "usuario": "jperez",
  "contraseña": "12345",
  "ruta": "/admin",
  "tipo": 2
}

## Base de datos

Motor: MySQL Workbench 8.0.21

Conexión configurada en Web.config

Acceso mediante MySqlConnection

Uso de procedimientos almacenados y vistas

Pruebas de conexión desde el endpoint AdminBdController

Script disponible en /database/control_acceso.sql

Para importarla:
1. Abrir MySQL Workbench
2. Ir a Server → Data Import
3. Seleccionar el archivo `control_acceso.sql`
4. Ejecutar la importación

## Nota de Seguridad
Las contraseñas se almacenan en texto plano únicamente con fines demostrativos.

## Ejecución del proyecto

Clonar el repositorio

Abrir la solución en Visual Studio Community

Restaurar paquetes NuGet

Configurar la cadena de conexión MySQL en Web.config

Ejecutar el proyecto

Probar endpoints desde Postman o frontend

## Notas adicionales

Este backend está diseñado para ejecutarse inicialmente en entorno local (localhost).

Puede ser desplegado posteriormente en un servidor IIS o servicio en la nube.

El frontend consume esta API mediante una URL base configurable.


Los endpoints retornan respuestas en formato JSON o DataSet según el tipo de operación.

Se utiliza MySqlConnection para la comunicación directa con la base de datos.

La lógica de negocio se apoya en procedimientos almacenados y vistas.

Manejo de errores controlado con mensajes estructurados.

## Autor
Backend Developer Jr | Ricardo Escamilla Mendoza
