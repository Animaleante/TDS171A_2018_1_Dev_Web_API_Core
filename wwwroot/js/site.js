const uri = 'api/medida';
let medidas = null;
function getCount(data) {
    const el = $('#counter');
    let name = 'medida';
    if (data) {
        if (data > 1) {
            name = 'medidas';
        }
        el.text(data + ' ' + name);
    } else {
        el.html('No ' + name);
    }
}

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        url: uri,
        success: function (data) {
            $('#medidas').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr>' +
                    '<td>' + item.nome + '</td>' +
                    '<td>' + item.abreviacao + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Editar</button></td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Deletar</button></td>' +
                    '</tr>').appendTo($('#medidas'));
            });

            medidas = data;
        }
    });
}

function addItem() {
    const item = {
        'name': $('#add-nome').val(),
        'name': $('#add-abreviacao').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: uri,
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            getData();
            $('#add-nome').val('');
            $('#add-abreviacao').val('');
        }
    });
}

function deleteItem(id) {
    $.ajax({
        url: uri + '/' + id,
        type: 'DELETE',
        success: function (result) {
            getData();
        }
    });
}

function editItem(id) {
    $.each(todos, function (key, item) {
        if (item.id === id) {
            $('#edit-nome').val(item.nome);
            $('#edit-abreviacao').val(item.abreviacao);
            $('#edit-id').val(item.id);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'name': $('#edit-nome').val(),
        'name': $('#edit-abreviacao').val(),
        'id': $('#edit-id').val()
    };

    $.ajax({
        url: uri + '/' + $('#edit-id').val(),
        type: 'PUT',
        accepts: 'application/json',
        contentType: 'application/json',
        data: JSON.stringify(item),
        success: function (result) {
            getData();
        }
    });

    closeInput();
    return false;
});

function closeInput() {
    $('#spoiler').css({ 'display': 'none' });
}