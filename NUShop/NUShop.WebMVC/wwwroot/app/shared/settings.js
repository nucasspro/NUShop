var NUShopConfig = {
    configs: {
        pageSize: 10,
        pageIndex: 1
    },
    toast: function (type,message) {
        toastr.options = {
            "closeButton": false,
            "debug": false,
            "newestOnTop": false,
            "progressBar": false,
            "positionClass": "toast-top-center",
            "preventDuplicates": false,
            "onclick": null,
            "showDuration": "300",
            "hideDuration": "1000",
            "timeOut": "5000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
        },
        toastr[type](message)

    },
    confirm: function (message, okCallback) {
        bootbox.confirm({
            message: message,
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (result === true) {
                    okCallback();
                }
            }
        });
    },
    dateFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        return day + "/" + month + "/" + year;
    },
    dateTimeFormatJson: function (datetime) {
        if (datetime == null || datetime == '')
            return '';
        var newdate = new Date(parseInt(datetime.substr(6)));
        var month = newdate.getMonth() + 1;
        var day = newdate.getDate();
        var year = newdate.getFullYear();
        var hh = newdate.getHours();
        var mm = newdate.getMinutes();
        var ss = newdate.getSeconds();
        if (month < 10)
            month = "0" + month;
        if (day < 10)
            day = "0" + day;
        if (hh < 10)
            hh = "0" + hh;
        if (mm < 10)
            mm = "0" + mm;
        if (ss < 10)
            ss = "0" + ss;
        return day + "/" + month + "/" + year + " " + hh + ":" + mm + ":" + ss;
    },
    startLoading: function () {
        if ($('.dv-loading').length > 0) {
            $('.dv-loading').removeClass('hide');
        }
    },
    stopLoading: function () {
        if ($('.dv-loading').length > 0) {
            $('.dv-loading').addClass('hide');
        }
    },
   
    formatNumber: function (number, precision) {
        if (!isFinite(number)) {
            return number.toString();
        }
        else {
            var a = number.toFixed(precision).split('.');
            a[0] = a[0].replace(/\d(?=(\d{3})+$)/g, '$&,');
            return a.join('.');
        }
    }
    //unflattern: function (arr) {
	   // var map = {};
	   // var roots = [];
	   // for (var i = 0; i < arr.length; i += 1) {
		  //  var node = arr[i];
		  //  node.children = [];
		  //  map[node.id] = i; // use map to look-up the parents
		  //  if (node.parentId !== null) {
			 //   arr[map[node.parentId]].children.push(node);
		  //  } else {
			 //   roots.push(node);
		  //  }
	   // }
	   // return roots;
    //}
}

// If ajax has type is POST or PUT, 
// it will get token from form 
// and add it to header to pass the security(CFRS)
$(document).ajaxSend(function (e, xhr, options) {
    if (options.type.toUpperCase() == 'POST') {
        var token = $('form').find("input[name='__RequestVerificationToken']").val();
        xhr.setRequestHeader("RequestVerificationToken", token);
    }
});