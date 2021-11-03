$(document).ready(function(){
    $("#soegform").submit (function (event){
        var formData = {
            soegtitel: $("#soegtitel").val(),
            soegforfatter: $("#soegforfatter").val()
        }
        console.log(formData)

        
        if($.trim(formData) != '') {
            $.post('name.php', {formData: formData}, function(data){
                console.log(data);
                $('#visliste').text(data);
            });
        }
        event.preventDefault();
    });
});