# Abp as aspnetboilerplate, with 4 layers
This is one soluction create fron scratch about example of use abp framework as traditional way(aspnetboilerplate) with 4 layers.

## TODO:


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
- Add manger service and test this, Agregar Ejemplo de domain service, test
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


![alt](/images/screencapture-localhost-5001-swagger-index-html-2022-12-02-16_18_03.png)
