$(document).ready(function () {
    // Confirm modal hides when clicking the cancel button or close button (×)
    $('#confirmModal').find('.btn-close, .btn-secondary').click(function () {
        $('#confirmModal').modal('hide');
    });
});

function showConfirm(confirmLabel, confirmText, yesCallback, yesCallbackData) {
    $('#confirmModal').modal('show');
    if (!confirmLabel) confirmLabel = 'Delete';
    $('#confirmModalLabel').text(confirmLabel);
    if (!confirmText) confirmText = 'Are you sure you want to delete?';
    $('#confirmModalText').html(confirmText);
    $('#confirmButton').off('click').click(function () {
        if (yesCallback && typeof yesCallback == "function") {
            yesCallback(yesCallbackData);
        }
    });
}

function hideConfirm() {
    $('#confirmModal').modal('hide');
}

function deleteYes(data) {
    hideConfirm();
    ajax.post(data.Url, data.Data, deleteSuccess, data);
}

function deleteSuccess(res) {
    if (res.statusCode == 200) {
        showNotification(res.message);
        //Delete row from UI
        highlightDeleteRow(res.additionalData.Row);
    }
}