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
    
    initChips:function () {
        $('.chips-placeholder').chips({
            placeholder: 'Enter a tag',
            secondaryPlaceholder: '+Tag',
        });
    }
};