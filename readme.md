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
- Add Serilog as logger.
- Mover el tema a Washyn.AspNetCore.Mvc.UI.Theme.AdminLte y crear un proyecto ahi para usar el tema con los modulos por defecto de abp framework.
- Remove un used code and comments.

# Notes
Theme shared contains all basic js libs, basic theme add layout.js and layout.css file for fix some


### Abp js library dependency (Dependency tree of package) 


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

- src : Contiene codigo de la aplicacion de 4 capas
- test : Tests de la aplicaicon de 4 capas
    