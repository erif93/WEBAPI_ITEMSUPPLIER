    $(document).ready(function () {  
        $.ajax({
            url: 'http://localhost:20662/api/Suppliers',
            type: 'GET',  
            dataType: 'json',
            success: function (data) {  
                //alert(JSON.stringify(data));                  
                $("#DIV").html('');   
                var DIV = '';  
                $.each(data, function (i, item) {  
                    var rows = "<tr>" +  
                        "<td id='Name'>" + item.Name + "</td>" +
                        "</tr>";  
                    $('#Table').append(rows);  
                }); //End of foreach Loop   
                console.log(data);  
            }, //End of AJAX Success function  
            failure: function (data) {  
                alert(data.responseText);  
            }, //End of AJAX failure function  
            error: function (data) {  
                alert(data.responseText);  
            } //End of AJAX error function  
  
        });         
    });  
