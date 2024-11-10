$(document).ready(function () {
    let currentStep = 1;
    var actions = ['Upload', 'Extraction', 'Validation', 'Submit'];
    var wizardContent = '#wizard-content';
    var wizardError = '#wizard-error';

    function loadStep() {
        if (currentStep == 2) {
            hideError();
            //Upload file is successful then load next step
            var dataFile = $("#dataFile")[0];
            var file = dataFile.files[0];

            // Check if a file is selected
            if (!file) {
                showError('Please select a file to upload before proceeding to the next step.')
            }
            else {
                // Create a FormData object to hold the file
                var formData = new FormData();
                formData.append("file", file);

                $.ajax({
                    url: '/import/savefile',
                    type: 'POST',
                    data: formData,
                    contentType: false,  // Don't set content type
                    processData: false,  // Don't process the data
                    success: function (res) {
                        const filename = res.response.fileName;
                        const encodedFilename = encodeURIComponent(filename);
                        const action = `${actions[currentStep - 1]}?filename=${encodedFilename}`;
                        loadUI(action);
                    },
                    error: function (xhr, status, error) {
                        var errorMessage = xhr.responseJSON ? xhr.responseJSON.message : "An error occurred during file upload.";
                        showError(errorMessage);
                    }
                });
            }
        }
        else {
            loadUI(actions[currentStep - 1]);
        }
    }

    function loadUI(action) {
        $(wizardContent).load(`/Import/${action}`, function () {
            updateStepUI(currentStep);
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

    // Initialize by loading the first step
    loadStep();
});
