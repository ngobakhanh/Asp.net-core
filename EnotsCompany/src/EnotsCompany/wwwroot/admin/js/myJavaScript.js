$(document).ready(function () {

    //upload image
    $('#confirm-modal').click(function () {
        var image = $('.avatar').text();
        bootbox.confirm({
            message: "<img id='myUploadedImg' src='/images/" + image + "' width='80px'> <hr/> <input type='file' id='f_UploadImage'>",
            title: "Change Avatar",
            callback: function () {
            }
        });
    });

    var _URL = window.URL || window.webkitURL;

    $('#f_UploadImage').change(function () {
        var file, img;
        if ((file = this.files[0])) {
            img = new Image();
            img.onload = function () {
                sendFile(file);
            };
            img.onerror = function () {
                alert("Not a valid file:" + file.type);
            };
            img.src = _URL.createObjectURL(file);
        }
    });

    $(function () {
        $(document).on("change", "#f_UploadImage", function (event) {
            var file, img;
            if ((file = this.files[0])) {
                img = new Image();
                img.onload = function () {
                    sendFile(file);
                };
                img.onerror = function () {
                    alert("Not a valid file:" + file.type);
                };
                img.src = _URL.createObjectURL(file);
            }
        });
    });

    function sendFile(file) {
        var formData = new FormData();
        formData.append('file', $('#f_UploadImage')[0].files[0]);
        $.ajax({
            type: 'post',
            url: '/Supplier/upload',
            data: formData,
            success: function (status) {
                if (status != 'error') {
                    var my_path = "/images/" + status;
                    $("#myUploadedImg").attr("src", my_path);
                    $("#avatar").attr("src", my_path);
                }
            },
            processData: false,
            contentType: false,
            error: function () {
                alert("Upload avatar unsuccess");
            }
        });
    }
    //*

    $('.delete').click(function (e) {
        if (!confirm('Do you want delete it?'))
            e.preventDefault();
    });

    $('#description-item').html($('#des-item').text());

    $('#myModal').bind('hidden.bs.modal', function () {
        window.location.href = "http://localhost:4333/supplier/index";
    });

    $('.view-detail-invoice').click(function (e) {
        e.preventDefault();
        var id = $(this).data('row');
        $('#invoice-' + id).toggle();
    });

    $(".code-dialog").click(function () {
        var id = $(this).data('row');
        var itemid = $('#' + id + '').val();
        var quantity = $('.quantity-reply').val();
        $.ajax({
            url: 'http://localhost:4333/api/product/' + itemid + '',
            method: 'get',
            cache: false,
            data: id,
            success: function (data) {
                $('#purchaseId').val(id);
                $("#quantity").val(quantity);
                $('#itemname').val(data.itemName);
                $('#discount').val(data.discount);
            },
            error: function (xhr, ajaxOptions, thrownError) {

            }
        });
    });

    $('.view-detail-order').click(function (e) {
        e.preventDefault();
        var id = $(this).data('row');
        $("#row-" + id).toggle();
    });

    for (var i = 0 ; i < $('.inquiry').length; i++) {
        $('#cmt_' + i + '').html($('#cmt1_' + i + '').text());
    }


    setInterval((function () {
        var id = 1;
        $.ajax({
            url: '/Wholesaler/NumMessage',
            type: 'post',
            cache: false,
            data: id,
            timeout: 1000,
            success: function (data) {
                location.reload();
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {

            }
        });
    }), 300000);

    var editor = CKEDITOR.replace('comment');
    $('#sendReply').click(function (e) {
        var data = {
            purchaseId: $('#purchaseId').val(),
            recievedate: $('#basic-datepicker').val(),
            price: $('#price').val(),
            discount: $('#discount').val(),
            tax: $('#tax').val(),
            comment: editor.getData()
        }
        $.ajax({
            url: '/Supplier/ReplyInquiry',
            type: "post",
            cache: false,
            data: data,
            success: function (result) {
                if (result) {
                    $('.alert-danger').addClass('hidden');
                    $('.alert-success').removeClass('hidden');
                }
                else $('.alert-danger').removeClass('hidden');
            },
            error: function (xhr, ajaxOptions, thrownError) {
                $('.alert-danger').removeClass('hidden');
            }
        });
    });
});