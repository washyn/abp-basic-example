$(function () {

    var l = abp.localization.getResource('washyn');

    var service = washyn.application.prueba;
    var createModal = new abp.ModalManager(abp.appPath + 'Crud/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Crud/UpdateModal');

    var dataTable = $('#EjemploTable').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: l('Edit'),
                                // visible: abp.auth.isGranted('School.Group.Update'),
                                visible: true,
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: l('Delete'),
                                // visible: abp.auth.isGranted('School.Group.Delete'),
                                visible: true,
                                confirmMessage: function (data) {
                                    return l('GroupDeletionConfirmationMessage', data.record.id);
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info(l('SuccessfullyDeleted'));
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: l('GroupName'),
                data: "nombre"
            },
        ]
    }));

    createModal.onResult(function () {
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        dataTable.ajax.reload();
    });

    $('#NewButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
