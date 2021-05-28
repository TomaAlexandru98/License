using System;
using System.Collections.Generic;
using System.Text;

namespace License.Utils
{
    public static class RegisterErrors
    {
        public static string FirstNameRequired = "First name field is required";
        public static string LastNameRequired = "Last name field is required";
        public static string EmailRequired = "Email field is required";
        public static string EmailExists = "The selected email is already used";
        public static string PasswordRequired = "Password field is required";
        public static string PasswordMinimumLength = "Password must have at least 6 characters";
        public static string ConfirmPasswordRequired = "Password field is required";
        public static string PasswordsNotMatch = "Passwords do not match";
        public static string PhoneNoRequired = "Phone number field is required";
    }
}
