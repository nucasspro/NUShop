var CategoryController = function () {
    this.Init = function () {
        loadParents();
        loadCategories();
        registerEvents();
        registerControls();
    }
    var categories = [];

    function registerControls() {
        CKEDITOR.replace('txtDescription', {});
    }

    function registerEvents() {
        $('#select-page-size').on('change', function () {
            NUShopConfig.configs.pageSize = parseInt($(this).val());
            NUShopConfig.configs.pageIndex = 1;
            loadCategories(true);
        });

        $('#search-input').on('keypress', function () {
            if (e.which === 13) {
                loadCategories();
            }
        });

        $('#btn-search').on('click', function () {
            loadCategories();
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
            $('#category-modal').modal('show');
            $('#btn-save').hide();
            $('#btn-add').show();
        });

        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var item = [];
            for (var i = 0; i < categories.length; i += 1) {
                if (categories[i].Id == id) {
                    item = categories[i];
                    break;
                }
            }

            $('#txt-hidden-id').val(id);
            $('#txt-name').val(item.Name);
            $('#select-parent').val(item.ParentId);
            $('#txt-image').val(item.Image);
            CKEDITOR.instances.txtDescription.setData(item.Description);
            $('#checkbox-status').prop('checked', item.Status == 1);
            $('#checkbox-homeflag').prop('checked', item.HomeFlag);
            $('#txt-seo-page-title').val(item.SeoPageTitle);
            $('#txt-seo-alias').val(item.SeoAlias);
            $('#txt-seo-keyword').val(item.SeoKeywords);
            $('#txt-seo-description').val(item.SeoDescription);
            $('#txt-home-order').val(item.HomeOrder);
            $('#txt-sort-order').val(item.SortOrder);

            $('#category-modal').modal('show');

            $('#btn-add').hide();
            $('#btn-save').show();
        });

        $('body').on('click', '#btn-add', function (e) {
            e.preventDefault();
            var data = collectData('add');
            $.ajax({
                type: 'POST',
                data: data,
                url: '/Admin/Category/Add',
                dataType: 'json',
                success: function (response) {
                    loadCategories();
                    loadParents();
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
                data: data,
                type: 'PUT',
                url:'/Admin/Category/Update',
                dataType: 'json',
                success: function (response) {
                    loadCategories();
                    loadParents();
                    NUShopConfig.toast("success", "Saved.");
                },
                error: function (status) {
                    console.log(status);
                    NUShopConfig.toast("error", "Has an error.");
                }
            });
        });

        $('body').on('click', '#btn-close', function () {
            resetForm();
        });

        //$('body').on('click', '.btn-delete', function (e) {
        //    e.preventDefault();
        //    $.ajax({
        //        type: 'DELETE',
        //        url: '/Admin/Category/Delete/' + $(this).data('id'),
        //        success: function (response) {
        //            loadCategories();
        //            loadParents();
        //        },
        //        error: function (status) {
        //            console.log(status);
        //        }
        //    });
        //});
    }

    function loadParents() {
        categories = [];
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/Admin/Category/GetAll',
            success: function (response) {
                $.each(response, function (i, item) {
                    categories.push(item);

                    var renderCategory = "<option value=''>Select category</option>";
                    $.each(categories, function (i, item) {
                        renderCategory += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                    });

                    $('#select-category').html(renderCategory);
                    $('#select-parent').html(renderCategory);
                });
            },
            error: function (status) {
                console.log(status);
                NUShopConfig.toast("error", "Has an error.");
            }
        });
    }

    function loadCategories(isPageChanged) {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#search-input').val(),
                categoryId: null,
                pageIndex: NUShopConfig.configs.pageIndex,
                pageSize: NUShopConfig.configs.pageSize
            },
            dataType: 'json',
            url: 'GetAllPaging',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Status: getStatus(item.Status),
                        Name: item.Name,
                        Parent: item.ParentId,
                        UpdatedDate: item.DateModified
                    });
                });

                if (render != null) {
                    $('#table-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadCategories();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                NUShopConfig.toast("error", "Has an error.");
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
        if ($('#category-pagination').length === 0 || changePageSize === true) {
            $('#category-pagination').empty();
            $('#category-pagination').removeData("twbs-pagination");
            $('#category-pagination').unbind("page");
        } else {
            $('#category-pagination').twbsPagination({
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
        var data = {
            Name: $('#txt-name').val(),
            ParentId: $('#select-parent').val(),
            Image: $('#txt-image').val(),
            Description: CKEDITOR.instances.txtDescription.getData(),
            Status: $('#checkbox-status').is(':checked') == true ? 1 : 0,
            HomeFlag: $('#checkbox-homeflag').is(':checked'),
            SeoPageTitle: $('#txt-seo-page-title').val(),
            seoAlias: $('#txt-seo-alias').val(),
            SeoKeywords: $('#txt-seo-keyword').val(),
            SeoDescription: $('#txt-seo-description').val(),
            HomeOrder: $('#txt-home-order').val(),
            SortOrder: $('#txt-sort-order').val()
        };
        if (action === 'update') {
            data.Id = $('#txt-hidden-id').val();
        }
        
        return data;
    }

    function resetForm() {
        $('#txt-hidden-id').val('');
        $('#txt-name').val('');
        $('#select-parent').val('');
        $('#txt-image').val('');
        CKEDITOR.instances.txtDescription.setData('');
        $('#checkbox-status').prop('checked', true);
        $('#checkbox-homeflag').prop('checked', false);
        $('#txt-seo-page-title').val('');
        $('#txt-seo-alias').val('');
        $('#txt-seo-keyword').val('');
        $('#txt-seo-description').val('');
        $('#txt-home-order').val('');
        $('#txt-sort-order').val('');
    }
}