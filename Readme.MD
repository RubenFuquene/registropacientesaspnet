Crear un esquema en Oracle

CREATE USER C##el_usuario IDENTIFIED BY la_contraseña

Dar permisos al usuario del esquema nuevo

GRANT RESOURCES, DBA, CONNECT TO C##el_usuario

Conectado al nuevo esquema con el nuevo usuario, ejecutar el script Scripts/script.sql

Copiar el archivo appsettings.json.example para configurar la conexión a la BD con el usuario creado en el esquema creado

Instalar dependencias para ASP.NET

Correr el proyecto
