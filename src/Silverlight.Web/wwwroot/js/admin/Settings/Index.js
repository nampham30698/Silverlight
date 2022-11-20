var websiteName = $('#WebsiteName');
var logo = $('#Logo');
var logoShort = $('#LogoShort');
var phone = $('#Phone');
var address = $('#Address');
var facebook = $('#Facebook');
var instagram = $('#Instagram');
var twitter = $('#Twitter');

const url = "/admin/settings/Save";

// Ready
$(function () {
    $('#btnSave').on('click', function () {
        $.ajax({
            url: url,
            type: "POST",
            dataType: 'json',
            data: document.body
        }).done(function () {
            toastr.success("Successfully");
        });
        
    })
});