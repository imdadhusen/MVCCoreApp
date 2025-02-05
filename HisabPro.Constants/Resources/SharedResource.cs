using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;

namespace HisabPro.Constants.Resources
{
    public class SharedResource
    {
        //private static readonly ResourceManager _resourceManager = 
        //    new ResourceManager("HisabPro.Constants.Resources.SharedResource", Assembly.GetExecutingAssembly());
        private static readonly ResourceManager _resourceManager =
            new ResourceManager("HisabPro.Constants.Resources.SharedResource",
                        typeof(SharedResource).Assembly);
        private static readonly CultureInfo _culture = CultureInfo.CurrentUICulture;

        public static string MessageWelcome { get; private set; }

        public static string FieldEmail { get; private set; }
        public static string FieldPassword { get; private set; }
        public static string FieldRememberMe { get; private set; }
        public static string FieldName { get; private set; }
        public static string FieldMobile { get; private set; }
        public static string FieldGender { get; private set; }
        public static string FieldType { get; private set; }
        public static string FieldTitle { get; private set; }
        public static string FieldAmount { get; private set; }
        public static string FieldNote { get; private set; }

        public static string FieldFullName { get; private set; }
        public static string FieldIsActive { get; private set; }
        public static string FieldParentCategory { get; private set; }
        public static string FieldIsStandard { get; private set; }
        public static string FieldDate { get; private set; }
        public static string FieldAccount { get; private set; }
        public static string FieldCategory { get; private set; }
        public static string FieldSubCategory { get; private set; }
        public static string FieldBulkImport { get; private set; }
        public static string FieldUserRole { get; private set; }

        public static string ValidationInvalidEmail { get; private set; }
        public static string ValidationRequiredEmail { get; private set; }
        public static string ValidationRequiredPassword { get; private set; }
        public static string ValidationRequired { get; private set; }

        public static string ValidationMobile { get; private set; }
        public static string ValidationEmail { get; private set; }
        public static string ValidationDate { get; private set; }
        public static string ValidationAmount { get; private set; }
        public static string ValidationTitle { get; private set; }
        public static string ValidationNote { get; private set; }
        public static string ValidationCategory { get; private set; }
        public static string ValidationName { get; private set; }
        public static string ValidationFullName { get; private set; }
        public static string ValidationUser { get; private set; }
        public static string ValidationPasswordSalt { get; private set; }
        public static string ValidationPasswordHash { get; private set; }
        public static string ValidationPasswordNew { get; private set; }
        public static string ValidationPasswordConfirm { get; private set; }

        //Menu options in public layout
        public static string LabelAboutUs { get; private set; }
        public static string LabelContact { get; private set; }
        public static string LabelHome { get; private set; }
        public static string LabelLogin { get; private set; }
        public static string LabelPrivacy { get; private set; }
        public static string LabelRegisterUser { get; private set; }
        public static string LabelDashboard { get; private set; }
        public static string LabelProfile { get; private set; }
        public static string LabelLogout { get; private set; }
        //Menu options in private layout
        public static string LabelAdmin { get; private set; }
        public static string LabelAccounts { get; private set; }
        public static string LabelExpenses { get; private set; }
        public static string LabelIncomes { get; private set; }
        public static string LabelUsers { get; private set; }
        public static string LabelImports { get; private set; }
        public static string LabelReports { get; private set; }
        public static string LabelMonthlyReports { get; private set; }
        public static string LabelAnnualReports { get; private set; }
        public static string LabelAnalytics { get; private set; }
        public static string LabelTrendAnalysis { get; private set; }
        public static string LabelActivityReports { get; private set; }
        public static string LabelSettings { get; private set; }


        //Start: Category related settings
        public static string LabelDeleteCategory { get; private set; }
        public static string LabelCategories { get; private set; }
        public static string LabelSaveCategory { get; private set; }
        public static string LabelCategoryTitle { get; private set; }
        //End: Category related settings

        //Start: Dashboard related settings
        public static string LabelDashboardDescription { get; private set; }
        public static string LabelDashboardAccount { get; private set; }
        public static string LabelDashboardForYear { get; private set; }
        public static string LabelDashboardIncomeVsExpense { get; private set; }
        public static string LabelDashboardIncomeNCharity { get; private set; }
        public static string LabelDashboardExpenseDistribution { get; private set; }
        public static string LabelDashboardIncomeDistribution { get; private set; }
        public static string LabelCharity { get; private set; }

        //End: Dashboard related settings

        //Start: Import Incomes and Expense related settings
        public static string LabelImportExpense { get; private set; }
        public static string LabelImportExpenseWizard { get; private set; }
        public static string LabelImportExpenseMessage { get; private set; }

        public static string LabelImportIncomes { get; private set; }
        public static string LabelImportIncomesWizard { get; private set; }
        public static string LabelImportIncomesMessage { get; private set; }
        public static string LabelImportWizardStep1 { get; private set; }
        public static string LabelImportWizardStep2 { get; private set; }
        public static string LabelImportWizardStep3 { get; private set; }
        public static string LabelImportWizardError { get; private set; }
        //Step 1
        public static string LabelImportFileTitle { get; private set; }
        public static string LabelImportFile { get; private set; }
        //Step 2
        public static string LabelImportExtractTitle { get; private set; }
        public static string LabelImportExtractMaximizeTable { get; private set; }
        public static string LabelImportExtractResetTable { get; private set; }
        public static string LabelImportExtractColumnDateCorrect { get; private set; }
        public static string LabelImportExtractColumnTitleCorrect { get; private set; }
        //Step 3
        public static string LabelSummaryImported { get; private set; }
        public static string LabelSummaryCongratulation { get; private set; }
        public static string LabelSummaryTotalRecords { get; private set; }
        public static string LabelSummaryTotalTime { get; private set; }
        public static string LabelSummaryNote { get; private set; }
        //End: Import Incomes and Expense related settings

        //Start: Account related settings
        public static string LabelDeleteAccount { get; private set; }
        public static string LabelAccount { get; private set; }
        public static string LabelSaveAccount { get; private set; }
        //End: Account related settings

        //Start: Expense related settings
        public static string LabelDeleteExpense { get; private set; }
        public static string LabelExpense { get; private set; }
        public static string LabelSaveExpense { get; private set; }
        //End: Expense related settings

        //Start: Income related settings
        public static string LabelDeleteIncome { get; private set; }
        public static string LabelIncome { get; private set; }
        public static string LabelSaveIncome { get; private set; }
        //End: Income related settings

        //Start: Email
        public static string LabelEmailActivationTitle { get; private set; }
        public static string LabelEmailTemplateNotFound { get; private set; }
        public static string LabelEmailNotFound { get; private set; }
        //End: Email

        //Start: Api messages
        public static string LabelApiAccountLocked { get; private set; }
        public static string LabelApiInvalidAttempt { get; private set; }
        public static string LabelApiAccountLockedWithUnlockTime { get; private set; }
        public static string LabelApiLoginSuccess { get; private set; }

        public static string LabelApiValidationFailed { get; private set; }
        public static string LabelApiSave { get; private set; }
        public static string LabelApiUserNotFound { get; private set; }
        public static string LabelApiPasswordShouldNotMatchCurrent { get; private set; }
        public static string LabelApiPasswordUpdated { get; private set; }
        public static string LabelApiUserActivate { get; private set; }
        public static string LabelApiUserActivateFailed { get; private set; }
        public static string LabelApiUserDeactivate { get; private set; }
        public static string LabelApiUserDeactivateFailed { get; private set; }
        public static string LabelApiInternalError { get; private set; }
        public static string LabelApiDelete { get; private set; }
        public static string LabelApiReferenceDeleteError { get; private set; }
        public static string LabelApiNotFound { get; private set; }
        public static string LabelApiDataWithSameName { get; private set; }
        public static string LabelApiSameNameInStandardCategory { get; private set; }
        public static string LabelApiDataRetrived { get; private set; }
        public static string LabelApiDataRetrivedFailed { get; private set; }
        public static string LabelApiDataImportSuccess { get; private set; }

        public static string LabelApiImportFileAllowedExtensions { get; private set; }
        public static string LabelApiImportSuccess { get; private set; }
        public static string LabelApiImportFileRequired { get; private set; }
        //End: Api messages

        //Start: screen or UI element
        public static string LabelGenderMale { get; private set; }
        public static string LabelGenderFemale { get; private set; }
        public static string LabelGenderOther { get; private set; }

        public static string LabelRoleSuperAdmin { get; private set; }
        public static string LabelRoleAdmin { get; private set; }
        public static string LabelRoleUser { get; private set; }


        //End: screen or UI element 

        //Start: Users related settings
        //Login
        public static string LabelHello { get; private set; }
        public static string LabelDeleteUser { get; private set; }
        public static string LabelUser { get; private set; }
        //Register user
        public static string LabelCheckEmail { get; private set; }
        public static string LabelEmailActivation { get; private set; }
        //Change pasword
        public static string LabelChangePassword { get; private set; }
        public static string LabelUpdatePassword { get; private set; }
        public static string LabelNewPassword { get; private set; }
        public static string LabelConfirmPassword { get; private set; }
        public static string LabelCurrentPassword { get; private set; }
        //Update password
        public static string LabelPasswordResetRequired { get; private set; }
        //Save user
        public static string LabelSaveUser { get; private set; }
        //Activation success
        public static string LabelActivationHead { get; private set; }
        public static string LabelActivationTitle { get; private set; }
        public static string LabelActivationMessage { get; private set; }
        //Activation failed
        public static string LabelActivationFailed { get; private set; }
        public static string LabelActivationFailedTitle { get; private set; }
        public static string LabelActivationFailedMessage { get; private set; }
        public static string LabelActivationFailedReason1 { get; private set; }
        public static string LabelActivationFailedReason2 { get; private set; }
        public static string LabelActivationFailedReason3 { get; private set; }
        //End: Users related settings

        //Common lables
        public static string LabelLoading { get; private set; }
        public static string LabelSave { get; private set; }
        public static string LabelCreateNew { get; private set; }
        public static string LabelContactSupport { get; private set; }
        public static string LabelContactSupportMessage { get; private set; }
        public static string LabelAccessDenied { get; private set; }
        public static string LabelAccessDeniedMessage { get; private set; }

        public static string LabelHere { get; private set; }
        public static string LabelAutoCorrect { get; private set; }
        public static string LabelGoToHome { get; private set; }
        public static string LabelError { get; private set; }
        public static string LabelErrorMessage { get; private set; }
        public static string LabelUnauthorized { get; private set; }
        public static string LabelUnauthorizedMessage { get; private set; }


        public static string LabelNext { get; private set; }
        public static string LabelPrevious { get; private set; }
        public static string LabelConfirmTitle { get; private set; }
        public static string LabelConfirmMessage { get; private set; }
        public static string LabelCancel { get; private set; }
        public static string LabelConfirm { get; private set; }
        public static string LabelBackToList { get; private set; }
        public static string LabelClose { get; private set; }

        public static string LabelFilter { get; private set; }
        public static string LabelFilterSelected { get; private set; }
        public static string LabelFilterCreateNew { get; private set; }
        public static string LabelFilterApplyFilter { get; private set; }
        public static string LabelFilterClearFilter { get; private set; }

        public static string LabelFilterCreatedDateRange { get; private set; }
        public static string LabelFilterStandard { get; private set; }
        public static string LabelFilterDateRange { get; private set; }
        public static string LabelFilterBulkImported { get; private set; }
        public static string LabelFilterRole { get; private set; }
        public static string LabelFilterGender { get; private set; }

        public static string LabelFieldName { get; private set; }
        public static string LabelFieldMobile { get; private set; }
        public static string LabelFieldType { get; private set; }
        public static string LabelFieldTitle { get; private set; }
        public static string LabelFieldAmount { get; private set; }
        public static string LabelFieldAccount { get; private set; }
        public static string LabelFieldNote { get; private set; }
        public static string LabelFieldEmail { get; private set; }

        public static string LabelColumnActive { get; private set; }
        public static string LabelColumnCreatedBy { get; private set; }
        public static string LabelColumnCreatedOn { get; private set; }
        public static string LabelColumnImport { get; private set; }

        public static string EmailIfQuestion { get; private set; }
        public static string EmailAllRightsReserved { get; private set; }
        public static string EmailPrivacyPolicy { get; private set; }
        public static string EmailTermsOfService { get; private set; }
        public static string EmailActivateAccountMessage { get; private set; }
        public static string EmailActivateAccountTitle { get; private set; }

        public static string LabelColumnDate { get; private set; }
        public static string LabelColumnTitle { get; private set; }
        public static string LabelColumnAmount { get; private set; }
        public static string LabelColumnCategory { get; private set; }
        public static string LabelColumnSubCategory { get; private set; }
        public static string LabelColumnPerson { get; private set; }
        public static string LabelGridShowing { get; private set; }
        public static string LabelGridShowingOutOf { get; private set; }
        public static string LabelGridNoRecords { get; private set; }
        public static string LabelGridPage { get; private set; }
        public static string LabelGridPageOf { get; private set; }
        public static string LabelNoRecords { get; private set; }
        public static string LabelYes { get; private set; }
        public static string LabelNo { get; private set; }
        public static string LabelEdit { get; private set; }
        public static string LabelDelete { get; private set; }
        public static string LabelDeleteConfirm { get; private set; } //
        public static string LabelDeleteTitle { get; private set; } //
        public static string WizardUploadNoFile { get; private set; } //
        public static string WizardUploadError { get; private set; } //
        public static string WizardExtractError { get; private set; } //
        public static string WizardAutoCorrectDateTitle { get; private set; } //
        public static string WizardAutoCorrectDateMessage { get; private set; } //
        public static string WizardAutoCorrectDateSuccess { get; private set; } //
        public static string WizardAutoCorrectTitleTitle { get; private set; } //
        public static string WizardAutoCorrectTitleMessage { get; private set; } //
        public static string WizardAutoCorrectTitleSuccess { get; private set; } //

        public static string[] Months
        {
            get
            {
                if (_culture.Name == "gu-IN")
                    return ["જાન્યુઆરી", "ફેબ્રુઆરી", "માર્ચ", "એપ્રિલ", "મે", "જૂન", "જુલાઈ", "ઓગસ્ટ", "ઓગસ્ટ", "ઑક્ટોબર", "નવેમ્બર", "ડિસેમ્બર"];
                return ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
            }
        }


        static SharedResource()
        {
            var properties = typeof(SharedResource).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.SetProperty);
            string key = "";
            try
            {
                foreach (var property in properties)
                {
                    if (property.PropertyType == typeof(string))
                    {
                        key = property.Name;
                        var value = _resourceManager.GetString(key, _culture) ?? string.Empty;
                        property.SetValue(null, value);
                    }
                }
            }
            catch
            {
                throw new KeyNotFoundException($"Resource key '{key}' not found in culture '{_culture.Name}'.");
            }
        }
    }
}