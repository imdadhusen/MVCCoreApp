$(document).ready(function () {
    // Confirm modal hides when clicking the cancel button or close button (×)
    $('#confirmModal').find('.btn-close, .btn-secondary').click(function () {
        $('#confirmModal').modal('hide');
    });
});

function showConfirm(confirmLabel, confirmText, yesCallback, yesCallbackData) {
    $('#confirmModal').modal('show');
    $('#confirmModalLabel').text(confirmLabel);
    $('#confirmModalText').text(confirmText);
    $('#confirmButton').off('click').click(function () {
        if (yesCallback && typeof yesCallback == "function") {
            yesCallback(yesCallbackData);
        }
    });
}
