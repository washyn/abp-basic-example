# Abp as aspnetboilerplate, with 4 layers

This is one soluction of admin lte template for abp 4.4.4 .
# Done
- Add bundle generation
- Create proxy scripts
- Add localization only for test, how works(this example is in another branch)
- Add crud with razor pages and theme admin lte.
- Add tag helpers
- Add front libs(bundle)
- when call remote service error, add jquery extensions for use abp.ajax, check where is located this function.

# TODO
- Disable proxy generation, for all by default and only add this with RemoteService decorator.
- Add Serilog as logger
- Mover el tema a Washyn.AspNetCore.Mvc.UI.Theme.AdminLte y crear un proyecto ahi para usar el tema con los modulos por defecto de abp framework.
# Notes
Theme shared contains all basic js libs, basic theme add layout.js and layout.css file for fix some


Abp js library dependency 

    @abp/jquery
        @abp/core
        jquery

---

<!-- 

### Ejemplo de agregar basic bundling and minify.

En este post se muestra como agregar, el bundling/minify, cuando se desarrolla en web, generalmente se tiene varios js y css, los cuales se consumiran desde el navegador del cliente. tener varios js y css puede ralentizar la carga del sitio web, en el mundo de node js se puede usar webpack o paquetes para juntar y minificar todos los archivocs css y js para que la carga de la pagina sea mas rapida.

En asp net puede que algunos no quieran saber de node js o las cosas que implica eso o ahorrarse tocar node, en abp existe el modulo AbpAspNetCoreMvcUiBundlingModule al cual sirve para poder minificar los js y css , cuando estamos en un entorno de desarrollo este paquete agregara los js y css tal cual se agregaria de la manera tradicional, en caso se quiera debugear(depurar), pero en produccion minifica los css y js en un solo archivo bundle para que la carga de la pagina sea mas rapida. Y podemos olvidarnos de usar node js.


Pasos 
- Instala el paquete  en el proyecto web, se grega el modulo, depends on.
- se agrega el add tag helpers en el view imports, para poder usar el nuevo tag helper o etiqueta, este tage helper nos trae nuevas etiquetas como, <abp-script-bundle> ,<abp-script>, para javascript <abp-style-bundle>,<abp-style> para css
- finalmente haces uso de ello.



```html
<abp-script-bundle name="ScriptBundle">
    <abp-script src="/lib/jquery/dist/jquery.min.js"></abp-script>
    <abp-script src="/lib/bootstrap/dist/js/bootstrap.bundle.min.js"></abp-script>
    <abp-script type="@(typeof(CoreScriptContributor))"></abp-script>
    <abp-script src="/js/site.js"></abp-script>
</abp-script-bundle>

```


``` html
<abp-style-bundle name="StylesBundle">
    <abp-style src="/lib/bootstrap/dist/css/bootstrap.min.css" />
    <abp-style src="/css/site.css" />
    <abp-style type="@(typeof(CoreStyleContributor))"></abp-style>
</abp-style-bundle>
``` -->




---

# Dependency tree of package


└─ @abp/jquery@4.4.4
   ├─ jquery@3.6.1
   └─ @abp/core@4.4.4
      └─ @abp/utils@4.4.4
         └─ just-compare@1.5.1



---

- modules

    - Washy.AspNetCore.Mvc.UI.Theme.AdminLte: 
    proyecto donde se movera una ves el tema este completado para usarse.

- others
    - Washyn.AdminLteTheme : Contiene el tema en si, con el codigo del tema y sus partial views.
    - Internet: hace uso del tema admin lte creado e integra los modulos por default del framework abp
    AdminLteTheme.

---

src : 
    Contiene codigo de la aplicacion de 4 capas
    web : 
test : 
    Tests de la aplicaicon de 4 capas