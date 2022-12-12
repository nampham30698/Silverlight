
// Ready
$(function () {
    initValidate();
    btnSaveClicked();
});

function btnSaveClicked() {
    $('#btnSave').on("click", function () {
        $('#categoryForm').submit();
    })
}

function initValidate() {
    $('#categoryForm').validate({
        focusInvalid: true,
        rules: {
            CategoryType: {
                required: true,
            },
            Name: {
                required: true,
            },
            NameShort: {
                required: true,
            }
        },
        messages: {
            CategoryType: {
                required: "Please enter username",
            },
            Name: {
                required: "Please enter firstname",
            },
            NameShort: {
                required: "Please enter firstname",
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
}