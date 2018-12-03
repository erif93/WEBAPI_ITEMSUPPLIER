LoadIndexItem();

function LoadIndexItem() {
    $.ajax({
        type: "GET",
        url: 'http://localhost:20662/api/Items',
        dateType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.Name + '</td>';
                html += '<td>' + val.Price + '</td>';
                html += '<td>' + val.Stock + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += '<td> <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '<tr>';
            });
            $('#tbody').html(html);
        }
    });
}



function Delete(Id) {
    swal({
        title: "Are you Sure?",
        text: "You will not be able to revocer this imaginary file!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Yes, delete it!",
        closeOnConfirm: false
    }, function () {
        $.ajax({
            url: "http://localhost:20662/api/Items/" + Id,
            type: "DELETE",
            success: function (response) {
                swal({
                    title: "Deleted",
                    text: "That data has been soft delete!",
                    type: "success"
                },
                function () {
                    window.location.href = '/Items/Index/';
                });
            },
            error: function (response) {
                swal("Oops", "We couldn't connect to the sertver!", "error");
            }
        });
    });
}



function combotampil() {
    $.ajax({
        type: 'get',
        url: 'http://localhost:20662/api/Suppliers/',
        dataType: 'JSON',
        success: function (data) {
            var html = '';
            html += '<select name="combosuppliers" id="combosuppliers" class="form-control">';
            for (i = 0; i < data.length; i++) {
                html += '<option value="' + data[i].Id + '">' + data[i].Name + '</option>';
            }
            html += '</select>';
            $('#Combobox').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });


    $('#Name').val('');
    $('#Id').val('');
    $('#Update').hide();
    $('#Save').show();
}



$('#Save').click(function () {
    var supplier = new Object();
    supplier.name = $('#Name').val();
    supplier.Supplier_id = $('#combosuppliers').val();
    if (supplier.name == "") {
        swal("Invalid", "Harap Mengisi Form", "warning");
        return false;
    }
    else {
        $.ajax({
            url: 'http://localhost:20662/api/Items',
            type: 'POST',
            dataType: 'json',
            data: supplier,
            success: function (data) {
                tampil();
                $('#myModal').modal('hide');
            }
        });
    }
});



function getById(id) {
    $.ajax({
        url: 'http://localhost:20662/api/Items' + id,
        type: 'get',
        dataType: 'json',
        success: function (item) {
            debugger;
            $.ajax({
                type: 'get',
                url: 'http://localhost:20662/api/Items',
                dataType: 'JSON',
                success: function (data) {
                    var html = '';
                    var val = '';
                    html += '<select name="combosuppliers" id="combosuppliers" class="form-control">';

                    for (i = 0; i < data.length; i++) {
                        if (data[i].Id == item.Supplier_Id) {
                            val = 'selected';
                        }
                        html += '<option ' + val + ' value="' + data[i].Id + '">' + data[i].Name + '</option>';
                        val = '';
                    }
                    html += '</select>';
                    $('#Combobox').html(html);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert('Terjadi Kesalahan, coba lagi!');
                }
            });

            $('#Name').val(item.Name);
            $('#NameOld').val(item.Name);
            $('#Id').val(item.Id);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
        }
    });
}



function Edit() {
    debugger;
    var item = new Object();
    item.id = $('#Id').val();
    item.name = $('#Name').val();
    item.supplier_id = $('#combosuppliers').val();
    if (item.name == "") {
        swal("Invalid", "Harap Mengisi Form", "warning");
        return false;
    }
    else if (item.name == $('#NameOld').val()) {
        swal("Invalid", "Harap Data Tidak Boleh Sama", "warning");
        return false;
    }
    else {
        $.ajax({
            url: 'http://localhost:20662/api/Items' + item.id,
            type: 'PUT',
            data: item,
            dataType: 'json',
            success: function (data) {
                tampil();
                $('#myModal').modal('hide');
                $('#Name').val('');
                $('#Id').val('');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Terjadi Kesalahan, coba lagi!');
            }
        });
    }
}