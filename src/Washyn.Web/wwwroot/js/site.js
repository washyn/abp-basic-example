(function(){
    abp.event.on('abp.configurationInitialized', function (){
        abp.ajax({
            type: 'GET',
            url: '/api/abp/application-user-configuration'
        }).then(function(result){
            abp.currentUser.id = result.id;
        });
    });
})();