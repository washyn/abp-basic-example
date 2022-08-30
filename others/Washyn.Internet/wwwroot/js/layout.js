document.addEventListener('DOMContentLoaded', function () {

    let contentHeader = "content-header";
    let content = "content";
    let alertsContainer = "AbpPageAlerts";
    let hasContenet = false;
    let itemAlerts = null;
    
    let contentWraper = document.querySelector(".content-wrapper");
    let childs = Array.from(contentWraper.childNodes);

    // si hay un elemento content-header o 
    // no agregar el estilo

    childs.forEach(function (item) {
        let clases = item.classList;
        
        if (clases !== undefined){
            if (clases.contains(content)){
                hasContenet = true;
            }
            if (clases.contains(contentHeader)){
                hasContenet = true;
            }

            if (clases.contains(alertsContainer)){
                itemAlerts = item;
            }
        }
        
    });

    if (!hasContenet){
        contentWraper.style.padding = "0.5rem";
        console.log(" NO Tiene elemento content")
    }
    
    if (itemAlerts !== null){
        console.log("exists alerts")
        if (hasContenet){
            itemAlerts.style.padding = "0.5rem";
        }
    }

});