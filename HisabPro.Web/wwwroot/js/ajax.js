var ajax = {
    post: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', url, data, successCallback, successAdditionalData, errorCallback);
    },
    get: function (url, successCallback, successAdditionalData, errorCallback) {
        callApi('GET', url, null, successCallback, successAdditionalData, errorCallback);
    }
};

function callApi(type, url, data, successCallback, successAdditionalData, errorCallback) {
    var req = {
        type: type,
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
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

    if (data != null) {
        req.data = JSON.stringify(data);
    }

    $.ajax(req);
}