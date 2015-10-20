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

function successPurge(data) {
    console.log(data);
    //document.write(data);
    $(".table-responsive").replaceWith('<div class="table-responsive">' + $(data).find('.table-responsive').html() + '</div>')
    $("#btnPurge").button('reset');
}

function errorPurge(){

    $("#btnPurge").button('reset');
}

function successGetAll(data) {
    console.log(data);
    //document.write(data);
    $(".table-responsive").replaceWith('<div class="table-responsive">' + $(data).find('.table-responsive').html() + '</div>')
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
            txtQueueName: $('#txtQueueName').val().trim().replace(/(\r\n|\n|\r)/gm,""),
            chkIsPublic: $('#chkIsPublic').is(':checked')
        };

        $(".table-responsive").empty();

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

        var filterData;

        selectedQueues.each(function (index, element) {

            var elementChk = $(element);

            filterData = {
                txtQueueName: elementChk.parent().parent().find('[data-queue-name="true"]').text().trim().replace(/(\r\n|\n|\r)/gm, ""),
                chkIsPublic: $('#chkIsPublic').is(':checked')
            };

            queues.push(filterData);
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