function login() {
    const item = {
        'email': $('#email').val(),
        'senha': $('#senha').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: '/api/login',
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            console.log('Login Done.', result);
            if(result.authenticated) {
                localStorage.setItem("JwtToken", result.accessToken);
                location.href = "/";
            } else {
                alert('error: ' + result.message)
            }
        }
    });
}

function register() {
    const item = {
        'nome': $('#nome').val(),
        'email': $('#email').val(),
        'senha': $('#senha').val()
    };

    $.ajax({
        type: 'POST',
        accepts: 'application/json',
        url: '/api/register',
        contentType: 'application/json',
        data: JSON.stringify(item),
        error: function (jqXHR, textStatus, errorThrown) {
            alert('here');
        },
        success: function (result) {
            console.log('Register Done.', result);
        }
    });
}