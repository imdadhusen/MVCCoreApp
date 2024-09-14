function highlightSaveRow(row) {
    highlightRow(row, 'green');
}

function highlightDeleteRow(row) {
    highlightRow(row, 'red', true);
}

function highlightRow(row, color, isDelete = false) {
    row.addClass('highlight-' + color);
    // After 500ms, switch to highlight-reset class to transition back
    setTimeout(function () { row.removeClass('highlight-' + color).addClass('highlight-reset'); }, 2000); // Keep highlight for 2 seconds
    // After the transition completes, remove the highlight-reset class
    setTimeout(function () { row.removeClass('highlight-reset'); }, 2500); // 2 seconds of highlight + 0.5 seconds of transition
    if (isDelete) {
        // Remove the row
        setTimeout(function () { row.remove(); }, 2500); // Delay to match highlight duration
    }
}