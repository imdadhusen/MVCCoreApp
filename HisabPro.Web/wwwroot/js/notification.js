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
   @param {any} delay
   @param {any} autoHide */
function showNotification(message, type = 'success', delay = 3000, autoHide = true) {
    var toastId = "toast_" + new Date().getTime(); // Unique ID for each toast

    if (type == 'success')
        message = `✅ ${message}`;
    else if (type == 'danger')
        message = `❌ ${message}`;
    else if (type == 'warning')
        message = `⚠️ ${message}`;
    else
        message = `ℹ️ ${message}`;

    // Toast template
    var toastHtml = `
        <div id="${toastId}" class="toast align-items-center text-white bg-${type} border-0 fade show" role="alert" aria-live="assertive" aria-atomic="true">
            <div class="d-flex">
                <div class="toast-body">${message}</div>
                <button type="button" class="btn-close btn-close-white me-2 m-auto close-toast" aria-label="Close"></button>
            </div>
        </div>`;

    // Append toast to container
    $("#toastContainer").append(toastHtml);

    // Get the toast element
    var $toastElement = $("#" + toastId);

    // Show the toast (Bootstrap's method)
    var toast = new bootstrap.Toast($toastElement[0], { autohide: autoHide, delay: delay });
    toast.show();

    if (autoHide) {
        let hideTimeout = setTimeout(() => {
            $toastElement.fadeOut(500, function () {
                $(this).remove();
            });
        }, delay);

        // Prevent hiding when hovered
        $toastElement.on("mouseenter", function () {
            clearTimeout(hideTimeout);
        });

        // Resume hiding when mouse leaves
        $toastElement.on("mouseleave", function () {
            hideTimeout = setTimeout(() => {
                $toastElement.fadeOut(500, function () {
                    $(this).remove();
                });
            }, 2000);
        });
    }

    // **Manually close on button click**
    $toastElement.find(".close-toast").on("click", function () {
        $toastElement.fadeOut(300, function () {
            $(this).remove();
        });
    });
}
// Example usage:
// showNotification('Your message here.', 'success', 5000, true);