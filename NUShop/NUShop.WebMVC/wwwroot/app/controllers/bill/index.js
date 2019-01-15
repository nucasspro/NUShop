var BillController = function () {
    var cachedObj = {
        products: [],
        colors: [],
        sizes: [],
        paymentMethods: [],
        billStatuses: []
    }

    this.Init = function () {
        $
        .when(
            loadBillStatus(),
            loadPaymentMethod(),
            loadColors(),
            loadSizes(),
            loadProducts())
        .done(function () {
            loadBills();
        });

        registerEvents();
    }

    function registerEvents() {
        // search, paging
        $("#select-page-size").on('change', function () {
            NUShopConfig.configs.pageSize = parseInt($(this).val());
            NUShopConfig.configs.pageIndex = 1;
            loadBills(true);
        });

        $('#txt-search').on('keypress', function () {
            if (e.which === 13) {
                loadBills();
            }
        });

        $("#btn-search").on('click', function () {
            loadBills();
        });

        // button create
        $("#btn-create").off('click').on('click', function () {
            resetForm();
            $('#bill-modal').modal('show');
            $('#btn-save').hide();
            $('#btn-add').show();
        });

        $('#btn-add').on('click', function (e) {
            e.preventDefault();
            var id = $('#txt-hidden-id').val();
            var customerName = $('#txt-customer-name').val();
            var customerAddress = $('#txt-customer-address').val();
            var customerId = $('#ddlCustomerId').val();
            var customerMobile = $('#txt-customer-phone').val();
            var customerMessage = $('#txt-customer-message').val();
            var paymentMethod = $('#select-payment-method').val();
            var billStatus = $('#select-bill-status').val();
            //bill detail

            var billDetails = [];
            $.each($('#table-bill-details tr'), function (i, item) {
                billDetails.push({
                    Id: $(item).data('id'),
                    ProductId: $(item).find('select.select-product').first().val(),
                    Quantity: $(item).find('input.txt-quantity').first().val(),
                    ColorId: $(item).find('select.select-color').first().val(),
                    SizeId: $(item).find('select.select-size').first().val(),
                    BillId: id
                });
            });

            $.ajax({
                type: "POST",
                url: "/Admin/Bill/Create",
                data: {
                    Id: id,
                    BillStatus: billStatus,
                    CustomerAddress: customerAddress,
                    CustomerId: customerId,
                    CustomerMessage: customerMessage,
                    CustomerMobile: customerMobile,
                    CustomerName: customerName,
                    PaymentMethod: paymentMethod,
                    Status: 1,
                    BillDetails: billDetails
                },
                dataType: "json",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    NUShopConfig.toast('success', 'Save order successful.');
                    $('#modal-detail').modal('hide');
                    resetForm();
                    NUShopConfig.stopLoading();
                    loadBills(true);
                },
                error: function () {
                    NUShopConfig.toast('error', 'Has an error in progress.');
                    NUShopConfig.stopLoading();
                }
            });
            return false;

        });

        // button edit
        $('body').on('click', '.btn-edit', function (e) {
            e.preventDefault();
            var id = $(this).data('id');
            $.ajax({
                type: "GET",
                url: "/Admin/Bill/GetById",
                data: {
                    id: id
                },
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    var data = response;
                    $('#txt-hidden-id').val(data.Id);
                    $('#txt-customer-name').val(data.CustomerName);
                    $('#txt-customer-address').val(data.CustomerAddress);
                    $('#txt-customer-phone').val(data.CustomerMobile);
                    $('#txt-customer-message').val(data.CustomerMessage);
                    $('#select-payment-method').val(data.PaymentMethod);
                    $('#ddlCustomerId').val(data.CustomerId);
                    $('#select-bill-status').val(data.BillStatus);

                    var billDetails = data.BillDetails;
                    if (data.BillDetails != null && data.BillDetails.length > 0) {
                        var render = '';
                        var templateDetails = $('#template-table-bill-details').html();

                        $.each(billDetails, function (i, item) {
                            var products = getProductOptions(item.ProductId);
                            var colors = getColorOptions(item.ColorId);
                            var sizes = getSizeOptions(item.SizeId);

                            render += Mustache.render(templateDetails,
                                {
                                    Id: item.Id,
                                    Products: products,
                                    Colors: colors,
                                    Sizes: sizes,
                                    Quantity: item.Quantity
                                });
                        });
                        $('#table-bill-details').html(render);
                    }
                    $('#modal-detail').modal('show');
                    NUShopConfig.stopLoading();

                },
                error: function (e) {
                    NUShopConfig.toast('error', 'Has an error in progress.');
                    NUShopConfig.stopLoading();
                }
            });
        });

        $('#btn-save').on('click', function (e) {
            e.preventDefault();
            var id = $('#txt-hidden-id').val();
            var customerName = $('#txt-customer-name').val();
            var customerAddress = $('#txt-customer-address').val();
            var customerId = $('#ddlCustomerId').val();
            var customerMobile = $('#txt-customer-phone').val();
            var customerMessage = $('#txt-customer-message').val();
            var paymentMethod = $('#select-payment-method').val();
            var billStatus = $('#select-bill-status').val();
            //bill detail

            var billDetails = [];
            $.each($('#table-bill-details tr'), function (i, item) {
                billDetails.push({
                    Id: $(item).data('id'),
                    ProductId: $(item).find('select.select-product').first().val(),
                    Quantity: $(item).find('input.txt-quantity').first().val(),
                    ColorId: $(item).find('select.select-color').first().val(),
                    SizeId: $(item).find('select.select-size').first().val(),
                    BillId: id
                });
            });

            $.ajax({
                type: "PUT",
                url: "/Admin/Bill/Update",
                data: {
                    Id: id,
                    BillStatus: billStatus,
                    CustomerAddress: customerAddress,
                    CustomerId: customerId,
                    CustomerMessage: customerMessage,
                    CustomerMobile: customerMobile,
                    CustomerName: customerName,
                    PaymentMethod: paymentMethod,
                    Status: 1,
                    BillDetails: billDetails
                },
                dataType: "json",
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    NUShopConfig.toast('success', 'Save order successful.');
                    $('#modal-detail').modal('hide');
                    resetForm();
                    NUShopConfig.stopLoading();
                    loadBills(true);
                },
                error: function () {
                    NUShopConfig.toast('error', 'Has an error in progress.');
                    NUShopConfig.stopLoading();
                }
            });
            return false;

        });


        
        
        $('#btn-add-detail').on('click', function () {
            var template = $('#template-table-bill-details').html();
            var products = getProductOptions(null);
            var colors = getColorOptions(null);
            var sizes = getSizeOptions(null);
            var render = Mustache.render(template,
                {
                    Id: 0,
                    Products: products,
                    Colors: colors,
                    Sizes: sizes,
                    Quantity: 0,
                    Total: 0
                });
            $('#table-bill-details').append(render);
        });

        // modal
        $('body').on('click', '.btn-delete-detail', function () {
            $(this).parent().parent().remove();
        });

        // modal
        $("#btn-export").on('click', function () {
            var that = $('#txt-hidden-id').val();
            $.ajax({
                type: "POST",
                url: "/Admin/Bill/ExportExcel",
                data: { billId: that },
                beforeSend: function () {
                    NUShopConfig.startLoading();
                },
                success: function (response) {
                    window.location.href = response;
                    NUShopConfig.stopLoading();
                }
            });
        });
    }

    function loadBillStatus() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetBillStatus",
            dataType: "json",
            success: function (response) {
                console.log('billstatus');
                console.log(response);
                cachedObj.billStatuses = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $('#select-bill-status').html(render);
            },
            error: function () {
                NUShopConfig.toast('error', "Has an error.");
            }
        });
    }

    function loadPaymentMethod() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetPaymentMethod",
            dataType: "json",
            success: function (response) {
                console.log('paymentmethod');
                console.log(response);
                cachedObj.paymentMethods = response;
                var render = "";
                $.each(response, function (i, item) {
                    render += "<option value='" + item.Value + "'>" + item.Name + "</option>";
                });
                $('#select-payment-method').html(render);
            }
        });
    }

    function loadProducts() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Product/GetAll",
            dataType: "json",
            success: function (response) {
                console.log('product');
                console.log(response);
                cachedObj.products = response;
            },
            error: function () {
                NUShopConfig.toast('error', 'Has an error in progress.');
            }
        });
    }

    function loadColors() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetColors",
            dataType: "json",
            success: function (response) {
                console.log('color');
                console.log(response);
                cachedObj.colors = response;
            },
            error: function () {
                NUShopConfig.toast('error', 'Has an error in progress.');
            }
        });
    }

    function loadSizes() {
        return $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetSizes",
            dataType: "json",
            success: function (response) {
                console.log('size');
                console.log(response);
                cachedObj.sizes = response;
            },
            error: function () {
                NUShopConfig.toast('error', 'Has an error in progress.');
            }
        });
    }

    function getProductOptions(selectedId) {
        var products = "<select class='form-control select-product'>";
        $.each(cachedObj.products, function (i, product) {
            if (selectedId === product.Id)
                products += '<option value="' + product.Id + '" selected="select">' + product.Name + '</option>';
            else
                products += '<option value="' + product.Id + '">' + product.Name + '</option>';
        });
        products += "</select>";
        return products;
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
    

    function loadBills(isPageChanged) {
        $.ajax({
            type: "GET",
            url: "/Admin/Bill/GetAllPaging",
            data: {
                startDate: $('#txt-from-date').val(),
                endDate: $('#txt-from-date').val(),
                keyword: $('#txt-search').val(),
                pageIndex: NUShopConfig.configs.pageIndex,
                pageSize: NUShopConfig.configs.pageSize
            },
            dataType: "json",
            beforeSend: function () {
                NUShopConfig.startLoading();
            },
            success: function (response) {
                console.log(response);
                var template = $('#table-template').html();
                var render = "";
                if (response.RowCount > 0) {
                    $.each(response.Results, function (i, item) {
                        render += Mustache.render(template, {
                            Id: item.Id,
                            BillStatus: getBillStatusName(item.BillStatus),
                            CustomerName: item.CustomerName,
                            PaymentMethod: getPaymentMethodName(item.PaymentMethod),
                            DateCreated: NUShopConfig.dateTimeFormatJson(item.DateCreated)
                        });
                    });
                    //$("#lbl-total-records").text(response.RowCount);
                    if (render != undefined) {
                        $('#table-content').html(render);

                    }
                    wrapPaging(response.RowCount, function () {
                        loadBills();
                    }, isPageChanged);
                }
                else {
                    //$("#lbl-total-records").text('0');
                    $('#table-content').html('');
                }
                NUShopConfig.stopLoading();
            },
            error: function (status) {
                console.log(status);
            }
        });
    };
    function getPaymentMethodName(paymentMethod) {
        var method = $.grep(cachedObj.paymentMethods, function (element, index) {
            return element.Value == paymentMethod;
        });
        if (method.length > 0) 
            return method[0].Name;
        else 
            return '';
    }

    function getBillStatusName(status) {
        var status = $.grep(cachedObj.billStatuses, function (element, index) {
            return element.Value == status;
        });
        if (status.length > 0)
            return status[0].Name;
        else return '';
    }
    function wrapPaging(recordCount, callBack, changePageSize) {
        var totalsize = Math.ceil(recordCount / NUShopConfig.configs.pageSize);
        if ($('#bill-pagination a').length === 0 || changePageSize === true) {
            $('#bill-pagination').empty();
            $('#bill-pagination').removeData("twbs-pagination");
            $('#bill-pagination').unbind("page");
        }
        $('#bill-pagination').twbsPagination({
            totalPages: totalsize,
            visiblePages: 7,
            first: 'First',
            prev: 'Prev',
            next: 'Next',
            last: 'Last',
            onPageClick: function (event, pageIndex) {
                NUShopConfig.configs.pageIndex = pageIndex;
                setTimeout(callBack(), 200);
            }
        });
    }

    function resetForm() {
        $('#txt-hidden-id').val(0);
        $('#txt-customer-name').val('');
        $('#txt-customer-address').val('');
        $('#txt-customer-phone').val('');
        $('#txt-customer-message').val('');
        $('#select-payment-method').val('');

        $('#ddlCustomerId').val('');
        $('#select-bill-status').val('');

        $('#table-bill-details').html('');
    }
}