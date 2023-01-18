(function(){
    // abp.event.trigger('abp.configurationInitialized');
    // on config initialized
    abp.event.on('abp.configurationInitialized', function (){
        // console.log("configuracion inicializada")
        abp.ajax({
            type: 'GET',
            url: '/api/abp/application-user-configuration'
        }).then(function(result){
            // console.log(result);
            // TODO:
            // merge some props or all props, and improve this.
            abp.currentUser.id = result.id;
        });
    });
})();