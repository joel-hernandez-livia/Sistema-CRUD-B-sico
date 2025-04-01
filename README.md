# Sistema-CRUD-Basico
Este es un sistema CRUD básico desarrollado en C# (.NET) con Windows Forms, utilizando ADO.NET para la conexión con SQL Server. La aplicación permite realizar operaciones de Crear, Leer, Actualizar y Eliminar (CRUD) sobre una tabla.

## Requisitos
- SQL Server Express (o cualquier versión de SQL Server)
- .NET Framework 4.2 o superiores

## Pasos para configurar la base de datos
1. Abre **SQL Server Management Studio (SSMS)**.
2. Ejecuta el script `CrearBD.sql` para crear la base de datos.
3. Verifica que la base de datos `CrudWinForm` se haya creado correctamente.

## Modificación de la cadena de conexión
Si tu instancia de SQL Server no se llama SQLEXPRESS, debes actualizar la cadena de conexión en el archivo PeopleDB.cs, línea 14.
