using System;
using System.Globalization;
using System.Reflection;
using System.Resources;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HisabPro.Constants.Resources
{
    public class SharedResource
    {
        private static readonly ResourceManager _resourceManager = new ResourceManager("HisabPro.Constants.Resources.SharedResource", Assembly.GetExecutingAssembly());
        private static readonly CultureInfo _culture = CultureInfo.CurrentUICulture;

        public static string MessageWelcome { get; private set; }

        public static string FieldEmail { get; private set; }
        public static string FieldPassword { get; private set; }
        public static string FieldRememberMe { get; private set; }

        public static string ValidationInvalidEmail { get; private set; }
        public static string ValidationRequiredEmail { get; private set; }
        public static string ValidationRequiredPassword { get; private set; }

        //Menu options
        public static string LabelAboutUs { get; private set; }
        public static string LabelContact { get; private set; }
        public static string LabelHome { get; private set; }
        public static string LabelLogin { get; private set; }
        public static string LabelPrivacy { get; private set; }
        public static string LabelRegisterUser { get; private set; }
        public static string LabelDashboard { get; private set; }
        public static string LabelProfile { get; private set; }
        public static string LabelLogout { get; private set; }

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

        public static string LabelHere { get; private set; }
        public static string LabelAutoCorrect { get; private set; }

        public static string LabelNext { get; private set; }
        public static string LabelPrevious { get; private set; }

        public static string LabelColumnDate { get; private set; }
        public static string LabelColumnTitle { get; private set; }
        public static string LabelColumnAmount { get; private set; }
        public static string LabelColumnCategory { get; private set; }
        public static string LabelColumnSubCategory { get; private set; }
        public static string LabelColumnPerson { get; private set; }

        static SharedResource()
        {
            var properties = typeof(SharedResource).GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetProperty | BindingFlags.SetProperty);

            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(string))
                {
                    var key = property.Name;
                    var value = _resourceManager.GetString(key, _culture) ?? string.Empty;
                    property.SetValue(null, value);
                }
            }
        }
    }
}