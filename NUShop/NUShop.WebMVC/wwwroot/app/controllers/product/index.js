var ProductController = function() {
    this.Init = function() {
	    loadProduct();
    }

    function loadProduct() {
        var template = $('#table-template').html();
        var render = '';
        $.ajax({
            type: 'GET',
            data: {
	            categoryId: 1,
	            keyword: 'pr',
	            pageIndex: 1,
	            pageSize: 2
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
			            UpdatedDate: item.DateModified,
                    });
                    if (render != null) {
	                    $('#table-content').html(render);
                    }

	            });
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
}