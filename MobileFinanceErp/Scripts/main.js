"use strict";
/**************Start of Script for Application*****************/
var popupNotification;

function getDropdownListById(elementId) {
    return $(document.getElementById(elementId)).data("kendoDropDownList");
}

function postAjaxData(url, data, successFunction, errorFunction) {
    showLoader();
    $.ajax({
        url: url,
        type: 'POST',
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(data),
        success: function (data) { hideLoader(); successFunction(data) },
        error: function (data) { hideLoader(); errorFunction(data) }
    })
}

function showNotification(message, type) {
    popupNotification.show(message, type);
}

function confirmDialog(message, okCallBack, cancelCallback) {
    alertify.confirm(message, okCallBack, cancelCallback)
}

function changeStatus(id, status) {
    confirmDialog(statusConfirmMsg, function () {
        $.ajax({
            type: 'POST',
            url: statusUrl + '/' + id + '?status=' + status,
            success: function (response) {
                if (response.status == true) {
                    showNotification('Status changed successfully', 'success');
                    grid.ajax.reload();
                } else {
                    showNotification('Unable to change the status. Please try again', 'danger');
                }
            }
        })
    }, function () {

    });
}

function postFormData(url, formId, successFunction, errorFunction) {
    var myform = document.getElementById(formId);
    var fd = new FormData(myform);
    $.ajax({
        url: url,
        data: fd,
        cache: false,
        processData: false,
        contentType: false,
        type: 'POST',
        success: successFunction,
        error: errorFunction
    });
}

function openKendoWindow(elementId, url, title, data, closeCallback) {
    var window = $(elementId).kendoWindow({
        width: "615px",
        title: title,
        content: {
            url: url,
            type: 'POST',
            data: data,
        },
        modal: true,
        close: closeCallback,
    });
    var kendoWindow = $(window).data('kendoWindow');
    kendoWindow.center().open();
    return kendoWindow;
}

function getFormData(formId) {
    var formArray = $(document.getElementById(formId)).serializeArray();
    var result = {};
    $.each(formArray, function (i, v) {
        result[v.name] = v.value;
    });
    return result;
}
/**************End of Script for Application*****************/

$(function () {
    //$.ajaxSetup({
    //    beforeSend: function () {
    //        showLoader();
    //    },
    //    complete: function () {
    //        hideLoader();
    //    },
    //    error: function () {
    //        hideLoader();
    //    }
    //})
});


function showLoader() {
    $.blockUI({
        css: {
            border: 'none',
            padding: '15px',
            backgroundColor: '#000',
            '-webkit-border-radius': '10px',
            '-moz-border-radius': '10px',
            opacity: .5,
            color: '#fff'
        }
    });
}

function hideLoader() {
    $.unblockUI();
}

function showSuccess(message) {
    showNotification(message, "success")
}

function showError(message) {
    showNotification(message, "error")
}

$(function () {
    popupNotification = $("#popupNotification").kendoNotification({
        stacking: "down",
        position: {
            top: "60px",

        }
    }).data("kendoNotification");

    if (mainMessage != "" && mainMessage != null && mainMessage != undefined) {
        showSuccess(mainMessage);
    }
});