# Gamadiel-Alerium

- [x] Utilizar el administrador de Base de Datos SQL Server
- [x] Creacion de la base de datos en el modelo Firts Code
- [x] Creacion de una Web Api con Arquitectura Clean Architecture
- [x] Crear las tablas, llaves, relaciones e índices que se requieran
- [x] Crear las consultas, funciones y stored procedures que se requieran
- [x] El código del proveedor debe ser único
- [x] El RFC del proveedor debe tener 13 caracteres (4 letras + 6 dígitos + 1 letra + 2 dígitos)
  ### Al intentar eliminar el proveedor
- [x] Si el proveedor tiene productos asociados se debe solicitar una confirmación antes de eliminarlo, en caso contrario, si no tiene productos asociados, se elimina sin solicitar confirmació
- [x] Al eliminar el proveedor se deben eliminar en cascada los productos que tenga asociados
- [x] Validar que el valor que se introduzca en el costo del producto sea un valor decimal. (Se creo una validacion para confirmar la scala(6,2), 2 decimal y 4 de precicion/scala)

## Como Correr el proyecto  
#### Clonar el repositorio,  Copiar comando
```bash
    git clone [repositorio]
```
#### Antes de cualquier cosa hacer un Build del proyecto
#### En el archivo appsettings.json de la capa Presentation debe cambiar ConnectionStrings, quite esta conexion y remplaza por tu base
```bash
    "DefaultConnection": "Server=GAMA\\SQLEXPRESS;Database=AleriumTest; user=SA; password=strongPassword;TrustServerCertificate=true"
```

#### Migrar la base de datos con EntityFramework tools en Visual Studio, Copiar comando
```bash
    update-database -s Alerium.Presentation -p Alerium.Infrastructure -context ApplicationDbContext
```
#### Importante que copi tal cual el codigo ya que hay una factoria de dbcontext, ya que muchas veces tenemos que conectarnos a mas de una base de datos a la vez.

#### Deberia ser todo.
