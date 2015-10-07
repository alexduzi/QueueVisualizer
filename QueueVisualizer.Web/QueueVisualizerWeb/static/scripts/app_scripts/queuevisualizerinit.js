/// <reference path="../_references.js" />
$(function () {

    selectAllMechanism();

    purgeClickMechanism();

    searchClickMechanism();

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

function searchClickMechanism() {

    $("#btnSearch").click(function () {
        var self = $(this);
        self.button('loading');

        var filterData = $("#searchForm").serialize();

        var queueServiceHelper = new QueueNS.QueueServiceHelper();
        queueServiceHelper.getAll(QueueNS.URLS.GET_ALL_URL, filterData, function () {
            successGetAll();
            self.button('reset');

        }, function () {
            errorGetAll();
            self.button('reset');

        });

    });

}

function purgeClickMechanism() {

    $("#btnPurge").click(function () {
        var self = $(this);
        self.button('loading');
        var queues = [];

        var selectedQueues = $("input[data-chkline='true']:checked");
        if (selectedQueues.length == 0) {
            showModal("You need to select an queue!");
            self.button('reset');
            return false;
        }

        selectedQueues.each(function (index, element) {

            var elementChk = $(element);

        });

        var queueServiceHelper = new QueueNS.QueueServiceHelper();
        queueServiceHelper.purgeQueue(QueueNS.URLS.PURGE_URL, queues, function () {
            successPurge();
            self.button('reset');
        },
        function () {
            errorPurge();
            self.button('reset');
        });

        
    });

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