$(document).ready(function () {

    $('#art-content').html($('#article-content').text());
    //feedback

    $('#btn-feedback').click(function () {
        var itemId = $('#itemId').val();
        var message = $('textarea#message').val();
        $.ajax({
            url: '/Wholesaler/SaveFeedback',
            type: "Post",
            cache: false,
            data: {
                itemId: itemId,
                message: message
            },
            success: function (result) {
                var temp = "";
                $.each(result, function () {
                    temp += '<div class="row">'
                    temp += '<div class="form-group">'
                    temp += '<label class="control-label col-sm-1">'
                    temp += ' <img src="/images/no_avatar.png" class="img-rounded" width="60px" />'
                    temp += '</label>'
                    temp += '<div class="col-sm-11">'
                    temp += '<span class="text-name">' + this.wholesaler.fullname + '</span>'
                    temp += '<p class="text-message">' + this.message + '</p>'
                    temp += '<span class="text-date">' + this.receivedDate + '</span>'
                    temp += '  </div>'
                    temp += '  </div>'
                    temp += ' </div>'
                    temp += '<hr/>'
                });
                //alert(temp);
                $('.list-feedback').html(temp);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                window.location.href = 'http://localhost:4333/Account/Login?returnUrl=/home/itemdetail?id=' + itemId + '';
            }
        });

    });

    //Inquiry
    $('#confirm').click(function () {
        var purchaseId = $(this).data('row');
        $.ajax({
            url: '/Wholesaler/ConfirmPurchase',
            type: "Post",
            cache: false,
            data: {
                purchaseId: purchaseId
            },
            success: function (result) {
                $.notify("Confirm purchase success", "success");
                $('.status_' + purchaseId + '').text("Đã xác nhận");
                window.setTimeout(function () {
                    window.location.href = "http://localhost:4333/Wholesaler";
                }, 500)
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $.notify("Confirm purchase unsuccess. Please try again!", "error");
            }
        });
    });


    for (var i = 0 ; i < $('.inquiry').length ; i++) {
        $('#cmt_' + i + '').html($('#cmt1_' + i + '').text());
    }

    $('.view-detail-order').click(function (e) {
        e.preventDefault();
        var id = $(this).data('row');
        $("#row-" + id).toggle();
    });

    setInterval((function () {
        $.ajax({
            url: '/Wholesaler/NumMessage',
            type: 'post',
            cache: false,
            //data: id,
            timeout: 1000,
            success: function (data) {
                if (data != 0) {
                    $("#message").show();
                    $("#message").html(data);
                }
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                $("#message").hide();
            }
        });
    }), 1000);

    //End Inquiry
});