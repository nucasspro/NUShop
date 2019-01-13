var RoleController = function () {
    var self = this;

    this.Init = function () {
        loadRoles();
        registerEvents();
    }


    function registerEvents() {
        $("#select-page-size").on('change', function () {
            NUShopConfig.configs.pageSize = $(this).val();
            NUShopConfig.configs.pageIndex = 1;
            loadRoles(true);
        });

        $('#search-input').keypress(function (e) {
            if (e.which == 13) {
                e.preventDefault();
                loadRoles();
            }
        });

        $("#btn-search").on('click', function () {
            loadRoles();
        });

        $("#btn-create").on('click', function () {
            resetForm();
            $('#role-modal').modal('show');
            $('#btn-save').hide();
            $('#btn-add').show();
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();

            $.ajax({
                type: "GET",
                url: "/Admin/Role/GetById",
                data: {
                    id: $(this).data('id')
                },
                dataType: "json",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#txt-hidden-id').val(data.Id);
                    $('#txt-name').val(data.Name);
                    $('#txt-description').val(data.Description);
                    $('#btn-add').hide();
                    $('#btn-save').show();
                    $('#role-modal').modal('show');
                    NUShopConfig.stopLoading();

                },
                error: function (status) {
                    NUShopConfig.toast('error', 'Has an error.');
                    NUShopConfig.stopLoading();
                }
            });
        });

        $('body').on('click', '#btn-add', function (e) {
            e.preventDefault();
            var data = collectData('add');
            $.ajax({
                type: 'POST',
                data: data,
                url: '/Admin/Role/Add',
                dataType: 'json',
                success: function (response) {
                    $('#user-modal').modal('hide');
                    loadRoles();
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
                url: "/Admin/Role/Update",
                data: data,
                dataType: "json",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    $('#user-modal').modal('hide');
                    resetForm();
                    NUShopConfig.stopLoading();
                    loadRoles(true);
                    NUShopConfig.toast("success", "Saved.");
                },
                error: function () {
                    NUShopConfig.toast("error", "Has an error.");
                    NUShopConfig.stopLoading();
                }
            });
            return false;
        });

        $('body').on('click', '#btn-close', function () {
            resetForm();
        });

        $('body').on('click', '#btn-delete', function (e) {
            e.preventDefault();
            var roleId = $(this).data('id');
            NUShopConfig.confirm('Are you sure to delete?', function () {
                $.ajax({
                    type: "POST",
                    url: "/Admin/Role/Delete",
                    dataType: "json",
                    data: {
                        id: roleId
                    },
                    beforeSend: function () {
                        NUShopConfig.startLoading();
                    },
                    success: function (response) {
                        NUShopConfig.toast('success', 'Delete successful');
                        NUShopConfig.stopLoading();
                        loadRoles();
                    },
                    error: function (status) {
                        NUShopConfig.toast('error', 'Has an error in deleting progress');
                        NUShopConfig.stopLoading();
                    }
                });
            });
        });

        //Grant permission
        $('body').on('click', '.btn-grant', function () {
            $('#txt-hidden-id').val($(this).data('id'));
            $.when(loadFunctions()).done(fillPermission($('#txt-hidden-id').val()));
            $('#modal-grantpermission').modal('show');
        });

        

        //$("#btnSavePermission").off('click').on('click', function () {
        //    var listPermmission = [];
        //    $.each($('#tblFunction tbody tr'), function (i, item) {
        //        listPermmission.push({
        //            RoleId: $('#txt-hidden-id').val(),
        //            FunctionId: $(item).data('id'),
        //            CanRead: $(item).find('.ckView').first().prop('checked'),
        //            CanCreate: $(item).find('.ckAdd').first().prop('checked'),
        //            CanUpdate: $(item).find('.ckEdit').first().prop('checked'),
        //            CanDelete: $(item).find('.ckDelete').first().prop('checked'),
        //        });
        //    });
        //    $.ajax({
        //        type: "POST",
        //        url: "/Admin/Role/UpdatePermission",
        //        data: {
        //            listPermmission: listPermmission,
        //            roleId: $('#txt-hidden-id').val()
        //        },
        //        beforeSend: function () {
        //            tedu.startLoading();
        //        },
        //        success: function (response) {
        //            tedu.notify('Save permission successful', 'success');
        //            $('#modal-grantpermission').modal('hide');
        //            tedu.stopLoading();
        //        },
        //        error: function () {
        //            tedu.notify('Has an error in save permission progress', 'error');
        //            tedu.stopLoading();
        //        }
        //    });
        //});
    };

    function loadFunctions(callback) {
        return $.ajax({
            type: "GET",
            url: "/Admin/Function/GetAll",
            dataType: "json",
            beforeSend: function () {
                NUShopConfig.startLoading();
            },
            success: function (response) {
                var template = $('#result-data-function').html();
                var render = "";
;                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Name: item.Name,
                        treegridparent: item.ParentId != null ? "treegrid-parent-" + item.ParentId : "",
                        Id: item.Id,
                        AllowCreate: item.AllowCreate ? "checked" : "",
                        AllowEdit: item.AllowEdit ? "checked" : "",
                        AllowView: item.AllowView ? "checked" : "",
                        AllowDelete: item.AllowDelete ? "checked" : "",
                        Status: tedu.getStatus(item.Status),
                    });
                });
                if (render != undefined) {
                    $('#lst-data-function').html(render);
                }
                $('.tree').treegrid();

                $('#ckCheckAllView').on('click', function () {
                    $('.ckView').prop('checked', $(this).prop('checked'));
                });

                $('#ckCheckAllCreate').on('click', function () {
                    $('.ckAdd').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllEdit').on('click', function () {
                    $('.ckEdit').prop('checked', $(this).prop('checked'));
                });
                $('#ckCheckAllDelete').on('click', function () {
                    $('.ckDelete').prop('checked', $(this).prop('checked'));
                });

                $('.ckView').on('click', function () {
                    if ($('.ckView:checked').length == response.length) {
                        $('#ckCheckAllView').prop('checked', true);
                    } else {
                        $('#ckCheckAllView').prop('checked', false);
                    }
                });
                $('.ckAdd').on('click', function () {
                    if ($('.ckAdd:checked').length == response.length) {
                        $('#ckCheckAllCreate').prop('checked', true);
                    } else {
                        $('#ckCheckAllCreate').prop('checked', false);
                    }
                });
                $('.ckEdit').on('click', function () {
                    if ($('.ckEdit:checked').length == response.length) {
                        $('#ckCheckAllEdit').prop('checked', true);
                    } else {
                        $('#ckCheckAllEdit').prop('checked', false);
                    }
                });
                $('.ckDelete').on('click', function () {
                    if ($('.ckDelete:checked').length == response.length) {
                        $('#ckCheckAllDelete').prop('checked', true);
                    } else {
                        $('#ckCheckAllDelete').prop('checked', false);
                    }
                });
                if (callback != undefined) {
                    callback();
                }
                NUShopConfig.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    }

    function fillPermission(roleId) {
        return $.ajax({
            type: "POST",
            url: "/Admin/Role/GetAllFunction",
            data: {
                roleId: roleId
            },
            dataType: "json",
            beforeSend: function () {
                NUShopConfig.stopLoading();
            },
            success: function (response) {
                var litsPermission = response;
                $.each($('#tblFunction tbody tr'), function (i, item) {
                    $.each(litsPermission, function (j, jitem) {
                        if (jitem.FunctionId == $(item).data('id')) {
                            $(item).find('.ckView').first().prop('checked', jitem.CanRead);
                            $(item).find('.ckAdd').first().prop('checked', jitem.CanCreate);
                            $(item).find('.ckEdit').first().prop('checked', jitem.CanUpdate);
                            $(item).find('.ckDelete').first().prop('checked', jitem.CanDelete);
                        }
                    });
                });

                if ($('.ckView:checked').length == $('#tblFunction tbody tr .ckView').length) {
                    $('#ckCheckAllView').prop('checked', true);
                } else {
                    $('#ckCheckAllView').prop('checked', false);
                }
                if ($('.ckAdd:checked').length == $('#tblFunction tbody tr .ckAdd').length) {
                    $('#ckCheckAllCreate').prop('checked', true);
                } else {
                    $('#ckCheckAllCreate').prop('checked', false);
                }
                if ($('.ckEdit:checked').length == $('#tblFunction tbody tr .ckEdit').length) {
                    $('#ckCheckAllEdit').prop('checked', true);
                } else {
                    $('#ckCheckAllEdit').prop('checked', false);
                }
                if ($('.ckDelete:checked').length == $('#tblFunction tbody tr .ckDelete').length) {
                    $('#ckCheckAllDelete').prop('checked', true);
                } else {
                    $('#ckCheckAllDelete').prop('checked', false);
                }
                NUShopConfig.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    }

    

    function loadRoles(isPageChanged) {
        var template = $('#table-template').html();
        var render = "";
        $.ajax({
            type: "GET",
            url: "/Admin/role/GetAllPaging",
            data: {
                keyword: $('#search-input').val(),
                pageSize: NUShopConfig.configs.pageSize,
                pageIndex: NUShopConfig.configs.pageIndex
            },
            dataType: "json",
            beforeSend: function () {
                NUShopConfig.startLoading();
            },
            success: function (response) {
                if (response.RowCount > 0) {
                    $.each(response.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            Name: item.Name,
                            Description: item.Description
                        });
                    });
                    if (render != undefined) {
                        $('#table-content').html(render);
                    }
                    wrapPaging(response.RowCount, function () {
                        loadRoles();
                    }, isPageChanged);
                }
                else {
                    $('#tbl-content').html('');
                }
                NUShopConfig.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    };

    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / NUShopConfig.configs.pageSize);
        //Unbind pagination if it existed or click change pagesize
        if ($('#role-pagination').length === 0 || changePageSize === true) {
            $('#role-pagination').empty();
            $('#role-pagination').removeData("twbs-pagination");
            $('#role-pagination').unbind("page");
        }
        //Bind Pagination Event
        $('#role-pagination').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'First',
            prev: 'Prev',
            next: 'Next',
            last: 'Last',
            onPageClick: function (event, p) {
                NUShopConfig.configs.pageIndex = p;
                setTimeout(callBack(), 200);
            }
        });
    }

    function collectData(action) {
        var data = {
            Name: $('#txt-name').val(),
            Description: $('#txt-description').val(),
        };
        if (action === 'update') {
            data.Id = $('#txt-hidden-id').val();
        };
        return data;
    }

    function resetForm() {
        $('#txt-hidden-id').val('');
        $('#txt-name').val('');
        $('#txt-description').val('');
    }

}