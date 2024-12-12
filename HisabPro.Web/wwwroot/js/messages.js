var Wizard = {
    FileUpload: {
        NoFile: 'Please select a file to upload before proceeding to the next step',
        Error: 'An error occurred during file upload'
    },
    Extraction: {
        Error: 'An error occurred while extracting the file data'
    },
    AutoCorrect: {
        Date: {
            Title: 'Auto Correct Date(s)',
            Message: "Dates will be automatically corrected using the date from the previous row.<br/>Please review the changes and update if necessary.<br/><br/><b>Are you sure you want to auto-correct the empty dates with the previous row's date?</b>",
            Success: 'Empty date(s) has been auto corrected'
        },
        Title: {
            Title: 'Auto Correct Title',
            Message: "Title will be automatically truncated (upto 25 chars) and keep original title inside the Note field (upto 250 chars).<br/>Please review the changes and update if necessary.<br/><br/><b>Are you sure you want to auto-correct the title to take only 25 chars?</b>",
            Success: 'Large title has been auto corrected'
        },
    },
};

var API = {
    Faile: "Internal server error"
};