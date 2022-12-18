# Abp as aspnetboilerplate, with 4 layers
This is one soluction create fron scractc about example of use abp framework as traditional way(aspnetboilerplate) with 4 layers.

## TODO:
- Agregar Ejemplo de domain service, test
- add js and css contributor for boostrap 4 and example for 5 (use rtl)
    - change select2 default options for sleep time when write, and combine with abp tag helper plus options in same version.
    - for bootstrap 5 check if this is RTL
    - fix when select2 open autofocus

- Test this in web module after configure abp localizations and test from frontend
```csharp
// test this...
context.Services.Configure<RequestLocalizationOptions>(options =>
{
  options.DefaultRequestCulture = new RequestCulture("es-pe");
});
```


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
- Add localization for select2

## Screenshots

![alt](/images/screencapture-localhost-5001-2022-11-16-19_54_57.png)
![alt](/images/screencapture-localhost-5001-Crud-2022-11-16-19_55_14.png)
