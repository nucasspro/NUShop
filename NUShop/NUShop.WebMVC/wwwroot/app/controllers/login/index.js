var loginController = function (){
    this.initialize = function () {
        loginEvent();
    }

    var loginEvent = function () {

        $('#form_submit').on('click', function (e) {
            e.preventDefault();
            var username = $('#txtInputUsername').val();
            var password = $('#txtInputPassword').val();
            var rememberMe = $('customControlAutosizing').val();
            login(username, password, rememberMe);
        });
    }

    var login = function (username, password, rememberMe) {
        $.ajax({
            type: 'POST',
            data: {
                Username: username,
                Password: password,
                RememberMe: rememberMe
            },
            contentType: 'application/x-www-form-urlencoded;',
            dataType: 'json',
            url: '/admin/login/Authentication',
            success: function (response) {
                if (response.IsSuccess) {
                    window.location.href = '/Admin/Home/Index';
                }
                else {
                    //NUShopConfig.notify('Login unsuccessfully', 'error');
                }
            }
        });
    }
}