var ProductController = function() {
    this.Init = function() {
        loadProduct();
        registerEvents();
    }

    function registerEvents() {
        $('#select-page').on('change', function() {
            NUShopConfig.configs.pageSize = parseInt($(this).val());
            NUShopConfig.configs.pageIndex = 1;
            loadProduct(true);
        });
    }

    function loadProduct(isPageChanged) {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
                //categoryId: $('#ddlCategorySearch').val(),
                //keyword: $('#txtKeyword').val(),
                categoryId: null,
                keyword: '',
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
                        Quantity: item.Quantity,
			            Name: item.Name,
			            Price: item.Price,
			            UpdatedDate: item.DateModified
                    });
                });
                $('#lbl-totalrow').text(response.RowCount);
                if (render != null) {
	                $('#table-content').html(render);
                }
                wrapPaging(response.RowCount, function() {
	                loadProduct();
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
        if ($('#paginationUL a').length == 0 || changePageSize === true) {
            $('#paginationUL').empty();
            $('#paginationUL').removeData();
            $('#paginationUL').unbind();
        } else {
            $('#paginationUL').twbsPagination({
                totalPages: totalPage,
	            visiblePages: 7,
	            first: 'First',
                prev: 'Prev',
	            next: 'Next',
                last: 'Last',
                onPageClick: function(e, pageIndex) {
                    NUShopConfig.configs.pageIndex = pageIndex;
                    setTimeout(callback, 200);
                }
            });
        }
    }
}