const RequestType = {
    API: 'api',
    FORM: 'form',
    UPLOAD: 'upload',
    HTML: 'html',
    DOWNLOAD: 'download'
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
    },
    html: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', RequestType.HTML, url, data, successCallback, successAdditionalData, errorCallback);
    },
    download: function (url, data, successCallback, successAdditionalData, errorCallback) {
        callApi('POST', RequestType.DOWNLOAD, url, data, successCallback, successAdditionalData, errorCallback);
    },
};

//Ensure CSRF Token Compatibility: If your application uses CSRF protection, include the CSRF token in AJAX requests.
//$.ajaxSetup({
//    headers: { 'X-CSRF-TOKEN': $('input[name="__RequestVerificationToken"]').val() }
//});

function setLoadingIndicator(loadingContainer, show = false) {
    //Hide loading indicator
    if (loadingContainer) {
        if (show) {
            loadingContainer.fadeIn();
        }
        else {
            loadingContainer.fadeOut();
        }
    }
}
function callApi(type, reqType, url, data, successCallback, successAdditionalData, errorCallback) {
    var req = {
        type: type,
        url: url,
        success: function (response, status, xhr) {
            if (data && data.Loading)
                setLoadingIndicator(data.Loading);

            if (reqType == RequestType.DOWNLOAD) {
                //// Check if response is actually a PDF
                //var contentType = xhr.getResponseHeader("Content-Type");
                //if (contentType !== "application/pdf") {
                //    showNotification('Invalid response type. Expected a PDF file', 'danger');
                //    return;
                //}
                //Extract custom header for filename
                var filename = xhr.getResponseHeader('X-Filename');
                // Create a blob and trigger download
                var fileContentType = "";
                if (data.ExportType == 1)
                    fileContentType = "application/pdf";
                else if (data.ExportType == 3)
                    fileContentType = "text/html";

                var blob = new Blob([response], { type: fileContentType });
                //Open new window to download the file
                //window.open(window.URL.createObjectURL(blob), '_blank');

                //Create dynamic element to download the file
                var link = document.createElement('a');
                link.href = window.URL.createObjectURL(blob);
                link.download = filename;
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
            }

            if (successCallback) {
                if (successAdditionalData) {
                    response.additionalData = successAdditionalData;
                }
                successCallback(response);
            }
        },
        error: function (xhr, status, error) {
            if (data && data.Loading)
                setLoadingIndicator(data.Loading);

            if (errorCallback) {
                errorCallback(xhr, status, error);
            }
            else {
                var notificationType = (xhr.status == 500) ? 'danger' : 'warning';
                var message = appResources.apiFailed;
                if (xhr.status == 501)
                    message = appResources.apiFeatureNotAvailable;

                if (reqType == RequestType.DOWNLOAD && xhr.status == 400) {
                    message = appResources.apiNoRecordsForExport;
                }
                else if (xhr.responseJSON && xhr.responseJSON.message) {
                    message = xhr.responseJSON.message;
                }
                showNotification(message, notificationType);
            }
        }
    };
    if (reqType == RequestType.API) {
        req.contentType = 'application/json; charset=utf-8';
        req.dataType = 'json';
    }
    if (reqType == RequestType.HTML) {
        req.contentType = 'application/json; charset=utf-8';
        req.dataType = 'html';
    }
    if (reqType == RequestType.DOWNLOAD) {
        req.contentType = 'application/json; charset=utf-8';
        req.xhrFields = { responseType: 'blob' };
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