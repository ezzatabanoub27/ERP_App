$(function () {
    const l = abp.localization.getResource('NewApp'); 
    const form = $('#generalSettingForm');

    form.submit(function (e) {
        e.preventDefault();

        const formData = {
            pageTitle: form.find('[name="pageTitle"]').val(),
            slug: form.find('[name="slug"]').val(),
            publishDate: new Date(form.find('[name="publishDate"]').val()).toISOString(),
            hideFromMenue: form.find('[name="hideFromMenue"]').is(':checked')
        };

        abp.ui.setBusy(form); 

        abp.ajax({
            url: abp.appPath + 'api/app/general-setting/general-setting',
            type: 'POST',
            data: JSON.stringify(formData),
            contentType: 'application/json'
        }).done(function () {
            abp.notify.success(l('SuccessfullyCreated'));
            form[0].reset();
        }).fail(function (error) {
            console.error(error);
            abp.notify.error(l('FailedToCreate'));
        }).always(function () {
            abp.ui.clearBusy(form); 
        });
    });
});
