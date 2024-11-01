var ajax = {
    post: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', null, url, data, successCallback, successAdditionalData, errorCallback);
    },
    get: function (url, successCallback, successAdditionalData, errorCallback) {
        callApi('GET', null, url, null, successCallback, successAdditionalData, errorCallback);
    },
    submitForm: function (url, form, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', form, url, null, successCallback, successAdditionalData, errorCallback);
    }
};

function callApi(type, form, url, data, successCallback, successAdditionalData, errorCallback) {
    var req = {
        type: type,
        url: url,
        success: function (response) {
            if (successCallback) {
                if (successAdditionalData) {
                    response.additionalData = successAdditionalData;
                }
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (errorCallback) {
                errorCallback(xhr, status, error);
            }
            else {
                showNotification(xhr.responseJSON.message, 'danger');
            }
        }
    };

    if (form == null) {
        req.contentType = 'application/json; charset=utf-8';
        req.dataType = 'json';
    }
    else {
        req.data = form.serialize();
    }

    if (data != null) {
        req.data = JSON.stringify(data);
    }

    $.ajax(req);
}