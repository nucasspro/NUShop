var ProductImageManagement = function () {

    var parent = parent;
    var images = [];

    this.Init = function () {
        registerEvents();
    }

    function registerEvents() {
        $('body').on('click', '.btn-images', function (e) {
            e.preventDefault();
            var that = $(this).data('id');
            $('#txt-hiddent-id').val(that);
            clearFileInput($("#file-image"));
            loadImages();
            $('#product-image-modal').modal('show');
        });

        $('body').on('click', '.btn-delete-image', function (e) {
            e.preventDefault();
            $(this).closest('div').remove();
        });

        $("#file-image").on('change', function () {
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
                    clearFileInput($("#file-image"));
                    images.push(path);
                    $('#image-list').append('<div class="col-md-3"><img width="100"  data-path="' + path + '" src="' + path + '"></div>');
                    NUShopConfig.toast('success', 'Uploaded');
                },
                error: function () {
                    NUShopConfig.toast('error', 'Has an error');
                }
            });
        });

        $("#btn-save-images").on('click', function () {
            var imageList = [];
            $.each($('#image-list').find('img'), function (i, item) {
                imageList.push($(this).data('path'));
            });
            $.ajax({
                url: '/admin/Product/SaveImages',
                data: {
                    productId: $('#txt-hiddent-id').val(),
                    images: images
                },
                type: 'post',
                dataType: 'json',
                success: function (response) {
                    $('#product-image-modal').modal('hide');
                    $('#image-list').html('');
                    clearFileInput($("#file-image"));
                }
            });
        });
    }
    function loadImages() {
        $.ajax({
            url: '/admin/Product/GetImages',
            data: {
                productId: $('#txt-hiddent-id').val()
            },
            type: 'get',
            dataType: 'json',
            success: function (response) {
                var render = '';
                $.each(response, function (i, item) {
                    render += '<div class="col-md-3"><img width="100" src="' + item.Path + '"><br/><a href="#" class="btn-delete-image">Xóa</a></div>'
                });
                $('#image-list').html(render);
                clearFileInput();
            }
        });
    }

    function clearFileInput(ctrl) {
        //try {
        //    ctrl.value = null;
        //} catch (ex) { }
        //if (ctrl.value) {
        //    ctrl.parentNode.replaceChild(ctrl.cloneNode(true), ctrl);
        //}
    }
}