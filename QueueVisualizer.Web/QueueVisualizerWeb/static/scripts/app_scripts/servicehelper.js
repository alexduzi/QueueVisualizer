/// <reference path="../_references.js" />

var QueueNS = QueueNS || {};

QueueNS.URLS = {
    GET_ALL_URL: "/home",
    PURGE_URL: "/purge"
};

QueueNS.QueueServiceHelper = function () {

    function ajaxRequest(url, data, method, success, error) {
        $.ajax({
            url: url,
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            method: method,
            success: function (data, textStatus, jqXHR) {
                success(data, textStatus, jqXHR)
            },
            error: function (jqXHR, textStatus, errorThrown) {
                error(jqXHR, textStatus, errorThrown)
            }
        });
    };

    function ajaxRequestToFormSubmission(form, data, method, success, error) {
        form.submit(function (event) {
            event.preventDefault();

            var $form = $(this),
                url = $form.attr('action');
            
            var posting;

            if (method === 'GET') {
                posting = $.get(url, data);
            }
            else {
                posting = $.get(url, data);
            }

            posting.done(function (data) {
                success(data);
            });

            posting.error(function (data) {
                error(data);
            });
        });
    };

    function getAllFormSubmission(form, data, method, success, error) {
        ajaxRequestToFormSubmission(form, data, method, success, error);
    };

    function getAll(url, filterData, success, error) {
        ajaxRequest(url, filterData, "GET", success, error)
    };

    function purgeQueue(url, queues, success, error) {
        ajaxRequest(url, queues, "POST", success, error)
    };

    return {
        getAll: getAll,
        purgeQueue: purgeQueue,
        getAllFormSubmission: getAllFormSubmission
    };

};