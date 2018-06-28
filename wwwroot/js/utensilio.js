const uri = '/api/utensilio';
let utensilios = null;
function getCount(data) {
    const el = $('#counter');
    let name = 'utensilio';
    if (data) {
        if (data > 1) {
            name = 'utensilios';
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
            $('#utensilios').empty();
            getCount(data.length);
            $.each(data, function (key, item) {
                $('<tr>' +
                    '<td>' + item.nome + '</td>' +
                    '<td><button onclick="editItem(' + item.id + ')">Editar</button></td>' +
                    '<td><button onclick="deleteItem(' + item.id + ')">Deletar</button></td>' +
                    '</tr>').appendTo($('#utensilios'));
            });

            utensilios = data;
        }
    });
}

function addItem() {
    const item = {
        'nome': $('#add-nome').val()
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
    $.each(utensilios, function (key, item) {
        if (item.id === id) {
            $('#edit-nome').val(item.nome);
            $('#edit-id').val(item.id);
        }
    });
    $('#spoiler').css({ 'display': 'block' });
}

$('.my-form').on('submit', function () {
    const item = {
        'nome': $('#edit-nome').val(),
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