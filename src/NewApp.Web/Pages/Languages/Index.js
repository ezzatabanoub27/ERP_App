$(function () {
    var l = abp.localization.getResource('NewApp');

    const fontTypeNames = {
        1: "Legacy",
        2: "Serif",
        3: "Monospace",
        4: "Cursive",
        5: "Fantasy",
        6: "SansSerif"
    };

    const cultureNameNames = {
        0: "AL",
        1: "DZ",
        2: "AT",
        3: "EG",
        4: "CN",
        5: "CA",
        6: "FR",
        7: "DE",
        8: "IN",
        9: "IT",
        10: "JP",
        11: "SA",
        12: "TR",
        13: "US"
    };

    function deleteLanguage(languageId) {
        return abp.ajax({
            url: abp.appPath + 'api/app/language/language/' + languageId,
            type: 'DELETE',
            headers: {
                'RequestVerificationToken': abp.security.antiForgery.getToken()

            }
        });
    }

    var dataTable = $('#LanguagesTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            searching: false,
            order: [[0, "asc"]],
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(newApp.languages.language.getAllLanguages),
            columnDefs: [
                { title: l('Title'), data: "title" },
                {
                    title: l('Font'),
                    data: "font",
                    render: data => l('Enum:FontType.' + fontTypeNames[data])
                },
                {
                    title: l('Culture'),
                    data: "culture",
                    render: data => {
                        var cultureName = cultureNameNames[data];
                        return cultureName ? l('Enum:CultureName.' + cultureName) : data;
                    }
                },
                {
                    title: l('Is Default'),
                    data: "isDefault",
                    render: data => `
                        <div class="form-check form-switch">
                            <input class="form-check-input" type="checkbox" disabled ${data ? 'checked' : ''} />
                        </div>`
                },
                {
                    title: l('Actions'),
                    data: null,
                    orderable: false,
                    render: (data, type, row) => `
                        <button class="btn btn-danger btn-sm delete-language" data-id="${row.id}">
                            ${l('Delete')}
                        </button>`
                }
            ]
        })
    );

    $('#addNewRow').on("click", function () {
        if ($('#newRow').length > 0) return;

        var newRow = $(`
            <tr id="newRow">
                <td><input type="text" class="form-control" id="newTitle" /></td>
                <td>
                    <select class="form-select" id="newFont">
                        <option value="1">${l('Enum:FontType.Legacy')}</option>
                        <option value="2">${l('Enum:FontType.Serif')}</option>
                        <option value="3">${l('Enum:FontType.Monospace')}</option>
                        <option value="4">${l('Enum:FontType.Cursive')}</option>
                        <option value="5">${l('Enum:FontType.Fantasy')}</option>
                        <option value="6">${l('Enum:FontType.SansSerif')}</option>
                    </select>
                </td>
                <td>
                    <select class="form-select" id="newCulture">
                        <option value="0">${l('Enum:CultureName.AL')}</option>
                        <option value="1">${l('Enum:CultureName.DZ')}</option>
                        <option value="2">${l('Enum:CultureName.AT')}</option>
                        <option value="3">${l('Enum:CultureName.EG')}</option>
                        <option value="4">${l('Enum:CultureName.CN')}</option>
                        <option value="5">${l('Enum:CultureName.CA')}</option>
                        <option value="6">${l('Enum:CultureName.FR')}</option>
                        <option value="7">${l('Enum:CultureName.DE')}</option>
                        <option value="8">${l('Enum:CultureName.IN')}</option>
                        <option value="9">${l('Enum:CultureName.IT')}</option>
                        <option value="10">${l('Enum:CultureName.JP')}</option>
                        <option value="11">${l('Enum:CultureName.SA')}</option>
                        <option value="12">${l('Enum:CultureName.TR')}</option>
                        <option value="13">${l('Enum:CultureName.US')}</option>
                    </select>
                </td>
                <td>
                    <input type="checkbox" id="newIsDefault" class="form-check-input" />
                </td>
                <td>
                    <button class="btn btn-primary btn-sm" id="saveNew">${l("Save")}</button>
                    <button class="btn btn-secondary btn-sm" id="cancelNew">${l("Cancel")}</button>
                </td>
            </tr>
        `);

        $('#LanguagesTable tbody').append(newRow);
    });

    $(document).on('click', '#saveNew', function () {
        var newLanguage = {
            title: $('#newTitle').val().trim(),
            font: parseInt($('#newFont').val()),
            culture: parseInt($('#newCulture').val()),
            isDefault: $('#newIsDefault').is(':checked')
        };

        if (!newLanguage.title || isNaN(newLanguage.font) || isNaN(newLanguage.culture)) {
            abp.message.warn(l("AllFieldsAreRequired"));
            return;
        }

        abp.ajax({
            url: abp.appPath + 'api/app/language/create-language',
            type: 'POST',
            data: JSON.stringify(newLanguage)
        }).done(function () {
            abp.notify.success(l('SavedSuccessfully'));
            dataTable.ajax.reload();
            $('#newRow').remove();
        }).fail(function (e) {
            abp.message.error(l("FailedToSave"));
            console.error(e);
        });
    });

    $(document).on('click', '#cancelNew', function () {
        $('#newRow').remove();
    });

    $(document).on('click', '.delete-language', function () {
        var id = $(this).data('id');
        abp.message.confirm(
            l('DeleteConfirmationMessage'),
            l('AreYouSure'),
            function (confirmed) {
                if (confirmed) {
                    deleteLanguage(id)
                        .then(function () {
                            abp.notify.success(l('DeletedSuccessfully'));
                            dataTable.ajax.reload();
                        })
                        .catch(function (e) {
                            abp.message.error(l("FailedToDelete"));
                            console.error(e);
                        });
                }
            }
        );
    });
});
