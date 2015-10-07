/// <reference path="../_references.js" />

var QueueNS = QueueNS || {};

QueueNS.URLS = {
    GET_ALL_URL: "",
    PURGE_URL: "./purge"
};

QueueNS.QueueServiceHelper = function () {

    function ajaxRequest(url, data, method, success, error) {
        $.ajax({
            url: url,
            data: data,
            dataType: "application/json",
            method: method,
            success: success,
            error: error
        });
    };


    function getAll(url, filterData, success, error) {
        ajaxRequest(url, { filters: filterData }, "GET", success, error)
    };

    function purgeQueue(url, queues, success, error) {
        ajaxRequest(url, { queues: queues}, "POST", success, error)
    };

    return {
        getAll: getAll,
        purgeQueue: purgeQueue
    };

};