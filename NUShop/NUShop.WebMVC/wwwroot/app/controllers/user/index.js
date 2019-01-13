var UserController = function () {
    this.Init = function () {
        loadUsers();
        getRoles();
        registerEvents();
    }


    var users = [];
    var roles = [];

   
    function registerEvents() {
        $('#select-page-size').on('change', function () {
            NUShopConfig.configs.pageSize = parseInt($(this).val());
            NUShopConfig.configs.pageIndex = 1;
            loadUsers(true);
        });

        $('#search-input').on('keypress', function (e) {
            if (e.which === 13) {
                loadUsers();
            }
        });

        $('#btn-search').on('click', function () {
            loadUsers();
        });

        $('body').on('click', '#btn-select-image', function () {
            $('#file-input-image').click();
        });

        $('#file-input-image').on('change', function () {
            var fileUpload = $(this).get(0);
            var files = fileUpload.files;
            var data = new FormData();
            for (var i = 0; i < files.length; i++) {
                data.append(files[i].name, files[i]);
            }

            $.ajax({
                type: "POST",
                url: "/Admin/Upload/UploadImage",
                contentType: false,
                processData: false,
                data: data,
                success: function (path) {
                    $('#txt-image').val(path);
                    NUShopConfig.toast("success", "Upload successfully.");
                },
                error: function (status) {
                    console.log(status);
                    NUShopConfig.toast("error", "Has an error while uploading.");
                }
            });
        });

        $('#btn-create').off('click').on('click', function () {
            disableFieldEdit(false);
            $('#user-modal').modal('show');
            $('#btn-save').hide();
            $('#btn-add').show();
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var item = [];
            for (var i = 0; i < users.length; i += 1) {
                if (users[i].Id == id) {
                    item = users[i];
                    break;
                }
            }

            $('#txt-hidden-id').val(id);
            $('#txt-fullname').val(item.FullName);
            $('#txt-username').val(item.FullName);

            $('#txt-password').val('********');
            $('#txt-password-confirm').val('********');
            disableFieldEdit(true);

            $('#txt-email').val(item.Email);
            $('#txt-birthday').val(item.BirthDay);
            $('#txt-phone').val(item.Phone);
            $('#txt-image').val(item.Image);
            $('#checkbox-status').prop('checked', item.Status == 1);

            $('#user-modal').modal('show');

            $('#btn-add').hide();
            $('#btn-save').show();
        });

        $('body').on('click', '#btn-add', function (e) {
            e.preventDefault();
            var data = collectData('add');
            $.ajax({
                type: 'POST',
                data: data,
                url: '/Admin/User/Add',
                dataType: 'json',
                success: function (response) {
                    loadUsers();
                    NUShopConfig.toast("success", "Created.");
                },
                error: function (status) {
                    console.log(status);
                    NUShopConfig.toast("error", "Has an error.");
                }
            });
        });

        $('body').on('click', '#btn-save', function (e) {
            e.preventDefault();
            var data = collectData('update');
            $.ajax({
                type: "PUT",
                url: "/Admin/User/Update",
                data: data,
                dataType: "json",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function () {
                    NUShopConfig.toast('success', 'Save user succesful');
                    $('#user-modal').modal('hide');
                    resetForm();

                    NUShopConfig.stopLoading();
                    loadUsers(true);
                },
                error: function () {
                    NUShopConfig.toast('error', 'Has an error');
                    NUShopConfig.stopLoading();
                }
            });
        });

        $('body').on('click', '#btn-close', function () {
            resetForm();
        });

        $('#btn-delete');
    }


    function getRoles(selectedRoles) {
        $.ajax({
            url: "/Admin/Role/GetAll",
            type: 'GET',
            dataType: 'json',
            async: false,
            success: function (response) {
                var template = $('#role-template').html();
                var data = response;
                var render = '';
                $.each(data, function (i, item) {
                    roles.push(item);
                    var checked = '';
                    if (selectedRoles !== undefined && selectedRoles.indexOf(item.Name) !== -1)
                        checked = 'checked';
                    render += Mustache.render(template,
                        {
                            Name: item.Name,
                            Description: item.Description,
                            Checked: checked
                        });
                });
                $('#list-roles').html(render);
            }
        });
    }

    function loadUsers(isPageChanged) {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#search-input').val(),
                pageIndex: NUShopConfig.configs.pageIndex,
                pageSize: NUShopConfig.configs.pageSize
            },
            dataType: 'json',
            url: '/Admin/User/GetAllPaging',
            success: function (response) {
                users = [];
                $.each(response.Results, function (i, item) {
                    users.push(item);
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Status: getStatus(item.Status),
                        UserName: item.UserName,
                        Avatar: item.Avatar,
                        UpdatedDate: item.DateModified
                    });
                });
                if (render != null) {
                    $('#table-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadUsers();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                NUShopConfig.toast('error', 'Has an error.');
            }
        });
    }

    function getStatus(status) {
        if (status == 1)
            return '<span class="status-p bg-primary">Activated</span>';
        else
            return '<span class="status-p bg-danger">Deactivated</span>';
    }

    function wrapPaging(totalRow, callback, changePageSize) {
        var totalPage = Math.ceil(totalRow / NUShopConfig.configs.pageSize);
        if ($('#user-pagination').length === 0 || changePageSize === true) {
            $('#user-pagination').empty();
            $('#user-pagination').removeData("twbs-pagination");
            $('#user-pagination').unbind("page");
        } else {
            $('#user-pagination').twbsPagination({
                totalPages: totalPage,
                visiblePages: 5,
                next: 'Next',
                prev: 'Prev',
                onPageClick: function (event, pageIndex) {
                    NUShopConfig.configs.pageIndex = pageIndex;
                    setTimeout(callback, 200);
                }
            });
        }
    }

    function collectData(action) {
        var roles = [];
        $.each($('input[name="checkbox-role"]'), function (i, item) {
            if ($(item).prop('checked') === true)
                roles.push($(item).prop('value'));
        });

        var data = {
            Fullname: $('#txt-fullname').val(),
            Username: $('#txt-username').val(),
            Password: $('#txt-password').val(),
            Email: $('#txt-email').val(),
            BirthDay: $('#txt-birthday').val(),
            PhoneNumber: $('#txt-phone').val(),
            Avatar: $('#txt-image').val(),
            Roles: roles,
            Status: $('#checkbox-status').is(':checked') == true ? 1 : 0,
        };
        if (action === 'update') {
            data.Id = $('#txt-hidden-id').val();
        }
        return data;
    }

    function resetForm() {
        $('#txt-hidden-id').val('');
        $('#txt-fullname').val('');
        disableFieldEdit(false);
        $('#txt-username').val('');
        $('#txt-password').val('');
        $('#txt-txt-password-confirm').val('');
        $('#txt-email').val('');
        $('#txt-birthday').val('');
        $('#txt-phone').val('');
        $('#txt-image').val('');
        $.each($('input[name="checkbox-role"]'), function (i, item) {
            $(item).prop('checked', false);
        });
        $('#checkbox-status').prop('checked', true);

    }

    function disableFieldEdit(disabled) {
        $('#txt-username').prop('disabled', disabled);
        $('#txt-password').prop('disabled', disabled);
        $('#txt-txt-password-confirm').prop('disabled', disabled);
    }

};

