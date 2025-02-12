namespace HisabPro.Constants.Resources
{
    public class SharedResource
    {
        //Only required Disaply and Email attributes props from the Model
        //Login
        public static string FieldEmail { get; set; }
        public static string FieldPassword { get; set; }
        public static string FieldRememberMe { get; set; }
        public static string ValidationInvalidEmail { get; set; }
        //Register
        public static string FieldName { get; set; }
        public static string FieldMobile { get; set; }
        public static string FieldUserRole { get; set; }
        public static string FieldGender { get; set; }
        //Save Account
        public static string FieldFullName { get; set; }
        public static string FieldIsActive { get; set; }
        public static string ValidationFullName { get; set; }
        public static string ValidationMobile { get; set; }
        //Save Category
        public static string FieldParentCategory { get; set; }
        public static string FieldType { get; set; }
        public static string FieldIsStandard { get; set; }
        public static string ValidationCategory { get; set; }
        //Save Expense
        public static string ValidationTitle { get; set; }
        public static string ValidationAmount { get; set; }
        public static string ValidationDate { get; set; }
        public static string ValidationNote { get; set; }
        public static string FieldTitle { get; set; }
        public static string FieldDate { get; set; }
        public static string FieldAmount { get; set; }
        public static string FieldNote { get; set; }
        public static string FieldAccount { get; set; }
        public static string FieldCategory { get; set; }
        public static string FieldSubCategory { get; set; }
        public static string FieldBulkImport { get; set; }
        //Save User
        public static string ValidationName { get; set; }
        public static string ValidationEmail { get; set; }
        //Set Password
        public static string ValidationPasswordNew { get; set; }
        public static string ValidationPasswordConfirm { get; set; }
        public static string FieldNewPassword { get; set; }
        public static string FieldConfirmPassword { get; set; }
        public static string FieldCurrentPassword { get; set; }
        //User
        public static string ValidationPasswordHash { get; set; }
        public static string ValidationPasswordSalt { get; set; }
    }
}