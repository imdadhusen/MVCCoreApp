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

        // Set feature attribute on save button
        $('#modalSaveButton').data('feature', feature);

        // If you need to load data for editing
        if (feature === 'Edit' && id) {
            // Load data into modal fields based on the ID
            // For example:
            // $.get('/YourController/GetData', { id: id }, function(data) {
            //     $('#yourField').val(data.yourField);
            // });
        }
    });
    $('#modalSaveButton').click(function () {
        var feature = $(this).data('feature');

        switch (feature) {
            case 'Add':
                handleAddSave();
                break;
            case 'Edit':
                handleEditSave();
                break;
            default:
                console.log('Unknown feature: ' + feature);
        }
    });
});


function handleAddSave() {
    // Logic for saving new item
    alert('Save logic for Add');
    $('#commonModal').modal('hide');
}

function handleEditSave() {
    // Logic for saving edited item
    alert('Save logic for Edit');
    $('#commonModal').modal('hide');
}