/// <reference path="../_references.js" />
$(function () {

    selectAllMechanism();

    var queueServiceHelper = new QueueNS.QueueServiceHelper();
    
    $("#btnPurge").click(function () {

        var queues = [];
        var selectedQueues = $("input[data-chkline='true']:checked");
        if (selectedQueues.length == 0) {
            showModal("You need to select an queue!");
            return false;
        }

        selectedQueues.each(function (index, element) {

            var elementChk = $(element);
            
        });

        queueServiceHelper.purgeQueue(QueueNS.URLS.GET_ALL_URL, queues, function (){
            successPurge();
            $(this).button('reset');
        },
        function () {
            errorPurge();
            $(this).button('reset');
        });

        $(this).button('loading');
    });

    $("#btnSearch").click(function () {
        queueServiceHelper.getAll('', null, function () {
            successGetAll();
            $(this).button('reset');
        }, function () {
            errorGetAll();
            $(this).button('reset');
        });
        $(this).button('loading');
    });

});

function showModal(msg) {
    $("#msgModal").text(msg);
    $("#myModal").modal();
}

function successPurge(){


}

function errorPurge(){


}

function successGetAll(){


}

function errorGetAll(){


}

function selectAllMechanism() {

    $("input[data-selectall='true']").click(function () {

        $("input[data-chkline='true']").each(function (index, element) {

            var elem = $(element);

            if (elem.prop('checked')) {
                elem.prop('checked', false)
            }
            else {
                elem.prop('checked', 'checked')
            }
        });

    });

};