const RequestType = {
    API: 'api',
    FORM: 'form',
    UPLOAD: 'upload'
}

var ajax = {
    post: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', RequestType.API, url, data, successCallback, successAdditionalData, errorCallback);
    },
    get: function (url, successCallback, successAdditionalData, errorCallback) {
        callApi('GET', RequestType.API, url, null, successCallback, successAdditionalData, errorCallback);
    },
    submitForm: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', RequestType.FORM, url, data, successCallback, successAdditionalData, errorCallback);
    },
    upload: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', RequestType.UPLOAD, url, data, successCallback, successAdditionalData, errorCallback);
    }
};

function callApi(type, reqType, url, data, successCallback, successAdditionalData, errorCallback) {
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
                if (xhr.responseJSON && xhr.responseJSON.message) {
                    showNotification(xhr.responseJSON.message, 'danger');
                }
                else {
                    showNotification(API.Faile, 'danger');
                }
            }
        }
    };

    if (reqType == RequestType.API) {
        req.contentType = 'application/json; charset=utf-8';
        req.dataType = 'json';
    }

    if (reqType == RequestType.FORM) {
        req.data = data.serialize();
    }
    else if (reqType == RequestType.UPLOAD) {
        req.data = data;
        req.contentType = false;
        req.processData = false;
    }
    else if (data != null) {
        req.data = JSON.stringify(data);
    }

    $.ajax(req);
}