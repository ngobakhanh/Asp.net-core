$(document).ready(function () {

    //remove right-sidebar-page

    $('.page-content').removeClass('right-sidebar-page');

    //active slider

    $('input[type=checkbox]').change(function () {
        var id = $(this).val();
        var active;
        if (this.checked) {
            active = true;
        } else {
            active = false;
        }
        $.ajax({
            url: '/Admin/ActiveSlider',
            type: "Post",
            cache: false,
            data: {
                id: id,
                active: active
            },
            success: function (result) {
                var temp = ' <input type="checkbox" value="' + result.sliderId + '" checked="' + result.isActive + '" />';
                $('#' + this.SliderId + '').html(temp);
            },
            error: function (xhr, ajaxOptions, thrownError) {
            }
        });

    });


    //role 

    $(document).on('click', '.delete-role', function () {
        if (confirm("Do you want delete it?")) {
            var role = $(this).data('row');
            $.ajax({
                url: '/Admin/DeleteRole',
                type: "Post",
                cache: false,
                data: {
                    role: role
                },
                success: function (result) {
                    var temp = "";
                    var count = 1;
                    $.each(result, function () {
                        temp += ' <div class="item">';
                        temp += '<tr>'
                        temp += '<td>' + count + '</td>'
                        temp += '<td>' + this.name + '</td>'
                        temp += ' <td>'
                        temp += '<button type="button" class="btn btn-primary pull-right delete-role" data-row="' + this.name + '"> <i class="fa fa-trash-o"></i></button>'
                        //temp += '<button type="button" class="btn btn-danger pull-right edit-role" data-row="' + this.name + '"><i class="fa fa-edit"></i></button>'
                        temp += '</td>'
                        temp += '</tr>'
                        count++;
                    });
                    //alert(temp);
                    $('#table-role').html(temp);
                },
                error: function (xhr, ajaxOptions, thrownError) {
                }
            });
        }

    });


    $('#add-role').click(function () {
        var role = $('#role').val();
        $.ajax({
            url: '/Admin/AddRole',
            type: "Post",
            cache: false,
            data: {
                role: role
            },
            success: function (result) {
                var temp = "";
                var count = 1;
                $.each(result, function () {
                    temp += ' <div class="item">';
                    temp += '<tr>'
                    temp += '<td>' + count + '</td>'
                    temp += '<td>' + this.name + '</td>'
                    temp += ' <td>'
                    temp += '<button type="button" class="btn btn-danger pull-right delete-role" data-row="' + this.name + '"> <i class="fa fa-trash-o"></i></button>'
                    //temp += '<button type="button" class="btn btn-danger pull-right edit-role" data-row="' + this.name + '"><i class="fa fa-edit"></i></button>'
                    temp += '</td>'
                    temp += '</tr>'
                    count++;
                });
                //alert(temp);
                $('#table-role').html(temp);
            },
            error: function (xhr, ajaxOptions, thrownError) {
            }
        });
    });
});