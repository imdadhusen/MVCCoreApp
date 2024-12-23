$(document).ready(function () {
    let currentStep = 1;
    var actions = ['Upload', 'Extraction', 'Summary'];
    var wizardContent = '#wizard-content';
    var wizardError = '#wizard-error';
    let url = window.location.href;
    let actionName = url.substring(url.lastIndexOf('/') + 1);

    function loadStep() {
        if (currentStep == 2) {
            step1UploadFile();
        }
        else if (currentStep == 3) {
            step2PerformDataValidation();
        }
        else {
            toggleLoading();
            loadUI(actions[currentStep - 1]);
        }
    }

    function loadUI(action) {
        $(wizardContent).load(`/Import/${action}`, function (response, status, xhr) {
            if (status === "error") {
                showError(Wizard.Extraction.Error);
            } else {
                updateStepUI(currentStep);
            }
            if (currentStep == 3) {
                var verifyData = $('#dataList');
                if (actionName.toUpperCase() == "EXPENSE") {
                    verifyData.attr('href', '/Expenses/Index');
                }
                else {
                    verifyData.attr('href', '/Income/Index');
                }
            }
            toggleLoading();
        });
    }

    function updateStepUI() {
        $(".step").removeClass("active complete");
        $(".step").each(function () {
            const stepNum = $(this).data("step");
            if (stepNum < currentStep) $(this).addClass("complete");
            else if (stepNum === currentStep) $(this).addClass("active");
        });

        // Set up next and previous button functionality
        $(wizardContent).off("click", ".next").on("click", ".next", function () {
            currentStep++;
            loadStep();
        });

        $(wizardContent).off("click", ".prev").on("click", ".prev", function () {
            currentStep--;
            loadStep();
        });
    }

    function showError(errorMessage) {
        var error = $(wizardError);
        if (!error.hasClass('visible')) {
            error.addClass('visible');
        }
        error.text(errorMessage);
    }

    function hideError() {
        $(wizardError).removeClass('visible');
    }

    function step1UploadFile() {
        hideError();
        //Upload file is successful then load next step
        var dataFile = $("#dataFile")[0];
        var file = dataFile.files[0];

        // Check if a file is selected
        if (!file) {
            showError(Wizard.FileUpload.NoFile)
            currentStep = 1;
        }
        else {
            // Create a FormData object to hold the file
            var formData = new FormData();
            formData.append("file", file);

            var urlUpload = '/Import/savefile';
            toggleLoading();
            ajax.upload(urlUpload, formData, saveFileSuccess, saveFileError);
        }
    }

    function saveFileSuccess(res) {
        const filename = res.response.fileName;
        const encodedFilename = encodeURIComponent(filename);
        const action = `${actions[currentStep - 1]}?filename=${encodedFilename}`;
        loadUI(action);
    }
    function saveFileError(error) {
        toggleLoading();
        var errorMessage = error.responseJSON ? error.responseJSON.message : Wizard.FileUpload.Error;
        showError(errorMessage);
    }

    function step2PerformDataValidation() {
        var form = $('#dataForm');
        form.validate();

        if (form.valid()) {
            let tableData = [];

            // Iterate through each row in the table
            $('#tblData tr').each(function () {
                let row = $(this);

                // Construct an object for the current row
                let rowData = {
                    Title: row.find('input[name*="Description"]').val(),
                    Note: row.find('input[name*="Note"]').val(),
                    Amount: parseInt(row.find('input[name*="Amount"]').val()) || 0,
                    CategoryId: row.find('select[name*="Category"]').val(),
                    SubCategoryId: row.find('select[name*="SubCategory"]').val(),
                    AccountId: row.find('select[name*="Person"]').val(),
                    IsBulkImported: true,
                    IsActive: true
                };

                if (actionName.toUpperCase() == "EXPENSE") {
                    rowData.ExpenseOn = row.find('input[name*="Date"]').val();
                }
                else {
                    rowData.IncomeOn = row.find('input[name*="Date"]').val();
                }

                tableData.push(rowData);
            });

            var urlSave = '/Import/SaveIncomes';
            if (actionName.toUpperCase() == "EXPENSE") {
                urlSave = '/Import/SaveExpenses';
            }
            toggleLoading();
            ajax.post(urlSave, tableData, saveSuccess, null, saveError);
        }
        else {
            //Don't allow to show next step until all errors are not resolved
            currentStep--;
        }
    }

    function saveSuccess(res) {
        if (res.statusCode == 200) {
            const action = `${actions[currentStep - 1]}?totalRecords=${res.response.totalRecords}&totalSeconds=${res.response.totalTimeTaken}`;
            loadUI(action);
        }
    }
    function saveError() {
        toggleLoading();
    }

    function toggleLoading() {
        $(".wizard-loading").toggle();
    }
    // Initialize by loading the first step
    loadStep();
});