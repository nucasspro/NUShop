var ProductController = function () {
    this.Init = function () {
        loadCategories();
        loadProducts();
        registerEvents();
        registerControls();
    }

    var products = [];
    var categories = [];
    function registerControls() {
        CKEDITOR.replace('txtDescription', {});
        CKEDITOR.replace('txtContent', {});

    }
    function registerEvents() {

        // search, paging
        $('#select-page-size').on('change', function () {
            NUShopConfig.configs.pageSize = parseInt($(this).val());
            NUShopConfig.configs.pageIndex = 1;
            loadProducts(true);
        });

        $('#search-input').on('keypress', function() {
            if (e.which === 13) {
	            loadProducts();
            }
        });

        $('#btn-search').on('click', function() {
	        loadProducts();
        });

        // upload image
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

        // button create
        $('#btn-create').off('click').on('click', function () {
            resetForm();
            $('#product-modal').modal('show');
            $('#btn-save').hide();
            $('#btn-add').show();
        });

        $('body').on('click', '#btn-add', function (e) {
            e.preventDefault();
            var data = collectData('add');
            $.ajax({
                type: 'POST',
                data: data,
                url: '/Admin/Product/Add',
                dataType: 'json',
                success: function (response) {
                    loadProducts();
                    NUShopConfig.toast("success", "Created.");
                },
                error: function (status) {
                    console.log(status);
                    NUShopConfig.toast("error", "Has an error.");
                }
            });
        });

        // button edit
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var id = $(this).data("id");
            var item = [];
            for (var i = 0; i < products.length; i += 1) {
                if (products[i].Id == id) {
                    item = products[i];
                    break;
                }
            }

            $('#txt-hidden-id').val(id);
            $('#txt-name').val(item.Name);
            $('#select-category').val(item.CategoryId);
            $('#txt-image').val(item.Image);
            $('#txt-price').val(item.Price);
            $('#txt-promotion-price').val(item.PromotionPrice);
            $('#txt-original-price').val(item.OriginalPrice);
            CKEDITOR.instances.txtDescription.setData(item.Description);
            CKEDITOR.instances.txtContent.setData(item.Content);
            $('#checkbox-status').prop('checked', item.Status == 1);
            $('#checkbox-homeflag').prop('checked', item.HomeFlag);
            $('#checkbox-hotflag').prop('checked', item.HotFlag);
            $('#txt-view-count').val(item.ViewCount);
            $('#txt-seo-page-title').val(item.SeoPageTitle);
            $('#txt-seo-alias').val(item.SeoAlias);
            $('#txt-seo-keyword').val(item.SeoKeywords);
            $('#txt-seo-description').val(item.SeoDescription);

            $('#product-modal').modal('show');

            $('#btn-add').hide();
            $('#btn-save').show();
        });

        $('body').on('click', '#btn-save', function (e) {
            e.preventDefault();
            var data = collectData('update');
            $.ajax({
                data: data,
                type: 'PUT',
                url: '/Admin/Product/Update',
                dataType: 'json',
                success: function (response) {
                    $('#product-modal').modal('hide');
                    loadProducts();
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

        // button import
        $('#btn-import').on('click', function () {
            $('#excel-modal').modal('show');
        });

        $('#btn-save-import').on('click', function () {
            var fileUpload = $("#btn-select-import").get(0);
            var files = fileUpload.files;

            // Create FormData object  
            var fileData = new FormData();

            // Looping over all files and add it to FormData object  
            if (files.length <= 0) {
                NUShopConfig.toast('error', "Select file please.");
                return false;
            }
            for (var i = 0; i < files.length; i++) {
                fileData.append("files", files[i]);
            }
            // Adding one more key to FormData object
            if ($('#select-category-excel').val() == "") {
                NUShopConfig.toast('error', "Select category please.");
                return false;
            }
            else {
                fileData.append('categoryId', parseInt($('#select-category-excel').val()));

                $.ajax({
                    url: '/Admin/Product/ImportExcelAsync',
                    type: 'POST',
                    data: fileData,
                    processData: false,  // tell jQuery not to process the data
                    contentType: false,  // tell jQuery not to set contentType
                    success: function (data) {
                        $('#excel-modal').modal('hide');
                        NUShopConfig.toast('success', "Upload successful.");
                        loadProducts();
                    },
                    error: function () {
                        NUShopConfig.toast('error', "Has an error.");
                    }
                });
                return true;
            }
        });

        //button export
        $('#btn-export').on('click', function () {
            $.ajax({
                type: "POST",
                url: "/Admin/Product/ExportExcel",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    window.location.href = response;
                    NUShopConfig.stopLoading();
                },
                error: function () {
                    NUShopConfig.toast('error', 'Has an error in progress');
                    NUShopConfig.stopLoading();
                }
            });
        });
    }

    function loadCategories() {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: '/Admin/Category/GetAll',
            success: function (response) {
                var render = "<option value=''>Select category</option>";
                $.each(response, function (i, item) {
                    categories.push(item);
                    render += "<option value='" + item.Id + "'>" + item.Name + "</option>";
                });
                $('#search-category').html(render);
                $('#select-category').html(render);
                $('#select-category-excel').html(render);
            },
            error: function (status) {
                console.log(status);
            }
        });
    }

    function loadProducts(isPageChanged) {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                keyword: $('#search-input').val(),
                categoryId: $('#search-category').val(),
                pageIndex: NUShopConfig.configs.pageIndex,
                pageSize: NUShopConfig.configs.pageSize
            },
            dataType: 'json',
            url: '/Admin/Product/GetAllPaging',
            success: function (response) {
                $.each(response.Results, function (i, item) {
                    products.push(item);
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Status: getStatus(item.Status),
                        Quantity: item.Quantity,
                        Name: item.Name,
                        Price: item.Price,
                        UpdatedDate: item.DateModified
                    });
                });
                if (render != null) {
                    $('#table-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
                    loadProducts();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
                NUShopConfig.toast('error', 'Has an error.')
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
        if ($('#product-pagination').length === 0 || changePageSize === true) {
            $('#product-pagination').empty();
            $('#product-pagination').removeData("twbs-pagination");
            $('#product-pagination').unbind("page");
        } else {
            $('#product-pagination').twbsPagination({
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
            CategoryId: $('#select-category').val(),
            Image: $('#txt-image').val(),
            Price: $('#txt-price').val(),
            PromotionPrice: $('#txt-promotion-price').val(),
            OriginalPrice: $('#txt-original-price').val(),
            Description: CKEDITOR.instances.txtDescription.getData(),
            Content: CKEDITOR.instances.txtContent.getData(),
            Status: $('#checkbox-status').is(':checked') == true ? 1 : 0,
            HomeFlag: $('#checkbox-homeflag').is(':checked'),
            HotFlag: $('#checkbox-hotflag').is(':checked'),
            ViewCount: $('#txt-view-count').val(),
            Tags: $('#txt-tags').val(),
            Unit: $('#txt-unit').val(),
            SeoPageTitle: $('#txt-seo-page-title').val(),
            seoAlias: $('#txt-seo-alias').val(),
            SeoKeywords: $('#txt-seo-keyword').val(),
            SeoDescription: $('#txt-seo-description').val(),
        };
        if (action === 'update') {
            data.Id = $('#txt-hidden-id').val();
        }
        return data;
    }

    function resetForm() {
        $('#txt-hidden-id').val('');
        $('#txt-name').val('');
        $('#select-category').val('');
        $('#txt-image').val('');
        $('#txt-price').val();
        $('#txt-promotion-price').val();
        $('#txt-original-price').val();
        $('#txt-tags').val();
        $('#txt-unit').val();
        CKEDITOR.instances.txtDescription.setData('');
        CKEDITOR.instances.txtContent.setData('');
        $('#checkbox-status').prop('checked', true);
        $('#checkbox-homeflag').prop('checked', false);
        $('#checkbox-hotflag').prop('checked', false);
        $('#txt-view-count').val();
        $('#txt-seo-page-title').val('');
        $('#txt-seo-alias').val('');
        $('#txt-seo-keyword').val('');
        $('#txt-seo-description').val('');
    }
}