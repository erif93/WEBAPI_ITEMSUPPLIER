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
                html += '<td>' + val.Supplier.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += '<td> <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '<tr>';
            });
            $('#tbody').html(html);
        }
    });
}


function Search() {
    alert('hi');
    $.ajax({
        type: "GET",
        url: "http://localhost:20662/api/Items/?name=" + $('#Search').val(),
        dateType: "json",
        success: function (data) {
            alert('lagi');
            var html = '';
            var i, k;
            for (i = 0; i < data.length; i++) {
                html += '<tr>' +
                        '<td>' + data[i].Name + '</td>' +
                        '<td>' + data[i].IsDelete + '</td>' +
                        '<td><a onclick="return getById(' + data[i].Id + ')">Edit</a> | <a onclick="return deleting(' + data[i].Id + ')">Delete</a></td>' +
                        '</tr>';
            }
            $('#tbody').html(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Terjadi Kesalahan, coba lagi!');
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
    supplier.price = $('#Price').val();
    supplier.stock = $('#Stock').val();
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


function GetById(Id) {
        alert('test id = ' + Id);
        $.ajax({
            url: 'http://localhost:20662/api/Items/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (result) {
                $('#Id').val(result.Id);
                $('#Name').val(result.Name);
                $('#Price').val(result.Price);
                $('#Stock').val(result.Stock);
                $('#myModal').modal('show');
                $('#Update').show();
                $('#Save').hide();
            },
            error: function (response) {
                alert('Something is wrong, try again');
            }
        });
 }




function Edit() {
    var item = new Object();
    item.id = $('#Id').val();
    item.name = $('#Name').val();
    item.price = $('#Price').val();
    item.stock = $('#Stock').val();
    item.supplier_id = $('#combosuppliers').val();
    if (item.name == "") {
        swal("Invalid", "Harap Mengisi Nama Item", "warning");
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
                LoadIndexItem();
                $('#myModal').modal('hide');
                $('#Name').val('');
                $('#Price').val('');
                $('#Stock').val('');
                $('#Id').val('');
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Terjadi Kesalahan, coba lagi!');
            }
        });
    }
}