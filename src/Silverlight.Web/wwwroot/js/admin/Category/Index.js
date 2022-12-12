
// Ready
$(function () {
    setTimeout(() => {
        initializeTree();
    })

    handleSearch();
});

function handleSearch() {
    $('#btnSearch').on('click', () => {
        var textSearch = $("#TextSearch").val();
        $(".jstree").jstree(true).search(textSearch);
    });

    $(document).keypress(function (event) {
        var keycode = (event.keyCode ? event.keyCode : event.which);
        if (keycode == '13') {
            $("#btnSearch").click();
            event.preventDefault();
        }
    });
}

function initializeTree() {
    $('.jstree').jstree({
        "core": {
            "themes": {
                "responsive": true
            },
            "check_callback": true
        },
        "types": {
            "default": {
                "icon": "fa fa-folder icon-state-warning icon-lg"
            },
            "file": {
                "icon": "fa fa-file icon-state-warning icon-lg"
            }
        },
        "cache": false,
        "state": { "key": "demo2" },
        "plugins": ["contextmenu", "html_data", "search", "crrm", "ui", "types", "wholerow"],
        contextmenu: {
            items: function ($node) {
                console.log($node, '$node');
                return {
                    createItem: {
                        "separator_before": false,
                        "icon": false,
                        "separator_after": false,
                        "_disabled": false,
                        "label": "Create Child",
                        "action": function (obj) {
                            createNode(obj);
                        }
                    },
                    renameItem: {
                        "separator_before": false,
                        "icon": false,
                        "separator_after": false,
                        "_disabled": false,
                        "label": "Rename",
                        "action": function (obj) { renameNode(obj); }
                    },
                    editItem: {
                        "label": "Edit",
                        "action": function (obj) { editNode(obj); }
                    },
                    deleteItem: {
                        "separator_before": false,
                        "icon": false,
                        "separator_after": false,
                        "_disabled": false,
                        "label": "Delete",
                        "action": function (obj) { deleteNode(obj); }
                    },
                    ActiveItem: {
                        "label": "Active",
                        "action": function (obj) { Approve(obj); }
                    },
                    InActiveItem: {
                        "label": "InActive",
                        "action": function (obj) { ApproveNot(obj); }
                    }
                };
            }
        },
    });
}

function createNode(data) {
    let inst = $.jstree.reference(data.reference);
    let obj = inst.get_node(data.reference);

    inst.create_node(obj, {}, "last", function (newNode) {
        setTimeout(function () {
            inst.edit(newNode);
            console.log(newNode, 'newNode');
        }, 0);
    });
}

function renameNode(data) {
    let inst = $.jstree.reference(data.reference);
    let obj = inst.get_node(data.reference);
    inst.edit(obj);
}

function deleteNode(data) {
    let inst = $.jstree.reference(data.reference);
    let obj = inst.get_node(data.reference);
}
