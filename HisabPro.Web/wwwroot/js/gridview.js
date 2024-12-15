(function ($) {
    $.fn.gridview = function (options) {
        // Default options
        var settings = $.extend({
            controllerName: '',
            actionLoad: 'Load',
            actionSave: 'Save',
            actionDelete: 'Delete',
            titleDelete: 'Delete Record',
            allData: false,
            filter: {
                enable: true,
                defaultOpen: false
            },
            pagination: {
                enable: true,
                pageSize: 10,
                onPagination: null
            },
            sort: {
                enable: true,
                onsort: null
            }
        }, options);

        var sortColumn = '';
        var sortOrder = '';
        var totalPage = 0;
        var currentPage = 0;
        var startRecords = 0;
        var endRecords = 0;
        var totalRecords = 0;
        var filters = [];
        //Grid Containers
        var lblRecords;
        var lblTotalPage;
        var txtCurrentPage;
        //Filter Container
        var filterContainer;
        var filterToggleButton;
        var filterBody;
        //Page Container
        var pageContainer;
        //Sort
        var sortIcons;

        // Iterate over each matched element
        return this.each(function () {
            var $table = $(this);
            // Initialize grid
            initializeGrid();

            // Gird : Handle sorting
            $table.on('click', 'th.sort', function () {
                //Don't do sort if record is single
                if (totalRecords > 1 ) {
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
                    loadGridview();
                }
            });
            // Grid : Handle pagination on button click
            $table.on('click', '.prev-page, .next-page', function (e) {
                var newPage = $(this).hasClass("prev-page") ? currentPage - 1 : currentPage + 1;

                if (newPage >= 1 && newPage <= totalPage) {
                    showHideLoading(true);
                    currentPage = newPage;

                    // Trigger onpagination callback
                    if (typeof settings.onpagination === 'function') {
                        settings.onpagination();
                    }

                    loadGridview();
                }
            });
            // Grid : Handle pagination on page number change
            $table.on('blur', '.current-page', function (e) {
                var enteredVal = $(this).val();
                if (enteredVal == '') {
                    $(this).val(currentPage);
                }
                else {
                    currentPage = enteredVal;
                    loadGridview();
                }
            });
            // Grid : Handle save action
            $table.on('click', '.save-action', function (e) {
                var button = $(this);
                var urlSave = `${settings.controllerName}/${settings.actionSave}?Id=${button.data('id')}`;
                window.location.assign(urlSave);
            });
            // Grid : Handle delete action
            $table.on('click', '.delete-action', function (e) {
                var button = $(this);
                var urlDelete = `${settings.controllerName}/${settings.actionDelete}`;
                var data = { 'Data': { 'Id': button.data('id') }, 'Row': button.closest('tr'), 'Url': urlDelete };
                showConfirm(settings.titleDelete, null, deleteYes, data);
            });

            // Filter : Handle apply and clear filters on button click
            $table.on('click', '.applyFilters', function () {
                applyFilter();
            });
            $table.on('click', '.clearFilters', function () {
                clearFilter();
            });
            // Filter : Show/Hide filter section
            $table.on('click', '.toggleFilters', function () {
                toggleFilter();
            });

            // Grid : Helper functions
            function initializeGrid() {
                filterContainer = $table.find('.grid-filter');
                filterToggleButton = $table.find('.toggleFilters');
                filterBody = $table.find('.grid-filter-body');
                sortIcons = $table.find('th.sort');
                lblRecords = $table.find('.grid-page-records span');

                if (!settings.allData) {
                    lblTotalPage = $table.find('.grid-page-action span.total-page');
                    txtCurrentPage = $table.find('.grid-page-action input.current-page');
                    pageContainer = $table.find('.grid-footer');

                    const firstDiv = $table.find('#spnTotalRec');
                    totalRecords = Number(firstDiv.text());
                    firstDiv.remove();
                    currentPage = 1;

                    setPageTitle();
                }
                else {
                    totalRecords = $table.find("table.table tbody tr").length;
                    lblRecords.text(`Showing 1 - ${totalRecords} out of ${totalRecords}`);
                }

                if (!settings.pagination.enable) {
                    pageContainer.hide();
                }

                if (!settings.filter.enable) {
                    filterContainer.hide();
                }
                if (!settings.filter.defaultOpen) {
                    toggleFilter();
                }
                if (!settings.sort.enable) {
                    sortIcons.removeClass('sort').find('span').hide();
                }
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
                var page = { PageNumber: currentPage, PageSize: settings.pagination.pageSize, SortBy: sortColumn, SortDirection: sortOrder }
                var data = { PageData: page, Filters: filters };
                var url = `${settings.controllerName}/${settings.actionLoad}`;
                ajax.html(url, data, refreshGridviewData, data);
            }
            function refreshGridviewData(res) {
                if (settings.allData) {
                    $table.find('tbody').html(res);
                }
                else {
                    const firstDiv = $(res).first();
                    totalRecords = Number(firstDiv.text());
                    var bodyWithoutTotalPageCount = res.replace(/<span id="spnTotalRec">.*?<\/span>/, '');
                    $table.find('tbody').html(bodyWithoutTotalPageCount);

                    setPageTitle();
                }
                showHideLoading(false);
            }
            function setPageTitle() {
                if (!settings.allData) {
                    $('.prev-page, .next-page').removeAttr('disabled');

                    if (totalRecords >= 1) {
                        totalPage = Math.ceil(totalRecords / settings.pagination.pageSize);
                        txtCurrentPage.removeAttr("disabled");
                    }
                    else {
                        totalPage = 0;
                        currentPage = 0;
                        txtCurrentPage.attr("disabled", "disabled");
                    }

                    if (currentPage >= totalPage || totalPage <= 1) {
                        $table.find('.next-page').attr('disabled', 'disabled');
                    }
                    if (currentPage == 1 || totalPage <= 1) {
                        $table.find('.prev-page').attr('disabled', 'disabled');
                    }

                    txtCurrentPage.val(currentPage);
                    lblTotalPage.text(totalPage);
                    setPageRecords();
                }
            }
            function setPageRecords() {
                if (totalRecords >= 1) {
                    startRecords = (currentPage - 1) * settings.pagination.pageSize + 1;
                    endRecords = Math.min(currentPage * settings.pagination.pageSize, totalRecords);
                    lblRecords.text(`Showing ${startRecords} - ${endRecords} out of ${totalRecords}`);
                }
                else {
                    lblRecords.text('No records found');
                }
            }

            //Filter : Helper functions
            function applyFilter() {
                filters = [];
                $table.find('.filterForm :input').each(function () {
                    const fieldType = $(this).data('type'); // Get the data-type attribute
                    const fieldName = $(this).attr('name'); // Get the input name attribute
                    const value = $.trim($(this).val()); // Get the input value
                    if (value != "") {
                        if (fieldType === "bool") {
                            if (this.type == "radio") {
                                let existingFilter = filters.find(f => f.FieldName === fieldName);
                                if (!existingFilter) {
                                    // Get the selected radio button for the current field
                                    const selectedRadio = $(`input[name="${fieldName}"]:checked`);
                                    if (selectedRadio.length) {
                                        filters.push({ FieldName: fieldName, StartValue: selectedRadio.val() === "Yes", type: filter.dataType.bool });
                                    }
                                }
                            }
                            else {
                                filters.push({ FieldName: fieldName, StartValue: $(this).is(':checked'), type: filter.dataType.bool });
                            }
                        }
                        else if (fieldType === "int" && this.tagName === "SELECT") {
                            var intValues = value.split(",").map(Number);
                            if (intValues && intValues.length >= 2) {
                                // Multiple values selected then use range
                                filters.push({ FieldName: fieldName, RangeValue: intValues, type: filter.dataType.int });
                            }
                            else {
                                // Single value
                                filters.push({ FieldName: fieldName, StartValue: intValues[0], type: filter.dataType.int });
                            }
                        }
                        else if (fieldType === "string") {
                            filters.push({ FieldName: fieldName, StartValue: value, type: filter.dataType.string });
                        }
                        else if (fieldType === "date" && (fieldName.endsWith("_Start") || fieldName.endsWith("_End"))) {
                            const baseFieldName = fieldName.split('_')[0]; // Extract base name
                            let existingFilter = filters.find(f => f.FieldName === baseFieldName);

                            if (!existingFilter) {
                                existingFilter = { FieldName: baseFieldName, type: filter.dataType.date };
                                filters.push(existingFilter);
                            }

                            if (fieldName.endsWith("_Start")) {
                                existingFilter.StartValue = value;
                            }
                            else if (fieldName.endsWith("_End")) {
                                existingFilter.EndValue = value;
                            }
                        }
                    }
                });
                displayFilterCount();
                currentPage = 1;
                toggleFilter();
                loadGridview();
            }
            function clearFilter() {
                $table.find('.filterForm :input').each(function () {
                    if (this.type === 'checkbox' || this.type === 'radio') {
                        this.checked = false; // Uncheck checkboxes and radios
                    }
                    else if (this.tagName === 'SELECT') {
                        $(this).val(''); // Clear dropdowns
                    }
                    else {
                        $(this).val(''); // Clear text, number, date inputs, etc.
                    }
                });
                $('.selectpicker').selectpicker('deselectAll'); //Clear all selection in bootstrap dropdowns

                filters = [];
                currentPage = 1;

                toggleFilter();
                displayFilterCount(); // Reset filter count
                loadGridview();
            }
            function displayFilterCount() {
                const count = filters.length;
                const filterCountBadge = $table.find('.filterCount');
                if (count > 0) {
                    filterCountBadge.text(`${count} Selected`).show();
                }
                else {
                    filterCountBadge.hide();
                }
            }
            function toggleFilter() {
                filterBody.toggle(); // Show/hide the filter body
                const icon = filterToggleButton.find('i');
                if (filterBody.is(':visible')) {
                    icon.removeClass('bi-chevron-down').addClass('bi-chevron-up');
                }
                else {
                    icon.removeClass('bi-chevron-up').addClass('bi-chevron-down');
                }
            }
        });
    };
})(jQuery);
