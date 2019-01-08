var CategoryController = function () {
    this.Init = function () {
        //loadCategories();
        loadCategories();
        registerEvents();
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
    }

    //function loadCategories() {
    //    $.ajax({
    //        type: 'GET',
    //        dataType: 'json',
    //        url: 'GetAllCategories',
    //        success: function (response) {
    //            console.log(response);
    //            var render = "<option value=''>Select category</option>";
    //            $.each(response, function (i, item) {
    //                render += "<option value='" + item.id + "'>" + item.Name + "</option>";
    //            });
    //            $('#select-category').html(render);
    //        },
    //        error: function (status) {
    //            console.log(status);
    //        }
    //    });
    //}

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
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Status: getStatus(item.Status),
                        Name: item.Name,
                        Parent: item.ParentId,
                        UpdatedDate: item.DateModified
                    });
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
}