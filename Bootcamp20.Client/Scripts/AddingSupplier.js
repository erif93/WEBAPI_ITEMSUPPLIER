//punya eri
    LoadIndexSupplier();

function LoadIndexSupplier() {
    $.ajax({
        type: "GET",
        url: "http://localhost:20662/api/Suppliers",
        dateType: "json",
        success: function (data) {
            var html = '';
            $.each(data, function (index, val) {
                html += '<tr>';
                html += '<td>' + val.Name + '</td>';
                html += '<td> <a href="#" onclick="return GetById(' + val.Id + ')">Edit</a>';
                html += '<td> <a href="#" onclick="return Delete(' + val.Id + ')">Delete</a></td>';
                html += '<tr>';
            });
            $('#tbody').html(html);
        }
    });
}

function Edit() {
    var supplier = new Object();
    supplier.Id = $('#Id').val();
    supplier.Name = $('#Name').val();
    $.ajax({
        url: "http://localhost:20662/api/Suppliers/" + $('#Id').val(),
        data: supplier,
        type: "PUT",
        datatype: "json",
        success: function (result) {
            LoadIndexSupplier();
            $('#myModal').modal('hide');
            $('#Name').val('');
        }
    });
}

function Save() {
    var supplier = new Object();
    supplier.name = $('#Name').val();
    $.ajax({
        url: "http://localhost:20662/api/Suppliers/",
        type: 'POST',
        datatype: 'json',
        data: supplier,
        success: function (result) {
            LoadIndexSupplier();
            $('#myModal').modal('hide');
        }
    });
}

function GetById(Id) {
    alert('test id = ' + Id);
    $.ajax({
        url: 'http://localhost:20662/api/Suppliers/' + Id,
        type: 'GET',
        dataType: 'json',
        success: function (result) {
            $('#Id').val(result.Id);
            $('#Name').val(result.Name);
            //$('#NameOld').val(data.Name);
            $('#myModal').modal('show');
            $('#Update').show();
            $('#Save').hide();
        },
        error: function (response) {
            alert('Something is wrong, try again');
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
                url: "http://localhost:20662/api/Suppliers/" + Id,
                type: "DELETE",
                success: function (response) {
                    swal({
                        title: "Deleted",
                        text: "That data has been soft delete!",
                        type: "success"
                    },
                    function () {
                        window.location.href = '/Suppliers/Index/';
                    });
                },
                error: function (response) {
                    swal("Oops", "We couldn't connect to the sertver!", "error");
                }
            });
        });
    }



function Search() {
    $.ajax({
        type: "GET",
        url: "http://localhost:20662/api/Suppliers/?typesearch=" + $('#typesearch').val() + "&&name=" + $('#cari').val(),
        dateType: "json",
        success: function (data) {
            alert('lagi');
            var html = '';
            var i, k;
            for (i = 0; i < data.length; i++) {
                html += '<tr>' +
                        '<td>' + data[i].Name + '</td>' +
                        '<td>' + data[i].CreateDate + '</td>' +
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

function Display() {
    $('#Name').val('');
    $('#Id').val('');
    $('#Update').val('');
    $('#Save').val('');
}
