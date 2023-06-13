# Veterinaria-Backed

Aplicacion Web Api realzada con entity Framwork Core



## Pasos para levantar el proyecto  Backend

- Clonar o Descargar el Codigo
- Tener instaldo EF-CLI ya que este proyecto fue creado con esta tecnologia, y es importante ejecutar unos comandos de la misma
- Restaurar los `Nuget Package` para que se instalen las dependencias del proyecto
- Configurar `ConnectionString` , este se encuentra en el archivo `appsettings.development.json` **IMPORTANTE** en el ejemplo 
se realizo la conexion con `Windows Authentication` por lo que si la conexion a la base  de datos se realiza con `Sql Authentication`,
Este `ConnectionString` cambiara, teniendo una estructura como esta `Server=NOMBRE_SERVIDOR; Database =BASE_DATOS;
User Id=USER_ID;Password=PASSWORD;TrustServerCertificate= true`.
-Crear la base de datos llamada `Veterinaria` en SQL SERVER
-El proyecto se realizo por medio de EF Core, por lo tanto para crear la tabla `Mascota` en la base de datos, debemos correr la migraciones 
del proyecto, para esto nos dirigimos al `Package Manager Console` y ejecutamos el comando `add-Migration Initial` para que se creen las tablas
- **IMPORTANTE** en caso de que no se cree las tablas , debemos ejecutar el comando `update-database`
- Tener presente la localhost con el cual se ejecutara la aplicacion, para asi mismo , habilitar el CORS a ese localhos, en el archvio
 `Program.cs`
- levantar el proyecto `CONTROL + F5`
