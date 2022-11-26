
// Ready
$(function () {
    $('#btnSave').on('click', function () {
        $('#settingsForm').submit();
    })
});

function handleFileInputChange(fileInfo,type) {
    if (fileInfo.type == 'file') {
        const arrFileExtensionsValid = ['png', 'jpg'];
        let fileName = getFileName(fileInfo);
        let fileExtension = fileName.split('.').pop();

        if (arrFileExtensionsValid.includes(fileExtension)) {
            checkInputFileChange(type);
        }
        else {
            toastr.error("file is not valid format");
        }
    }
}

function checkInputFileChange(type) {
    if (type == 'logo') {
        $('#IsLogoChange').val('true');
    }
    else if (type == 'logoShort') {
        $('#IsLogoShortChange').val('true');
    }
}

function getFileName(elm) {
    var fn = $(elm).val();
    var filename = fn.match(/[^\\/]*$/)[0]; // remove C:\fakename
    return filename;
}