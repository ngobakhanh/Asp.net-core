if ($('#back-to-top').length) {
    var scrollTrigger = 100, // px
        backToTop = function () {
            var scrollTop = $(window).scrollTop();
            if (scrollTop > scrollTrigger) {
                $('#back-to-top').addClass('show');
            } else {
                $('#back-to-top').removeClass('show');
            }
        };
    backToTop();
    $(window).on('scroll', function () {
        backToTop();
    });
    $('#back-to-top').on('click', function (e) {
        e.preventDefault();
        $('html,body').animate({
            scrollTop: 0
        }, 700);
    });
}

var editor = CKEDITOR.replace('comment');

$('#description-item').html($('#des-item').text());

$('#faq-item').html($('#f-item').text());

$('#MinQuantity').on('change', function () {
    $('#quantity').val($('#MinQuantity').val());
});

$("#sendInquiry").click(function () {
    var data = {
        itemId: $('#itemId').val(),
        quantity: $('#quantity').val(),
        comment: editor.getData()
    }

    $.ajax({
        url: "/Wholesaler/SaveInquiry",//Controller/Action xu ly yeu cau
        method: "post",//Phuong thuc gui du lieu len server
        async: true,//Xu ly yeu cau theo kieu bat dong bo
        cache: false,//Khong cache du lieu
        data: data,
        success: function (result) {
            if (result == true) {
                //$('.label-info').val("Đã xác nhận");
                $.notify("Send inquiry success", "success");
                window.setTimeout(function () {
                    window.location.href = "http://localhost:4333/Wholesaler/Inquiry";
                }, 500)
            }
            else {
                window.localtion.href = "http://localhost:4333/Account/Login";
            }
            //$.notify("Send inquiry usuccess. Please try again !", "success");
        },
        error: function (xhr, ajaxOptions, thrownError) {
            //window.localtion.href = "http://localhost:4333/Account/Login";
            $.notify("Send inquiry usuccess. Please try again !", "success");
        }
    });
});



//$('#itemslider').carousel({ interval: 3000 });

//$('.carousel-showmanymoveone .item').each(function () {
//    var itemToClone = $(this);

//    for (var i = 1; i < 6; i++) {
//        itemToClone = itemToClone.next();

//        if (!itemToClone.length) {
//            itemToClone = $(this).siblings(':first');
//        }

//        itemToClone.children(':first-child').clone()
//        .addClass("cloneditem-" + (i))
//        .appendTo($(this));
//    }
//});

$(document).ready(function () {
    $('.carousel').carousel({
        pause: true,
        interval: false
    });
});




$(document).ready(function () {
    $(".col-md-3 ").mouseenter(function () {
        $(this).find(".col-img-responsive02").show(200);
    });


    $(".col-md-3").mouseleave(function () {
        $(this).find(".col-img-responsive02").hide();
    });
});