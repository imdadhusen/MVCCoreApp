$(document).ready(function () {
    $('[data-toggle="modal"]').click(function () {
        var feature = $(this).data('feature');
        var title = $(this).data('title');
        var contentSelector = $(this).data('content');
        var btnSaveTitle = $(this).data('save');
        if (!btnSaveTitle) btnSaveTitle = "Save";
        var id = $(this).data('id'); // If you need to pass additional data

        // Update modal title
        $('#commonModalLabel').text(title);
        $('#modalSaveButton').text(btnSaveTitle);
        // Insert the appropriate content into the modal body
        if (contentSelector != "") {
            var content = $(contentSelector).html();
            $('#modalContent').html(content);
        }
    });
   
});

function showModal(targetModal, contentModal, saveCallback, saveCallbackData) {
    $('#modalContent').html(contentModal);
    $(targetModal).modal('show');
    $('#modalSaveButton').off('click').click(function () {
        if (saveCallback && typeof saveCallback == "function") {
            saveCallback(saveCallbackData);
        }
    });
}



