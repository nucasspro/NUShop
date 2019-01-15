var WholePriceManagement = function (parent) {
    var cachedObj = {
        colors: [],
        sizes: []
    }

    this.Init = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-whole-price', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#txt-hidden-id').val(that);
            loadWholePrices();
            $('#whole-price-modal').modal('show');
        });
        $('body').on('click', '.btn-delete-whole-price', function (e) {
            e.preventDefault();
            $(this).closest('tr').remove();
        });

        $('#btn-add-whole-price').on('click', function () {
            var template = $('#template-table-whole-price').html();
            var render = Mustache.render(template, {
                Id: 0,
                FromQuantity: 0,
                ToQuantity: 0,
                Price: 0
            });
            $('#table-content-whole-price').append(render);
        });
        $("#btn-save-whole-price").on('click', function () {
            var priceList = [];
            $.each($('#table-content-whole-price').find('tr'), function (i, item) {
                priceList.push({
                    Id: $(item).data('id'),
                    ProductId: $('#txt-hidden-id').val(),
                    FromQuantity: $(item).find('input.txt-quantity-from').first().val(),
                    ToQuantity: $(item).find('input.txt-quantity-to').first().val(),
                    Price: $(item).find('input.txt-whole-price').first().val(),
                });
            });
            $.ajax({
                url: '/admin/Product/SaveWholePrice',
                data: {
                    productId: $('#txt-hidden-id').val(),
                    wholePrices: priceList
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#whole-price-modal').modal('hide');
                    $('#table-content-whole-price').html('');
                }
            });
        });
    }
    function loadWholePrices() {
        $.ajax({
            url: '/admin/Product/GetWholePrices',
            data: {
                productId: $('#txt-hidden-id').val()
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#template-table-whole-price').html();
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        FromQuantity: item.FromQuantity,
                        ToQuantity: item.ToQuantity,
                        Price: item.Price
                    });
                });
                $('#table-content-whole-price').html(render);
            }
        });
    }
    
}