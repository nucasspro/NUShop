var ProductQuantityManagement = function(){

    var cachedObj = {
        colors: [],
        sizes: []
    }

    this.Init = function () {
        loadColors();
        loadSizes();
        registerEvents();
    }


    function registerEvents() {
        $('body').on('click', '.btn-quantity', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#txt-hidden-id').val(that);
            loadQuantities();
            $('#product-quantity-modal').modal('show');
        });
        $('body').on('click', '.btn-delete-quantity', function (e) {
            e.preventDefault();
            $(this).closest('tr').remove();
        });

        $('#btn-add-quantity').on('click', function () {
            var template = $('#template-table-quantity').html();
            var render = Mustache.render(template, {
                Id: 0,
                Colors: getColorOptions(null),
                Sizes: getSizeOptions(null),
                Quantity: 0
            });
            $('#table-quantity-content').append(render);
        });
        $("#btn-save-quantity").on('click', function () {
            var quantityList = [];
            $.each($('#table-quantity-content').find('tr'), function (i, item) {
                quantityList.push({
                    Id: $(item).data('id'),
                    ProductId: $('#txt-hidden-id').val(),
                    Quantity: $(item).find('input.txt-quantity').first().val(),
                    SizeId: $(item).find('select.select-size').first().val(),
                    ColorId: $(item).find('select.select-color').first().val(),
                });
            });
            $.ajax({
                url: '/Admin/Product/SaveQuantities',
                data: {
                    productId: $('#txt-hidden-id').val(),
                    quantities: quantityList
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#product-quantity-modal').modal('hide');
                    $('#table-quantity-content').html('');
                }
            });
        });
    }
    function loadQuantities() {
        $.ajax({
            url: '/Admin/Product/GetQuantities',
            data: {
                productId: $('#txt-hidden-id').val()
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var render = '';
                var template = $('#template-table-quantity').html();
                $.each(response, function (i, item) {
                    render += Mustache.render(template, {
                        Id: item.Id,
                        Colors: getColorOptions(item.ColorId),
                        Sizes: getSizeOptions(item.SizeId),
                        Quantity: item.Quantity
                    });
                });
                $('#table-quantity-content').html(render);
            }
        });
    }
    function loadColors() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetColors",
            dataType: "json",
            success: function (response) {
                cachedObj.colors = response;
            },
            error: function () {
                NUShopConfig.toast('error', 'Has an error.');
            }
        });
    }

    function loadSizes() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetSizes",
            dataType: "json",
            success: function (response) {
                cachedObj.sizes = response;
            },
            error: function () {
                NUShopConfig.toast('error', 'Has an error.');
            }
        });
    }

    function getColorOptions(selectedId) {
        var colors = "<select class='form-control select-color'>";
        $.each(cachedObj.colors, function (i, color) {
            if (selectedId === color.Id)
                colors += '<option value="' + color.Id + '" selected="select">' + color.Name + '</option>';
            else
                colors += '<option value="' + color.Id + '">' + color.Name + '</option>';
        });
        colors += "</select>";
        return colors;
    }

    function getSizeOptions(selectedId) {
        var sizes = "<select class='form-control select-size'>";
        $.each(cachedObj.sizes, function (i, size) {
            if (selectedId === size.Id)
                sizes += '<option value="' + size.Id + '" selected="select">' + size.Name + '</option>';
            else
                sizes += '<option value="' + size.Id + '">' + size.Name + '</option>';
        });
        sizes += "</select>";
        return sizes;
    }

}