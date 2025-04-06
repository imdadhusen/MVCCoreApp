using System.Globalization;

namespace HisabPro.Constants.Resources
{
    public class ResourceKey
    {
        public const string MessageWelcome = "MessageWelcome";

        public const string FieldEmail = "FieldEmail";
        public const string FieldPassword = "FieldPassword";
        public const string FieldRememberMe = "FieldRememberMe";
        public const string FieldName = "FieldName";
        public const string FieldMobile = "FieldMobile";
        public const string FieldGender = "FieldGender";
        public const string FieldType = "FieldType";
        public const string FieldTitle = "FieldTitle";
        public const string FieldAmount = "FieldAmount";
        public const string FieldNote = "FieldNote";
        public const string FieldFullName = "FieldFullName";
        public const string FieldIsActive = "FieldIsActive";
        public const string FieldParentCategory = "FieldParentCategory";
        public const string FieldIsStandard = "FieldIsStandard";
        public const string FieldDate = "FieldDate";
        public const string FieldAccount = "FieldAccount";
        public const string FieldCategory = "FieldCategory";
        public const string FieldSubCategory = "FieldSubCategory";
        public const string FieldBulkImport = "FieldBulkImport";
        public const string FieldUserRole = "FieldUserRole";
        public const string FieldNewPassword = "FieldNewPassword";
        public const string FieldConfirmPassword = "FieldConfirmPassword";
        public const string FieldCurrentPassword = "FieldCurrentPassword";

        public const string ValidationInvalidEmail = "ValidationInvalidEmail";
        public const string ValidationRequired = "ValidationRequired";
        public const string ValidationMobile = "ValidationMobile";
        public const string ValidationEmail = "ValidationEmail";
        public const string ValidationDate = "ValidationDate";
        public const string ValidationAmount = "ValidationAmount";
        public const string ValidationTitle = "ValidationTitle";
        public const string ValidationNote = "ValidationNote";
        public const string ValidationCategory = "ValidationCategory";
        public const string ValidationName = "ValidationName";
        public const string ValidationFullName = "ValidationFullName";
        public const string ValidationUser = "ValidationUser";
        public const string ValidationPasswordSalt = "ValidationPasswordSalt";
        public const string ValidationPasswordHash = "ValidationPasswordHash";
        public const string ValidationPasswordNew = "ValidationPasswordNew";
        public const string ValidationPasswordConfirm = "ValidationPasswordConfirm";

        //Menu options in public layout 
        public const string LabelAboutUs = "LabelAboutUs";
        public const string LabelContact = "LabelContact";
        public const string LabelHome = "LabelHome";
        public const string LabelLogin = "LabelLogin";
        public const string LabelPrivacy = "LabelPrivacy";
        public const string LabelRegisterUser = "LabelRegisterUser";
        public const string LabelDashboard = "LabelDashboard";
        public const string LabelProfile = "LabelProfile";
        public const string LabelLogout = "LabelLogout";
        public const string LabelLanguage = "LabelLanguage";

        //Export
        public const string LabelExport = "LabelExport";
        public const string LabelExportPDF = "LabelExportPDF";
        public const string LabelExportExcel = "LabelExportExcel";
        public const string LabelExportHTML = "LabelExportHTML";
        public const string LabelExportCSV = "LabelExportCSV";

        //Menu options in private layout
        public const string LabelAccounts = "LabelAccounts";
        public const string LabelExpenses = "LabelExpenses";
        public const string LabelIncomes = "LabelIncomes";
        public const string LabelUsers = "LabelUsers";
        public const string LabelImports = "LabelImports";
        public const string LabelReports = "LabelReports";

        public const string LabelReportIncomeExpense = "LabelReportIncomeExpense";

        public const string LabelAnnualReports = "LabelAnnualReports";
        public const string LabelAnalytics = "LabelAnalytics";
        public const string LabelTrendAnalysis = "LabelTrendAnalysis";
        public const string LabelActivityReports = "LabelActivityReports";
        public const string LabelTaxCalculator = "LabelTaxCalculator";
        public const string LabelZakat = "LabelZakat";
        public const string LabelKhums = "LabelKhums";
        public const string LabelIncomeTax = "LabelIncomeTax";

        public const string LabelSettings = "LabelSettings";
        public const string ReportDate = "ReportDate";
        public const string ReportAppliedSort = "ReportAppliedSort";
        public const string ReportAppliedFilter = "ReportAppliedFilter";
        public const string ReportNA = "ReportNA";
        public const string ReportSortAsc = "ReportSortAsc";
        public const string ReportSortDes = "ReportSortDes";

        public const string ReportAccountsDetail = "ReportAccountsDetail";
        public const string ReportCategoryAndSubcategory = "ReportCategoryAndSubcategory";
        public const string ReportExpense = "ReportExpense";
        public const string ReportIncome = "ReportIncome";
        public const string ReportIncomeAndExpense = "ReportIncomeAndExpense";
        public const string ReportUser = "ReportUser";
        public const string ReportFilterDescription = "ReportFilterDescription";


        //Start: Category related settings
        public const string LabelDeleteCategory = "LabelDeleteCategory";
        public const string LabelCategories = "LabelCategories";
        public const string LabelSaveCategory = "LabelSaveCategory";
        public const string LabelCategoryTitle = "LabelCategoryTitle";
        //End: Category related settings

        //Start: Dashboard related settings 
        public const string LabelDashboardDescription = "LabelDashboardDescription";
        public const string LabelDashboardAccount = "LabelDashboardAccount";
        public const string LabelDashboardForYear = "LabelDashboardForYear";
        public const string LabelDashboardIncomeVsExpense = "LabelDashboardIncomeVsExpense";
        public const string LabelDashboardIncomeNCharity = "LabelDashboardIncomeNCharity";
        public const string LabelDashboardExpenseDistribution = "LabelDashboardExpenseDistribution";
        public const string LabelDashboardIncomeDistribution = "LabelDashboardIncomeDistribution";
        public const string LabelCharity = "LabelCharity";
        //End: Dashboard related settings

        //Start: Import Incomes and Expense related settings
        public const string LabelImportExpense = "LabelImportExpense";
        public const string LabelImportExpenseWizard = "LabelImportExpenseWizard";
        public const string LabelImportExpenseMessage = "LabelImportExpenseMessage";
        public const string LabelImportIncomes = "LabelImportIncomes";
        public const string LabelImportIncomesWizard = "LabelImportIncomesWizard";
        public const string LabelImportIncomesMessage = "LabelImportIncomesMessage";
        public const string LabelImportWizardStep1 = "LabelImportWizardStep1";
        public const string LabelImportWizardStep2 = "LabelImportWizardStep2";
        public const string LabelImportWizardStep3 = "LabelImportWizardStep3";
        public const string LabelImportWizardError = "LabelImportWizardError";
        //Step 1
        public const string LabelImportFileTitle = "LabelImportFileTitle";
        public const string LabelImportFile = "LabelImportFile";
        //Step 2
        public const string LabelImportExtractTitle = "LabelImportExtractTitle";
        public const string LabelImportExtractMaximizeTable = "LabelImportExtractMaximizeTable";
        public const string LabelImportExtractResetTable = "LabelImportExtractResetTable";
        public const string LabelImportExtractColumnDateCorrect = "LabelImportExtractColumnDateCorrect";
        public const string LabelImportExtractColumnTitleCorrect = "LabelImportExtractColumnTitleCorrect";
        //Step 3
        public const string LabelSummaryImported = "LabelSummaryImported";
        public const string LabelSummaryCongratulation = "LabelSummaryCongratulation";
        public const string LabelSummaryTotalRecords = "LabelSummaryTotalRecords";
        public const string LabelSummaryTotalTime = "LabelSummaryTotalTime";
        public const string LabelSummaryNote = "LabelSummaryNote";
        //End: Import Incomes and Expense related settings

        //Start: Account related settings 
        public const string LabelDeleteAccount = "LabelDeleteAccount";
        public const string LabelSaveAccount = "LabelSaveAccount";
        //End: Account related settings

        //Start: Expense related settings
        public const string LabelDeleteExpense = "LabelDeleteExpense";
        public const string LabelExpense = "LabelExpense";
        public const string LabelSaveExpense = "LabelSaveExpense";
        //End: Expense related settings

        //Start: Income related settings
        public const string LabelDeleteIncome = "LabelDeleteIncome";
        public const string LabelIncome = "LabelIncome";
        public const string LabelSaveIncome = "LabelSaveIncome";
        //End: Income related settings

        //Start: Email
        public const string LabelEmailActivationTitle = "LabelEmailActivationTitle";
        public const string LabelEmailTemplateNotFound = "LabelEmailTemplateNotFound";
        public const string LabelEmailNotFound = "LabelEmailNotFound";
        //End: Email

        //Start: Api messages
        public const string LabelApiAccountLocked = "LabelApiAccountLocked";
        public const string LabelApiInvalidAttempt = "LabelApiInvalidAttempt";
        public const string LabelApiAccountLockedWithUnlockTime = "LabelApiAccountLockedWithUnlockTime";
        public const string LabelApiLoginSuccess = "LabelApiLoginSuccess";
        public const string LabelApiValidationFailed = "LabelApiValidationFailed";
        public const string LabelApiSave = "LabelApiSave";
        public const string LabelApiUserNotFound = "LabelApiUserNotFound";
        public const string LabelApiPasswordShouldNotMatchCurrent = "LabelApiPasswordShouldNotMatchCurrent";
        public const string LabelApiPasswordUpdated = "LabelApiPasswordUpdated";
        public const string LabelApiUserActivate = "LabelApiUserActivate";
        public const string LabelApiUserDeactivate = "LabelApiUserDeactivate";
        public const string LabelApiUserDeactivateFailed = "LabelApiUserDeactivateFailed";
        public const string LabelApiInternalError = "LabelApiInternalError";
        public const string ErrorInChangeLang = "ErrorInChangeLang";
        public const string LabelApiDelete = "LabelApiDelete";
        public const string LabelApiReferenceDeleteError = "LabelApiReferenceDeleteError";
        public const string LabelApiNotFound = "LabelApiNotFound";
        public const string LabelApiDataWithSameName = "LabelApiDataWithSameName";
        public const string LabelApiSameNameInStandardCategory = "LabelApiSameNameInStandardCategory";
        public const string LabelApiDataRetrived = "LabelApiDataRetrived";
        public const string LabelApiDataRetrivedFailed = "LabelApiDataRetrivedFailed";
        public const string LabelApiDataImportSuccess = "LabelApiDataImportSuccess";
        public const string ApiSuccess = "ApiSuccess";
        public const string ApiNoRecordsForExport = "ApiNoRecordsForExport";
        public const string ApiFeatureNotAvailable = "ApiFeatureNotAvailable";


        public const string LabelApiImportFileAllowedExtensions = "LabelApiImportFileAllowedExtensions";
        public const string LabelApiImportSuccess = "LabelApiImportSuccess";
        public const string LabelApiImportFileRequired = "LabelApiImportFileRequired";
        //End: Api messages

        //Start: screen or UI element
        public const string LabelGenderMale = "LabelGenderMale";
        public const string LabelGenderFemale = "LabelGenderFemale";
        public const string LabelGenderOther = "LabelGenderOther";

        public const string LabelRoleSuperAdmin = "LabelRoleSuperAdmin";
        public const string LabelRoleAdmin = "LabelRoleAdmin";
        public const string LabelRoleUser = "LabelRoleUser";
        //End: screen or UI element

        //Start: Users related settings
        //Logi
        public const string LabelHello = "LabelHello";
        public const string LabelDeleteUser = "LabelDeleteUser";
        //Register user
        public const string LabelCheckEmail = "LabelCheckEmail";
        public const string LabelEmailActivation = "LabelEmailActivation";
        //Change pasword
        public const string LabelChangePassword = "LabelChangePassword";
        public const string LabelUpdatePassword = "LabelUpdatePassword";
        //Update password 
        public const string LabelPasswordResetRequired = "LabelPasswordResetRequired";
        //Save user
        public const string LabelSaveUser = "LabelSaveUser";
        //Activation success
        public const string LabelActivationHead = "LabelActivationHead";
        public const string LabelActivationTitle = "LabelActivationTitle";
        public const string LabelActivationMessage = "LabelActivationMessage";
        //Activation failed 
        public const string LabelActivationFailed = "LabelActivationFailed";
        public const string LabelActivationFailedTitle = "LabelActivationFailedTitle";
        public const string LabelActivationFailedMessage = "LabelActivationFailedMessage";
        public const string LabelActivationFailedReason1 = "LabelActivationFailedReason1";
        public const string LabelActivationFailedReason2 = "LabelActivationFailedReason2";
        public const string LabelActivationFailedReason3 = "LabelActivationFailedReason3";
        //End: Users related settings

        //Common lables
        public const string LabelLoading = "LabelLoading";
        public const string LabelSave = "LabelSave";
        public const string LabelCreateNew = "LabelCreateNew";
        public const string LabelContactSupport = "LabelContactSupport";
        public const string LabelContactSupportMessage = "LabelContactSupportMessage";
        public const string LabelAccessDenied = "LabelAccessDenied";
        public const string LabelAccessDeniedMessage = "LabelAccessDeniedMessage";
        public const string LabelHere = "LabelHere";
        public const string LabelAutoCorrect = "LabelAutoCorrect";
        public const string LabelGoToHome = "LabelGoToHome";
        public const string LabelError = "LabelError";
        public const string LabelErrorMessage = "LabelErrorMessage";
        public const string LabelUnauthorized = "LabelUnauthorized";
        public const string LabelUnauthorizedMessage = "LabelUnauthorizedMessage";
        public const string LabelNext = "LabelNext";
        public const string LabelPrevious = "LabelPrevious";
        public const string LabelConfirmTitle = "LabelConfirmTitle";
        public const string LabelConfirmMessage = "LabelConfirmMessage";
        public const string LabelCancel = "LabelCancel";
        public const string LabelConfirm = "LabelConfirm";
        public const string LabelBackToList = "LabelBackToList";
        public const string LabelClose = "LabelClose";

        public const string LabelFilter = "LabelFilter";
        public const string LabelFilterSelected = "LabelFilterSelected";
        public const string LabelFilterApplyFilter = "LabelFilterApplyFilter";
        public const string LabelFilterClearFilter = "LabelFilterClearFilter";
        public const string LabelFilterCreatedDateRange = "LabelFilterCreatedDateRange";
        public const string LabelFilterStandard = "LabelFilterStandard";
        public const string LabelFilterDateRange = "LabelFilterDateRange";
        public const string LabelFilterBulkImported = "LabelFilterBulkImported";
        public const string LabelFilterRole = "LabelFilterRole";
        public const string LabelFieldEmail = "LabelFieldEmail";

        public const string LabelColumnActive = "LabelColumnActive";
        public const string LabelColumnCreatedBy = "LabelColumnCreatedBy";
        public const string LabelColumnCreatedOn = "LabelColumnCreatedOn";
        public const string LabelColumnImport = "LabelColumnImport";

        public const string EmailIfQuestion = "EmailIfQuestion";
        public const string EmailAllRightsReserved = "EmailAllRightsReserved";
        public const string EmailPrivacyPolicy = "EmailPrivacyPolicy";
        public const string EmailTermsOfService = "EmailTermsOfService";
        public const string EmailActivateAccountMessage = "EmailActivateAccountMessage";
        public const string EmailActivateAccountTitle = "EmailActivateAccountTitle";

        public const string LabelColumnPerson = "LabelColumnPerson";
        public const string LabelGridShowing = "LabelGridShowing";
        public const string LabelGridShowingOutOf = "LabelGridShowingOutOf";
        public const string LabelGridNoRecords = "LabelGridNoRecords";
        public const string LabelGridPage = "LabelGridPage";
        public const string LabelGridPageOf = "LabelGridPageOf";
        public const string LabelNoRecords = "LabelNoRecords";
        public const string LabelCalculate = "LabelCalculate";
        public const string LabelNewTaxRegime = "LabelNewTaxRegime";
        public const string LabelAnnualIncome = "LabelAnnualIncome";
        public const string IncomeTaxResult = "IncomeTaxResult";
        public const string AnnualIncome = "AnnualIncome";
        public const string StandardDeduction = "StandardDeduction";
        public const string TaxableIncome = "TaxableIncome";
        public const string TotalTax = "TotalTax";

        public const string IncomeRange = "IncomeRange";
        public const string RatePercent = "RatePercent";
        public const string TaxableAmount = "TaxableAmount";
        public const string Tax = "Tax";
        public const string Recalculate = "Recalculate";


        public const string LabelYes = "LabelYes";
        public const string LabelNo = "LabelNo";
        public const string LabelEdit = "LabelEdit";
        public const string LabelDelete = "LabelDelete";
        public const string LabelDeleteConfirm = "LabelDeleteConfirm ";
        public const string LabelDeleteTitle = "LabelDeleteTitle ";

        public const string WizardUploadNoFile = "WizardUploadNoFile ";
        public const string WizardUploadError = "WizardUploadError ";
        public const string WizardExtractError = "WizardExtractError ";
        public const string WizardAutoCorrectDateTitle = "WizardAutoCorrectDateTitle ";
        public const string WizardAutoCorrectDateMessage = "WizardAutoCorrectDateMessage ";
        public const string WizardAutoCorrectDateSuccess = "WizardAutoCorrectDateSuccess ";
        public const string WizardAutoCorrectTitleTitle = "WizardAutoCorrectTitleTitle ";
        public const string WizardAutoCorrectTitleMessage = "WizardAutoCorrectTitleMessage ";
        public const string WizardAutoCorrectTitleSuccess = "WizardAutoCorrectTitleSuccess ";

        public static string[] Months
        {
            get
            {
                if (CultureInfo.CurrentUICulture.Name == "gu-IN")
                    return ["જાન્યુઆરી", "ફેબ્રુઆરી", "માર્ચ", "એપ્રિલ", "મે", "જૂન", "જુલાઈ", "ઓગસ્ટ", "ઓગસ્ટ", "ઑક્ટોબર", "નવેમ્બર", "ડિસેમ્બર"];
                return ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            }
        }
    }
}