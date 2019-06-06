using System.Text.RegularExpressions;

namespace WpfAppRss.Helper
{
    static class Validation
    {
        public static bool ValidLogin(string login, ref string error)
        {
            string pattern = @"[0-9a-zA-Z]{3,}";

            bool isError = false;

            if (!Regex.IsMatch(login, pattern))
            {
                isError = true;
                error = "Enter a valid login" +
                        "\nYou can use latin letters (a-z, A-Z) and numbers (0-9)" +
                        "\nThe minimum length of 3 characters";
            }

            return isError;
        }

        public static bool ValidEmail(string email, ref string error)
        {
            string pattern = @"([a-zA-Z0-9\.]{1,})\@([a-zA-Z0-9]{1,})\.([a-zA-Z0-9]{1,})";

            bool isError = false;

            if (!Regex.IsMatch(email, pattern))
            {
                isError = true;
                error = "Enter a valid email address";
            }

            return isError;
        }

        public static bool ValidPassword(string password, ref string error)
        {
            string pattern = @"[0-9a-zA-Z]{6,}";

            bool isError = false;

            if (!Regex.IsMatch(password, pattern))
            {
                isError = true;
                error = "Enter a valid password" +
                        "\nYou can use latin letters (a-z, A-Z) and numbers (0-9)" +
                        "\nThe minimum length of 6 characters";
            }

            return isError;
        }
    }
}
