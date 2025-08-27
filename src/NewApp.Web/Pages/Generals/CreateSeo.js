$(function () {
    var l = abp.localization.getResource('NewApp');

    var createUrl = '/api/app/SEOSetting';

    $('#seoSettingForm').submit(function (e) {
        e.preventDefault();

        var formData = {
            metaTitle: $('#SeoSetting_MetaTitle').val(),
            metaDescription: $('#SeoSetting_MetaDescription').val(),
            metaKeyWords: $('#SeoSetting_MetaKeyWords').val(),
            metaIndex: $('#SeoSetting_MetaIndex').is(':checked'),
            metaFollow: $('#SeoSetting_MetaFollow').is(':checked'),
            metaPriority: parseInt($('#SeoSetting_MetaPriority').val()) || 0
        };

        abp.ajax({
            url: createUrl,
            type: 'POST',
            data: JSON.stringify(formData),
            contentType: 'application/json'
        }).then(function () {
            abp.notify.success(l('SuccessfullyCreated'));

            $('#seoSettingForm')[0].reset();
        });
    });
});
