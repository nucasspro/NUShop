var CategoryController = function () {
    this.Init = function () {
        loadCategories();
        registerEvents();
    }
    var categories = [];
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

        $('#btn-create').off('click').on('click', function () {
	        $('#category-modal').modal('show');
        });


        $('body').on('click', '.btn-edit', function(e) {
            e.preventDefault();
            var id = $(this).data("id");
            var item = [];
            for (var i = 0; i < categories.length; i += 1) {
	            if (categories[i].Id == id) {
		            item = categories[i];
		            break;
	            }
            }
            $('#hidden-id').val(id);
            $('#txt-name').val(item.Name);
            $('#txt-des').val(item.Description);
            $('#txt-image').val(item.Image);
            $('#txt-seo-keyword').val(item.SeoKeywords);
            $('#txt-seo-des').val(item.SeoDescription);
            $('#txt-seo-title').val(item.SeoPageTitle);
            $('#txt-seo-alias').val(item.SeoAlias);
            $('#checkbox-status').prop('checked', item.Status == 1);
            $('#btn-home').prop('checked', item.HomeFlag);
            $('#txt-sort-order').val(item.SortOrder);
            $('#txt-home-order').val(item.HomeOrder);
            $('#category-modal').modal('show');
        });

        $('body').on('click', '#btn-save', function() {

        });

        $('body').on('click', '#btn-close', function () {
	        resetForm();
        });


        $('#btn-delete');
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
                console.log(response);
                $.each(response.Results, function (i, item) {
	                categories.push(item);
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Status: getStatus(item.Status),
                        Name: item.Name,
                        Parent: item.ParentId,
                        UpdatedDate: item.DateModified
                    });

                    var renderCategory = "<option value=''>Select category</option>";
                    $.each(categories, function (i, item) {
	                    renderCategory += "<option value='" + item.id + "'>" + item.Name + "</option>";
                    });
                    $('#select-category').html(renderCategory);
                    $('#select-parent').html(renderCategory);
                });


                
                $('#lbl-totalrow').text(response.RowCount);
                if (render != null) {
                    $('#table-content').html(render);
                }
                wrapPaging(response.RowCount, function () {
	                loadCategories();
                }, isPageChanged);
            },
            error: function (status) {
                console.log(status);
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

    function resetForm() {
	    $('#hidden-id').val();
	    $('#txt-name').val('');
	    $('#txt-des').val('');
	    $('#txt-image').val('');
	    $('#txt-seo-keyword').val('');
	    $('#txt-seo-des').val('');
	    $('#txt-seo-title').val('');
	    $('#txt-seo-alias').val('');
	    $('#txt-sort-order').val('');
	    $('#txt-home-order').val('');
	    $('#checkbox-status').prop('checked', true);
	    $('#checkbox-show-home').prop('checked', false);
    }
}