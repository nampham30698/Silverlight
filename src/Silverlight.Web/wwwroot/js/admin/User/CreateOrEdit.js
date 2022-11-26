
// Ready
$(function () {
    initValidate();
    btnSaveClicked();
});

function btnSaveClicked() {
    $('#btnSave').on("click", function () {
        $('#userForm').submit();
    })
}

function initValidate() {
    $('#userForm').validate({
        focusInvalid: true,
        rules: {
            UserName: {
                required: true,
            },
            FirstName: {
                required: true,
            },
            LastName: {
                required: true,
            }
        },
        messages: {
            UserName: {
                required: "Please enter username",
            },
            FirstName: {
                required: "Please enter firstname",
            },
            LastName: {
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

function uploadFile() {
    let file = $('#UrlImageInputFile')[0].files[0];
    let formData = new FormData();
    formData.append("file", file);

    const url = '/admin/file/upload';

    $.ajax({
        url: url,
        type: 'POST',
        data: formData,
        //processData: false,  // tell jQuery not to process the data
        //contentType: false,  // tell jQuery not to set contentType
        beforeSend: function (xhr) {
            xhr.setRequestHeader("XSRF-TOKEN",
                $('input:hidden[name="__RequestVerificationToken"]').val());
        },
        success: function (result) {
            if (result.status == 'success') {
                toastr.success("Successfully");
            }
            else {
                toastr.error("Failure");
            }
        },
        error: function (jqXHR) {
        },
        complete: function (jqXHR, status) {
        }
    });
}

function handleFileInputChange(fileInfo) {
    if (fileInfo.type == 'file') {
        const arrFileExtensionsValid = ['png', 'jpg'];
        let fileName = getFileName(fileInfo);
        let fileExtension = fileName.split('.').pop();

        if (arrFileExtensionsValid.includes(fileExtension)) {

            $('#IsUrlImageChange').val('True');

            var reader = new FileReader();
            reader.onload = function (e) {
                $('#previewImage').attr('src', e.target.result).fadeIn('slow');
            }
            reader.readAsDataURL(fileInfo.files[0]);
        }
        else {
            toastr.error("file is not valid format");
        }
    }
}

function getFileName(elm) {
    var fn = $(elm).val();
    var filename = fn.match(/[^\\/]*$/)[0]; // remove C:\fakename
    return filename;
}