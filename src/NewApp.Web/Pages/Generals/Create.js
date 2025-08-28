$(function () {
    var l = abp.localization.getResource('NewApp');

    var createUrl = abp.appPath + 'api/app/general-setting';

    $('#generalSettingForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            pageTitle: $('#GeneralSetting_PageTitle').val(),
            slug: $('#GeneralSetting_Slug').val(),
            content: $('#GeneralSetting_Content').val(),
            publishDate: $('#GeneralSetting_PublishDate').val(),
            hideFromMenue: $('#GeneralSetting_HideFromMenue').is(':checked')
        };

        abp.ajax({
            url: createUrl,
            type: 'POST',
            data: JSON.stringify(formData),
            contentType: 'application/json'
        }).then(function () {
            abp.notify.success(l('SuccessfullyCreated'));

            $('#generalSettingForm')[0].reset();
        });
    });

    $('#cancelGeneral').on('click', function () {
        $('#generalSettingForm')[0].reset();
    });
});
