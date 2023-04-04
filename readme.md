# Abp as aspnetboilerplate, with 4 layers
This is one soluction create fron scractc about example of use abp framework as traditional way(aspnetboilerplate) with 4 layers.

## TODO:
- Agregar Ejemplo de domain service, test

## Improvement
- Test
  - Add manger service and test this.
  - Disable proxy generation, for all by default and only add this with RemoteService decorator.

## DONE
- Agregar data seeder
- Agregar crud basico
- Add json secret file
- Added logger
- when call remote service error, add jquery extensions for use abp.ajax, check where is located this function.
- Agregar las librerias base de abp, front para poder probar, 1
- Add localization only for test, how works                 3, hay otro ejemplo ya hecho, o crear una rama para proba esto
- Remove unused code and comments
- Add bundle generation
- create proxy scripts
- Add crud of in basic theme, razor pages
- Add localization json
- Agregar ejemplos de test en todas las capas

## Screenshots

![alt](/images/screencapture-localhost-5001-2022-11-16-19_54_57.png)
![alt](/images/screencapture-localhost-5001-Crud-2022-11-16-19_55_14.png)



# Explain
- Others
  - Console.- este es un cliente http consola que consume el serervicio Web(a traves de HttpApi.Client)
  - DbMigrator.- este proyecto es para crear la base de datos e insertar datos semilla en la aplicacion.

---
- src
  - Domain.- contiene entidades(clases) de dominio(que representan las tablas en la base de datos).
  - Application.- contiene casos de uso, servicios de aplicacion
  - EntityFrameworkCore.- contiene el dbContext, migraciones e implementacion de repositorios.
  - Web.- contienen la capa de presentacion de la acplicacion en razor pages
  - HttpApi.Client .- Se encarga de exponer los servicios aplicacion para que se pueda consumir por servicios externos como el proyecto consola.


---
- test
  - Tests.- contiene test de integracion de la capa de EntityFrameworkCore, Application y Domain.
  - Web.Tests.- contiene tests de la capa web, esto realizando peticiones http.