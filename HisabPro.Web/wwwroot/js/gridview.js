
(function ($) {
    $.fn.gridview = function (options) {
        // Default options
        var settings = $.extend({
            controllerName: '',
            actionLoad: 'Load',
            actionSave: 'Save',
            actionDelete: 'Delete',
            titleDelete: 'Delete Record',
            pageSize: 10,
            onsort: null,
            onpagination: null,
        }, options);

        var sortColumn = '';
        var sortOrder = '';
        var totalPage = 0;
        var currentPage = 0;
        var startRecords = 0;
        var endRecords = 0;
        var totalRecords = 0;

        // Iterate over each matched element
        return this.each(function () {
            var $table = $(this);

            // Initialize grid
            initializeGrid();
            // Handle sorting
            $table.on('click', 'th.sort', function () {
                //Don't do sort if record is single
                if (totalRecords > 1) {
                    showHideLoading(true);

                    var $header = $(this);
                    //Reset sort icon on all header of the active grid
                    $table.find('th.sort').removeClass('sort-desc sort-asc');
                    sortColumn = $header.data('column');
                    if ($header.data('order') === 'asc') {
                        sortOrder = 'desc'
                        $header.addClass('sort-desc');
                    }
                    else {
                        sortOrder = 'asc';
                        $header.addClass('sort-asc');
                    }
                    // Update sort order on header
                    $header.data('order', sortOrder);

                    // Trigger onsort callback
                    if (typeof settings.onsort === 'function') {
                        settings.onsort();
                    }
                    //On sort reset page
                    currentPage = 1;
                    setPageTitle();
                    loadGridview();
                }
            });

            // Handle pagination
            $table.on('click', '.prev-page, .next-page', function (e) {
                var newPage = $(this).hasClass("prev-page") ? currentPage - 1 : currentPage + 1;

                if (newPage >= 1 && newPage <= totalPage) {
                    showHideLoading(true);
                    currentPage = newPage;
                    setPageTitle();

                    // Trigger onpagination callback
                    if (typeof settings.onpagination === 'function') {
                        settings.onpagination();
                    }

                    loadGridview();
                }
            });

            $table.on('click', '.delete-action', function (e) {
                var urlDelete = `${settings.controllerName}/${settings.actionDelete}`;
                var button = $(this);
                var data = { 'Data': { 'Id': button.data('id') }, 'Row': button.closest('tr'), 'Url': urlDelete };
                showConfirm(settings.titleDelete, null, deleteYes, data);
            });

            $table.on('blur', '.current-page', function (e) {
                var enteredVal = $(this).val();
                if (enteredVal == '') {
                    $(this).val(currentPage);
                }
                else {
                    currentPage = enteredVal;
                    loadGridview();
                    setPageTitle();
                }
            });

            // Initialize grid
            function initializeGrid() {
                setPageTitle();
            }
            function showHideLoading(isVisible) {
                if (isVisible) {
                    $table.find(".grid-loading").fadeIn(); // Show the loading container
                }
                else {
                    $table.find(".grid-loading").fadeOut();
                }
            }
            function loadGridview() {
                var data = { PageNumber: currentPage, PageSize: settings.pageSize, SortBy: sortColumn, SortDirection: sortOrder }
                var url = `${settings.controllerName}/${settings.actionLoad}`;
                ajax.html(url, data, refreshGridviewData, data);
            }
            function refreshGridviewData(res) {
                if (res) {
                    $table.find('tbody').html(res);
                }
                showHideLoading(false);
            }
            function setPageTitle() {
                $('.prev-page, .next-page').removeAttr('disabled');
               
                var record = $table.find('.grid-page-records span');
                var _toalpage = $table.find('.grid-page-action span.total-page');
                var _currentpage = $table.find('.grid-page-action input.current-page');
                if (currentPage == 0) {
                    totalPage = 0;
                    currentPage = 0;
                    if (_toalpage) {
                        totalPage = Number(_toalpage.text());
                        currentPage = Number(_currentpage.val());
                    }
                }
                if (startRecords == 0) {
                    var records = record.text().match(/\d+/g);
                    if (records && records.length == 3) {
                        startRecords = parseInt(records[0]);
                        endRecords = parseInt(records[1]);
                        totalRecords = parseInt(records[2]);
                    }
                }

                setPageRecords(record);

                _currentpage.val(currentPage);


                if (currentPage >= totalPage || totalPage <= 1) {
                    $table.find('.next-page').attr('disabled', 'disabled');
                }
                if (currentPage == 1 || totalPage <= 1) {
                    $table.find('.prev-page').attr('disabled', 'disabled');
                }
            }

            function setPageRecords(record) {
                if (totalRecords >= 1) {
                    startRecords = (currentPage - 1) * settings.pageSize + 1;
                    endRecords = Math.min(currentPage * settings.pageSize, totalRecords);
                    record.text(`Showing ${startRecords} - ${endRecords} out of ${totalRecords}`);
                }
            }
        });
    };
})(jQuery);
