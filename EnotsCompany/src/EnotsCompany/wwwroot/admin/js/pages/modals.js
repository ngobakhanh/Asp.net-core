//------------- modals.js -------------//
$(document).ready(function () {

    //------------- Sparklines in header stats -------------//
    $('#spark-visitors').sparkline([5, 8, 10, 8, 7, 12, 11, 6, 13, 8, 5, 8, 10, 11, 7, 12, 11, 6, 13, 8], {
        type: 'bar',
        width: '100%',
        height: '20px',
        barColor: '#dfe2e7',
        zeroAxis: false,
    });

    $('#spark-templateviews').sparkline([12, 11, 6, 13, 8, 5, 8, 10, 12, 11, 6, 13, 8, 5, 8, 10, 12, 11, 6, 13, 8, 5, 8], {
        type: 'bar',
        width: '100%',
        height: '20px',
        barColor: '#dfe2e7',
        zeroAxis: false,
    });

    $('#spark-sales').sparkline([19, 18, 20, 17, 20, 18, 22, 24, 23, 19, 18, 20, 17, 20, 18, 22, 24, 23, 19, 18, 20, 17], {
        type: 'bar',
        width: '100%',
        height: '20px',
        barColor: '#dfe2e7',
        zeroAxis: false,
    });

    //------------- Bootbox modals -------------//
    //Alert modal
    $('#alert-modal').click(function () {
        bootbox.dialog({
            message: "<img src='/images/" + image + "' width='80px'> <hr/> <input type='file' id='avatar'/>",
            title: "Change Avatar",
            buttons: {
                success: {
                    label: "Close",
                    className: "btn-primary btn-alt",
                    callback: function () {
                        //callback result
                    }
                }
            }
        });
    });


    //Confirm modal
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
                    var my_path = "images/" + status;
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

    //Prompt modal
    $('#prompt-modal').click(function () {
        bootbox.prompt({
            title: "What is your name ?",
            callback: function (result) {
                //callback result
                alert(result);
            }
        });
    });

    //------------- Modals -------------//
    $('#remote-modal').click(function () {
        $('#ajax-modal').modal({
            show: true,
            remote: 'ajax/remoteModal.html'
        });
    });

    //------------- Autoplay video -------------//
    function autoPlayYouTubeModal() {
        var trigger = $("body").find('[data-toggle="modal"]');
        trigger.click(function () {
            var theModal = $(this).data("target"),
            videoSRC = $(this).attr("data-theVideo"),
            videoSRCauto = videoSRC + "?autoplay=1";
            $(theModal + ' iframe').attr('src', videoSRCauto);
            $(theModal + ' button.close').click(function () {
                $(theModal + ' iframe').attr('src', videoSRC);
            });
        });
    }
    autoPlayYouTubeModal();

});