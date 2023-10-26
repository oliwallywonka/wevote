# PRUEBA TECNICA WEVOTE

## 2da etapa test de evaluación 

Las tecnologias usadas para esta prueba son .NET CORE 6, REACT JS, y SQL SERVER, se uso el enfoque "CODE-FIRST" para el diseño y migración de la base de datos.

- [x] Crear una página web que identifique la geolocalización del visitante mediante el API:   https://api.vatcomply.com/geolocate
- [x] Al detectar la geolocalización mostrar la moneda aplicable al visitante mediante el API:   https://api.vatcomply.com/currencies
- [x] Guardar las visitas a la página en una tabla de base de datos guardando el país de origen del resultado "geolocate" y la moneda del resultado de "currencies".

### PREVIEW
![preview](/preview.png)
[http://localhost:5111/](http://localhost:5111/)

### SWAGGER
![preview](/swagger.png)
[http://localhost:5111/swagger/index.html](http://localhost:5111/swagger/index.html)

### DIAGRAMA DB
![diagrama entidad-relacion](/diagramaDB.png)

### PREREQUISITOS
1. Tener [.NET 6](https://dotnet.microsoft.com/es-es/download/dotnet/6.0) y [SQL SERVER](https://www.microsoft.com/es-es/sql-server/sql-server-downloads) instalado Puedes descargar la última versión desde el sitio web oficial de Microsoft.

### EJECUCIÓN DEL PROYECTO
1. Clonar el repositorio del proyecto desde GitHub.
2. Abrir el proyecto con Visual Studio 2022 o superior
3. Cambiar la cadena de conexion del archivo  ```appsettings.json``` con los datos de prueba 
```json 
"ConnectionStrings": {
    "WevoteConnection": "Server=TU_SERVER;Database=NOMBRE_BASEDATOS;Trusted_Connection=True;"
  }
```
4. Iniciar el proyecto con el depurador de visual studio. 
5. Abrir el navegador web y dirigirse a [http://localhost:5111/](http://localhost:5111/) para ver la aplicación en funcionamiento.
6. Para detener la aplicación, regresar a Visual Studio y apretar el boton stop o ir a la terminal y apretar ```cmd + c```.