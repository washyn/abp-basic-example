$(function () {

    // var l = abp.localization.getResource('School');
    var service = washyn.application.prueba;
    
    var createModal = new abp.ModalManager(abp.appPath + 'Crud/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Crud/EditModal');

    var dataTable = $('#Table').DataTable(abp.libs.datatables.normalizeConfiguration({
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
                    // title: "Opciones",
                    items:
                        [
                            {
                                text: 'Edit',
                                // visible: abp.auth.isGranted('School.Enrollment.Update'),
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: 'Delete',
                                // visible: abp.auth.isGranted('School.Enrollment.Delete'),
                                confirmMessage: function (data) {
                                    // return l('EnrollmentDeletionConfirmationMessage', data.record.id);
                                    return "Esta seguro de eliminar este elemento.";
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info("Eliminado correctamente");
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: 'Id',
                data: "id"
            },
            {
                title: "Nombre",
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
