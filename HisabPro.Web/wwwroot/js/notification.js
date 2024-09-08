/* @param {any} message
   @param {any} type
        success: For success
        primary: For primary information.
        secondary: For secondary information.
        danger: For error or danger messages (red).
        warning: For warning messages (yellow).
        info: For informational messages (blue).
        light: For light-colored alerts (grey background).
        dark: For dark-colored alerts.
   @param {any} duration
   @param {any} autoHide */
function showNotification(message, type = 'success', duration = 5000, autoHide = true) {
    var alertElement = $(`
            <div class="alert alert-${type} alert-dismissible fade show" role="alert">
                ${message}
                <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
        `);
    // Append the alert to the container
    $('#notificationContainer').append(alertElement);

    // Set the timeout
    if (autoHide == true) {
        var timeoutId = setNotificationToHide(alertElement, duration);
        // Pause the timer on mouse hover
        alertElement.on('mouseenter', function () {
            clearTimeout(timeoutId);
        });
        // Resume the timer on mouse leave
        alertElement.on('mouseleave', function () {
            timeoutId = setNotificationToHide(alertElement, duration);
        });
    }
}

function setNotificationToHide(alertElement, duration) {
    return setTimeout(function () {
        alertElement.addClass('fade');
        setTimeout(function () {
            alertElement.alert('close');
        }, 150);
    }, duration);
}
// Example usage:
// showNotification('Your message here.', 'success', 5000, true);