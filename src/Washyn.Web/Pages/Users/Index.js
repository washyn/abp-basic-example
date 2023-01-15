$(function () {
    
    var service = washyn.application.identity.user;
    var createModal = new abp.ModalManager(abp.appPath + 'Users/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Users/UpdateModal');

    var dataTable = $('#TablaUsuarios').DataTable(abp.libs.datatables.normalizeConfiguration({
        processing: true,
        serverSide: true,
        paging: true,
        searching: false,
        autoWidth: false,
        scrollCollapse: true,
        order: [[0, "asc"]],
        lengthChange: false,
        ajax: abp.libs.datatables.createAjax(service.getList),
        columnDefs: [
            {
                rowAction: {
                    items:
                        [
                            {
                                text: 'Editar',
                                visible: true,
                                action: function (data) {
                                    editModal.open({ id: data.record.id });
                                }
                            },
                            {
                                text: 'Eliminar',
                                visible: true,
                                confirmMessage: function (data) {
                                    return "Esta seguro de eliminar ?";
                                },
                                action: function (data) {
                                    service.delete(data.record.id)
                                        .then(function () {
                                            abp.notify.info("Eliminado.");
                                            dataTable.ajax.reload();
                                        });
                                }
                            }
                        ]
                }
            },
            {
                title: "Nombres",
                data: "name",
                sortable: false,
                render: function (arg1, arg2, row) {
                    return (row.name ?? "") + " " + (row.surname ?? "");
                }
            },
            {
                title: "Usuario",
                data: "userName"
            },
            {
                title: "Correo",
                data: "email"
            },
            {
                title: "Activo",
                data: "isActive",
                render: function (data) {
                    return abp.libs.datatables.defaultRenderers.boolean(data);
                }
            },
            {
                title: "Cel",
                data: "phoneNumber"
            },
            {
                title: "Rol",
                data: "rolName"
            }
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
