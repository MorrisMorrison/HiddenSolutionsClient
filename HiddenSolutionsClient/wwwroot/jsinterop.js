materializeHelpers = {
    initMaterialize: function () {
        console.log("Init Materialize");
        M.AutoInit();
    },
    
    initSelect(){
        $(document).ready(function(){
            $('select').formSelect();
        });  
    },
    
    initChips:function (callback) {
        $('.chips-placeholder').chips({
            placeholder: 'Enter a tag',
            secondaryPlaceholder: '+Tag',
            onChipAdd: (event, chip) => {
                callback(event[0].M_Chips.chipsData);
            },
        });
    }
};

window.callbackProxy =  function(dotNetInstance, callMethod, callbackMethod){
    // Execute function that will do the actual job
    materializeHelpers[callMethod](function(result){
        // Invoke the C# callback method passing the result as parameter
        return dotNetInstance.invokeMethodAsync(callbackMethod, result);
    });
    return true;
};
