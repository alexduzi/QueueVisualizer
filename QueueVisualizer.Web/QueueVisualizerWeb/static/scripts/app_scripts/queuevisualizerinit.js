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

    $("#btnSearch").button('reset');
}

function errorPurge(){

    $("#btnSearch").button('reset');
}

function successGetAll(data, textStatus, jqXHR) {
    console.log(data);
    $("#btnSearch").button('reset');
}

function successGetAll(data) {
    console.log(data);
    document.write(data);
    $("#btnSearch").button('reset');
}

function errorGetAll(jqXHR, textStatus, errorThrown) {
    console.log(errorThrown);
    $("#btnSearch").button('reset');
}

function searchClickMechanism() {

    $("#btnSearch").click(function () {
        var self = $(this);
        self.button('loading');

        var filterData = {
            txtQueueName: $('#txtQueueName').val(),
            chkIsPublic: $('#chkIsPublic').is(':checked')
        };

        var queueServiceHelper = new QueueNS.QueueServiceHelper();
        queueServiceHelper.getAllFormSubmission($("#searchForm"), filterData, 'GET', successGetAll, null);

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
        queueServiceHelper.purgeQueue(QueueNS.URLS.PURGE_URL, queues, successPurge, errorPurge);

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