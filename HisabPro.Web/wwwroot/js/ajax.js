var ajax = {
    post: function (url, data, successCallback, errorCallback) {
        callApi('POST', url, data, successCallback, errorCallback);
    },
    get: function (url, successCallback, errorCallback) {
        callApi('GET', url, null, successCallback, errorCallback);
    }
};

function callApi(type, url, data, successCallback, errorCallback) {
    var req = {
        type: type,
        url: url,
        contentType: 'application/json; charset=utf-8',
        dataType: 'json',
        success: function (response) {
            if (successCallback) {
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (errorCallback) {
                errorCallback(xhr, status, error);
            }
        }
    };

    if (data != null) {
        req.data = data;
    }

    $.ajax(req);
}